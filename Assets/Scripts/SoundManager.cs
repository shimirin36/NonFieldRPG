using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //�V���O���g��
    //�Q�[������1�������݂��Ȃ����́i�����Ǘ�������̂Ȃǁj
    //���p�ꏊ�F�V�[���Ԃł̃f�[�^���L/�I�u�W�F�N�g���L
    public static SoundManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public AudioSource audioSourceBGM; //BGM�̃X�s�[�J�[
    public AudioClip[] audioClipsBGM; //BGM�̑f�ށi0:Title, 1:Town, 2:Quest, 3:Battle, 4:Item�j

    public AudioSource audioSourceSE; //SE�̃X�s�[�J�[
    public AudioClip[] audioClipsSE; //�Ȃ炷�f��

    public void StopBGM()
    {
        audioSourceBGM.Stop();
    }
    public void PlayBGM(string sceneName)
    {
        audioSourceBGM.Stop();
        switch (sceneName)
        {
            default:
            case "Title":
                audioSourceBGM.clip = audioClipsBGM[0];
                break;
            case "Town":
                audioSourceBGM.clip = audioClipsBGM[1];
                break;
            case "Quest":
                audioSourceBGM.clip = audioClipsBGM[2];
                break;
            case "Battle":
                audioSourceBGM.clip = audioClipsBGM[3];
                break;
            case "Shop":
                audioSourceBGM.clip = audioClipsBGM[4];
                break;
        }
        audioSourceBGM.Play();
    }

    //SE��炷�f�ށi0:Click, 1:Attack, 2:Clear)
    public void PlaySE(int index)
    {
        audioSourceSE.PlayOneShot(audioClipsSE[index]); //SE����x�����炷
    }
}
