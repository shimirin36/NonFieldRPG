using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MoneyDataBase", menuName = "CreateMoneyDataBase")]
public class MoneyDataBase : ScriptableObject
{
    public List<Money> moneys = new List<Money>();
}