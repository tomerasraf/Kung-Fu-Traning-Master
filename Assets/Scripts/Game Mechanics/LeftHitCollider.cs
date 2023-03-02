using UnityEngine;

public class LeftHitCollider : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
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
