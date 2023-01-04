using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class PlayerController : Singleton<PlayerController>
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Camera _camera;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetBool(Constants.PlayerState.IS_IDLE.ToString(), true);
        if (_camera == null)
        {
            _camera = Camera.main;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.GameState == Constants.GameState.IS_READY)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameManager.Instance.GameState = Constants.GameState.IS_PLAYING;
            }
        }
        else if (GameManager.Instance.GameState == Constants.GameState.IS_PLAYING)
        {
            _animator.SetBool(Constants.PlayerState.IS_IDLE.ToString(), false);
            _animator.SetBool(Constants.PlayerState.IS_PLAYING.ToString(), true);
        }
    }
    void FixedUpdate()
    {

    }
}
