using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Player‚ÆEnemy‚Ì‘ÎíŠÇ—
public class BattleManager : MonoBehaviour
{
    public QuestManager questManager;
    public PlayerUIManager playerUI;
    public EnemyUIManager enemyUI;
    public PlayerManager player;
    EnemyManager enemy;

    private void Start()
    {
        enemyUI.gameObject.SetActive(false);
    }

    //‰Šúİ’è
    public void SetUp(EnemyManager enemyManager)
    {
        SoundManager.instance.PlayBGM("Battle");
        enemyUI.gameObject.SetActive(true);
        enemy = enemyManager;
        enemyUI.SetupUI(enemy);
        playerUI.SetupUI(player);

        enemy.AddEventListenerOnTap(PlayerAttack);
    }

    void PlayerAttack()
    {
        SoundManager.instance.PlaySE(1);
        player.Attack(enemy);
        enemyUI.UpdateUI(enemy);
        if(enemy.hp <= 0)
        {
            enemyUI.gameObject.SetActive(false);
            Destroy(enemy.gameObject);
            EndBattle();
        }
        else
        {
            EnemyTurn();
        }
    }

    void EnemyTurn()
    {
        //SoundManager.instance.PlaySE(1);
        enemy.Attack(player);
        playerUI.UpdateUI(player);
    }

    void EndBattle()
    {
        SoundManager.instance.PlayBGM("Quest");
        questManager.EndBattle();
    }

}
