using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonAiming : MonoBehaviour
{
    [SerializeField] private Transform _elevation;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _elevationSpeed;
    [SerializeField] private float _maxElevation;
    [SerializeField] private float _maxDepression;
    [SerializeField] [Range(0, 180)] private float _rotationArc;


    float _inputX = 0;
    float _inputY = 0;

    private void Update()
    {
        GetInput();
        Rotate();
        Elevate();
    }

    private void GetInput()
    {
        _inputX = Input.GetAxis("Horizontal");
        _inputY = Input.GetAxis("Vertical");
    }

    public void Rotate()
    {
        if (CanRotate())
        {
            transform.Rotate(Vector3.up, _inputX * Time.deltaTime * _rotationSpeed);
        }
    }

    private void Elevate()
    {
        if (CanElevateOrDepress())
        {
            _elevation.Rotate(Vector3.right, _inputY * Time.deltaTime * _elevationSpeed);
        }
    }

    private bool CanElevateOrDepress()
    {
        float correctedAngle = _elevation.localRotation.eulerAngles.x;

        if (correctedAngle > 180)
        {
            correctedAngle = -(360 - correctedAngle);
        }

        if (_inputY > 0)
        {
            return correctedAngle < _maxDepression;
        }
        else if (_inputY < 0)
        {
            return correctedAngle > _maxElevation * -1;
        }

        return false;
    }

    private bool CanRotate()
    {
        if (_rotationArc == 180f) return true;

        float correctedAngle = transform.localRotation.eulerAngles.y;

        if (correctedAngle > 180)
        {
            correctedAngle = -(360 - correctedAngle);
        }

        if (_inputX > 0)
        {
            return correctedAngle < (_rotationArc * 0.5f);
        }
        else if (_inputX < 0)
        {
            return correctedAngle > (_rotationArc * 0.5f * -1);
        }

        return false;
    }
}
