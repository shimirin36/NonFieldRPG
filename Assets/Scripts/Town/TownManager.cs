using UnityEngine;

//Town�ł̐ݒ�
public class TownManager : MonoBehaviour
{
    private void Start()
    {
        DialogTextManager.instance.SetScenarios(new string[] { "�X�ɂ����B" });
    }
    //�N�G�X�g�{�^���������ꂽ��
    public void OnTapQuestButton()
    {
        SoundManager.instance.PlaySE(0);
    }
    //�^�C�g���{�^���������ꂽ��
    public void OnTapTitleButton()
    {
        SoundManager.instance.PlaySE(0);
    }
    //�V���b�v�{�^���������ꂽ��
    public void OnTapShopButton()
    {
        SoundManager.instance.PlaySE(0);
    }
    //�f�[�^�폜�{�^���������ꂽ��
    public void OnTapDeleteSaveDataButton()
    {
        SoundManager.instance.PlaySE(0);
    }
}

