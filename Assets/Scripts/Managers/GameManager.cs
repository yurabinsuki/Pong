using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Interactables
    public GameObject playerOne_Player;
    public GameObject playerTwo_Player;
    public GameObject playerOne_Bot;
    public GameObject playerTwo_Bot;
    public GameObject ball;
    public BallController ballController;
    #endregion

    #region Settings
    public GameSettings gameSettings;
    #endregion  

    #region UI
    public TextMeshProUGUI playerOnePoints;
    public TextMeshProUGUI playerTwoPoints;
    public TextMeshProUGUI playerOneName;
    public TextMeshProUGUI playerTwoName;
    public TextMeshProUGUI winnerText;
    public TextMeshProUGUI restartButtonText;
    public Effects effects;
    public GameObject winnerScreen;
    #endregion    

    #region Variables
    public int playerScore = 0;
    public int enemyScore = 0;
    public int winPoints = 10;

    private GameObject currentPlayerOne;
    private GameObject currentPlayerTwo;
    #endregion

    void Start()
    {
        SetupPlayers();
        winnerScreen.SetActive(false);
        ResetGame();
    }

    public void SetupPlayers()
    {
        // nomes
        playerOneName.text = gameSettings.playerOneName;
        playerTwoName.text = gameSettings.playerTwoName;

        // PLAYER ONE
        if (gameSettings.playerOneIsBot)
        {
            playerOne_Player.SetActive(false);
            playerOne_Bot.SetActive(true);

            currentPlayerOne = playerOne_Bot;

            playerOne_Bot.GetComponent<SpriteRenderer>().color = gameSettings.playerOneColor;
        }
        else
        {
            playerOne_Player.SetActive(true);
            playerOne_Bot.SetActive(false);

            currentPlayerOne = playerOne_Player;

            playerOne_Player.GetComponent<SpriteRenderer>().color = gameSettings.playerOneColor;
        }

        // PLAYER TWO
        if (gameSettings.playerTwoIsBot)
        {
            playerTwo_Player.SetActive(false);
            playerTwo_Bot.SetActive(true);

            currentPlayerTwo = playerTwo_Bot;

            playerTwo_Bot.GetComponent<SpriteRenderer>().color = gameSettings.playerTwoColor;
        }
        else
        {
            playerTwo_Player.SetActive(true);
            playerTwo_Bot.SetActive(false);

            currentPlayerTwo = playerTwo_Player;

            playerTwo_Player.GetComponent<SpriteRenderer>().color = gameSettings.playerTwoColor;
        }
    }

    public void ResetGame()
    {
        currentPlayerOne.transform.position = new Vector3(-7f, 0f, 0f); 
        currentPlayerTwo.transform.position = new Vector3(7f, 0f, 0f);

        ballController.ResetBall();

        playerScore = 0;    
        enemyScore = 0;

        playerOnePoints.text = playerScore.ToString();
        playerTwoPoints.text = enemyScore.ToString();

    }

    public void PlayerScores()
    {
        playerScore++;
        playerOnePoints.text = playerScore.ToString();
        CheckWin();
    }

    public void EnemyScores()
    {
        enemyScore++;
        playerTwoPoints.text = enemyScore.ToString();
        CheckWin();
    }

    public void CheckWin()
    {
        if (playerScore >= winPoints)
            EndGame(gameSettings.playerOneName);
        else if (enemyScore >= winPoints)
            EndGame(gameSettings.playerTwoName);
    }

    private void EndGame(string winnerName)
    {
        if (winnerText != null)
            winnerText.text = $"{winnerName} Wins!";

        WinnerScreen();
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void RestartGame()
    {
        winnerScreen.SetActive(false);
        ball.SetActive(true);   
        ResetGame();
    }

    public void WinnerScreen()
    {
        ball.SetActive(false);   
        winnerScreen.SetActive(true);
        effects.ScalingEffect(winnerText.transform, 0.5f, 1.5f);
        effects.BlinkingText(restartButtonText);
    }
}