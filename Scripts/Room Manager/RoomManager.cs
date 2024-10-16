using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [SerializeField] EnemyObject[] enemies;
    [SerializeField] Chest[] chests;
    [SerializeField] Door[] doors;

    bool isAnyEnemyAlive;

    private void OnEnable()
    {
        CheckIsMyEnemiesDead();
    }

    public void CheckIsMyEnemiesDead() 
    {
        isAnyEnemyAlive = true;
        for (int i = 0; i < enemies.Length; i++) 
        {
            if (enemies[i].IsThisEnemyDead() == false) 
            {
                isAnyEnemyAlive = true;
                break;
            }
            if (enemies[i].IsThisEnemyDead() == true) 
            {
                isAnyEnemyAlive = false;
                continue;
            }
        }
        if (isAnyEnemyAlive == true)
        {
            Debug.Log("Alive");
            return;
        }
        else 
        {
            Debug.Log("Dead");
            Invoke("SystemError", 1f);
        }
    }

    void PlayerEnteredTheRoom() 
    {
        if (isAnyEnemyAlive) 
        {
            CloseDoors();
            ActivateEnemies();
        }
    }

    void SystemError() 
    {
        Debug.Log("SUCCESS!! ERROR");
        //VISUAL FEEDBACK

        //CHEST OPEN
        OpenChests();

        OpenDoors();
    }

    void OpenDoors() 
    {
        for (int i = 0; i < doors.Length; i++)
        {
            doors[i].GetDoorOpen();
        }
    }

    void OpenChests()
    {
        for (int i = 0; i < chests.Length; i++)
        {
            chests[i].GetChestOpen();
        }
    }

    void CloseDoors()
    {
        for (int i = 0; i < doors.Length; i++)
        {
            doors[i].GetDoorClosed();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerEnteredTheRoom();
        }
    }

    void ActivateEnemies() 
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].PlayerEnteredThisRoom();
        }
    }
}
