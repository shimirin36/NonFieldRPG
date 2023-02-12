using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//クエスト全体を管理する
public class QuestManager : MonoBehaviour
{
    public StageUIManager stageUI;
    public GameObject enemyPrefab;
    public BattleManager battleManager;
    public SceneTransitionManager sceneTransitionManager;

    //敵に遭遇するテーブル：－1なら遭遇しない、0なら遭遇
    int[] encountTable = { -1, -1, 0, -1, 0, -1 };

    int currentStage = 0; //現在のステージ進行度

    private void Start()
    {
        stageUI.UpdateUI(currentStage);
    }

    //Nextボタンが押されたら
    public void OnNextButton()
    {
        currentStage++;
        //進行度をUIに反映
        stageUI.UpdateUI(currentStage);

        if(encountTable.Length <= currentStage)
        {
            Debug.Log("クエストクリア");
            QuestClear();
        }
        else if(encountTable[currentStage] == 0)
        {
            EncountEnemy();
        }
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
        //クエストクリアと表示する
        stageUI.ShowClearText();
        //街に戻るボタンのみ表示する
    }
}
