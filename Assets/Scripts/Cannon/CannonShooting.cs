using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShooting : MonoBehaviour
{
    [SerializeField] private CannonBall _cannonBallPrefab;
    [SerializeField] private Vector3 _maxShootingForce;
    [SerializeField] private Vector3 _minShootingForce;


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) StartCharging();
        if (Input.GetKeyUp(KeyCode.Space)) StopCharging();
    }

    private void StartCharging()
    {

    }

    private void StopCharging()
    {

    }
}
