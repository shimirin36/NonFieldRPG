using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
[CreateAssetMenu(fileName = "Item", menuName = "CreateItem")]
public class Item : ScriptableObject
{
    public enum Type // ��������Item�̎��
    {
        Portion,
        StrongPortion,
        HPUpRing,
        ATUpBook,
        ReBirthSpell,
        ToTownBall
    }

    public int count; // ��
    public string infomation; // ���
    public Sprite sprite; // �摜

    public Item(Item item)
    {
        this.count = item.count;
        this.infomation = item.infomation;
        this.sprite = item.sprite; 
    }
}