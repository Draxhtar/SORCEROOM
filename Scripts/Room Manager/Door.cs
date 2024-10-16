using UnityEngine;
using DG.Tweening;

public class Door : MonoBehaviour
{
    [SerializeField] float openAnimationDuration = 5f;
    [SerializeField] float YPosToStopAt = 13f;
    private float startYPos;
    [SerializeField] bool isTransitionDoor;
    [SerializeField] GameObject doorSound;

    private void OnEnable()
    {
        startYPos = transform.position.y;
    }
    public void GetDoorOpen() 
    {
        transform.DOMoveY(YPosToStopAt, openAnimationDuration);
        Debug.Log(YPosToStopAt);
        PlayDoorOpenSound();
    }

    public void GetDoorClosed()
    {
        transform.DOMoveY(startYPos, 0.1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            GetDoorOpen();
            Debug.Log("Open Sesame Open!");
        }
    }

    void PlayDoorOpenSound() {
        Instantiate(doorSound, transform.position, Quaternion.identity);
    }
}
