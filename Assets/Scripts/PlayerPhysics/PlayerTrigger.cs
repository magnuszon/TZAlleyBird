using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerIdentity>() != null)
        {
            Triggered();
        }
    }

    protected abstract void Triggered();

}
