using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public ItemDataBase itemDB;
    public Text haveCountText;
    public GameObject obj;

    public void SetUpCount()
    {
        string ObjName = obj.name;
        switch (ObjName)
        {
            case "Portion":
                haveCountText.text = string.Format("x{0}", itemDB.items[0].count.ToString());
                break;
            case "StrongPortion":
                haveCountText.text = string.Format("x{0}", itemDB.items[1].count.ToString());
                break;
            case "HPUpRing":
                haveCountText.text = string.Format("x{0}", itemDB.items[2].count.ToString());
                break;
            case "ATUpBook":
                haveCountText.text = string.Format("x{0}", itemDB.items[3].count.ToString());
                break;
            case "RebirthBook":
                haveCountText.text = string.Format("x{0}", itemDB.items[4].count.ToString());
                break;
            case "ReturnToTown":
                haveCountText.text = string.Format("x{0}", itemDB.items[5].count.ToString());
                break;
        }
    }
}
