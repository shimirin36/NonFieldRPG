using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public MoneyDataBase moneyDB;
    public ShopUIManager shopUI;


    [SerializeField] 
    public ItemDataBase itemDB;

    private void Start()
    {
        shopUI.SetupUI(moneyDB);
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
        if (moneyDB.moneys[0].havaMoney >= money)
        {
            moneyDB.moneys[0].havaMoney -= money;
            itemDB.items[0].count++;
            SaveInventryChange(itemDB.items[0]);
            shopUI.UpdateUI(moneyDB);
        }
        else
        {
            NoMoney();
        }
    }

    //強ポーション
    public void OnTapBuyStrongPortion(int money)
    {
        if (moneyDB.moneys[0].havaMoney >= money)
        {
            moneyDB.moneys[0].havaMoney -= money;
            itemDB.items[1].count++;
            SaveInventryChange(itemDB.items[1]);
            shopUI.UpdateUI(moneyDB);
        }
        else
        {
            NoMoney();
        }
    }

    //HPUP
    public void OnTapBuyHPUpRing(int money)
    {
        if (moneyDB.moneys[0].havaMoney >= money)
        {
            moneyDB.moneys[0].havaMoney -= money;
            itemDB.items[2].count++;
            SaveInventryChange(itemDB.items[2]);
            shopUI.UpdateUI(moneyDB);
        }
        else
        {
            NoMoney();
        }
    }

    //ATUP
    public void OnTapBuyATUpBook(int money)
    {
        if (moneyDB.moneys[0].havaMoney >= money)
        {
            moneyDB.moneys[0].havaMoney -= money;
            itemDB.items[3].count++;
            SaveInventryChange(itemDB.items[3]);
            shopUI.UpdateUI(moneyDB);
        }
        else
        {
            NoMoney();
        }
    }

    //復活
    public void OnTapBuyReBirthBook(int money)
    {
        if (moneyDB.moneys[0].havaMoney >= money)
        {
            moneyDB.moneys[0].havaMoney -= money;
            itemDB.items[4].count++;
            SaveInventryChange(itemDB.items[4]);
            shopUI.UpdateUI(moneyDB);
        }
        else
        {
            NoMoney();
        }
    }

    //戻り玉
    public void OnTapBuyReturnToTown(int money)
    {
        if (moneyDB.moneys[0].havaMoney >= money && itemDB.items[5].count == 0)
        {
            moneyDB.moneys[0].havaMoney -= money;
            itemDB.items[5].count++;
            SaveInventryChange(itemDB.items[5]);
            shopUI.UpdateUI(moneyDB);
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

    void SaveInventryChange(Item itemCount)
    {
        EditorUtility.SetDirty(itemCount);
        AssetDatabase.SaveAssets();
    }
}
