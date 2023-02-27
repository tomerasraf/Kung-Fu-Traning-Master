using System;
using UnityEngine;


public class PlayerInput : MonoBehaviour
{
    public static event Action RightTriggerAction;
    public static event Action LeftTriggerAction;
    public void LeftTrigger() 
    {
        RightTriggerAction?.Invoke();
    }
    public void RightTrigger() 
    {
        LeftTriggerAction?.Invoke();
    }
}
