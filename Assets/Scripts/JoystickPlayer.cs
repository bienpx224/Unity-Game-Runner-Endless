using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class JoystickPlayer : MonoBehaviour
{
    public float speed;
    public VariableJoystick variableJoystick;
    public Rigidbody rb;
    [SerializeField] private Animator _animator;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (GameManager.Instance.GameState == Constants.GameState.IS_PLAYING)
        {
            /* Bienpx: Movement */
            Vector3 m_Input = new Vector3(variableJoystick.Horizontal, 0, 0);
            rb.MovePosition(transform.position + m_Input * Time.deltaTime * speed);

            /* Animation */
            _animator.SetFloat("velocityX", variableJoystick.Horizontal);
            _animator.SetFloat("velocityZ", variableJoystick.Vertical);
        }

    }
    public void FixedUpdate()
    {
        // Default script
        // Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        // rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);


    }
}