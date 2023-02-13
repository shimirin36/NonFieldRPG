using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

//�G���Ǘ�������́i�X�e�[�^�X/�N���b�N���o�j
public class EnemyManager : MonoBehaviour
{
    //�֐��o�^
    Action tapAction; //�N���b�N�i�^�b�v�j���ꂽ�Ƃ��Ɏ��s�������֐��i�O������ݒ肵�����j

    public new string name;
    public int hp;
    public int at;
    public GameObject hitEffect;

    //�U������
    public void Attack(PlayerManager player)
    {
        player.Damage(at);
    }

    //�_���[�W���󂯂�
    public void Damage(int damage)
    {
        Instantiate(hitEffect, this.transform, false);
        transform.DOShakePosition(0.3f, 0.5f, 20, 30, false, true);
        hp -= damage;
        if (hp <= 0)
        {
            hp = 0;
        }
    }

    public void AddEventListenerOnTap(Action action)
    {
        tapAction += action;�@//PlayerAttack�̊֐���o�^������
    }

    public void OnTap()
    {
        tapAction();�@//PlayerAttack�̊֐������s������
    }

}
