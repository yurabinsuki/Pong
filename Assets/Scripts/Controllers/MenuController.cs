using UnityEngine;
using TMPro;

public class MenuController : MonoBehaviour
{
    public GameSettings gameSettings;

    public TMP_InputField playerOneNameInput;
    public TMP_InputField playerTwoNameInput;

    public void SaveNames()
    {
        // PLAYER ONE
        if (string.IsNullOrWhiteSpace(playerOneNameInput.text))
        {
            gameSettings.playerOneName = gameSettings.playerOneIsBot ? "Bot 1" : "Player One";
        }
        else
        {
            gameSettings.playerOneName = playerOneNameInput.text.Trim();
        }

        // PLAYER TWO
        if (string.IsNullOrWhiteSpace(playerTwoNameInput.text))
        {
            gameSettings.playerTwoName = gameSettings.playerTwoIsBot ? "Bot 2" : "Player Two";
        }
        else
        {
            gameSettings.playerTwoName = playerTwoNameInput.text.Trim();
        }
    }

    public void QuitGame()
    {        
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}