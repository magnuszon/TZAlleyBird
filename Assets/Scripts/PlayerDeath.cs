using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class PlayerDeath : MonoBehaviour
{
    private Transform playerTransform;
    private PlayerIdentity player;
    private GameObject deadPopup;
    public UnityEvent deadEvent= new UnityEvent();
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
                OnPlayerDead();
            }
            yield return new WaitForSeconds(1);
        }
    }

    public void OnPlayerDead()
    {
        deadEvent.Invoke();
        player.DisableCollider();
        deadPopup.SetActive(true);
    }
}
