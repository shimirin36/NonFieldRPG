using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayeManager : MonoBehaviour
{
    public int hp;
    public int at;

    //UŒ‚‚·‚é
    public void Attack(EnemyManager enemy)
    {
        enemy.Damage(at);
    }
    //ƒ_ƒ[ƒW‚ğó‚¯‚é
    public void Damage(int damage)
    {
        hp -= damage;
        Debug.Log("Playre‚ÌHP‚Í"+ hp);
    }

}
