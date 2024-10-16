using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{
    public float moveSpeed;

    public Rigidbody2D myRb;

    Vector2 movement;


    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");

 
    }

    private void FixedUpdate()
    {
        //myRb.MovePosition(myRb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
