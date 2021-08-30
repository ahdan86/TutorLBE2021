using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text playerScoreText;
    public Text computerScoreText;

    // Ini
    public Ball ball;

    private int playerScore;

    // Ini
    public Paddle playerPaddle;

    private int computerScore;

    // dan Ini
    public Paddle computerPaddle;

    // Fungsi / method baru
    public void StartRound()
    {
        playerPaddle.ResetPosition();
        computerPaddle.ResetPosition();
        ball.ResetPosition();
        ball.AddStartingForce();
    }

    public void PlayerScores()
    {
        SetPlayerScore(playerScore + 1);

        StartRound();
    }

    public void ComputerScores()
    {
        SetComputerScore(computerScore + 1);

        StartRound();
    }

    private void SetPlayerScore(int score)
    {
        playerScore = score;
        playerScoreText.text = score.ToString();
    }

    private void SetComputerScore(int score)
    {
        computerScore = score;
        computerScoreText.text = score.ToString();
    }

    public void NewGame()
    {
        SetPlayerScore(0);
        SetComputerScore(0);
        StartRound();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            NewGame();
        }
    }
}