﻿using UnityEngine;
using UnityEngine.Events;
using System.IO;

[System.Serializable]
public class MoneyHolder : MonoBehaviour
{
    [HideInInspector][SerializeField] UnityEvent onMoneyChange;

    int actualMoney = 0;

    void Start()
    {
        if (File.Exists(Application.persistentDataPath + "/rbSave.bp"))
        {
            actualMoney = SaveLoad.saveGame.data.moneyCount;
        }
    }

    public int ActualMoney
    {
        get { return actualMoney; }
        set
        {
            actualMoney += value;
            OnMoneyChange.Invoke();
        }
    }

    public UnityEvent OnMoneyChange
    {
        get { return onMoneyChange; }
    }
}
