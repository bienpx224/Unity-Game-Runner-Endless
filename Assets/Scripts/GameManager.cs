using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameObject _groupPressStartGame;
    private Constants.GameState _gameState;
    public Constants.GameState GameState { 
        get { return _gameState; } 
        set { _gameState = value; } }
    void Awake()
    {
        /* Cần phải base.Awake để thực thi function cha */
        base.Awake();
        GameState = Constants.GameState.IS_READY;
    }
    void Start()
    {

    }
    public void OnPressStartGame(){
        GameState = Constants.GameState.IS_PLAYING;
        _groupPressStartGame.SetActive(false);
    }
    public void OnRestartGame(){
        GameState = Constants.GameState.IS_READY;
        _groupPressStartGame.SetActive(true);
    }

}