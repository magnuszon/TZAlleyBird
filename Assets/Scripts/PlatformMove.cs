using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    [SerializeField] private float downSpeed=1;
    void Update()
    {
        transform.position += Vector3.down* downSpeed*Time.deltaTime;
    }

    public void DI(float downSpeed)
    {
        this.downSpeed = downSpeed;
    }
}
