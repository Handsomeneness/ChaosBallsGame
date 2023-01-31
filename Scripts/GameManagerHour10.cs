using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class GameManagerHour10 : MonoBehaviour
{
    public GoalScript blue, green, red, orange;
    private bool isGameOver = false;
    public GameObject player;
    private GameObject blueBall;
    private GameObject redBall;
    private GameObject orangeBall;
    private GameObject greenBall;

    private float elapsedTime = 0;
    private bool isRunning = false;

    private FirstPersonController fpsController;
    
    private void Start()
    {
        fpsController = player.GetComponent<FirstPersonController>();
        fpsController.enabled = false;
    }
    private void StartGame()
    {
        elapsedTime = 0;
        isRunning = true;
        isGameOver = false;
        fpsController.enabled = true;
    }

    void Update()
    {
        if (isRunning)
        {
            elapsedTime = elapsedTime + Time.deltaTime;
        }
        // ≈сли все четыре цели выполнены - игра завершаетс€
        isGameOver = blue.isSolved && green.isSolved && red.isSolved && orange.isSolved;
    }

    public void FinishedGame()
    {
        isRunning = false;
        isGameOver = true;
        fpsController.enabled = false;
    }

    private void OnGUI()
    {
        if (!isRunning)
        {
            string message = "Click or press enter to play again";

            Rect startButton = new Rect(Screen.width / 2 - 120, Screen.height / 2, 240, 30);

            if (GUI.Button(startButton, message) || Input.GetKeyDown(KeyCode.Return))
            {
                StartGame();
            }
        }

        if (isGameOver)
        {
            GUI.Box(new Rect(Screen.width / 2 - 65, Screen.height - 115, 200, 60), "Game Over, Your Time Was");
            GUI.Label(new Rect(Screen.width / 2 - 10, Screen.height - 100, 20, 30), ((int)elapsedTime).ToString());
            FinishedGame();
        }

        else if (isRunning)
        {
            GUI.Box(new Rect(Screen.width / 2 - 65, Screen.height - 115, 130, 40), "Your Time Is");
            GUI.Label(new Rect(Screen.width / 2 - 10, Screen.height - 100, 20, 30), ((int)elapsedTime).ToString());
        }
    }
}
