using UnityEngine;
using DG.Tweening;
using TMPro;

public class Pickuppable : MonoBehaviour
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
        WeaponManager myWeaponManager =  player.GetComponent<WeaponManager>();
        myWeaponManager.PickUpSword(GunContainer.GetGun(indexOnGunContainer));
        model.SetActive(false);
        uiCanvas.SetActive(false);
        PlayPickUpSound();
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
