using UnityEngine;
using DG.Tweening;

//�t�F�[�h�C���A�E�g���o�̐ݒ�
public class FadeIOManager : MonoBehaviour
{
    //�V���O���g����
    public static FadeIOManager instance;

    //�t�F�[�h����
    public float fadeTime = 2f;

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
