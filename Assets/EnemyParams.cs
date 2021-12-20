using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParams : MonoBehaviour
{
   public enum EnemyType
   {
      staticEnemy,dropingEnemy,walkingEnemy,jumpingEnemy
   }

   public EnemyType myType;
   public bool currentMoveRight;

   private void Start()
   {
      EnemyMove.Instance.Add(this);
   }
}
