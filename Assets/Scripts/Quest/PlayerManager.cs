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
    public int currentStage;
    public int money;
    public int[] items;

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

    string SAVEKEY = "player_SAVE";
    public void save()
    {
        PlayerPrefs.SetString(SAVEKEY, JsonUtility.ToJson(this));
        PlayerPrefs.Save();
    }

    public void Load()
    {
        string jsonPlayer = PlayerPrefs.GetString(SAVEKEY, JsonUtility.ToJson(new PlayerManager()));
        instance = JsonUtility.FromJson<PlayerManager>(jsonPlayer);
    }

    public void DeleteSaveData()
    {
        PlayerPrefs.DeleteKey(SAVEKEY);
        PlayerPrefs.Save();
        Load();
    }
}
