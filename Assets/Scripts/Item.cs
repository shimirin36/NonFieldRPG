using System;
using UnityEngine;

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

    [SerializeField] public int count; // ŒÂ”
    public string infomation; // î•ñ
    public Sprite sprite; // ‰æ‘œ

    public Item(Item item)
    {
        this.count = item.count;
        this.infomation = item.infomation;
        this.sprite = item.sprite; 
    }
    public int Count
    {
        get { return count; }
        set { count = value; }
        
    }
    public string Infomation
    {
        get { return infomation; }
        set { infomation = value; }
    }
    public Sprite Sprite
    {
        get { return sprite; }
        set { sprite = value; }
    }

    public void Save(int itemNum)
    {
        var data = JsonUtility.ToJson(this, true);

        PlayerPrefs.SetString($"PlayerItem{itemNum}", data);
    }

    public void Load(int itemNum)
    {
        var data = PlayerPrefs.GetString($"PlayerItem{itemNum}");

        JsonUtility.FromJsonOverwrite(data, this);
    }
}