using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//StageUIを管理する（ステージ数のUI/進行ボタン/街に戻るボタン）の管理
public class StageUIManager : MonoBehaviour
{
    public Text stageText;
    public Text haveMoneyText;
    public GameObject itemList;
    public GameObject stageClearImage;
    public GameObject nextButton;
    public GameObject toTownButton;
    public Button useItemButton;
    public GameObject closeItemListButton;
    public MoneyDataBase moneyDB;

    private void Start()
    {
        stageClearImage.SetActive(false);
        itemList.SetActive(false);
        closeItemListButton.SetActive(false);
    }
    public void UpdateUI(int currentStage)
    {
        stageText.text = string.Format("ステージ：{0}", currentStage + 1);
        haveMoneyText.text = string.Format("{0}", moneyDB.moneys[0].havaMoney.ToString());
    }
    public void UpdateGetGoldUI(int getGold)
    {
        haveMoneyText.text = string.Format("{0}", moneyDB.moneys[0].havaMoney.ToString());
    }

    public void HideButtons()
    {
        nextButton.SetActive(false);
        toTownButton.SetActive(false);
    }

    public void ShowButtons()
    {
        nextButton.SetActive(true);
        toTownButton.SetActive(true);
    }

    public void CanTapItemButton()
    {
        useItemButton.interactable = true;
    }

    public void CanNotTapItemButton()
    {

        useItemButton.interactable = false;
    }

    public void ShowItemList()
    {
        itemList.SetActive(true);
        closeItemListButton.SetActive(true);
    }
    public void CloseItemList()
    {
        itemList.SetActive(false);
        closeItemListButton.SetActive(false);
    }

    public void ShowClearText()
    {
        stageClearImage.SetActive(true);
        nextButton.SetActive(false);
        toTownButton.SetActive(true);
    }
}
