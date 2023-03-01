using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHitCollider : MonoBehaviour
{
    private bool _canHit = false;

    private void Update()
    {
        if (_canHit & PlayerInput.Instance.IsHitRight)
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
            print("Right Hit");
            _canHit = true;
        }
        
        if(other == null)
        {
            _canHit = false;
        }
    }
}
