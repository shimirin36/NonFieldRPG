using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

//Player��Enemy�̑ΐ�Ǘ�
public class BattleManager : MonoBehaviour
{
    public Transform playerDamageEffect;
    public QuestManager questManager;
    public PlayerUIManager playerUI;
    public EnemyUIManager enemyUI;
    public PlayerManager player;
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
        if (player.hp <= 0)
        {
            StartCoroutine(EndBattle(player)); //�v���C���[���퓬�s�\�̏ꍇ
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
            enemy.name + "��|�����I�I"});
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
            player.name + "���|����Ă��܂����I�I", "�X�֖߂낤�I�I"});
        yield return new WaitForSeconds(3f);
        questManager.QuestFail();
    }
}
