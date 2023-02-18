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
        DialogTextManager.instance.SetScenarios(new string[] { "�A�C�e���V���b�v�ɂ����B" });
    }

    public void OnBackTownButton()
    {
        SoundManager.instance.PlaySE(0);
    }

    public void OnTapBuyButton()
    {
        SoundManager.instance.PlaySE(0);
        DialogTextManager.instance.SetScenarios(new string[] { "�Ȃɂ𔃂����H" });
        shopUI.ShowShopBoard();
    }

    public void OnTapCloseButton()
    {
        SoundManager.instance.PlaySE(0);
        shopUI.CloseShopBoard();
    }

    //�w���{�^���������ꂽ��
    //�|�[�V����
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

    //���|�[�V����
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

    //����
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

    //�߂��
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
            DialogTextManager.instance.SetScenarios(new string[] { "����ȏ�͎��ĂȂ��I�I" });
        }
        else
        {
            NoMoney();
        }
    }
    //����������Ȃ��ꍇ�̏���
    void NoMoney()
    {
        DialogTextManager.instance.SetScenarios(new string[] { "����������Ȃ��I�I" });
    }

    void SaveInventryChange(Item itemCount)
    {
        EditorUtility.SetDirty(itemCount);
        AssetDatabase.SaveAssets();
    }
}
