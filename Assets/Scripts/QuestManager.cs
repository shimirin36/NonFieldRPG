using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�N�G�X�g�S�̂��Ǘ�����
public class QuestManager : MonoBehaviour
{
    public StageUIManager stageUI;

    //�G�ɑ�������e�[�u���F�|1�Ȃ瑘�����Ȃ��A0�Ȃ瑘��
    int[] encountTable = { -1, -1, 0, -1, 0, -1 };

    int currentStage = 0; //���݂̃X�e�[�W�i�s�x

    private void Start()
    {
        stageUI.UpdateUI(currentStage);
    }

    //Next�{�^���������ꂽ��
    public void OnNextButton()
    {
        currentStage++;
        //�i�s�x��UI�ɔ��f
        stageUI.UpdateUI(currentStage);

        if(encountTable.Length <= currentStage)
        {
            Debug.Log("�N�G�X�g�N���A");
            //�N���A����
        }
        else if(encountTable[currentStage] == 0)
        {
            Debug.Log("�G�ɑ���");
        }
    }
}
