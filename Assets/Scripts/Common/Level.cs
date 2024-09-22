using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint1, _spawnPoint2;
    [SerializeField] private float _minSpawnTime, _maxSpawnTime;

    private void Start()
    {
        StartCoroutine(IDelaySpawn());
    }

    private void SpawnRandomEnemy(Vector3 pos)
    {
        int rndNum = Random.Range(0, 6);

        if (rndNum == 0)
            EnemyFactory.Get(EnemyType.Enemy1, pos);
        else if (rndNum == 1)
            EnemyFactory.Get(EnemyType.Enemy2, pos);
        else if (rndNum == 2)
            EnemyFactory.Get(EnemyType.Enemy3, pos);
        else if (rndNum == 3)
            EnemyFactory.Get(EnemyType.Enemy4, pos);
        else if (rndNum == 4)
            EnemyFactory.Get(EnemyType.Enemy5, pos);
    }

    private IEnumerator IDelaySpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(_minSpawnTime, _maxSpawnTime));

            if (Random.Range(0, 2) >= 1)
                SpawnRandomEnemy(_spawnPoint1.position);
            else
                SpawnRandomEnemy(_spawnPoint2.position);
        }
    }
}
