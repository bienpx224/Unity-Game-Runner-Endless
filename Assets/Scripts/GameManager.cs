using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameObject _groupPressStartGame;
    private Constants.GameState _gameState;
    public Constants.GameState GameState
    {
        get { return _gameState; }
        set { _gameState = value; }
    }
    void Awake()
    {
        /* Cần phải base.Awake để thực thi function cha */
        base.Awake();
        GameState = Constants.GameState.IS_READY;
    }
    void Start()
    {
        GameState = Constants.GameState.IS_READY;
    }
    void Update()
    {
        if (GameState == Constants.GameState.IS_READY)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameManager.Instance.GameState = Constants.GameState.IS_PLAYING;
            }
        }else if(GameState == Constants.GameState.IS_PLAYING){
            if (Input.GetKeyDown(KeyCode.Return))
            {
                OnRestartGame();
            }
        }
    }
    public void OnPressStartGame()
    {
        GameState = Constants.GameState.IS_PLAYING;
        _groupPressStartGame.SetActive(false);
    }
    public void OnRestartGame()
    {
        GameState = Constants.GameState.IS_READY;
        _groupPressStartGame.SetActive(true);
        
    }
    public void OnDead(){
        OnRestartGame();
    }
    public void OnWin(){

    }

}