using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

//PlayerとEnemyの対戦管理
public class BattleManager : MonoBehaviour
{
    public Transform playerDamageEffect;
    public QuestManager questManager;
    public PlayerUIManager playerUI;
    public EnemyUIManager enemyUI;
    public PlayerManager player;
    //攻撃可否
    public bool canAttack;
    EnemyManager enemy;

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
        enemyUI.SetupUI(enemy);

        canAttack = true;
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
        if (player.hp <= 0)
        {
            StartCoroutine(EndBattle(player)); //プレイヤーが戦闘不能の場合
        }
        else
        {
            canAttack = true;
        }
    }

    IEnumerator EndBattle(EnemyManager enemy)
    {
        yield return new WaitForSeconds(2f);
        DialogTextManager.instance.SetScenarios(new string[] {
            enemy.name + "を倒した！！"});
        enemyUI.gameObject.SetActive(false);
        Destroy(enemy.gameObject);
        SoundManager.instance.PlayBGM("Quest");
        questManager.EndBattle();
    }

    IEnumerator EndBattle(PlayerManager player)
    {
        yield return new WaitForSeconds(2f);
        SoundManager.instance.PlayBGM("Quest");
        DialogTextManager.instance.SetScenarios(new string[] {
            player.name + "が倒されてしまった！！", "街へ戻ろう！！"});
        yield return new WaitForSeconds(3f);
        questManager.QuestFail();
    }
}
