﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class GiveMoney : MonoBehaviour
{

    int moneyToGive; // This variable is temporary

    Health health;
    MoneyHolder moneyHolder;

    void Start()
    {
        moneyToGive = Random.Range(4, 8);

        health = GetComponent<Health>();
        health.OnDeath.AddListener(GiveMoneyToPlayer);

        moneyHolder = GameObject.Find("Player").GetComponent<MoneyHolder>();
    }

    void GiveMoneyToPlayer()
    {
        moneyHolder.ActualMoney = moneyToGive;
    }
}
