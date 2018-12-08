﻿using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BuyTextManager : MonoBehaviour
{
    [System.Serializable]
    public class Elements
    {
        public List<Sprite> hudSellers;
        public List<Sprite> hudAbilities;
        public SpriteRenderer sprite;
        public Image image;
        public BuyElement seller;
        public TextMeshPro sellerText;

        public int index;
        public int index2;
    }

    [SerializeField] Elements[] elements;
    [SerializeField] string[] differentAnswers;
    //[SerializeField] string notEnoughMoneyText;

    //int indexOfText;
    //string savedText = "";
  
    void Start()
    {
        for (int i = 0; i < elements.Length; i++)
        {
            int level = elements[i].seller.GetLevel();

            if (level > 0)
            {
                elements[i].sprite.sprite = elements[i].hudSellers[level];
                elements[i].image.sprite = elements[i].hudAbilities[level];
            }

            elements[i].sellerText.enabled = false;
            elements[i].sprite.enabled = false;
            elements[i].seller.OnRange.AddListener(OnRange);
            elements[i].seller.OnQuit.AddListener(OnQuit);

            elements[i].seller.OnInteract.AddListener(ChangeSprite);

            //elements[i].index = -1;
            //elements[i].index2 = -1;

            //elements[i].seller.OnNotEnoughMoney.AddListener(OnNotEnoughMoney);
        }

        //ChangeSprite();
    }

    void OnRange()
    {
        for (int i = 0; i < elements.Length; i++)
        {
            if (elements[i].seller.IsOnRange())
            {
                elements[i].sprite.enabled = true;
                elements[i].sellerText.enabled = true;
            }
        }
    }

    void OnQuit()
    {
        for (int i = 0; i < elements.Length; i++)
        {
            if (elements[i].sellerText.enabled)
            {
                elements[i].sellerText.enabled = false;
                elements[i].sprite.enabled = false;
            }
        }
    }

    void OnInteract()
    {
        for (int i = 0; i < elements.Length; i++)
        {
            if (elements[i].seller.IsOnRange())
            {
                if(IsInvoking("NameBackToNormal"))
                    CancelInvoke("NameBackToNormal");

                int newMessageIndex = Random.Range(0, differentAnswers.Length);
                //elements[i].sellerText.text = differentAnswers[newMessageIndex];
            }
        }
    }

    void ChangeSprite()
    {
        for (int i = 0; i < elements.Length; i++)
        {
            if (elements[i].sellerText.enabled)
            {
                elements[i].sprite.sprite = elements[i].hudSellers[elements[i].seller.GetLevel()];
                elements[i].image.sprite = elements[i].hudAbilities[elements[i].seller.GetLevel()];
            }
        }
    }

    /*void OnNotEnoughMoney()
    {
        for (int i = 0; i < elements.Length; i++)
        {
            if (elements[i].seller.IsOnRange())
            {
                indexOfText = i;
                savedText = elements[i].sellerText.text;
                elements[i].sellerText.text = notEnoughMoneyText;
                Invoke("NameBackToNormal", 0.5f);
            }
        }
    }

    void NameBackToNormal()
    {
        elements[indexOfText].sellerText.text = savedText;
    }*/
}
