using UnityEngine;

public class Gun
{
    private float fireRate;
    private int damage;
    private string description;

    public Gun(float fireRate, int damage, string desc)
    {
        this.fireRate = fireRate;
        this.description = desc;
        this.damage = damage;
    }
    public float GetFireRate()
    {
        return fireRate;
    }

    public string GetDescription()
    {
        return description;
    }

    public int GetDamage()
    {
        return damage;
    }
}
