using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;

public class EnenySpawner : Singleton<EnenySpawner>
{
    [SerializeField] private Enemy _prefabEnemy;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _spawnTime = 5f;
    [SerializeField] private int _spawnLimit = 10;
    public List<Enemy> _listSpawning;
    float _nextSpawnTime;
    /* Arrow Function: Viet tat cua function */
    bool ReadyToSpawn() => Time.time >= _nextSpawnTime;

    /* Delegate để biết được các enemy nào bị chết thì call event */


    // Start is called before the first frame update
    void Start()
    {
        _listSpawning = new List<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.GameState == Constants.GameState.IS_READY)
        {

        }
        else if (GameManager.Instance.GameState == Constants.GameState.IS_PLAYING)
        {
            if (ReadyToSpawn() && _listSpawning.Count < _spawnLimit){
                StartCoroutine(SpawnEnemy());
            }
                
        }
    }
    IEnumerator SpawnEnemy()
    {
        _nextSpawnTime = Time.time + _spawnTime;

        Vector3 enemyPosition = new Vector3(Random.Range(-0.5f, 1.5f), _spawnPoint.position.y, _spawnPoint.position.z);
        
        Enemy enemy = LeanPool.Spawn(_prefabEnemy, enemyPosition, Quaternion.identity).GetComponent<Enemy>();
        _listSpawning.Add(enemy);
        enemy.Run(PlayerController.Instance.gameObject.transform);
        yield return null;
    }
    /* FUnction Remove in list when a enemy dead */
    public void RemoveEnemyInList(Enemy enemy){
        _listSpawning.Remove(enemy);
    }

}
