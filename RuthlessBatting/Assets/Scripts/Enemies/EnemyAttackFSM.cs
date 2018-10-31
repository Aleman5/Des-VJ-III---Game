﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackFSM : MonoBehaviour, IAttack
{
    [SerializeField] Enemy fsmScript;
    [SerializeField] BoxCollider box;

    void Awake()
    {
        box.enabled = false;
    }

    public void Attack()
    {
        StartCoroutine("AttackCourutine");
    }

    IEnumerator AttackCourutine()
    {
        Vector3 dist = fsmScript.GetDistance();
        dist.y = 0;
        transform.rotation = Quaternion.LookRotation(dist, Vector3.up);

        fsmScript.enabled = false;

        yield return new WaitForSeconds(0.1f);

        ChangeBoxState();

        Utilities.GetDirection(transform, dist);

        yield return new WaitForSeconds(0.4f);
                                                                        // NUNCA DESHABILITAMOS EL DESTINATION, POR ESO ES QUE SIGUE CAMINANDO AL MISMO PUNTO.
        transform.eulerAngles = new Vector3(0f, 0f, 0f);

        ChangeBoxState();

        yield return new WaitForSeconds(0.5f);

        fsmScript.enabled = true;

        yield break;
    }

    private void ChangeBoxState()
    {
        box.enabled = !box.enabled;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            Health health = collision.GetComponent<Health>();
            health.Amount -= 1;
        }
    }
}
