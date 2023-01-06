using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;

public class BulletSpawner :  Singleton<EnenySpawner>
{
    [SerializeField] private BulletBase _prefabBullet;
    [SerializeField] private Transform _bulletSpawnPoint;
    [SerializeField] private float _spawnTime = 3f;
    private List<BulletBase> _listSpawning;
    float _nextSpawnTime;
    /* Arrow Function: Viet tat cua function */
    bool ReadyToSpawn() => Time.time >= _nextSpawnTime;

    // Start is called before the first frame update
    void Start()
    {
        _listSpawning = new List<BulletBase>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.GameState == Constants.GameState.IS_READY)
        {

        }
        else if (GameManager.Instance.GameState == Constants.GameState.IS_PLAYING)
        {
            if (ReadyToSpawn()){
                StartCoroutine(SpawnBullet());
            }
                
        }
    }
    IEnumerator SpawnBullet()
    {
        _nextSpawnTime = Time.time + _spawnTime;
        BulletBase bullet = LeanPool.Spawn(_prefabBullet, _bulletSpawnPoint.position, Quaternion.identity).GetComponent<BulletBase>();
        /* Add bullet đã spawn ra vào list. Nhưng chưa cần dùng đến nên comment lại */
        // _listSpawning.Add(bullet);  
        bullet.SetupData(_bulletSpawnPoint);
        bullet.Fire();
        yield return null;
    }

}
