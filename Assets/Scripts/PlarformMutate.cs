using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlarformMutate : MonoBehaviour
{
    private StatistcSave _statistcSave;
    [SerializeField] private Collider2D collider;
    [SerializeField] private GameObject scoreLabel;
    [SerializeField] private GameObject SwitchTrigger;
    [SerializeField] private GameObject PlayerTrigger;

    private void Start()
    {
        collider.enabled = false;
        scoreLabel.SetActive(false);
    }

   
    public void DI( StatistcSave save,LevelGeneration generation)
    {
        _statistcSave = save;
    }

    public void Triggered()
    {
        collider.enabled = true;
        _statistcSave.AddScore();
        PlayerTrigger.SetActive(false);
        SwitchTrigger.SetActive(true);
    }

    public void Reload()
    {
        SwitchTrigger.SetActive(false);
        PlayerTrigger.SetActive(true);
    }
}
