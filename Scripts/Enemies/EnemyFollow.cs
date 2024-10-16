using UnityEngine.AI;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform player;
    public PlayerHealth playerHealth;
    private bool amIAlive;
    private bool amIActive;
    private EnemyObject myEnemyObject;
    Rigidbody myRb;
    private float lastAttackTime;

    [SerializeField] float attackRange;
    [SerializeField] float overlapRadius;
    [SerializeField] float attackRate = 2f;
    [SerializeField] int attackDamage;
    [SerializeField] GameObject[] hitSound;

    [SerializeField] Animator enemyAnimator;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] float attackPositionUpdateDelay = 0.35f;
    bool isPlayerCrouching;

    [SerializeField] Transform lowPoint;
    [SerializeField] Transform upPoint;

    private void OnEnable()
    {
        myEnemyObject = GetComponent<EnemyObject>();
        amIAlive = true;
        amIActive = false;
        myRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (amIAlive && amIActive) 
        {
            float distanceToPlayer = (transform.position - player.position).magnitude;

                FollowPlayer();
            if (distanceToPlayer <= attackRange)
            {
                if ((Time.time - lastAttackTime) > attackRate)
                    AttackToPlayer();
            }

        }

        InvokeRepeating("IsPlayerCrouchingUpdate", 0.35f, 9999999);
    }
    void IsPlayerCrouchingUpdate() 
    {
        isPlayerCrouching = playerMovement.IsPlayerCrouching();
    }

    void FollowPlayer() 
    {
        enemy.SetDestination(player.position);
        //Vector3 desiredVelocityNav = enemy.desiredVelocity;
        //myRb.velocity = desiredVelocityNav;
       
    }

    void AttackToPlayer() 
    {
       
        //PLAY ANIMATION
        enemyAnimator.SetTrigger("Attack");
        //DoAttackAnimation();

        
            //Fire Rate
         lastAttackTime = Time.time;
        

    }

    public void DoAttack() 
    {
        Transform attackPoint;
        if (isPlayerCrouching)
        {
            attackPoint = lowPoint;
        }
        else 
        {
            attackPoint = upPoint;
        }
        Debug.Log(attackPoint);

        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, overlapRadius, LayerMask.GetMask("Player"));

        if (hitEnemies[0] != null) 
        {
            playerHealth.GetDamage(CalculateDamage());
            PlayHitSound(player.transform.position - (player.transform.position - transform.position).normalized);
        }

    }
    int CalculateDamage()
    {
        int finalDamage = attackDamage + Random.Range(-4, 6);
        return finalDamage;
    }

    public void OnIAmDead() 
    {
        amIAlive = false;
    }

    public void PlayerEnteredThisRoom()
    {
        amIActive = true;
    }


    void PlayHitSound(Vector3 hitPos)
    {
        Instantiate(hitSound[UnityEngine.Random.Range(0, hitSound.Length)], hitPos, Quaternion.identity);
    }
    
}
