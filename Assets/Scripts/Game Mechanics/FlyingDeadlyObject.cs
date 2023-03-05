using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingDeadlyObject : MonoBehaviour
{
    [SerializeField]
    Rigidbody _flyingObjectRB;

    private void Start()
    {
        _flyingObjectRB.rotation = Quaternion.Euler(-90, 180, 0);
        ThrowObject();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (GameManager.instance.isGameOver)
            return;

        if (collision.gameObject.CompareTag("Floor"))
        {
            ScoreAndCombo.instance.IncreaseCombo();
            UIManager.Instance.UpdateCombo(collision.transform);
            ScoreAndCombo.instance.AddScore(10);
            UIManager.Instance.UpdateScore();
            Destroy(this);
        }
    }

    void ThrowObject()
    {
        _flyingObjectRB.AddForce(new Vector3(0, 1 * 4, -1 * 8), ForceMode.Impulse);

        // Random torque to make the object spin
        _flyingObjectRB.AddTorque(new Vector3(0, Random.Range(-10, 10) * 1000, 0 ), ForceMode.Impulse);
    }
}
