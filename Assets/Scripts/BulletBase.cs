using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletBase : MonoBehaviour
{
    [SerializeField] protected float _speed = 10f;
    [SerializeField] protected int _damage = 5;
    [SerializeField] protected Transform _direction;
    void Start(){
    }
    public void SetupData(Transform direction){
        _direction = direction;
    }
    public void Fire(){
        GetComponent<Rigidbody>().velocity = _direction.forward * _speed;
    }
    public void OnCollisionEnter(Collision collision){
        // Debug.Log("OnCollisionEnter : " + collision.gameObject.name);
        Destroy(gameObject);
        
    }
}
