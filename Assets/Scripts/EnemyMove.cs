using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public static EnemyMove Instance;
    private List<EnemyParams> _enemyParamses = new List<EnemyParams>();
    [SerializeField] private float walkingEnemySpeed = 0.2f;
    private float bounds;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        bounds = GetComponent<PlayerMovement>().StealBoundsInfo();
    }

    public void Add(EnemyParams newEp)
    {
        _enemyParamses.Add(newEp);
        if (newEp.myType == EnemyParams.EnemyType.dropingEnemy)
        {
            newEp.GetComponent<Collider2D>().enabled = false;
        }
        if (newEp.myType == EnemyParams.EnemyType.staticEnemy || newEp.myType == EnemyParams.EnemyType.walkingEnemy)
        {
            newEp.GetComponent<Collider2D>().isTrigger = true;
            newEp.GetComponent<Rigidbody2D>().gravityScale = 0;
        }
    }

    private void Update()
    {
        for (int i = 0; i < _enemyParamses.Count; i++)
        {
            if (_enemyParamses[i] != null)
            {
                switch (_enemyParamses[i].myType)
                {
                    case EnemyParams.EnemyType.walkingEnemy:
                        MovedPlayerBehaviour(_enemyParamses[i]);
                        break;
                    case EnemyParams.EnemyType.jumpingEnemy:
                        break;
                }
            }
        }
        
    }

    private void MovedPlayerBehaviour(EnemyParams currentParams)
    {
        if (currentParams.currentMoveRight)
        {
            if (currentParams.transform.position.x > bounds)
            {
                currentParams.currentMoveRight = !currentParams.currentMoveRight;
            }
            currentParams.transform.position+=Vector3.right*(walkingEnemySpeed*Time.deltaTime);
        }
        else
        {
            if (currentParams.transform.position.x < -bounds)
            {
                currentParams.currentMoveRight = !currentParams.currentMoveRight;
            }
            currentParams.transform.position+=Vector3.left*(walkingEnemySpeed*Time.deltaTime);
        }
    }
}
