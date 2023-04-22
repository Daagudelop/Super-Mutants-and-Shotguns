using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState //Estados del juego
{
    YourTurn,
    EnemyTurn,
}

public class GameManager : MonoBehaviour
{

    public GameState currentGameState = GameState.YourTurn;//Estado inicial del juego
    public static GameManager sharedInstanceGameManager;//Instancia unica generada por singleton.


    //********************************
    //  Unity methods
    private void Awake()
    {
        initializeSingleton();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    //********************************

    private void initializeSingleton()
    {
        if (sharedInstanceGameManager == null)
        {
            sharedInstanceGameManager = this;
        }
    }

    
    private void SetGameState(GameState newGameState)//Este metodo cambiara el estado del juego.
    {
        if (newGameState == GameState.YourTurn)
        {
            //TODO: logica de que pasa en tu turno
        }
        else if (newGameState == GameState.EnemyTurn)
        {
            //TODO: logica de que pasa en el turno enemigo
        }
        this.currentGameState = newGameState;
    }

}
