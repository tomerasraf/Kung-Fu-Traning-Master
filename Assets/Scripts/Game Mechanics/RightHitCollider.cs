using UnityEngine;
using MoreMountains.Tools;

public class RightHitCollider : MonoBehaviour
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
            if (PlayerInput.Instance.IsHitRight)
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
            if (PlayerInput.Instance.IsHitRight)
            {
                if (other.TryGetComponent(out FlyingObject flyingObject))
                {
                    MMSoundManagerPlayOptions options;
                    options = MMSoundManagerPlayOptions.Default;

                    if (flyingObject.name.StartsWith("rice"))
                    {
                        MMSoundManager.Instance.PlaySound(SoundCollection.Instance.BreakSounds[Mathf.RoundToInt(Random.Range(0, 2))], options);
                    }

                    if (flyingObject.name.StartsWith("Wood") || flyingObject.name.StartsWith("Bamboo") || flyingObject.name.StartsWith("Smal"))
                    {
                        MMSoundManager.Instance.PlaySound(SoundCollection.Instance.BreakSounds[Mathf.RoundToInt(Random.Range(2, 4))], options);
                    }

                    if (flyingObject.name.StartsWith("Water") || flyingObject.name.StartsWith("Teapot"))
                    {
                        MMSoundManager.Instance.PlaySound(SoundCollection.Instance.BreakSounds[Mathf.RoundToInt(Random.Range(4, 6))], options);
                    }

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
