using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private LevelManager[] levels;
    private static GameManager Instance;

    private GameState currentState;
    private LevelManager currentLevel;
    private int currentLevelIndex = 0;
    private bool isInputActive = true;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public static GameManager GetInstance()
    {
        return Instance;
    }

    public bool IsInputActive()
    {
        return isInputActive;
    }
    // Start is called before the first frame update
    void Start()
    {
        //Go to briefing state
        if (levels.Length > 0)
        {
            ChangeState(GameState.OpeningCutscene, levels[currentLevelIndex]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeState(GameState state, LevelManager level)
    {
        currentState = state;
        currentLevel = level;

        switch(currentState)
        {
            case GameState.OpeningCutscene:
                StartCutscene(); break;
            case GameState.LevelStart:
                 StartCutscene(); break;
            case GameState.LevelPlaying:
                 LevelPlaying(); break;
            case GameState.LevelEnd:
                BeatLevel(); break;
            case GameState.GameOver:
                GameOver(); break;
            case GameState.GameEnd:
                GameEnd(); break;
        }
    }

    private void StartCutscene()
    {
        Debug.Log("Cutscene Started");
        isInputActive = false;

        ChangeState(GameState.LevelStart, currentLevel);
    } 
    private void StartLevel()
    {
        Debug.Log("Level Started");
        isInputActive = true;

        currentLevel.StartLevel();
        ChangeState(GameState.LevelPlaying, currentLevel);
    }
    private void LevelPlaying()
    {
        Debug.Log("Level is playing sunshine");
    }

    private void BeatLevel()
    {
        Debug.Log("Level complete");

        //Go to next level
        ChangeState(GameState.LevelStart, levels[++currentLevelIndex]);
    }
    private void GameOver()
    {
        Debug.Log("Don't tell me you're clocking out already!?");
    }
    private void GameEnd()
    {
        Debug.Log("Don't miss me too much, sunshine...");
    }
    public enum GameState
    {
        OpeningCutscene,
        LevelStart,
        LevelPlaying,
        LevelEnd,
        GameOver,
        GameEnd
    }
}
