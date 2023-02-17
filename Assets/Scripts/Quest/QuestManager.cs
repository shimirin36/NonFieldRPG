using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

//クエスト全体を管理する
public class QuestManager : MonoBehaviour
{
    public StageUIManager stageUI;
    public GameObject enemyPrefab;
    public BattleManager battleManager;
    public SceneTransitionManager sceneTransitionManager;
    public GameObject questBG;
    public MonsterDataBase monsterDB;

    //敵に遭遇するテーブル：奇数なら遭遇しない、偶数なら遭遇
    //ダンジョン上限数
    int[] encountTable = new int [50];

    int currentStage = 0; //現在のステージ進行度

    private void Start()
    {
        stageUI.UpdateUI(currentStage);
        DialogTextManager.instance.SetScenarios(new string[] { "ダンジョンについた。" });
        //乱数をエンカウントテーブルに設定
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

    //Nextボタンが押されたら
    public void OnNextButton()
    {
        SoundManager.instance.PlaySE(0);
        stageUI.HideButtons();
        stageUI.CanNotTapItemButton();
        StartCoroutine(Searching());
    }

    IEnumerator Searching()
    {
        DialogTextManager.instance.SetScenarios(new string[] { "探索中・・・" });

        //背景を進んでいるように見せる
        questBG.transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 2f).OnComplete(() => questBG.transform.localScale = new Vector3(1, 1, 1));

        //進んだ背景をフェードアウトさせる
        SpriteRenderer questBGSpriteRenderer = questBG.GetComponent<SpriteRenderer>();
        questBGSpriteRenderer.DOFade(0f, 2f).OnComplete(() => questBGSpriteRenderer.DOFade(1f, 0f));

        //処理を待機させる
        yield return new WaitForSeconds(2f);

        //ステージ進行度を1進める
        currentStage++;

        //ステージ進行度をUIに反映
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


    //街に戻るボタンを押されたら
    public void OnTapTownButtton()
    {
        SoundManager.instance.PlaySE(0);
    }

    //アイテム使うボタンを押したら
    public void OnTapItemUseButton()
    {
        SoundManager.instance.PlaySE(0);
        stageUI.ShowItemList();
    }
    
    //アイテム一覧消したら
    public void OnTapCloseItemListButton()
    {
        SoundManager.instance.PlaySE(0);
        stageUI.CloseItemList();
    }

    //選んだアイテムを使うボタン押したら
    public void OnTapUseButtom()
    {
        SoundManager.instance.PlaySE(0);
    }

    public void EncountEnemy()
    {
        DialogTextManager.instance.SetScenarios(new string[] {"モンスターに遭遇した！！" });
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

    //バトル終了処理
    public void EndBattle()
    {
        stageUI.ShowButtons();
    }

    //プレイヤー戦闘不能処理
    public void QuestFail()
    {
        sceneTransitionManager.LoadTo("Town");
    }

    void QuestClear()
    {
        DialogTextManager.instance.SetScenarios(new string[] { "宝箱を手に入れた！！", "街に戻ろう。" });
        //クエストクリア音を鳴らす
        SoundManager.instance.StopBGM();
        SoundManager.instance.PlaySE(2);
        //街に戻るボタンのみ表示する
        stageUI.ShowClearText();
    }
}
