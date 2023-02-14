using System.Collections;
using System.Collections.Generic;
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
}

