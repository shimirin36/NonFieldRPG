using UnityEngine;
using UnityEngine.SceneManagement;

//シーン切り替え設定
public class SceneTransitionManager : MonoBehaviour
{
    public void LoadTo(string sceneName)
    {
        FadeIOManager.instance.FadeOutToIn(() => Load(sceneName));
    }

    void Load(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        SoundManager.instance.PlayBGM(sceneName);
    }
}
