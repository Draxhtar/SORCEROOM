using UnityEngine;
using DG.Tweening;
using TMPro;

public class Powerup : MonoBehaviour
{
    GameObject player;
    bool isPlayerInside;
    bool canBePickedUp;
    [SerializeField] KeyCode keyToPickUp = KeyCode.E;
    [SerializeField] TMP_Text pickUpText;
    [SerializeField] GameObject model;
    [SerializeField] GameObject uiCanvas;
    [SerializeField] int indexOnGunContainer = 0;
    [SerializeField] GameObject pickUpSound;
    [SerializeField] GameObject powerupParticle;

    [SerializeField] GameObject heart;
    [SerializeField] GameObject sneakers;
    [SerializeField] GameObject rock;
    [SerializeField] GameObject pill;
    private void Start()
    {
        canBePickedUp = true;
        DisablePickUpUI();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.gameObject;
            isPlayerInside = true;
            ShowPickUpUI();
            Debug.Log("Enter");
        }
    }
    public void GetRandomPowerup() 
    {
        indexOnGunContainer = Random.Range(0, 4);

        switch (indexOnGunContainer)
        {
            case 0:
                pickUpText.text = "Increase Max Health by 25";
                Instantiate(pill, model.transform);
                break;
            case 1:
                pickUpText.text = "Increase Strength by 10";
                Instantiate(rock, model.transform);
                break;
            case 2:
                pickUpText.text = "Increase Move Speed 15";
                Instantiate(sneakers, model.transform);
                break;
            case 3:
                pickUpText.text = "+50 Health";
                Instantiate(heart, model.transform);
                break;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.gameObject;
            isPlayerInside = false;
            DisablePickUpUI();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isPlayerInside == true && canBePickedUp)
        {
            DoPickup(); 
        }
    }

    void DoPickup() 
    {
        Debug.Log("Pick Uppped!");
        canBePickedUp = false;
        PlayerPowerupManager myWeaponManager =  player.GetComponent<PlayerPowerupManager>();
        myWeaponManager.TakePowerup(indexOnGunContainer);
        model.SetActive(false);
        uiCanvas.SetActive(false);
        PlayPickUpSound();
        Instantiate(powerupParticle, transform.position, Quaternion.identity);
    }
    //POLISH FADE
    void ShowPickUpUI() 
    {
        pickUpText.faceColor = new Color32(255, 255, 255, 255);
        pickUpText.outlineColor = new Color32(0, 0, 0, 255);
        //pickUpText.color = new Color32(218, 82, 98, 100);
    }
    void DisablePickUpUI()
    {
        pickUpText.faceColor = new Color32(255, 255, 255, 0);
        pickUpText.outlineColor = new Color32(255, 255, 255, 0);
        //pickUpText.color = new Color32(218, 82, 98, 0);
    }

    void PlayPickUpSound() 
    {
        Instantiate(pickUpSound, transform.position, Quaternion.identity);
    }
}
