using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    static PlayerManager instance = null;
    public static PlayerManager GetInstance()
    {
        if(instance == null)
        {
            instance = new PlayerManager();
        }
        return instance;
    }
    public int maxHP;
    public int hp;
    public int at;


    //UŒ‚‚·‚é
    public int Attack(EnemyManager enemy)
    {
        int damage = enemy.Damage(at);
        return damage;
    }
    //ƒ_ƒ[ƒW‚ğó‚¯‚é
    public int Damage(int damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
            hp = 0;
        }
        return damage;
    }
}
