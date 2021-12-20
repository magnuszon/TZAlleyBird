using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerDeath : MonoBehaviour
{
    private Transform playerTransform;
    public UnityEvent onDead;
    public static PlayerDeath Instance { get; set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        StartCoroutine(UnderTextureCaseFix());
        
    }
    public void DI(Transform playerTransform)
    {
        this.playerTransform = playerTransform;
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
        onDead.Invoke();
    }
}
