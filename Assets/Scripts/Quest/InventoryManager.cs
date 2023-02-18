using System.Collections;
using UnityEngine;
using UnityEngine.UI;

//�v���C���[���A�C�e�����g�p����ۂ̃C���x���g��
public class InventoryManager : MonoBehaviour
{
    public PlayerManager player;
    public PlayerUIManager playerUI;
    public ItemDataBase itemDB;
    public Text haveCountText;
    public Text itemDescrioption;
    public GameObject item;
    public GameObject itemScroll;
    public SceneTransitionManager sceneTransitionManager;

    public void SetUpCount()
    {
        string ObjName = item.name;
        
        switch (ObjName)
        {
            case "Portion":
                haveCountText.text = string.Format("x{0}", itemDB.items[0].count.ToString());
                itemDescrioption.text = string.Format("{0}", itemDB.items[0].infomation.ToString());
                break;
            case "StrongPortion":
                haveCountText.text = string.Format("x{0}", itemDB.items[1].count.ToString());
                itemDescrioption.text = string.Format("{0}", itemDB.items[1].infomation.ToString());
                break;
            case "HPUpRing":
                haveCountText.text = string.Format("x{0}", itemDB.items[2].count.ToString());
                itemDescrioption.text = string.Format("{0}", itemDB.items[2].infomation.ToString());
                break;
            case "ATUpBook":
                haveCountText.text = string.Format("x{0}", itemDB.items[3].count.ToString());
                itemDescrioption.text = string.Format("{0}", itemDB.items[3].infomation.ToString());
                break;
            case "RebirthBook":
                haveCountText.text = string.Format("x{0}", itemDB.items[4].count.ToString());
                itemDescrioption.text = string.Format("{0}", itemDB.items[4].infomation.ToString());
                break;
            case "ReturnToTown":
                haveCountText.text = string.Format("x{0}", itemDB.items[5].count.ToString());
                itemDescrioption.text = string.Format("{0}", itemDB.items[5].infomation.ToString());
                break;
        }
    }

    public void UseItem()
    {
        string ObjName = item.name;
        switch (ObjName)
        {
            case "Portion":
                //�A�C�e������1�ȏ�A�v���C���[��HP������l�����̎��g�p�\
                if (itemDB.items[0].count > 0 && player.hp < player.maxHP)
                {
                    itemDB.items[0].count--;
                    itemDB.items[0].Save(0);
                    DialogTextManager.instance.SetScenarios(new string[] { $"�|�[�V�������g�����I\n�̗͂�50�񕜁I"});
                    haveCountText.text = string.Format("x{0}", itemDB.items[0].count.ToString()); //�g�p�����A�C�e����1���炷
                    player.hp += 50;
                    if (player.hp > player.maxHP)
                    {
                        player.hp = player.maxHP;
                        playerUI.UpdateUI(player);
                        player.Save();
                    }
                    else
                    {
                        playerUI.UpdateUI(player);
                        player.Save();
                    }
                }
                //�A�C�e������0�̎�
                else if (itemDB.items[0].count == 0)
                {
                    DialogTextManager.instance.SetScenarios(new string[] { $"�|�[�V�����������ĂȂ��I\n�����Ă����΂悩�����I�I" });
                }
                //HP������l�Ɠ����Ƃ�
                else if(player.hp == player.maxHP)
                {
                    DialogTextManager.instance.SetScenarios(new string[] { $"�̗͖͂��^�����I�I" });
                }
                break;

            case "StrongPortion":
                //�A�C�e������1�ȏ�A�v���C���[��HP������l�����̎��g�p�\
                if (itemDB.items[1].count > 0 && player.hp < player.maxHP)
                {
                    itemDB.items[1].count--;
                    itemDB.items[1].Save(1);
                    DialogTextManager.instance.SetScenarios(new string[] { $"�n�C�|�[�V�������g�����I\n�̗͂�200�񕜁I" });
                    haveCountText.text = string.Format("x{0}", itemDB.items[1].count.ToString()); //�g�p�����A�C�e����1���炷
                    player.hp += 200;
                    if (player.hp > player.maxHP)
                    {
                        player.hp = player.maxHP;
                        player.Save();
                        playerUI.UpdateUI(player);
                    }
                    else
                    {
                        playerUI.UpdateUI(player);
                        player.Save();
                    }
                }
                //�A�C�e������0�̎�
                else if (itemDB.items[1].count == 0)
                {
                    DialogTextManager.instance.SetScenarios(new string[] { $"�n�C�|�[�V�����������ĂȂ��I\n�����Ă����΂悩�����I�I" });
                }
                //HP������l�Ɠ����Ƃ�
                else if (player.hp == player.maxHP)
                {
                    DialogTextManager.instance.SetScenarios(new string[] { $"�̗͖͂��^�����I�I" });
                }
                break;

            case "HPUpRing":
                //�A�C�e������1�ȏ�̎��g�p�\
                if (itemDB.items[2].count > 0)
                {
                    itemDB.items[2].count--;
                    itemDB.items[2].Save(2);
                    DialogTextManager.instance.SetScenarios(new string[] { $"�̗͑����̎w�ւ��g�����I\n�ő�̗͂�100�オ�����I" });
                    haveCountText.text = string.Format("x{0}", itemDB.items[2].count.ToString()); //�g�p�����A�C�e����1���炷
                    player.maxHP += 100;
                    player.Save();
                    playerUI.UpdateUI(player);
                }
                //�A�C�e������0�̎�
                else if (itemDB.items[0].count == 0)
                {
                    DialogTextManager.instance.SetScenarios(new string[] { $"�̗͑����̎w�ւ������ĂȂ��I\n�����Ă����΂悩�����I�I" });
                }
                break;

            case "ATUpBook":
                //�A�C�e������1�ȏ�̎��g�p�\
                if (itemDB.items[3].count > 0)
                {
                    itemDB.items[3].count--;
                    itemDB.items[3].Save(3);
                    DialogTextManager.instance.SetScenarios(new string[] { $"�U���̏����g�����I\n�U���͂�90�オ�����I" });
                    haveCountText.text = string.Format("x{0}", itemDB.items[3].count.ToString()); //�g�p�����A�C�e����1���炷
                    player.at += 90;
                    player.Save();
                    playerUI.UpdateUI(player);
                }
                //�A�C�e������0�̎�
                else if (itemDB.items[3].count == 0)
                {
                    DialogTextManager.instance.SetScenarios(new string[] { $"�U���̏��������ĂȂ��I\n�����Ă����΂悩�����I�I" });
                }
                break;

            case "ReturnToTown":
                //�A�C�e������1�ȏ�̎��g�p�\
                if (itemDB.items[5].count == 1)
                {
                    itemDB.items[5].count--;
                    itemDB.items[5].Save(5);
                    DialogTextManager.instance.SetScenarios(new string[] { $"���ǂ肾�܂��g�����I\n�X�^�R���T�b�T�[�I�I" });
                    StartCoroutine(returnToTown());
                }
                //�A�C�e������0�̎�
                else if (itemDB.items[5].count == 0)
                {
                    DialogTextManager.instance.SetScenarios(new string[] { $"���ǂ肾�܂������ĂȂ��I\n�����Ă����΂悩�����I�I" });
                }
                break;
        }
    }

    //�X�ɖ߂�
    IEnumerator returnToTown()
    {
        yield return new WaitForSeconds(3f);
        sceneTransitionManager.LoadTo("Town");
    }
}
