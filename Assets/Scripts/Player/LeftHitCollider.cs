using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftHitCollider : MonoBehaviour
{
    private bool _canHit = false;

    private void Update()
    {
        if (_canHit & PlayerInput.Instance.IsHitLeft)
        {
            if (TryGetComponent(out FlyingObject flyingObject))
            {
                flyingObject.BrakeObject();
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("FlyingObject"))
        {
            print("Left Hit");
            _canHit = true;
        }
        else
        {
            _canHit = false;
        }
    }
}
