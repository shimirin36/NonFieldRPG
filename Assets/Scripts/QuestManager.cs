using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�N�G�X�g�S�̂��Ǘ�����
public class QuestManager : MonoBehaviour
{
    public StageUIManager stageUI;

    int currentStage = 0; //���݂̃X�e�[�W�i�s�x

    private void Start()
    {
        stageUI.UpdateUI(currentStage);
    }

    //Next�{�^���������ꂽ��
    public void OnNextButton()
    {
        currentStage++;
        Debug.Log("�i�s�x����" + currentStage);
        //�i�s�x��UI�ɔ��f
        stageUI.UpdateUI(currentStage);
    }
}
