using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPunch : MonoBehaviour
{
    [SerializeField] private PlayerBoredomMeterModifier playerBoredomMeterModifier;
    private EnemySpawner _enemySpawner;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Got Enemy");
            _enemySpawner = other.GetComponentInParent<EnemySpawner>();
            _enemySpawner.DestroyEnemy();
            playerBoredomMeterModifier.DecreaseBoredom();
        }
    }
}
