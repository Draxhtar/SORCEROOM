using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendAttack : MonoBehaviour
{
    [SerializeField] EnemyFollow enemyFollow;

    public void DoAttack() 
    {
        enemyFollow.DoAttack();
    }
}
