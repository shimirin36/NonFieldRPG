using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayeManager : MonoBehaviour
{
    public int hp;
    public int at;

    //�U������
    public void Attack(EnemyManager enemy)
    {
        enemy.Damage(at);
    }
    //�_���[�W���󂯂�
    public void Damage(int damage)
    {
        hp -= damage;
        Debug.Log("Playre��HP��"+ hp);
    }

}
