using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdentity : MonoBehaviour
{
    private Collider2D _collider2D;

    public void DisableCollider()
    {
        _collider2D.enabled = false;
    }
}
