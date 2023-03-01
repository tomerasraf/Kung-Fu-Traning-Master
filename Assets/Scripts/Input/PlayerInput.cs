using System;
using UnityEngine;
using System.Collections;

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
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LeftTrigger()
    {
        StartCoroutine(HitLeftState());
        RightTriggerAction?.Invoke();
    }
    public void RightTrigger()
    {
        StartCoroutine(HitRightState());
        LeftTriggerAction?.Invoke();
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
