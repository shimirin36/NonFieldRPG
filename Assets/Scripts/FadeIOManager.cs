using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

//フェードインアウト演出の設定
public class FadeIOManager : MonoBehaviour
{
    //シングルトン化
    public static FadeIOManager instance;

    //フェード時間
    public float fadeTime = 1f;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public CanvasGroup canvasGroup;

    
    public void FadeOut()
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.DOFade(1f, fadeTime).OnComplete(() => canvasGroup.blocksRaycasts = false);
    }
    public void FadeIn()
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.DOFade(0f, fadeTime).OnComplete(() => canvasGroup.blocksRaycasts = false);
    }

    public void FadeOutToIn(TweenCallback action)
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.DOFade(1f, fadeTime).OnComplete(() => { action(); FadeIn(); });
    }
}
