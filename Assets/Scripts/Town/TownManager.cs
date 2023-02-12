using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownManager : MonoBehaviour
{
    //クエストボタンが押されたら
    public void OnTapQuestButton()
    {
        SoundManager.instance.PlaySE(0);
    }
}

