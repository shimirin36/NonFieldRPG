using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

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
                    SaveInventryChange(itemDB.items[0]);
                    DialogTextManager.instance.SetScenarios(new string[] { $"�|�[�V�������g�����I\n�̗͂�50�񕜁I"});
                    haveCountText.text = string.Format("x{0}", itemDB.items[0].count.ToString()); //�g�p�����A�C�e����1���炷
                    player.hp += 50;
                    if (player.hp > player.maxHP)
                    {
                        player.hp = player.maxHP;
                        playerUI.UpdateUI(player);
                    }
                    else
                    {
                        playerUI.UpdateUI(player);
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
                    SaveInventryChange(itemDB.items[1]);
                    DialogTextManager.instance.SetScenarios(new string[] { $"�n�C�|�[�V�������g�����I\n�̗͂�200�񕜁I" });
                    haveCountText.text = string.Format("x{0}", itemDB.items[1].count.ToString()); //�g�p�����A�C�e����1���炷
                    player.hp += 200;
                    if (player.hp > player.maxHP)
                    {
                        player.hp = player.maxHP;
                        playerUI.UpdateUI(player);
                    }
                    else
                    {
                        playerUI.UpdateUI(player);
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
                    SaveInventryChange(itemDB.items[2]);
                    DialogTextManager.instance.SetScenarios(new string[] { $"�̗͑����̎w�ւ��g�����I\n�ő�̗͂�100�オ�����I" });
                    haveCountText.text = string.Format("x{0}", itemDB.items[2].count.ToString()); //�g�p�����A�C�e����1���炷
                    player.maxHP += 100;
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
                    SaveInventryChange(itemDB.items[3]);
                    DialogTextManager.instance.SetScenarios(new string[] { $"�U���̏����g�����I\n�U���͂�100�オ�����I" });
                    haveCountText.text = string.Format("x{0}", itemDB.items[3].count.ToString()); //�g�p�����A�C�e����1���炷
                    player.at += 100;
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
                    SaveInventryChange(itemDB.items[5]);
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

    //�ύX���e��ۑ�����
    void SaveInventryChange(Item itemCount)
    {
        EditorUtility.SetDirty(itemCount);
        AssetDatabase.SaveAssets();
    }

    //�X�ɖ߂�
    IEnumerator returnToTown()
    {
        yield return new WaitForSeconds(3f);
        sceneTransitionManager.LoadTo("Town");
    }
}
