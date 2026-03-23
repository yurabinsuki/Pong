using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Game/Game Settings")]
public class GameSettings : ScriptableObject
{
    [Header("Player One")]
    public Color playerOneColor = Color.white;
    public string playerOneName = "Player One";
    public bool playerOneIsBot = false;

    [Header("Player Two")]
    public Color playerTwoColor = Color.white;
    public string playerTwoName = "Player Two";
    public bool playerTwoIsBot = false;
}