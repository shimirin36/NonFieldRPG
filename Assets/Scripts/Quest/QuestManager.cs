using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�N�G�X�g�S�̂��Ǘ�����
public class QuestManager : MonoBehaviour
{
    public StageUIManager stageUI;
    public GameObject enemyPrefab;
    public BattleManager battleManager;
    public SceneTransitionManager sceneTransitionManager;

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
        SoundManager.instance.PlaySE(0);
        currentStage++;
        //�i�s�x��UI�ɔ��f
        stageUI.UpdateUI(currentStage);

        if(encountTable.Length <= currentStage)
        {
            Debug.Log("�N�G�X�g�N���A");
            QuestClear();
        }
        else if(encountTable[currentStage] == 0)
        {
            EncountEnemy();
        }
    }

    //�X�ɖ߂�{�^���������ꂽ��
    public void OnTapTownButtton()
    {
        SoundManager.instance.PlaySE(0);
    }

    public void EncountEnemy()
    {
        stageUI.HideButtons();
        GameObject enemyObj = Instantiate(enemyPrefab);
        EnemyManager enemy = enemyObj.GetComponent<EnemyManager>();
        battleManager.SetUp(enemy);
    }

    public void EndBattle()
    {
        stageUI.ShowButtons();
    }

    void QuestClear()
    {
        //�N�G�X�g�N���A����炷
        SoundManager.instance.StopBGM();
        SoundManager.instance.PlaySE(2);
        //�X�ɖ߂�{�^���̂ݕ\������
        stageUI.ShowClearText();
    }
}
