using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//�G���Ǘ�������́i�X�e�[�^�X/�N���b�N���o�j
public class EnemyManager : MonoBehaviour
{
    //�֐��o�^
    Action tapAction; //�N���b�N�i�^�b�v�j���ꂽ�Ƃ��Ɏ��s�������֐��i�O������ݒ肵�����j

    public new string name;
    public int hp;
    public int at;

    //�U������
    public void Attack(PlayerManager player)
    {
        player.Damage(at);
    }
    //�_���[�W���󂯂�
    public void Damage(int damage)
    {
        hp -= damage;
        Debug.Log("Playre��HP��" + hp);
    }

    //tapAction�Ɋ֐���o�^����֐������
    public void AddEventListenerOnTap(Action action)
    {
        tapAction += action;
    }

    public void OnTap()
    {
        Debug.Log("�N���b�N���ꂽ");
        tapAction();
    }

}
