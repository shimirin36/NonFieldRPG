using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public PlayerManager player;
    public ShopUIManager shopUI;


    public ItemDataBase itemDB;

    private void Start()
    {
        shopUI.SetupUI(player);
        DialogTextManager.instance.SetScenarios(new string[] { "アイテムショップについた。" });
    }

    public void OnBackTownButton()
    {
        SoundManager.instance.PlaySE(0);
    }

    public void OnTapBuyButton()
    {
        SoundManager.instance.PlaySE(0);
        DialogTextManager.instance.SetScenarios(new string[] { "なにを買おう？" });
        shopUI.ShowShopBoard();
    }

    public void OnTapCloseButton()
    {
        SoundManager.instance.PlaySE(0);
        shopUI.CloseShopBoard();
    }

    //購入ボタンが押されたら
    //ポーション
    public void OnTapBuyPortion(int money)
    {
        if (player.money >= money)
        {
            player.money -= money;
            itemDB.items[0].count++; 
            shopUI.UpdateUI(player);
        }
        else
        {
            NoMoney();
        }
    }

    //強ポーション
    public void OnTapBuyStrongPortion(int money)
    {
        if (player.money >= money)
        {
            player.money -= money;
            itemDB.items[1].count++;
            shopUI.UpdateUI(player);
        }
        else
        {
            NoMoney();
        }
    }

    //HPUP
    public void OnTapBuyHPUpRing(int money)
    {
        if (player.money >= money)
        {
            player.money -= money;
            itemDB.items[2].count++;
            shopUI.UpdateUI(player);
        }
        else
        {
            NoMoney();
        }
    }

    //ATUP
    public void OnTapBuyATUpBook(int money)
    {
        if (player.money >= money)
        {
            player.money -= money;
            itemDB.items[3].count++;
            shopUI.UpdateUI(player);
        }
        else
        {
            NoMoney();
        }
    }

    //復活
    public void OnTapBuyReBirthBook(int money)
    {
        if (player.money >= money)
        {
            player.money -= money;
            itemDB.items[4].count++;
            shopUI.UpdateUI(player);
        }
        else
        {
            NoMoney();
        }
    }

    //戻り玉
    public void OnTapBuyReturnToTown(int money)
    {
        if (player.money >= money && itemDB.items[5].count == 0)
        {
            player.money -= money;
            itemDB.items[5].count++;
            shopUI.UpdateUI(player);
        }
        else if (itemDB.items[5].count == 1)
        {
            DialogTextManager.instance.SetScenarios(new string[] { "これ以上は持てない！！" });
        }
        else
        {
            NoMoney();
        }
    }
    //お金が足りない場合の処理
    void NoMoney()
    {
        DialogTextManager.instance.SetScenarios(new string[] { "お金が足りない！！" });
    }
}
