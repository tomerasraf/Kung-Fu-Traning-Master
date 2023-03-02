using UnityEngine;

public class RightHitCollider : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("FlyingObject"))
        {
            if (PlayerInput.Instance.IsHitRight)
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
