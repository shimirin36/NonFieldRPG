using UnityEngine;
using System;

[Serializable]
public class DeletePlayerData : MonoBehaviour
{
    [SerializeField] ItemDataBase itemDB;
    [SerializeField] MoneyDataBase moneyDB;
    [SerializeField] PlayerManager player;
    public void OnTapDataClear()
    {
        for (int i = 0; i < itemDB.items.Count; i++)
        {
            itemDB.items[i].count = 0;
            itemDB.items[i].Save(i);
        }
        moneyDB.moneys[0].havaMoney = 0;
        moneyDB.moneys[0].Save();
        player.hp = 100;
        player.maxHP = 100;
        player.at = 30;
        player.Save();
    }
}
