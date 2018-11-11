﻿using UnityEngine;

public class MultiplierTextSettings : MonoBehaviour
{
    [SerializeField] float speed;

    void Update()
    {
        Vector3 mov = new Vector3(0.0f, speed * Time.deltaTime, 0.0f);
        transform.Translate(mov);
    }
}
