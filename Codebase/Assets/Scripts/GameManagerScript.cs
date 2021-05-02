using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript Instance { get; private set; }

    public int numberOfKnivesRemaining;
    public int totalNumberOfKnives;
    public GameState currentGameState = GameState.Playing;

    [SerializeField]
    private GameObject GameOverMenuObject;
    

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }

    }
    private void Start()
    {
        numberOfKnivesRemaining = totalNumberOfKnives;
    }

    public void ChangeGameState(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.GameOverVictory:
                GameOverMenuObject.SetActive(true);
                GameOverMenuObject.GetComponent<GameOverMenuScript>().ArrangeVictoryMenu();
                currentGameState = GameState.GameOverVictory;
                break;
            case GameState.GameOverDefeat:
                GameOverMenuObject.SetActive(true);
                GameOverMenuObject.GetComponent<GameOverMenuScript>().ArrangeDefeatMenu();
                currentGameState = GameState.GameOverDefeat;
                break;
            case GameState.Playing:
                //Not needed
                break;
            default:
                break;
        }
    }
}
