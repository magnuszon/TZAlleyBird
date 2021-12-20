using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerDeath : MonoBehaviour
{
    private Transform playerTransform;
    private PlayerIdentity player;
    private GameObject deadPopup;
    public static PlayerDeath Instance { get; set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        StartCoroutine(UnderTextureCaseFix());
        
    }
    public void DI(PlayerIdentity player,GameObject deadPopup)
    {
        this.playerTransform = player.transform;
        this.player = player;
        this.deadPopup = deadPopup;
    }

    private IEnumerator UnderTextureCaseFix()
    {
        while (true)
        {
            
            if (playerTransform.position.y < -10)
            {
                PlayerDead();
            }
            yield return new WaitForSeconds(1);
        }
    }

    public void PlayerDead()
    {
        player.DisableCollider();
        deadPopup.SetActive(true);
    }
}
