using UnityEngine;

public class GameInputHandler : MonoBehaviour
{
    public GameManager gameManager;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
                gameManager.RestartGame();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
                gameManager.ReturnToMenu();
        }
    }
}
