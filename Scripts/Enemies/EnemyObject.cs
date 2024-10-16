using System;
using UnityEngine;
using TMPro;

public class EnemyObject : MonoBehaviour
{
    [SerializeField] int maxHealth = 100;
    [SerializeField] public float moveSpeed;
    bool amIDead;

    private int currentHealth;

    public HealthBar healthBar;

    [SerializeField] RoomManager myRoomManager;
    [SerializeField] EnemyFollow myEnemyFollow;

    [SerializeField] GameObject[] hitSound;
    [SerializeField] GameObject[] killSounds;
    [SerializeField] GameObject textPopupPrefab;
    [SerializeField] Transform damageCanvas;

    private void OnEnable()
    {
        currentHealth = maxHealth;
        amIDead = false;
        healthBar.SetMaxHealthAtStart(maxHealth);
        myEnemyFollow = GetComponent<EnemyFollow>();
    }

    public void GetDamage(int damageToTake) 
    {
        currentHealth -= damageToTake;
        CheckIfImDead();
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthBar.SetHealth(currentHealth);
        DoTextPopup(damageToTake);
    }

    void DoTextPopup(int damage) 
    {
        GameObject textPopup = Instantiate(textPopupPrefab, damageCanvas);
        textPopup.GetComponent<TMP_Text>().text = damage.ToString();
    }

    void CheckIfImDead() 
    {
        if (currentHealth <= 0)
        {
            Die();
        }
        else 
        {
            PlayHitSound(transform.position);
        }
    }

    void Die() 
    {
        amIDead = true;
        healthBar.SetHealth(0);
        GetComponent<Collider>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;
        myRoomManager.CheckIsMyEnemiesDead();
        myEnemyFollow.OnIAmDead();
        PlayKillSound(transform.position);
    }

    public bool IsThisEnemyDead() 
    {
        return amIDead;
    }

    public void PlayerEnteredThisRoom() 
    {
        myEnemyFollow.PlayerEnteredThisRoom();
    }

    void PlayHitSound(Vector3 hitPos)
    {
        Instantiate(hitSound[UnityEngine.Random.Range(0, hitSound.Length)], hitPos, Quaternion.identity);
    }
    void PlayKillSound(Vector3 hitPos)
    {
        Instantiate(killSounds[UnityEngine.Random.Range(0, killSounds.Length)], hitPos, Quaternion.identity);
    }
}
