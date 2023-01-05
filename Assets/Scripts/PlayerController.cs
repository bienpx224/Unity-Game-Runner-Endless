using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class PlayerController : Singleton<PlayerController>
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Camera _camera;
    [Header("Rotation Character")]

    private Constants.GameState _oldGameState;

    public Vector3 START_POSITION_CAMERA ;


    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetBool(Constants.PlayerState.IS_IDLE.ToString(), true);
        if (_camera == null)
        {
            _camera = Camera.main;
        }

        START_POSITION_CAMERA = new Vector3(0.600000024f,3.93000007f,-22.3099995f);
    }

    // Update is called once per frame
    void Update()
    {

        if (GameManager.Instance.GameState == Constants.GameState.IS_READY)
        {
            SetupCharacterReady();
        }
        else if (GameManager.Instance.GameState == Constants.GameState.IS_PLAYING)
        {
            SetupCharacterStartPlay();
            
        }
        else if (GameManager.Instance.GameState == Constants.GameState.IS_ENDED)
        {
            SetupCharacterReady();
        }

        _oldGameState = GameManager.Instance.GameState;
    }
    private void SetupCharacterStartPlay(){
        
        /* Nếu muốn chỉ gọi 1 lần với những hàm ko cần chạy đi chạy lại trong Update */
        if (_oldGameState == GameManager.Instance.GameState)
        {
            return;
        }
        /* Thì ta viết các actions đó ở dưới này. */
        
        _animator.SetBool(Constants.PlayerState.IS_IDLE.ToString(), false);
        _animator.SetBool(Constants.PlayerState.IS_PLAYING.ToString(), true);
    }
    private void SetupCharacterReady()
    {
        /* Nếu muốn chỉ gọi 1 lần với những hàm ko cần chạy đi chạy lại trong Update */
        if (_oldGameState == GameManager.Instance.GameState)
        {
            return;
        }
        /* Thì ta viết các actions đó ở dưới này. */
        _animator.SetBool(Constants.PlayerState.IS_IDLE.ToString(), true);
        _animator.SetBool(Constants.PlayerState.IS_PLAYING.ToString(), false);
    }
}
