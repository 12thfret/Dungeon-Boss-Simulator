using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStats : MonoBehaviour
{

    public static PlayerStats playerStats;

    public GameObject player;
    public TMP_Text healthText;
    public Slider healthSlider;
    public float health;
    public float maxHealth;
    public int coins;

    void Awake() {
        if(playerStats != null) {
            Destroy(playerStats);
        }
        else {
            playerStats = this;
        }
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        health = maxHealth;
        SetHealthUI();
    }

    public void DealDamage(float damage) 
    {
        health -= damage;
        CheckDeath();
        SetHealthUI();
    }

    public void HealCharacter(float heal) {

        health += heal;
        CheckOverheal();
        SetHealthUI();
    }

    private void CheckOverheal() 
    {
        if (health > maxHealth) {
            health = maxHealth;
        }
    }

    private void SetHealthUI() {
        healthSlider.value = CalculateHealthPercentage();
        healthText.text = Mathf.Ceil(health).ToString() + " / " + Mathf.Ceil(maxHealth).ToString();
    }

    private void CheckDeath() 
    {
        if (health <= 0) {
            Destroy(player);
        }
    }

    float CalculateHealthPercentage() {
        return (health / maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}