using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private int respawnTime = 3;
    
    private Vector3 _startPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        _startPosition = enemyPrefab.gameObject.transform.position;
    }
    
    public void DestroyEnemy()
    {
        enemyPrefab.gameObject.SetActive(false);
        respawnTime++;
        Invoke(nameof(RespawnEnemy), respawnTime);
    }

    private void RespawnEnemy()
    {
        enemyPrefab.gameObject.transform.position = _startPosition;
        enemyPrefab.gameObject.SetActive(true);
    }
}
