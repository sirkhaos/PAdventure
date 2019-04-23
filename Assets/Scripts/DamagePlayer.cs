using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public int damage;
    public GameObject damageNumber;


    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            collision.gameObject.GetComponent<HealthManager>().damgeCharacter(damage);
            var clone = (GameObject)Instantiate(damageNumber, collision.transform.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<DamageNumber>().damagePoints = damage;
        }
    }
}
