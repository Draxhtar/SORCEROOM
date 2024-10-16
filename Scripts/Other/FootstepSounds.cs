using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSounds : MonoBehaviour
{
     bool isWalking; //true if im walking
     float FootstepDelayTime;
    Rigidbody myRb;
    public Transform footPoint;

    private void OnEnable()
    {
        myRb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Start()
     {
         StartCoroutine(PlayFootsteps()); //Starts the coroutine below (basically a function)
     }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)) 
        {
            if (myRb.velocity.magnitude > 0.1f) 
            {
                isWalking = true;
            }
        }
    }
    IEnumerator PlayFootsteps()
     {
         Start: //loop
 
         if (isWalking == true) //check if im walking
         {
            Step(); //play footstep sound (sound shouldnt really be longer than a second, just one footstep is enough)
             yield return new WaitForSeconds(FootstepDelayTime); //delay for a period of time
         }
 
         goto Start; //loop back to checking if im still walking
     }

    [SerializeField] private GameObject[] footstepSounds;

    public void Step()
    {
        Instantiate(footstepSounds[Random.Range(0, footstepSounds.Length)], footPoint.position, Quaternion.identity);
    }
}
