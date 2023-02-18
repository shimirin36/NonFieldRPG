using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

//PlayerとEnemyの対戦管理
public class BattleManager : MonoBehaviour
{
    public ItemDataBase itemDB;
    public MoneyDataBase moneyDB;
    public Text useRebirthBook;
    public Transform playerDamageEffect;
    public QuestManager questManager;
    public PlayerUIManager playerUI;
    public EnemyUIManager enemyUI;
    public PlayerManager player;
    public StageUIManager stageUI;
    EnemyManager enemy;

    //攻撃可否
    public bool canAttack;

    //獲得ゴールド
    int getGold;

    private void Start()
    {
        enemyUI.gameObject.SetActive(false);
        playerUI.SetupUI(player);
    }

    //初期設定
    public void SetUp(EnemyManager enemyManager)
    {
        SoundManager.instance.PlayBGM("Battle");
        enemyUI.gameObject.SetActive(true);
        enemy = enemyManager;
        canAttack = true;
        enemyUI.SetupUI(enemy);
        getGold = enemy.hp * 5;
        enemy.AddEventListenerOnTap(PlayerAttack);
    }

    void PlayerAttack()
    {
        if(canAttack == false)
        {
            return;
        }
        canAttack = false; //連続攻撃不可処理
        StopAllCoroutines();
        SoundManager.instance.PlaySE(1);
        stageUI.CanNotTapItemButton();
        int damage = player.Attack(enemy);
        DialogTextManager.instance.SetScenarios(new string[] {
            "プレイヤーの攻撃！！\nモンスターに"+ damage +"のダメージ！！"});
        enemyUI.UpdateUI(enemy);
        if(enemy.hp <= 0)
        {
            StartCoroutine(EndBattle(enemy)); //モンスターを倒した場合
        }
        else
        {
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator EnemyTurn()
    {
        yield return new WaitForSeconds(2f);
        SoundManager.instance.PlaySE(1);
        playerDamageEffect.DOShakePosition(0.3f, 0.5f, 10, 20);
        int damage = enemy.Attack(player);
        DialogTextManager.instance.SetScenarios(new string[] {
            enemy.name + "の攻撃！！\nプレイヤーは"+ damage +"のダメージを受けた！！"});
        playerUI.UpdateUI(player);

        //プレイヤーが死亡時に復活の呪文を持っていた場合
        if (player.hp <= 0 && itemDB.items[4].count > 0)
        {
            yield return new WaitForSeconds(2.5f);
            DialogTextManager.instance.SetScenarios(new string[] {
            "復活の呪文を使った！！\n冒険者はよみがえった！！"});
            itemDB.items[4].count--;
            itemDB.items[4].Save(4);
            player.hp += 50;
            playerUI.UpdateUI(player);
            useRebirthBook.text = string.Format("x{0}", itemDB.items[4].count.ToString());
            yield return new WaitForSeconds(2.5f);
            stageUI.CanTapItemButton();
            canAttack = true;
        }
        //死んだ場合
        else if (player.hp <= 0 && itemDB.items[4].count == 0)
        {
            StartCoroutine(EndBattle(player));
        }
        //ダメージを食らった場合
        else
        {
            yield return new WaitForSeconds(2.5f);
            stageUI.CanTapItemButton();
            canAttack = true;
        }
    }

    IEnumerator EndBattle(EnemyManager enemy)
    {
        yield return new WaitForSeconds(2f);
        DialogTextManager.instance.SetScenarios(new string[] {
            enemy.name + "を倒した！！"});
        moneyDB.moneys[0].havaMoney += getGold;
        SaveHaveMoneyChange(moneyDB);
        DialogTextManager.instance.SetScenarios(new string[] {
            "冒険者は" + getGold + "ゴールドをゲットした！！"});
        stageUI.UpdateGetGoldUI(getGold);
        enemyUI.gameObject.SetActive(false);
        Destroy(enemy.gameObject);
        SoundManager.instance.PlayBGM("Quest");
        questManager.EndBattle();
    }

    IEnumerator EndBattle(PlayerManager player)
    {
        stageUI.CanNotTapItemButton();
        InventryContentsLost(itemDB);
        SaveHaveMoneyChange(moneyDB);
        yield return new WaitForSeconds(2f);
        SoundManager.instance.PlayBGM("Quest");
        DialogTextManager.instance.SetScenarios(new string[] {"冒険者が倒されてしまった！！\nアイテムと所持金をすべて失った！！", "街へ戻ろう！！"});
        yield return new WaitForSeconds(4f);
        questManager.QuestFail();
    }

    void InventryContentsLost(ItemDataBase itemDataBase)
    {
        for(int i = 0; i < itemDataBase.items.Count; i++)
        {
            itemDataBase.items[i].count = 0;
            itemDataBase.items[i].Save(i);
        }
    }
    void SaveHaveMoneyChange(MoneyDataBase money)
    {
        moneyDB.moneys[0].havaMoney = 0;
        money.moneys[0].Save();
    }

}
