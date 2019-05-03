﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value;
    private CoinsManager manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<CoinsManager>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            manager.AddMoney(value);
            Destroy(gameObject);
        }
    }
}
