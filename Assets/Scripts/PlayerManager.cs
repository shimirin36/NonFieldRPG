using System;
using UnityEngine;

[Serializable]
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
    [SerializeField]public int maxHP;
    [SerializeField]public int hp;
    [SerializeField]public int at;

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
    public void Save()
    {
        var data = JsonUtility.ToJson(this, true);

        PlayerPrefs.SetString("PlayerStatus", data);
    }

    public void Load()
    {
        var data = PlayerPrefs.GetString("PlayerStatus");

        JsonUtility.FromJsonOverwrite(data, this);

        hp = maxHP;
    }
}
