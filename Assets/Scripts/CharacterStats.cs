using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int currentLevel;
    public int currentExp;
    public int[] expToLevelUp;

    public int[] hpLvl, strLvl, defLvl;
    private HealthManager healthManager;

    // Start is called before the first frame update
    void Start()
    {
        healthManager = GetComponent<HealthManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (currentLevel >= expToLevelUp.Length)
        {
            return;
        }

        if (currentExp >= expToLevelUp[currentLevel])
        {
            currentLevel++;
            healthManager.updateMaxhelth(hpLvl[currentLevel]);
        }
    }
    public void AddExp(int exp)
    {
        currentExp += exp;
    }
}
