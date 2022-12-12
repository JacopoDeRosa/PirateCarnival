using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetRail : MonoBehaviour
{
    [SerializeField] private Target[] _targetPrefabs;

    [SerializeField] private Transform _leftSpawnPoint;
    [SerializeField] private Transform _rightSpawnPoint;

    [SerializeField] private float _minSpeed;
    [SerializeField] private float _maxSpeed;

    private Target _activeTarget;
    private float _currentSpeed;


    private void Update()
    {
        if(_activeTarget == null)
        {
            _activeTarget = SpawnNewTarget();
            SetRandomSpeed();
        }
        else
        {

        }
    }

    private void SetRandomSpeed()
    {
        _currentSpeed = Random.Range(_minSpeed, _maxSpeed);
    }

    private Target SpawnNewTarget()
    {
        Transform point = GetRandomSpawnPoint();
        Target target = GetRandomTarget();

        return Instantiate(target, point.position, point.rotation);
    }

    private Target GetRandomTarget()
    {
        return _targetPrefabs[Random.Range(0, _targetPrefabs.Length)];
    }

    private Transform GetRandomSpawnPoint()
    {
        return Random.Range(0, 100) > 50 ? _leftSpawnPoint : _rightSpawnPoint;
    }
}
