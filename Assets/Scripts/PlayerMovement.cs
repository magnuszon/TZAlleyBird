using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D _rigidbody2D;
    private bool currentMoveRight;
    private bool controlBlocked;
    [SerializeField]private float bounds;
    [SerializeField] private float baseSpeed, speedIncreaserPerSec;
    private float totalSpeed;
    [SerializeField] private float JumpPower;
    [SerializeField] private float GroundcheckDistance = 1;
    [SerializeField] private bool Groundcheck;

    private void Awake()
    {
        Physics2D.queriesStartInColliders = false;
    }

    void Start()
    {
        _rigidbody2D = player.GetComponent<Rigidbody2D>();
        totalSpeed = baseSpeed;
    }

    void Update()
    {
        CalcTotalSpeed();
        Move();
        GroundCheck();
        WinControl();
    }

    private void WinControl()
    {
       
        if (!controlBlocked)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Jump();
            }
        }
    }

    private void CalcTotalSpeed()
    {
        totalSpeed +=  (speedIncreaserPerSec * Time.deltaTime);
    }

    private void GroundCheck()
    {
        Groundcheck = Physics2D.Raycast(player.transform.position, Vector3.down, GroundcheckDistance);
    }
    private void Jump()
    {
        if (Groundcheck)
        {
            _rigidbody2D.AddForce(Vector2.up * JumpPower * 100);
        }
    }

    private void Move()
    {
        
        if (currentMoveRight)
        {
            if (player.transform.position.x > bounds)
            {
                currentMoveRight = !currentMoveRight;
            }
            player.transform.position+=Vector3.right*totalSpeed;
            //_rigidbody2D.AddForce(Vector3.right*totalSpeed,ForceMode2D.Force);
        }
        else
        {
            if (player.transform.position.x < -bounds)
            {
                currentMoveRight = !currentMoveRight;
            }
            player.transform.position+=Vector3.left*totalSpeed;
            //_rigidbody2D.AddForce(Vector3.left*totalSpeed,ForceMode2D.Force);
        }
    }

    public void DI(GameObject player)
    {
        this.player = player;
    }

}
