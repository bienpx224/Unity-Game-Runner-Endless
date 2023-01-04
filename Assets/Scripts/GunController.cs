using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class GunController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Camera _camera;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.GameState == Constants.GameState.IS_READY)
        {
        }else if (GameManager.Instance.GameState == Constants.GameState.IS_PLAYING){
            
        }
    }
    void FixedUpdate() {

    }
}
