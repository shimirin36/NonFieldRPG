using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Player‚ÆEnemy‚Ì‘ÎíŠÇ—
public class BattleManager : MonoBehaviour
{
    public PlayeManager player;
    public EnemyManager enemy;

    void Start()
    {
        //Player‚ªEnemy‚ÉUŒ‚
        player.Attack(enemy);
        //Enemy‚ªPlayer‚ÉUŒ‚
        enemy.Attack(player);
    }
}
