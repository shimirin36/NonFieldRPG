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
    public MonsterDataBase monsterDB;

    //�G�ɑ�������e�[�u���F��Ȃ瑘�����Ȃ��A�����Ȃ瑘��
    //�_���W���������
    int[] encountTable = new int [50];

    int currentStage = 0; //���݂̃X�e�[�W�i�s�x

    private void Start()
    {
        stageUI.UpdateUI(currentStage);
        DialogTextManager.instance.SetScenarios(new string[] { "�_���W�����ɂ����B" });
        //�������G���J�E���g�e�[�u���ɐݒ�
        for (int i = 0; i < 50; i++)
        {
            int rnd = Random.Range(1, 11);
            encountTable[i] = rnd;
            if(i >= 47)
            {
                encountTable[i] = 2;
            }
        }
    }

    //Next�{�^���������ꂽ��
    public void OnNextButton()
    {
        SoundManager.instance.PlaySE(0);
        stageUI.HideButtons();
        stageUI.CanNotTapItemButton();
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

        if (encountTable.Length <= currentStage + 1)
        {
            QuestClear();
        }
        else if (encountTable[currentStage] % 2 == 0)
        {
            EncountEnemy();
        }
        else
        {
            stageUI.ShowButtons();
            stageUI.CanTapItemButton();
        }
    }
    /// </return>


    //�X�ɖ߂�{�^���������ꂽ��
    public void OnTapTownButtton()
    {
        SoundManager.instance.PlaySE(0);
    }

    //�A�C�e���g���{�^������������
    public void OnTapItemUseButton()
    {
        SoundManager.instance.PlaySE(0);
        stageUI.ShowItemList();
    }
    
    //�A�C�e���ꗗ��������
    public void OnTapCloseItemListButton()
    {
        SoundManager.instance.PlaySE(0);
        stageUI.CloseItemList();
    }

    //�I�񂾃A�C�e�����g���{�^����������
    public void OnTapUseButtom()
    {
        SoundManager.instance.PlaySE(0);
    }

    public void EncountEnemy()
    {
        DialogTextManager.instance.SetScenarios(new string[] {"�����X�^�[�ɑ��������I�I" });
        stageUI.HideButtons();
        stageUI.CanTapItemButton();
        if (currentStage < 10)
        {
            int rnd = Random.Range(0, 4);
            GameObject enemyObj = Instantiate(monsterDB.monsters[rnd].monsterPrefab);
            EnemyManager enemy = enemyObj.GetComponent<EnemyManager>();
            battleManager.SetUp(enemy);
        }
        else if (currentStage >= 10 && currentStage < 20)
        {
            int rnd = Random.Range(2, 7);
            GameObject enemyObj = Instantiate(monsterDB.monsters[rnd].monsterPrefab);
            EnemyManager enemy = enemyObj.GetComponent<EnemyManager>();
            battleManager.SetUp(enemy);
        }
        else if (currentStage >= 20 && currentStage < 30)
        {
            int rnd = Random.Range(5, 11);
            GameObject enemyObj = Instantiate(monsterDB.monsters[rnd].monsterPrefab);
            EnemyManager enemy = enemyObj.GetComponent<EnemyManager>();
            battleManager.SetUp(enemy);
        }
        else if (currentStage >= 30 && currentStage < 40)
        {
            int rnd = Random.Range(7, 13);
            GameObject enemyObj = Instantiate(monsterDB.monsters[rnd].monsterPrefab);
            EnemyManager enemy = enemyObj.GetComponent<EnemyManager>();
            battleManager.SetUp(enemy);
        }
        else if (currentStage >= 40 && currentStage < 47)
        {
            int rnd = Random.Range(11, 14);
            GameObject enemyObj = Instantiate(monsterDB.monsters[rnd].monsterPrefab);
            EnemyManager enemy = enemyObj.GetComponent<EnemyManager>();
            battleManager.SetUp(enemy);
        }
        else if (currentStage == 47)
        {
            int rnd = 14;
            GameObject enemyObj = Instantiate(monsterDB.monsters[rnd].monsterPrefab);
            EnemyManager enemy = enemyObj.GetComponent<EnemyManager>();
            battleManager.SetUp(enemy);
        }
        else if (currentStage == 48)
        {
            int rnd = 15;
            GameObject enemyObj = Instantiate(monsterDB.monsters[rnd].monsterPrefab);
            EnemyManager enemy = enemyObj.GetComponent<EnemyManager>();
            battleManager.SetUp(enemy);
        }


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
