using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Player��Enemy�̑ΐ�Ǘ�
public class BattleManager : MonoBehaviour
{
    public PlayeManager player;
    public EnemyManager enemy;

    void Start()
    {
        //Player��Enemy�ɍU��
        player.Attack(enemy);
        //Enemy��Player�ɍU��
        enemy.Attack(player);
    }
}
