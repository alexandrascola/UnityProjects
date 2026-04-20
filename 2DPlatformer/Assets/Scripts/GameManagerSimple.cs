using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

//Global Manager for Score and UI
//Create an empty GameObject aka Game Manager and attach this script
//Assign score text and message text in the inspector

public class GameManagerSimple : MonoBehaviour
{
    //Create singleton loop: create instance of this object and point it at itself
    public static GameManagerSimple Instance;

    //Define UI elements
    [Header("UI")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI messageText;

    //Define global variables
    private int score = 0;
    private bool gameOver = false;


    //Make a simple singleton loop using void Awake()
    private void Awake() 
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreUI();
        ShowMessage(""); //empty at start
    }

    // Update is called once per frame
    void Update()
    {
        //handle win lose and restart
        if (gameOver && Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1f; //reset time scale in case we paused it
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    //Void to Add Score
    public void AddScore(int amount)
    {
        if (gameOver) return;
        score += amount;
        //call method to update UI
        UpdateScoreUI();

    }

    //Void to show Message
    public void ShowMessage(string msg)
    {
        if (messageText.text != null) messageText.text = msg;
    }


    //Void to WIN
    public void Win()
    {
        gameOver = true;
        ShowMessage("You WIN! Press R to Restart");
        //set time scale to 0 to pause til restart
        Time.timeScale = 0f;
    }

    //Void to LOSE
    public void Lose()
    {
        gameOver = true;
        ShowMessage("GAME OVER. Press R to Restart");
        //set time scale to 0 to pause til restart
        Time.timeScale = 0f;
    }

    //Void to update UI
    private void UpdateScoreUI()
    {
        if (scoreText.text != null) scoreText.text = "Score: " + score;
    }

}
