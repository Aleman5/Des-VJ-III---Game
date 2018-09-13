﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement3D : MonoBehaviour
{
    //Vector3 mousePos;

    [SerializeField] float movSpeed;

    Rigidbody rb;
    Vector3 movForce;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        movForce = Vector3.zero;
        movForce.x = Input.GetAxis("Horizontal") * movSpeed;
        movForce.z = Input.GetAxis("Vertical") * movSpeed;
        movForce.y = 0;
        

        // Rotation by the mouse position
        //mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);

        // Moving with transform
        /*Vector3 movHor = Vector3.right * Input.GetAxis("Horizontal") * movSpeed;
        Vector3 movVer = Vector3.up * Input.GetAxis("Vertical") * movSpeed;
        transform.position += (movHor + movVer) * Time.deltaTime;*/
    }

    void FixedUpdate()
    {
        rb.AddForce(movForce);
    }
}
