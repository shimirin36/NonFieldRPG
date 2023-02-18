using UnityEngine;

//タイトルのSE設定
public class TitleManager : MonoBehaviour
{
    DialogTextManager instance;
    public ItemDataBase itemDB;
    public MoneyDataBase moneyDB;
    public PlayerManager player;
    //スタートボタンが押されたら
    public void OnTapTownButton()
    {
        SoundManager.instance.PlaySE(0);
    }
    private void Start()
    {
        SetUp();
        //タイトル画面でのダイアログの非表示
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

