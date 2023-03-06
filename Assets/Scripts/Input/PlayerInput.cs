using System;
using System.Collections;
using UnityEngine;
using MoreMountains.Tools;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    float _canHitDuration = 0.3f;

    public static PlayerInput Instance { get; private set; }
    public bool IsHitLeft { get; private set; } = false;
    public bool IsHitRight { get; private set; } = false;

    public static event Action RightTriggerAction;
    public static event Action LeftTriggerAction;

    private void Awake()
    {
       Instance = this;
    }

    public void LeftTrigger()
    {
        StartCoroutine(HitLeftState());
        RightTriggerAction?.Invoke();
        MMSoundManager.Instance.PlaySound(SoundCollection.Instance.PlayerHitSounds[UnityEngine.Random.Range(0, SoundCollection.Instance.PlayerHitSounds.Length)], MMSoundManagerPlayOptions.Default);


    }
    public void RightTrigger()
    {
        StartCoroutine(HitRightState());
        LeftTriggerAction?.Invoke();
        MMSoundManager.Instance.PlaySound(SoundCollection.Instance.PlayerHitSounds[UnityEngine.Random.Range(0, SoundCollection.Instance.PlayerHitSounds.Length)], MMSoundManagerPlayOptions.Default);
    }

    IEnumerator HitLeftState()
    {
        IsHitLeft = true;
        yield return new WaitForSeconds(_canHitDuration);
        IsHitLeft = false;
    }
    IEnumerator HitRightState()
    {
        IsHitRight = true;
        yield return new WaitForSeconds(_canHitDuration);
        IsHitRight = false;
    }
}
