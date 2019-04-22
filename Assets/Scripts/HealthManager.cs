using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHealth;

    /*
    [SerializeField]
    private */public int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
    public void damgeCharacter(int damage)
    {
        currentHealth -= damage;
    }

    public void updateMaxhelth(int newMaxHelth)
    {
        maxHealth = newMaxHelth;
        currentHealth = maxHealth;
    }
}
