using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHitCollider : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("FlyingObject"))
        {
            print("Right Hit");
     
            if (PlayerInput.Instance.IsHitRight)
            {
                if (other.TryGetComponent(out FlyingObject flyingObject))
                {
                    flyingObject.BrakeObject();
                }
            }
        }
    }
}
