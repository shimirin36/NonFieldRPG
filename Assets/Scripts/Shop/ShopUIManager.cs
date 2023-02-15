using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUIManager : MonoBehaviour
{
    public Text money;
    public Canvas shopBoard;

    public void SetupUI(PlayerManager player)
    {
        player.money = 200000;
       money.text = string.Format("{0}", player.money);
       shopBoard.gameObject.SetActive(false);
    }

    public void UpdateUI(PlayerManager player)
    {
        money.text = string.Format("{0}", player.money);
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
