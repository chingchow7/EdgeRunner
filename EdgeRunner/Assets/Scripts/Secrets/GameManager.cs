using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Text ScoreText;
    public GameObject retryButton;
    public GameObject gameStartText;
    public GameObject highScoreText;

    public int score;

    public PlayerController playerController;
    public PlayerScript playerScript;

    private bool gameOverInit = false;
    private bool gameStarted = false;

    private float[] speeds = new float[2];

	// Use this for initialization
	void Start () {
        speeds[0] = playerController.speed;
        speeds[1] = playerScript.speed;

        playerController.speed = 0;
        playerScript.speed = 0;

        Debug.Log(getHighScore());
    }
	
	// Update is called once per frame
	void Update () {
        //check for left click to start the game
        if (!gameStarted) {
            if (Input.GetMouseButtonDown(0)) {
                gameStarted = true;
                GameStart();
                gameStartText.SetActive(false);
            }
        }


        if (!playerController.dead) {
            if (gameStarted) {
                score++;
                ScoreText.text = "Score: " + score;
            }
        } else {
            // if game over hasnt been initialized yet. initialize game over
            if (!gameOverInit) {
                GameOver();
            }
        }            
    }

    public void GameStart() {

        playerController.speed = speeds[0];
        playerScript.speed = speeds[1];
    }

    private void GameOver() {
        gameOverInit = false;
        retryButton.SetActive(true);

        highScoreText.SetActive(true);
        float highScore = getHighScore();

        if (score > highScore) {
            SetHighScore(score);
        }

        highScoreText.GetComponent<Text>().text = "High Score: " + getHighScore();
    }

    public void RetryButton() {
        Application.LoadLevel(0);
    }

    //score stuff
    public bool SetHighScore(int score) {
        string key = "highscore";
        bool newHigh = false;

        if (PlayerPrefs.HasKey(key)) {
            if (PlayerPrefs.GetInt(key) < score) {
                newHigh = true;
                PlayerPrefs.SetInt(key, score);
            }
        } else {
            PlayerPrefs.SetInt(key, score);
            newHigh = true;
        }
        return newHigh;
    }

    public int getHighScore() {
        string key = "highscore";

        return PlayerPrefs.GetInt(key);
    }

    public void clearHighScore() {
        string key = "highscore";

        PlayerPrefs.SetInt(key, 0);
    }
}
