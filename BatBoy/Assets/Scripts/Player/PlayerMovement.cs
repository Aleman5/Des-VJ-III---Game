﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector3 mousePos;
    Animator anim;

    [SerializeField] float movSpeed;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);

        Vector3 movHor = Vector3.right * Input.GetAxis("Horizontal") * movSpeed;
        Vector3 movVer = Vector3.up * Input.GetAxis("Vertical") * movSpeed;

        transform.position += (movHor + movVer) * Time.deltaTime;

        anim.SetFloat("VerticalSpeed", Input.GetAxis("Vertical") / movSpeed);
        anim.SetFloat("HorizontalSpeed", Input.GetAxis("Horizontal") / movSpeed);
    }
}
