using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState gameState;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        ChangeState(GameState.GeneratedGrid);
    }

    public void ChangeState(GameState newState)
    {
        gameState = newState;
        switch(newState)
        {
            case GameState.GeneratedGrid:
                GridManager.Instance.GenerateGrid();
                break;
            case GameState.SpawnEnemies:
                UnitsManager.Instance.SpawnEnemies();
                break;
            case GameState.SpawnHeroes:
                UnitsManager.Instance.SpawnHeroes();
                break;
            case GameState.Fight:
                break;
        }
    }
}

public enum GameState
{
    GeneratedGrid = 0,
    SpawnEnemies = 1,
    SpawnHeroes = 2,
    Fight = 3
}
