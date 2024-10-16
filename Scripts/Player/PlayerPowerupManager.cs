using UnityEngine;

public class PlayerPowerupManager : MonoBehaviour
{

    PlayerMovement playerMovement;
    PlayerHealth playerHealth;
    WeaponManager weaponManager;

    [SerializeField] int increaseMaxHealthAmount = 25;

    private void OnEnable()
    {
        playerHealth = GetComponent<PlayerHealth>();
        playerMovement = GetComponent<PlayerMovement>();
        weaponManager = GetComponent<WeaponManager>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
            IncreaseMaxHealth();
    }
    public void IncreaseMaxHealth() 
    {
        playerHealth.IncreaseMaxHealth(increaseMaxHealthAmount);
    }

    public void IncreaseDamage() 
    {
        weaponManager.bonusDamage += 10;
    }

    public void IncreaseMoveSpeed() 
    {
        playerMovement.maxSpeed += 10f;
    }

    void IncreaseHealth() 
    {
        playerHealth.IncreaseHealth(40);
    }

    public void TakePowerup(int i) 
    {
        switch(i)
        {
            case 0:
                IncreaseMaxHealth();
                break;
            case 1:
                IncreaseDamage();
                break;
            case 2:
                IncreaseMoveSpeed();
                break;
            case 3:
                IncreaseHealth();
                break;
        }
    }
}
