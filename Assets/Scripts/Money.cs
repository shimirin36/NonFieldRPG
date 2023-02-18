using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
[CreateAssetMenu(fileName = "Money", menuName = "CreateMoney")]
public class Money : ScriptableObject
{
    [SerializeField] public int havaMoney; // èäéùã‡

    public Money(Money money)
    {
        this.havaMoney = money.havaMoney;
    }
    public int HaveMoney
    {
        get { return havaMoney; }
        set { havaMoney = value; }

    }
    /*
    public void Calculate(int money)
    {
        this.havaMoney -= money;
    }
    */
    public void Save()
    {
        var data = JsonUtility.ToJson(this, true);

        Debug.Log(data);

        PlayerPrefs.SetString("PlayerMoney", data);
    }

    public void Load()
    {
        var data = PlayerPrefs.GetString("PlayerMoney");

        Debug.Log(data);

        JsonUtility.FromJsonOverwrite(data, this);
    }
}