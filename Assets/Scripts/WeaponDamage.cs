﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    public int damage;

    public GameObject hurtAnimation;
    public GameObject hitPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            collision.gameObject.GetComponent<HealthManager>().damgeCharacter(damage);
            Instantiate(hurtAnimation, hitPoint.transform.position, hitPoint.transform.rotation);
        }
    }
}
