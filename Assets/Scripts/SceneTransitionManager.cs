using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//�V�[���؂�ւ��ݒ�
public class SceneTransitionManager : MonoBehaviour
{
    public string moveToScene;
    public void LoadTo(string sceneName)
    {
        FadeIOManager.instance.FadeOutToIn(() => Load(sceneName));
        moveToScene = sceneName;
        Debug.Log(moveToScene);
    }

    void Load(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        SoundManager.instance.PlayBGM(sceneName);
    }
}
