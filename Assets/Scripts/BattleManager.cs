using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Player‚ÆEnemy‚Ì‘ÎíŠÇ—
public class BattleManager : MonoBehaviour
{
    public PlayerUIManager playerUI;
    public EnemyUIManager enemyUI;
    public PlayerManager player;
    public EnemyManager enemy;
    void Start()
    {
        SetUp();
    }

    void SetUp()
    {
        enemyUI.SetupUI(enemy);
        playerUI.SetupUI(player);
    }
    //‰Šúİ’è

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
