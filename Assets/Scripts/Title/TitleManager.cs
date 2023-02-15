using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//タイトルのSE設定
public class TitleManager : MonoBehaviour
{
    DialogTextManager instance;
    //スタートボタンが押されたら
    public void OnTapTownButton()
    {
        SoundManager.instance.PlaySE(0);
    }
    private void Start()
    {
        //タイトル画面でのダイアログの非表示
        GameObject obj = GameObject.Find("DialogUICanvas");
        if(obj != null)
        {
            Destroy(obj);
        }
    }
}

