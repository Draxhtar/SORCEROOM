using UnityEngine;

public class Chest : MonoBehaviour
{
    private Animator myAnimator;
    [SerializeField] Transform powerupPosition;
    [SerializeField] GameObject revealSound;
    [SerializeField] GameObject powerupPrefab;

    private void OnEnable()
    {
        myAnimator = GetComponent<Animator>();
    }
    public void GetChestOpen()
    {
        if(myAnimator != null)
        myAnimator.SetBool("IsChestOpen", true);
        Instantiate(revealSound, powerupPosition.position, Quaternion.identity);
        SpawnPowerup();
    }

    public void GetChestClosed()
    {
        if(myAnimator != null)
        myAnimator.SetBool("IsChestOpen", false);
    }

    void SpawnPowerup() 
    {
        powerupPrefab.SetActive(enabled);
        powerupPrefab.GetComponent<Powerup>().GetRandomPowerup();
    }


}
