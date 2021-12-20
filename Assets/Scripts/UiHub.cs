using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiHub : MonoBehaviour
{
    private GameObject deadPopup;
    public void RespawnButton()
    {
        SceneManager.LoadScene(0);
    }


    public void DI(GameObject deadPopup)
    {
        this.deadPopup = deadPopup;
        deadPopup.SetActive(false);
    }
}
