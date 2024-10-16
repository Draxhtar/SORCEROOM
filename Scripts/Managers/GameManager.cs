using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] Transform playerSpawnPosition;
    [SerializeField] GameObject player;
    [SerializeField] PlayerMovement playerMovementScript;

    public void RestartGame() 
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        player.transform.position = playerSpawnPosition.position;
        player.transform.rotation = playerSpawnPosition.rotation;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
