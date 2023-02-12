using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//StageUI���Ǘ�����i�X�e�[�W����UI/�i�s�{�^��/�X�ɖ߂�{�^���j�̊Ǘ�
public class StageUIManager : MonoBehaviour
{
    public Text stageText;
    public GameObject stageClearText;
    public GameObject nextButton;
    public GameObject toTownButton;

    private void Start()
    {
        stageClearText.SetActive(false);
    }
    public void UpdateUI(int currentStage)
    {
        stageText.text = string.Format("�X�e�[�W�F{0}", currentStage + 1);
    }

    public void HideButtons()
    {
        nextButton.SetActive(false);
        toTownButton.SetActive(false);
    }

    public void ShowButtons()
    {
        nextButton.SetActive(true);
        toTownButton.SetActive(true);
    }

    public void ShowClearText()
    {
        stageClearText.SetActive(true);
        nextButton.SetActive(false);
        toTownButton.SetActive(true);
    }
}
