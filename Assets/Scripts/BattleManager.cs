using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Player��Enemy�̑ΐ�Ǘ�
public class BattleManager : MonoBehaviour
{
    
    public PlayerUIManager playerUI;
    public EnemyUIManager enemyUI;
    public PlayerManager player;
    public EnemyManager enemy;

    void Start()
    {
        //Player��Enemy�ɍU��
        player.Attack(enemy);
        enemyUI.UpdateUI(enemy);

        //Enemy��Player�ɍU��
        enemy.Attack(player);
        playerUI.UpdateUI(player);
    }
}
