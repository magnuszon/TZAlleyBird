using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillTrigger : PlayerTrigger
{
   private PlayerDeath playerDeath;

   private void Start()
   {
      playerDeath = PlayerDeath.Instance;
   }

   protected override void Triggered()
   {
      playerDeath.OnPlayerDead();
   }
}
