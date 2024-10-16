using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 100;
    private int currentHealth;
    bool amIDead;
    public HealthBar healthBar;
    public PauseMenu pauseMenuManager;
    public Animator redVignette;


    private void OnEnable()
    {
        currentHealth = maxHealth;
        amIDead = false;
        healthBar.SetMaxHealthAtStart(maxHealth);
    }

    public void GetDamage(int damageToTake)
    {
        currentHealth -= damageToTake;
        CheckIfImDead();
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthBar.SetHealth(currentHealth);
        redVignette.SetTrigger("Damage");
    }

    void CheckIfImDead()
    {
        if (currentHealth <= 0)
        {
            if(amIDead == false)
                Die();
        }
    }

    void Die()
    {
        amIDead = true;
        Debug.Log("Player is dead");
        pauseMenuManager.OnPlayerDie();
    }

    public bool IsThisPlayerDead()
    {
        return amIDead;
    }

    public void IncreaseMaxHealth(int amount)
    {
        maxHealth += amount;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void IncreaseHealth(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthBar.SetHealth(currentHealth);
    }


}
