using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTrigger : PlayerTrigger
{
   [SerializeField] private PlarformMutate _mutate;
   protected override void Triggered()
   {
       _mutate.Triggered();
       gameObject.SetActive(false);
      
   }
}
