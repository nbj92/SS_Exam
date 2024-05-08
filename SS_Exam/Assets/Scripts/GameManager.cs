using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    private int score;

    public enum GameState {
        MainMenu,
        Playing,
        Paused,
        Ended
    }

    public GameState currentState { get; private set; }


    private void Awake() {
        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

   

    public void SetGameState(GameState newState) {
        currentState = newState;
        OnStateChange(currentState);
    }

    private void OnStateChange(GameState newState) {
        switch (newState) {
            case GameState.MainMenu:
                // Handle main menu logic
                break;
            case GameState.Playing:
                // Reset or start gameplay
                break;
            case GameState.Paused:
                // Pause the game, maybe open a pause menu
                break;
            case GameState.Ended:
                // Clean up the game, show game over screen
                break;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame() {
        SetGameState(GameState.Playing);
        score = 0; 
                   
    }

    public void PauseGame() {
        SetGameState(GameState.Paused);
    }

    public void ResumeGame() {
        SetGameState(GameState.Playing);
    }

    public void EndGame() {
        SetGameState(GameState.Ended);
        // Handle end game logic
        SceneManager.LoadScene(0);  //Mangler at skrive scenen, som skal loades, når man klikker på End Game btn. 
    }


    public void AddScore(int points) {
        score += points;
        UpdateUI();
    }

    private void UpdateUI() {
        // You would typically update UI elements here
        Debug.Log("Current Score: " + score);
    }

    public void SaveGame() {
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save();
    }

    public void LoadGame() {
        score = PlayerPrefs.GetInt("Score", 0);
        // Load other necessary data
    }
}
