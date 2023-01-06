using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;

[RequireComponent(typeof(Rigidbody))]
public class BulletBase : MonoBehaviour
{
    [SerializeField] protected float _speed = 10f;
    [SerializeField] protected int _damage = 5;
    [SerializeField] protected Transform _direction;
    [SerializeField] protected GameObject _prefabFxHit;
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
        /* Spawn Effect when bullet colide */
        var hitFx = LeanPool.Spawn(_prefabFxHit, gameObject.transform.position, Quaternion.identity);
        hitFx.transform.LookAt(Camera.main.transform);
        Destroy(gameObject);
        
    }
}
