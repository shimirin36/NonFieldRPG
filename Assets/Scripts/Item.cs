using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
[CreateAssetMenu(fileName = "Item", menuName = "CreateItem")]
public class Item : ScriptableObject
{
    public enum Type // À‘•‚·‚éItem‚Ìí—Ş
    {
        Portion,
        StrongPortion,
        HPUpRing,
        ATUpBook,
        ReBirthSpell,
        ToTownBall
    }

    public int count; // ŒÂ”
    public string infomation; // î•ñ
    public Sprite sprite; // ‰æ‘œ

    public Item(Item item)
    {
        this.count = item.count;
        this.infomation = item.infomation;
        this.sprite = item.sprite; 
    }
}