using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class PlayerController : Singleton<PlayerController>
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Camera _camera;
    
    private Constants.GameState _gameState = Constants.GameState.IS_READY;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        if(_camera == null){
            _camera = Camera.main;
        }
        _animator.SetBool(Constants.PlayerState.IS_IDLE.ToString(), true);
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameState == Constants.GameState.IS_READY)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _gameState = Constants.GameState.IS_PLAYING;
            }
        }else if (_gameState == Constants.GameState.IS_PLAYING){
            _animator.SetBool(Constants.PlayerState.IS_IDLE.ToString(), false);
            _animator.SetBool(Constants.PlayerState.IS_PLAYING.ToString(), true);
            transform.Translate(0,0,0.05f);
        }
    }
    void FixedUpdate() {

    }
}
