//using System;
using UnityEngine;
using UnityEngine.Events;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] GameObject m_sword;
    [SerializeField] GameObject activeWeaponObject;
    [SerializeField] Gun activeGun;
    [SerializeField] Animator gunAnimator;
    private float lastAttackTime;

    [Header("Attack")]
    [SerializeField] Transform attackPoint;
    [SerializeField] float attackRange = 2.5f;
    [SerializeField] LayerMask enemyLayers;

    public int bonusDamage;


    [Tooltip("Event that will be called")]
    [SerializeField] UnityEvent m_EventEnemyHit;
    void Start()
    {
        if (m_EventEnemyHit == null)
            m_EventEnemyHit = new UnityEvent();
        bonusDamage = 0;
    }

    [SerializeField] private GameObject[] footstepSounds;

    public void Step()
    {
        Instantiate(footstepSounds[Random.Range(0, footstepSounds.Length)]);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && activeGun != null)
        {
            if((Time.time - lastAttackTime) > activeGun.GetFireRate())
                Attack();
        }
        if(Input.GetKey(KeyCode.Mouse0) && activeGun != null) 
        {
            if ((Time.time - lastAttackTime) > activeGun.GetFireRate())
                Attack();
        }
    }

    public void PickUpSword(Gun gunToPickUp) 
    {
        m_sword.SetActive(true);
        activeGun = gunToPickUp;
        Debug.Log(activeGun.GetDamage());
    }

    void Attack() 
    {
        //PLAY ANIMATION
        DoAttackAnimation();

        //Fire Rate
        lastAttackTime = Time.time;

        Invoke("SendScreenShakeEvent", 0.24f);
        Step();

        
            

    }

    void DoAttackAnimation() 
    {
        gunAnimator.SetTrigger("Attack");
    }

    int CalculateDamage() 
    {
        int finalDamage = activeGun.GetDamage() + Random.Range(-4, 6) + bonusDamage;
        Debug.Log(finalDamage);
        return finalDamage;
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    void SendScreenShakeEvent() 
    {
        //Detecting Enemies
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

        //Damage Them
        foreach (Collider enemy in hitEnemies)
        {
            //Debug.Log("We hit" + enemy.name + CalculateDamage());
            EnemyObject thisEnemy = enemy.GetComponent<EnemyObject>();
            thisEnemy.GetDamage(CalculateDamage());
        }


        //Feedbacks
        if (hitEnemies[0].gameObject != null) 
        {
            Invoke("ScreenShakeEvent", 0f);
            //Instantiate(hitSound, hitEnemies[0].gameObject.transform.position, Quaternion.identity);
        }
    }

    void ScreenShakeEvent() 
    {
        m_EventEnemyHit.Invoke();
    }

    
}
