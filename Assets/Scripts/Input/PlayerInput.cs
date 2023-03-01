using System;
using UnityEngine;


public class PlayerInput : MonoBehaviour
{
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
        IsHitLeft = true;
        RightTriggerAction?.Invoke();
        Invoke("HitLeftState", 0.1f);

    }
    public void RightTrigger()
    {
        IsHitRight = true;
        LeftTriggerAction?.Invoke();
        Invoke("HitRightState", 0.1f);
    }

    private void HitRightState()
    {
        IsHitRight = !IsHitRight;
    }
    private void HitLeftState()
    {
        IsHitLeft = !IsHitLeft;
    }

    
}
