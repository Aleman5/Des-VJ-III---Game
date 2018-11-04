﻿using UnityEngine;

public class TriggerDetection : MonoBehaviour
{
    [SerializeField] string objective;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag(objective))
        {
            Health health = collision.GetComponent<Health>();
            if (health)
                health.Amount -= 1;
        }
    }
}
