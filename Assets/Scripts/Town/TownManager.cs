using UnityEngine;

//Townでの設定
public class TownManager : MonoBehaviour
{
    private void Start()
    {
        DialogTextManager.instance.SetScenarios(new string[] { "街についた。" });
    }
    //クエストボタンが押されたら
    public void OnTapQuestButton()
    {
        SoundManager.instance.PlaySE(0);
    }
    //タイトルボタンが押されたら
    public void OnTapTitleButton()
    {
        SoundManager.instance.PlaySE(0);
    }
    //ショップボタンが押されたら
    public void OnTapShopButton()
    {
        SoundManager.instance.PlaySE(0);
    }
    //データ削除ボタンが押されたら
    public void OnTapDeleteSaveDataButton()
    {
        SoundManager.instance.PlaySE(0);
    }
}

