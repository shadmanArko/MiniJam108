using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float walkPointRange;
    [SerializeField] private float sightRange;
    [SerializeField] private LayerMask playerLm;
    [SerializeField] private LayerMask groundLm;
    
    private Transform _player;
    private Vector3 _walkStartingPoint;
    private bool _walkPointSet;
    private bool _playerInSightRange;
    private NavMeshAgent _agent;

    private void Awake()
    {
        _player = GameObject.Find("Player").transform;
        _agent = GetComponent<NavMeshAgent>();
    }
    
    // Update is called once per frame
    void Update()
    {
        _playerInSightRange = Physics.CheckSphere(transform.position, sightRange, playerLm);
        
        if (!_playerInSightRange) Patroling();
        if (_playerInSightRange) ChasePlayer();
    }
    
    private void Patroling()
    {
        if (!_walkPointSet) SearchWalkPoint();

        if (_walkPointSet)
            _agent.SetDestination(_walkStartingPoint);

        Vector3 distanceToWalkPoint = transform.position - _walkStartingPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            _walkPointSet = false;
    }
    
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        Vector3 position = transform.position;
        _walkStartingPoint = new Vector3(position.x + randomX, position.y, position.z + randomZ);

        if (Physics.Raycast(_walkStartingPoint, -transform.up, 2f, groundLm))
            _walkPointSet = true;
    }
    
    private void ChasePlayer()
    {
        _agent.SetDestination(_player.position);
    }
}
