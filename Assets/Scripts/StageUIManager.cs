using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//StageUI���Ǘ�����i�X�e�[�W����UI/�i�s�{�^��/�X�ɖ߂�{�^���j�̊Ǘ�
public class StageUIManager : MonoBehaviour
{
    public Text stageText;

    public void UpdateUI(int currentStage)
    {
        stageText.text = string.Format("�X�e�[�W�F{0}", currentStage + 1);
    }
}
