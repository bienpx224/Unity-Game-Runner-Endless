using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour
{
    [SerializeField] protected float _speed = 5f;
    [SerializeField] protected int _health = 5;
    [SerializeField] protected Animator _animator;
    private const int INIT_HEALTH = 5;
    void Start(){
        if(_animator == null){ 
            _animator = GetComponent<Animator>();
        }
    }
    void OnEnable() {

    }
    void OnDisable() {
        ResetToDefault();
    }
    public void Run(Transform targetTransform){
        Debug.Log("targetTransform: " + targetTransform);
        transform.LookAt(targetTransform);
        GetComponent<Rigidbody>().velocity = Vector3.back * _speed;
    }
    public void OnCollisionEnter(Collision collision){
        // Debug.Log("OnCollisionEnter : " + collision.gameObject.name);
        if(collision.gameObject.tag == "Player"){
            OnDead();
        }else if(collision.gameObject.tag == "Bullet"){
            _animator.Play("Hit", 0, 0);
            _health --;
            if(_health <= 0){
                OnDead();
            }
        }
    }
    private void ResetToDefault(){
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        _health = INIT_HEALTH;
    }
    private void OnDead(){
            EnenySpawner.Instance.RemoveEnemyInList(this);
            Destroy(gameObject);
    }
    private void OnTouchPlayer(){

    }
}
