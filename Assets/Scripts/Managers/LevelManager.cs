using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private bool isFinalLevel = false;
    public UnityEvent onLevelStart;
    public UnityEvent onLevelEnd;
   

    public void StartLevel()
    {
        onLevelStart?.Invoke();
    }

    public void EndLevel()
    {
        onLevelEnd?.Invoke();

        if (isFinalLevel == true)
        {
            GameManager.GetInstance().ChangeState(GameManager.GameState.GameEnd, this);
        }
        else
        {
            GameManager.GetInstance().ChangeState(GameManager.GameState.GameOver, this);
            //To Do: Let game manager know that the level state chould be changed to LevelEnd
        }
    }
}
