using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HideDialog : MonoBehaviour
{
    public Image dialog;
    public void Awake()
    {
        if (SceneManager.GetActiveScene().name == "Title")
        {
            this.gameObject.SetActive(false);
        }
    }
}
