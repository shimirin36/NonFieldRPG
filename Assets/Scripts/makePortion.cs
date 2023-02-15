using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makePortion : MonoBehaviour
{
    public ItemDataBase itemDB;
    // Start is called before the first frame update
    public void OnTapBuyButton()
    {
        Debug.Log(itemDB.items[0].count);
    }
}
