using UnityEngine;

public class LeftHitCollider : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("FlyingObject"))
        {
            print("Left Hit");

            if (PlayerInput.Instance.IsHitLeft)
            {
                if (other.TryGetComponent(out FlyingObject flyingObject))
                {
                    GameManager.instance.ResetChances();
                    ScoreAndCombo.IncreaseCombo();
                    ScoreAndCombo.AddScore(10);
                    flyingObject.BrakeObject();
                    Destroy(flyingObject);
                }
            }
        }
    }
}
