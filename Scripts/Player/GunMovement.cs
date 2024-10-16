using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMovement : MonoBehaviour
{

    public GameObject ParentObje;
    public float moveAmount;
    public float moveSpeed;
    private float moveX;
    private float moveY;
    private Vector3 defaultParentObjePos;
    private Vector3 newParentObjePos;



    void Start()
    {
        defaultParentObjePos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxis("Mouse X") * Time.deltaTime * moveAmount;

        moveY = Input.GetAxis("Mouse Y") * Time.deltaTime * moveAmount;

        newParentObjePos = new Vector3(defaultParentObjePos.x + moveX, defaultParentObjePos.y + moveY, defaultParentObjePos.z);

        ParentObje.transform.localPosition = Vector3.Lerp(ParentObje.transform.localPosition, newParentObjePos, moveSpeed * Time.deltaTime);
    }
}