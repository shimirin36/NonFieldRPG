using UnityEngine;
using UnityEngine.SceneManagement;

//ƒV[ƒ“Ø‚è‘Ö‚¦Ý’è
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
