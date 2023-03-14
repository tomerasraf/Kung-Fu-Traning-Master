using MoreMountains.Tools;
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
                    flyingDeadlyObject.Explode();
                    PlayerAnim.Instance.PlayerExplode(new Vector3(-1 * 10f, 1 * 35f, 0));
                    GameManager.instance.InstantDeath();
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
                    MMSoundManagerPlayOptions options;
                    options = MMSoundManagerPlayOptions.Default;

                    if (flyingObject.name.StartsWith("rice"))
                    {
                        MMSoundManager.Instance.PlaySound(SoundCollection.Instance.BreakBowlSounds[Random.Range(0, SoundCollection.Instance.BreakBowlSounds.Length)], options);
                    }

                    if (flyingObject.name.StartsWith("Wood") || flyingObject.name.StartsWith("Bamboo") || flyingObject.name.StartsWith("Smal"))
                    {
                        MMSoundManager.Instance.PlaySound(SoundCollection.Instance.BreakWoodSounds[Random.Range(0, SoundCollection.Instance.BreakWoodSounds.Length)], options);
                    }

                    if (flyingObject.name.StartsWith("Water") || flyingObject.name.StartsWith("Teapot") || flyingObject.name.StartsWith("Bottle_1") || flyingObject.name.StartsWith("Bottle_2"))
                    {
                        MMSoundManager.Instance.PlaySound(SoundCollection.Instance.BreakGlassSounds[Random.Range(0, SoundCollection.Instance.BreakGlassSounds.Length)], options);
                    }

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
