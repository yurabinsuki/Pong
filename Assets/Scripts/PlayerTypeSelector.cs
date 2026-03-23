using TMPro;
using UnityEngine;

public class PlayerTypeSelector : MonoBehaviour
{
    public enum PlayerID
    {
        PlayerOne,
        PlayerTwo
    }

    public PlayerID playerID;

    public TMP_Text label;

    public GameSettings gameSettings;

    private bool isBot;

    void Start()
    {
        if (playerID == PlayerID.PlayerOne)
            isBot = gameSettings.playerOneIsBot;
        else
            isBot = gameSettings.playerTwoIsBot;

        UpdateLabel();
    }

    public void Next()
    {
        isBot = !isBot;
        Apply();
    }

    public void Previous()
    {
        isBot = !isBot;
        Apply();
    }

    void Apply()
    {
        if (playerID == PlayerID.PlayerOne)
            gameSettings.playerOneIsBot = isBot;
        else
            gameSettings.playerTwoIsBot = isBot;

        UpdateLabel();
    }

    void UpdateLabel()
    {
        label.text = isBot ? "Bot" : "Player";
    }
}