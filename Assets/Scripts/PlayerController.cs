using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float TorqueAmount = 1f;
    [SerializeField] float BoostSpeed = 30f;
    [SerializeField] float NormalSpeed = 20f;
    [SerializeField] SurfaceEffector2D surfaceEffector2D;
    bool canMove = true;
    Rigidbody2D rb2d;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    void Update()
    {
        if (canMove == true)
        {
            RotatePlayer();
            respondtoBoost();
        }
    }
    public void DisableControl()
    {
        canMove = false;
    }

    void respondtoBoost()
    {
        //speed up if hover else normal speed
        //acess to surfaceeffect2d to change speed
        if (Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector2D.speed = BoostSpeed;
        }
        else
        {
            surfaceEffector2D.speed = NormalSpeed;
        }
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(TorqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-TorqueAmount);
        }
    }
}
