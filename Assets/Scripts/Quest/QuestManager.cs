using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

//�N�G�X�g�S�̂��Ǘ�����
public class QuestManager : MonoBehaviour
{
    public StageUIManager stageUI;
    public GameObject enemyPrefab;
    public BattleManager battleManager;
    public SceneTransitionManager sceneTransitionManager;
    public GameObject questBG;

    //�G�ɑ�������e�[�u���F�|1�Ȃ瑘�����Ȃ��A0�Ȃ瑘��
    int[] encountTable = { -1, -1, 0, -1, 0, -1 };

    int currentStage = 0; //���݂̃X�e�[�W�i�s�x

    private void Start()
    {
        stageUI.UpdateUI(currentStage);
        DialogTextManager.instance.SetScenarios(new string[] { "�_���W�����ɂ����B" });
    }

    //Next�{�^���������ꂽ��
    public void OnNextButton()
    {
        SoundManager.instance.PlaySE(0);
        stageUI.HideButtons();
        StartCoroutine(Searching());
    }

    IEnumerator Searching()
    {
        DialogTextManager.instance.SetScenarios(new string[] { "�T�����E�E�E" });

        //�w�i��i��ł���悤�Ɍ�����
        questBG.transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 2f).OnComplete(() => questBG.transform.localScale = new Vector3(1, 1, 1));

        //�i�񂾔w�i���t�F�[�h�A�E�g������
        SpriteRenderer questBGSpriteRenderer = questBG.GetComponent<SpriteRenderer>();
        questBGSpriteRenderer.DOFade(0f, 2f).OnComplete(() => questBGSpriteRenderer.DOFade(1f, 0f));

        //������ҋ@������
        yield return new WaitForSeconds(2f);

        //�X�e�[�W�i�s�x��1�i�߂�
        currentStage++;

        //�X�e�[�W�i�s�x��UI�ɔ��f
        stageUI.UpdateUI(currentStage);

        if (encountTable.Length <= currentStage)
        {
            QuestClear();
        }
        else if (encountTable[currentStage] == 0)
        {
            EncountEnemy();
        }
        else
        {
            stageUI.ShowButtons();
        }
    }


    //�X�ɖ߂�{�^���������ꂽ��
    public void OnTapTownButtton()
    {
        SoundManager.instance.PlaySE(0);
    }

    public void EncountEnemy()
    {
        DialogTextManager.instance.SetScenarios(new string[] {"�����X�^�[�ɑ��������I�I" });
        stageUI.HideButtons();
        GameObject enemyObj = Instantiate(enemyPrefab);
        EnemyManager enemy = enemyObj.GetComponent<EnemyManager>();
        battleManager.SetUp(enemy);
    }

    //�o�g���I������
    public void EndBattle()
    {
        stageUI.ShowButtons();
    }

    //�v���C���[�퓬�s�\����
    public void QuestFail()
    {
        sceneTransitionManager.LoadTo("Town");
    }

    void QuestClear()
    {
        DialogTextManager.instance.SetScenarios(new string[] { "�󔠂���ɓ��ꂽ�I�I", "�X�ɖ߂낤�B" });
        //�N�G�X�g�N���A����炷
        SoundManager.instance.StopBGM();
        SoundManager.instance.PlaySE(2);
        //�X�ɖ߂�{�^���̂ݕ\������
        stageUI.ShowClearText();
    }
}
