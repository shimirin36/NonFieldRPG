using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�G���Ǘ�������́i�X�e�[�^�X/�N���b�N���o�j
public class EnemyManager : MonoBehaviour
{
    public new string name;
    public int hp;
    public int at;

    //�U������
    public void Attack(PlayeManager player)
    {
        player.Damage(at);
    }
    //�_���[�W���󂯂�
    public void Damage(int damage)
    {
        hp -= damage;
        Debug.Log("Playre��HP��" + hp);
    }

    public void OnTap()
    {
        Debug.Log("�N���b�N���ꂽ");
    }

}
