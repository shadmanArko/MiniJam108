using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Combat : MonoBehaviour
{
    private PlayerBoredomMeterModifier _playerBoredomMeterModifier;
    
    public UnityEvent onAttack;

    private EnemySpawner _enemySpawner;
    // Start is called before the first frame update
    void Awake()
    {
        _playerBoredomMeterModifier = GetComponent<PlayerBoredomMeterModifier>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnAttack();
        }
    }

    private void OnAttackEnemy(EnemySpawner enemySpawner)
    {
        _playerBoredomMeterModifier.DecreaseBoredom();
        enemySpawner.DestroyEnemy();
    }

    private void OnAttack()
    {
        onAttack.Invoke();

        if (_enemySpawner != null)
        {
            OnAttackEnemy(_enemySpawner);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
             _enemySpawner = other.GetComponentInParent<EnemySpawner>();
        }
    }
}
