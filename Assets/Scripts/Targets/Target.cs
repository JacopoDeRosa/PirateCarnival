using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Target : MonoBehaviour
{
    [SerializeField] private bool _dieOnHit;

    public UnityEvent onHit;

    public void Hit()
    {
        onHit.Invoke();

        if(_dieOnHit)
        {
            Destroy(gameObject);
        }
    }
}
