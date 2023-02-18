using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUIManager : MonoBehaviour
{
    public Text money;
    public Canvas shopBoard;
    public MoneyDataBase moneyDB;

    public void SetupUI(MoneyDataBase moneyDB)
    {
        
        money.text = string.Format("{0}", moneyDB.moneys[0].havaMoney);
        shopBoard.gameObject.SetActive(false);
    }

    public void UpdateUI(MoneyDataBase moneyDB)
    {
        money.text = string.Format("{0}", moneyDB.moneys[0].havaMoney);
        DialogTextManager.instance.SetScenarios(new string[] { "Ç‹Ç¢Ç«Ç†ÇËÅIÅI" });
    }

    public void ShowShopBoard()
    {
        shopBoard.gameObject.SetActive(true);
    }

    public void CloseShopBoard()
    {
        shopBoard.gameObject.SetActive(false);
    }
}
