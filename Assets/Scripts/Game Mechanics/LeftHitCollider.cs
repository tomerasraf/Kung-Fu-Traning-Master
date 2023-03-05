using UnityEngine;

public class LeftHitCollider : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        FlyingObject(other);
        FlyingDeadlyObject(other);
    }

    private static void FlyingDeadlyObject(Collider other)
    {
        if (other.CompareTag("FlyingDeadlyObject"))
        {
            if (PlayerInput.Instance.IsHitLeft)
            {
                if (other.TryGetComponent(out FlyingDeadlyObject flyingDeadlyObject))
                {
                    GameManager.instance.DecreaseChances();
                    ScoreAndCombo.instance.ResetCombo();
                    Destroy(flyingDeadlyObject);
                }
            }
        }
    }

    private static void FlyingObject(Collider other)
    {
        if (other.CompareTag("FlyingObject"))
        {
            if (PlayerInput.Instance.IsHitLeft)
            {
                if (other.TryGetComponent(out FlyingObject flyingObject))
                {
                    GameManager.instance.ResetChances();
                    ScoreAndCombo.instance.IncreaseCombo();
                    UIManager.Instance.UpdateCombo(flyingObject.transform);
                    ScoreAndCombo.instance.AddScore(5);
                    UIManager.Instance.UpdateScore();
                    flyingObject.BrakeObject();
                    Destroy(flyingObject);
                }
            }
        }
    }
}
