using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Town�ł̐ݒ�
public class TownManager : MonoBehaviour
{
    private void Start()
    {
        DialogTextManager.instance.SetScenarios(new string[] { "�X�ɂ����B" });
    }
    //�N�G�X�g�{�^���������ꂽ��
    public void OnTapQuestButton()
    {
        SoundManager.instance.PlaySE(0);
    }
}

