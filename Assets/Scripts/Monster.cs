using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
[CreateAssetMenu(fileName = "Monster", menuName = "CreateMonster")]
public class Monster : ScriptableObject
{
    [SerializeField] public GameObject monsterPrefab; //モンスターのプレハブ

    public GameObject monster
    {
        get { return monsterPrefab; }
        set { monsterPrefab = value; }

    }
}