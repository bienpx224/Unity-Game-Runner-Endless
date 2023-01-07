using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Lean.Pool;
using Hellmade.Sound;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour
{
    [Header("Info Group")]
    [SerializeField] private GameObject _infoGroup;
    [SerializeField] private TextMeshPro _healthText;
    [SerializeField] private FxTextHandler _prefabTextChange;

    [Header("Index")]
    [SerializeField] protected float _speed = 5f;
    [SerializeField] protected int _health = 5;
    [SerializeField] protected Animator _animator;
    private const int INIT_HEALTH = 5;
    void Start()
    {
        if (_animator == null)
        {
            _animator = GetComponent<Animator>();
        }
        SetHealth(_health);
    }
    void OnEnable()
    {

    }
    void OnDisable()
    {
        ResetToDefault();
    }
    public void Run(Transform targetTransform)
    {
        Debug.Log("targetTransform: " + targetTransform);
        transform.LookAt(targetTransform);
        _infoGroup.transform.LookAt(Camera.main.transform);
        GetComponent<Rigidbody>().velocity = Vector3.back * _speed;
    }
    public void OnCollisionEnter(Collision collision)
    {
        // Debug.Log("OnCollisionEnter : " + collision.gameObject.name);
        if (collision.gameObject.tag == "Player")
        {
            OnDead();
        }
        else if (collision.gameObject.tag == "Bullet")
        {
            OnGetHit();
        }else if(collision.gameObject.tag == "DeadWall")
        {
            OnDead(false);
        }
    }
    private void ResetToDefault()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        SetHealth(INIT_HEALTH);
    }
    public void SetHealth(int health){
        _health = health;
        _healthText.text = string.Format("{0}", health);
    }
    public void SetSpeed(float speed){
        _speed = speed;
    }

    private void OnGetHit()
    {
        Vector3 textChangePos = new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z + 1.5f);
        // Vector3 textChangePos = new Vector3(0, 1.5f, 1f);
        FxTextHandler textChange = LeanPool.Spawn(_prefabTextChange, textChangePos, gameObject.transform.rotation).GetComponent<FxTextHandler>();
        textChange.gameObject.transform.parent = gameObject.transform;
        textChange.gameObject.transform.localPosition = new Vector3(0f, 0.5f, 1.5f);
        textChange.SetText("-1", FxTextHandler.COLOR_TYPE.DECREASE);
        _animator.Play("Hit", 0, 0.2f);
        _health--;
        SetHealth(_health);
        if (_health <= 0)
        {
            OnDead();
        }
    }
    private void OnDead(bool isKilled = true)
    {
        /* Nếu enemy bị giết bởi Player hoặc do va chạm với Player chứ ko phải do đã chạy hết đường */
        if(isKilled == true){
            EazySoundManager.PlaySound(Sounds.Instance.Sfx_Collect_Coin);
        }
        
        EnemySpawner.Instance.RemoveEnemyInList(this);
        Destroy(gameObject);
    }
    private void OnTouchPlayer()
    {

    }
}
