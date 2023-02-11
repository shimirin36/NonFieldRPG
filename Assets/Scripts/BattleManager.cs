using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Player‚ÆEnemy‚Ì‘ÎíŠÇ—
public class BattleManager : MonoBehaviour
{
    public PlayerUIManager playerUI;
    public EnemyUIManager enemyUI;
    public PlayerManager player;
    EnemyManager enemy;
    
    //‰Šúİ’è
    public void SetUp(EnemyManager enemyManager)
    {
        enemy = enemyManager;
        enemyUI.SetupUI(enemy);
        playerUI.SetupUI(player);

        enemy.AddEventListenerOnTap(PlayerAttack);
    }

    void PlayerAttack()
    {
        player.Attack(enemy);
        enemyUI.UpdateUI(enemy);
    }

    void EnemyAttack()
    {
        enemy.Attack(player);
        playerUI.UpdateUI(player);
    }
}
