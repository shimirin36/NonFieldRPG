using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
[CreateAssetMenu(fileName = "Money", menuName = "CreateMoney")]
public class Money : ScriptableObject
{
    [SerializeField] public int havaMoney; // Š‹à

    public Money(Money money)
    {
        this.havaMoney = money.havaMoney;
    }
    public int HaveMoney
    {
        get { return havaMoney; }
        set { havaMoney = value; }

    }
}