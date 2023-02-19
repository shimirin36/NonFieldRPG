using UnityEngine;

//�^�C�g����SE�ݒ�
public class TitleManager : MonoBehaviour
{
    DialogTextManager instance;
    public ItemDataBase itemDB;
    public MoneyDataBase moneyDB;
    public PlayerManager player;
    //�X�^�[�g�{�^���������ꂽ��
    public void OnTapTownButton()
    {
        SoundManager.instance.PlaySE(0);
    }
    private void Start()
    {
        SetUp();
        //�^�C�g����ʂł̃_�C�A���O�̔�\��
        GameObject obj = GameObject.Find("DialogUICanvas");
        if(obj != null)
        {
            Destroy(obj);
        }
    }
    void SetUp()
    {
        for (int i = 0; i < itemDB.items.Count; i++)
        {
            itemDB.items[i].Load(i);
        }
        moneyDB.moneys[0].Load();
        player.Load();
    }
}

