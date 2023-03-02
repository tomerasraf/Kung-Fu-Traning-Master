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
                    ScoreAndCombo.instance.IncreaseCombo();
                    ScoreAndCombo.instance.AddScore(10);
                    UIManager.Instance.UpdateScore();
                    flyingObject.BrakeObject();
                    Destroy(flyingObject);
                }
            }
        }
    }
}
