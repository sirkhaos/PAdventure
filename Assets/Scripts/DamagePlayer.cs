using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public int damage;
    public GameObject damageNumber;
    private SFXManager sfxmanager;

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            int totalDamage = damage;
            CharacterStats stats = collision.gameObject.GetComponent<CharacterStats>();
            totalDamage = totalDamage - stats.defLvl[stats.currentLevel] >= 0 ? totalDamage - stats.defLvl[stats.currentLevel] : 1;
            collision.gameObject.GetComponent<HealthManager>().damgeCharacter(totalDamage);
            var clone = (GameObject)Instantiate(damageNumber, collision.transform.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<DamageNumber>().damagePoints = totalDamage;
            sfxmanager = FindObjectOfType<SFXManager>();
            sfxmanager.playerHurt.Play();
        }
    }
}
