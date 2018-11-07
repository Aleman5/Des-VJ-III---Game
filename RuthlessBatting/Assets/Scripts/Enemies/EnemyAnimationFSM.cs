﻿using UnityEngine;

public class EnemyAnimationFSM : MonoBehaviour
{
    Animator anim;
    Enemy fsmScript;

    bool isChasing;

    void Awake()
    {
        anim = GetComponent<Animator>();
        fsmScript = transform.GetComponentInParent<Enemy>();
        transform.GetComponentInParent<EnemyBase>().OnAttack.AddListener(Attacking);
        transform.GetComponentInParent<Health>().OnDeath.AddListener(Death);
    }

    void Update()
    {
        anim.SetInteger("Direction", fsmScript.GetDirection());

        anim.speed = isChasing == false ? 0.5f : 1.0f;

        if (fsmScript.PlayerOnSight())
            anim.speed = 1.6f;
        else if (fsmScript.PlayerOnAttackRange())
            anim.speed = 1f;
        
    }

    void Attacking()
    {
        anim.SetTrigger("Attack");
    }

    void Death()
    {
        anim.SetInteger("Direction", fsmScript.GetDirection());
        anim.SetTrigger("Death");
    }
}
