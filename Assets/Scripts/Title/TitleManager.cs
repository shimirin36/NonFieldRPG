using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//�^�C�g����SE�ݒ�
public class TitleManager : MonoBehaviour
{
    DialogTextManager instance;
    //�X�^�[�g�{�^���������ꂽ��
    public void OnTapTownButton()
    {
        SoundManager.instance.PlaySE(0);
    }
    private void Start()
    {
        //�^�C�g����ʂł̃_�C�A���O�̔�\��
        GameObject obj = GameObject.Find("DialogUICanvas");
        if(obj != null)
        {
            Destroy(obj);
        }
    }
}

