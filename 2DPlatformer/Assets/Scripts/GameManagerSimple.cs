using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Void to Add Score


    //Void to show Message


    //Void to WIN


    //Void to LOSE


    //Void to update UI


}
