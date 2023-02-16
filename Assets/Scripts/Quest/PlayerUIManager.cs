using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIManager : MonoBehaviour
{
    public Text hpText;
    public Text atText;

    public void SetupUI(PlayerManager player)
    {
        hpText.text = string.Format("HP：{0}/{1}", player.hp, player.maxHP);
        atText.text = string.Format("AT：{0}", player.at);
    }

    public void UpdateUI(PlayerManager player)
    {
        hpText.text = string.Format("HP：{0}/{1}", player.hp, player.maxHP);
        atText.text = string.Format("AT：{0}", player.at);
    }
}
