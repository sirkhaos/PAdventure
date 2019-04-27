using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class UIManager : MonoBehaviour
{
    public Slider playerHealthBar;
    public Text playerHealthText;
    public HealthManager playerHealthManager;
    public CharacterStats characterstats;
    public Text lvlTxt;
    // Update is called once per frame
    void Update()
    {
        //level up
        playerHealthBar.maxValue = playerHealthManager.maxHealth;
        playerHealthBar.value = playerHealthManager.currentHealth;

        StringBuilder sb = new StringBuilder("HP: ");
        sb.Append(playerHealthManager.currentHealth);
        sb.Append("/");
        sb.Append(playerHealthManager.maxHealth);
        playerHealthText.text = sb.ToString();
        sb = new StringBuilder("Level: ");
        sb.Append(characterstats.currentLevel);
        lvlTxt.text = sb.ToString();
    }
}
