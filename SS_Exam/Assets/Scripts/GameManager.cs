using Assets.Scripts.Alternativ;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    private int score;




    public TextMeshProUGUI scoreText;
    public List<Animal_2> animals = new List<Animal_2>();
    public List<string> names = new List<string>();

    public void AddAnimal(Animal_2 animal)
    {
        if (animal != null)
        {
            animals.Add(animal);
            names.Add(animal.AnimalName);
        }

    }

    public void RemoveAnimal(Animal_2 animal)
    {
        if (animals.Contains(animal))
        {
            animals.Remove(animal);
            names.Remove(animal.AnimalName);
        }
    }

    public List<Animal_2> GetAnimals()
    {
        return new List<Animal_2>(animals);
    }


    // Til pauseskærmen
    public GameObject pause;
    private bool isPaused = false;
    //

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
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {

        
        if (SceneManager.GetActiveScene().name == "Laboratorie" && UIManager.Instance.labGroup == UIManager.Instance.activeGroup)
            UIManager.Instance.ShowUILayout(UILayouts.Lab);


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else {
                PauseGame();
            }
        }
    }

    public void StartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SetGameState(GameState.Playing);
        score = 0;
    }

    public void PauseGame() {
        SetGameState(GameState.Paused);
        pause.SetActive(true);

        Time.timeScale = 0f;
        isPaused = true;
        //SceneManager.LoadScene(3);
    }

    public void ResumeGame() {
        // SetGameState(GameState.Playing);
        pause.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        //Debug.Log("button test");
    }

    public void EndGame() {
        SetGameState(GameState.Ended);
        SceneManager.LoadScene(0);
        //Debug.Log("Game Ended");
        // Handle end game logic
    }

    public void QuitGame()
    {
        Application.Quit();
    }


    public void AddScore(int points) {
        score += points;
        UpdateUI();
    }

    public void UpdateUI() {

        if ( scoreText != null )
        {
            scoreText.text = "Gold: " + score.ToString();
        }
    }

    public void SaveGame() {
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save();
    }

    public void LoadGame() {
        score = PlayerPrefs.GetInt("Score", 0);
        UpdateUI();
    }

    public void HowToPlay(GameObject g)
    {
        CanvasGroup cg = g.GetComponent<CanvasGroup>();
        cg.alpha = cg.alpha == 0 ? 1 : 0;
        cg.interactable = !cg.interactable;
        cg.blocksRaycasts = !cg.blocksRaycasts;
    }
}
