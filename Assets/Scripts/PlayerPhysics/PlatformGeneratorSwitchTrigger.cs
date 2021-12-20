using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGeneratorSwitchTrigger : MonoBehaviour
{
   [SerializeField] private PlatrformMutate _mutate;
   private void OnTriggerEnter2D(Collider2D other)
   {
      _mutate.Reload();
   }
}
