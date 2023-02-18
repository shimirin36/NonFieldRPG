using System.Collections;
using UnityEngine;
using UnityEngine.UI;

//プレイヤーがアイテムを使用する際のインベントリ
public class InventoryManager : MonoBehaviour
{
    public PlayerManager player;
    public PlayerUIManager playerUI;
    public ItemDataBase itemDB;
    public Text haveCountText;
    public Text itemDescrioption;
    public GameObject item;
    public GameObject itemScroll;
    public SceneTransitionManager sceneTransitionManager;

    public void SetUpCount()
    {
        string ObjName = item.name;
        
        switch (ObjName)
        {
            case "Portion":
                haveCountText.text = string.Format("x{0}", itemDB.items[0].count.ToString());
                itemDescrioption.text = string.Format("{0}", itemDB.items[0].infomation.ToString());
                break;
            case "StrongPortion":
                haveCountText.text = string.Format("x{0}", itemDB.items[1].count.ToString());
                itemDescrioption.text = string.Format("{0}", itemDB.items[1].infomation.ToString());
                break;
            case "HPUpRing":
                haveCountText.text = string.Format("x{0}", itemDB.items[2].count.ToString());
                itemDescrioption.text = string.Format("{0}", itemDB.items[2].infomation.ToString());
                break;
            case "ATUpBook":
                haveCountText.text = string.Format("x{0}", itemDB.items[3].count.ToString());
                itemDescrioption.text = string.Format("{0}", itemDB.items[3].infomation.ToString());
                break;
            case "RebirthBook":
                haveCountText.text = string.Format("x{0}", itemDB.items[4].count.ToString());
                itemDescrioption.text = string.Format("{0}", itemDB.items[4].infomation.ToString());
                break;
            case "ReturnToTown":
                haveCountText.text = string.Format("x{0}", itemDB.items[5].count.ToString());
                itemDescrioption.text = string.Format("{0}", itemDB.items[5].infomation.ToString());
                break;
        }
    }

    public void UseItem()
    {
        string ObjName = item.name;
        switch (ObjName)
        {
            case "Portion":
                //アイテム個数が1以上、プレイヤーのHPが上限値未満の時使用可能
                if (itemDB.items[0].count > 0 && player.hp < player.maxHP)
                {
                    itemDB.items[0].count--;
                    itemDB.items[0].Save(0);
                    DialogTextManager.instance.SetScenarios(new string[] { $"ポーションを使った！\n体力を50回復！"});
                    haveCountText.text = string.Format("x{0}", itemDB.items[0].count.ToString()); //使用したアイテムを1つ減らす
                    player.hp += 50;
                    if (player.hp > player.maxHP)
                    {
                        player.hp = player.maxHP;
                        playerUI.UpdateUI(player);
                        player.Save();
                    }
                    else
                    {
                        playerUI.UpdateUI(player);
                        player.Save();
                    }
                }
                //アイテム個数が0の時
                else if (itemDB.items[0].count == 0)
                {
                    DialogTextManager.instance.SetScenarios(new string[] { $"ポーションを持ってない！\n買っておけばよかった！！" });
                }
                //HPが上限値と同じとき
                else if(player.hp == player.maxHP)
                {
                    DialogTextManager.instance.SetScenarios(new string[] { $"体力は満タンだ！！" });
                }
                break;

            case "StrongPortion":
                //アイテム個数が1以上、プレイヤーのHPが上限値未満の時使用可能
                if (itemDB.items[1].count > 0 && player.hp < player.maxHP)
                {
                    itemDB.items[1].count--;
                    itemDB.items[1].Save(1);
                    DialogTextManager.instance.SetScenarios(new string[] { $"ハイポーションを使った！\n体力を200回復！" });
                    haveCountText.text = string.Format("x{0}", itemDB.items[1].count.ToString()); //使用したアイテムを1つ減らす
                    player.hp += 200;
                    if (player.hp > player.maxHP)
                    {
                        player.hp = player.maxHP;
                        player.Save();
                        playerUI.UpdateUI(player);
                    }
                    else
                    {
                        playerUI.UpdateUI(player);
                        player.Save();
                    }
                }
                //アイテム個数が0の時
                else if (itemDB.items[1].count == 0)
                {
                    DialogTextManager.instance.SetScenarios(new string[] { $"ハイポーションを持ってない！\n買っておけばよかった！！" });
                }
                //HPが上限値と同じとき
                else if (player.hp == player.maxHP)
                {
                    DialogTextManager.instance.SetScenarios(new string[] { $"体力は満タンだ！！" });
                }
                break;

            case "HPUpRing":
                //アイテム個数が1以上の時使用可能
                if (itemDB.items[2].count > 0)
                {
                    itemDB.items[2].count--;
                    itemDB.items[2].Save(2);
                    DialogTextManager.instance.SetScenarios(new string[] { $"体力増強の指輪を使った！\n最大体力が100上がった！" });
                    haveCountText.text = string.Format("x{0}", itemDB.items[2].count.ToString()); //使用したアイテムを1つ減らす
                    player.maxHP += 100;
                    player.Save();
                    playerUI.UpdateUI(player);
                }
                //アイテム個数が0の時
                else if (itemDB.items[0].count == 0)
                {
                    DialogTextManager.instance.SetScenarios(new string[] { $"体力増強の指輪を持ってない！\n買っておけばよかった！！" });
                }
                break;

            case "ATUpBook":
                //アイテム個数が1以上の時使用可能
                if (itemDB.items[3].count > 0)
                {
                    itemDB.items[3].count--;
                    itemDB.items[3].Save(3);
                    DialogTextManager.instance.SetScenarios(new string[] { $"攻撃の書を使った！\n攻撃力が90上がった！" });
                    haveCountText.text = string.Format("x{0}", itemDB.items[3].count.ToString()); //使用したアイテムを1つ減らす
                    player.at += 90;
                    player.Save();
                    playerUI.UpdateUI(player);
                }
                //アイテム個数が0の時
                else if (itemDB.items[3].count == 0)
                {
                    DialogTextManager.instance.SetScenarios(new string[] { $"攻撃の書を持ってない！\n買っておけばよかった！！" });
                }
                break;

            case "ReturnToTown":
                //アイテム個数が1以上の時使用可能
                if (itemDB.items[5].count == 1)
                {
                    itemDB.items[5].count--;
                    itemDB.items[5].Save(5);
                    DialogTextManager.instance.SetScenarios(new string[] { $"もどりだまを使った！\nスタコラサッサー！！" });
                    StartCoroutine(returnToTown());
                }
                //アイテム個数が0の時
                else if (itemDB.items[5].count == 0)
                {
                    DialogTextManager.instance.SetScenarios(new string[] { $"もどりだまを持ってない！\n買っておけばよかった！！" });
                }
                break;
        }
    }

    //街に戻る
    IEnumerator returnToTown()
    {
        yield return new WaitForSeconds(3f);
        sceneTransitionManager.LoadTo("Town");
    }
}
