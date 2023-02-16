using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEditor;

//Player��Enemy�̑ΐ�Ǘ�
public class BattleManager : MonoBehaviour
{
    public ItemDataBase itemDB;
    public Text useRebirthBook;
    public Transform playerDamageEffect;
    public QuestManager questManager;
    public PlayerUIManager playerUI;
    public EnemyUIManager enemyUI;
    public PlayerManager player;
    public StageUIManager stageUI;

    //�U����
    public bool canAttack;
    EnemyManager enemy;

    private void Start()
    {
        enemyUI.gameObject.SetActive(false);
        playerUI.SetupUI(player);
    }

    //�����ݒ�
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
        canAttack = false; //�A���U���s����
        StopAllCoroutines();
        SoundManager.instance.PlaySE(1);
        stageUI.CanNotTapItemButton();
        int damage = player.Attack(enemy);
        DialogTextManager.instance.SetScenarios(new string[] {
            "�v���C���[�̍U���I�I\n�����X�^�[��"+ damage +"�̃_���[�W�I�I"});
        enemyUI.UpdateUI(enemy);
        if(enemy.hp <= 0)
        {
            StartCoroutine(EndBattle(enemy)); //�����X�^�[��|�����ꍇ
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
            enemy.name + "�̍U���I�I\n�v���C���[��"+ damage +"�̃_���[�W���󂯂��I�I"});
        playerUI.UpdateUI(player);

        //�v���C���[�����S���ɕ����̎����������Ă����ꍇ
        if (player.hp <= 0 && itemDB.items[4].count > 0)
        {
            yield return new WaitForSeconds(2.5f);
            DialogTextManager.instance.SetScenarios(new string[] {
            "�����̎������g�����I�I\n�`���҂͂�݂��������I�I"});
            itemDB.items[4].count--;
            SaveInventryChange(itemDB.items[4]);
            player.hp += 50;
            playerUI.UpdateUI(player);
            useRebirthBook.text = string.Format("x{0}", itemDB.items[4].count.ToString());
            yield return new WaitForSeconds(2.5f);
            stageUI.CanTapItemButton();
            canAttack = true;
        }
        //���񂾏ꍇ
        else if (player.hp <= 0 && itemDB.items[4].count == 0)
        {
            StartCoroutine(EndBattle(player));
        }
        //�_���[�W��H������ꍇ
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
            enemy.name + "��|�����I�I"});
        enemyUI.gameObject.SetActive(false);
        Destroy(enemy.gameObject);
        SoundManager.instance.PlayBGM("Quest");
        questManager.EndBattle();
    }

    IEnumerator EndBattle(PlayerManager player)
    {
        stageUI.CanNotTapItemButton();
        InventryContentsLost(itemDB);
        yield return new WaitForSeconds(2f);
        SoundManager.instance.PlayBGM("Quest");
        DialogTextManager.instance.SetScenarios(new string[] {"�`���҂��|����Ă��܂����I�I\n�A�C�e�������ׂĎ������I�I", "�X�֖߂낤�I�I"});
        yield return new WaitForSeconds(4f);
        questManager.QuestFail();
    }

    void SaveInventryChange(Item itemCount)
    {
        EditorUtility.SetDirty(itemCount);
        AssetDatabase.SaveAssets();
    }

    void InventryContentsLost(ItemDataBase itemDataBase)
    {
        for(int i = 0; i < itemDataBase.items.Count; i++)
        {
            itemDataBase.items[i].count = 0;
            EditorUtility.SetDirty(itemDataBase);
            AssetDatabase.SaveAssets();
        }
    }

}
