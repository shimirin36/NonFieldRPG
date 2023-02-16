using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MonsterDataBase", menuName = "CreateMonsterDataBase")]
public class MonsterDataBase : ScriptableObject
{
    public List<Monster> monsters = new List<Monster>();
}