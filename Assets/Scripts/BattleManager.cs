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
        SetUp();
    }

    void SetUp()
    {
        enemyUI.SetupUI(enemy);
        playerUI.SetupUI(player);
    }
    //�����ݒ�

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
