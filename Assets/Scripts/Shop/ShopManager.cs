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

    //���|�[�V����
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

    //����
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

    //�߂��
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
}
