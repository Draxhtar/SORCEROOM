using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool isGamePaused = false;
    public static bool isPlayerDead = false;

    public GameObject pauseMenuUI;
    public PlayerMovement playerMovementScript;
    public GameObject deadScreen;
    public GunMovement gunMovement;
    [SerializeField] GameManager gameManager;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (isGamePaused)
            {
                if(isPlayerDead == false)
                    Resume();
            }
            else 
            {
                if (isPlayerDead == false)
                    Pause();
            }
        }
    }

    public void OnPlayerDie() 
    {
        deadScreen.SetActive(true);
        playerMovementScript.enabled = false;
        playerMovementScript.gameObject.SetActive(false);
        gunMovement.enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
        isPlayerDead = true;
    }

    public void RestartGame() 
    {
        deadScreen.SetActive(false);
        gunMovement.enabled = true;
        isPlayerDead = false;
        gameManager.RestartGame();
    }

    public void Resume() 
    {
        pauseMenuUI.SetActive(false);
        playerMovementScript.enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    void Pause() 
    {
        pauseMenuUI.SetActive(true);
        playerMovementScript.enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
        isGamePaused = true;
    }

    public void LoadMenu() 
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitGame()
    {
        Application.Quit();

        Debug.Log("Quitting Game");
    }
}
