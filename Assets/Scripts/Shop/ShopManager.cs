using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public ShopUIManager shopUI;
    public PlayerManager player;

    [SerializeField] 
    public ItemDataBase itemDB;
    [SerializeField]
    public MoneyDataBase moneyDB;

    private void Start()
    {
        for (int i = 0; i < moneyDB.moneys.Count; i++)
        {
            itemDB.items[i].Load(i);
        }
        moneyDB.moneys[0].Load();
        shopUI.SetupUI(moneyDB);
        //shopUI.SetupUI(player);
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
            moneyDB.moneys[0].Save();
            shopUI.UpdateUI(moneyDB);
            itemDB.items[0].count++;
            itemDB.items[0].Save(0);
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
            moneyDB.moneys[0].Save();
            shopUI.UpdateUI(moneyDB);
            itemDB.items[1].count++;
            itemDB.items[1].Save(1);
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
            moneyDB.moneys[0].Save();
            shopUI.UpdateUI(moneyDB);
            itemDB.items[2].count++;
            itemDB.items[2].Save(2);
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
            moneyDB.moneys[0].Save();
            shopUI.UpdateUI(moneyDB);
            itemDB.items[3].count++;
            itemDB.items[3].Save(3);
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
            moneyDB.moneys[0].Save();
            shopUI.UpdateUI(moneyDB);
            itemDB.items[4].count++;
            itemDB.items[4].Save(4);
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
            moneyDB.moneys[0].Save();
            shopUI.UpdateUI(moneyDB);
            itemDB.items[5].count++;
            itemDB.items[5].Save(5);
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
