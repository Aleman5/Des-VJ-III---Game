﻿using UnityEngine;

public class MouseDirection : MonoBehaviour
{
    void LateUpdate()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        mousePosition.y = 0;
        transform.rotation = Quaternion.LookRotation(mousePosition, Vector3.up);
    }
}
