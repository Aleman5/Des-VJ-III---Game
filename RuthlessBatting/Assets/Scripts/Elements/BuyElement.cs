﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BuyElement : MonoBehaviour
{
    [SerializeField] Transform objective;
    [SerializeField] float distanceToInteract;
    [SerializeField] int levelOfTheElement;
    [Range(0,500)]
    [SerializeField] int priceOfTheElement;

    [HideInInspector][SerializeField] UnityEvent onInteract;
    [HideInInspector][SerializeField] UnityEvent onRange;
    [HideInInspector][SerializeField] UnityEvent onQuit;

    IBuyable buyable;
    MoneyHolder moneyHolder;

    bool isOnRange = false;
    bool isBought = false;

    void Start() {
        buyable = GetComponent<IBuyable>();
        moneyHolder = objective.GetComponent<MoneyHolder>();
    }

    void Update()
    {
        Vector3 dist = objective.position - transform.position;

        if (dist.magnitude < distanceToInteract)
        {
            if (!isOnRange)
            {
                isOnRange = true;
                onRange.Invoke();
            }

            if (InputManager.Instance.GetInteractButton() && !isBought && moneyHolder.ActualMoney >= priceOfTheElement)
            {
                isBought = true;
                buyable.Buy(objective, levelOfTheElement);
                moneyHolder.ActualMoney = -priceOfTheElement;
                onInteract.Invoke();
            }
        }
        else if (isOnRange)
        {
            isOnRange = false;
            onQuit.Invoke();
        }
    }

    public UnityEvent OnInteract
    {
        get { return onInteract; }
    }
    public UnityEvent OnRange
    {
        get { return onRange; }
    }
    public UnityEvent OnQuit
    {
        get { return onQuit; }
    }
    public bool IsOnRange()
    {
        return isOnRange;
    }
}
