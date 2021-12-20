using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTrigger : PlayerTrigger
{
   [SerializeField] private PlatrformMutate _mutate;
   protected override void Triggered()
   {
       _mutate.Triggered();
       gameObject.SetActive(false);
      
   }
}
