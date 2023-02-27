using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    [SerializeField]
    Animator _anim;
    [SerializeField]
    float _attackDuration = 0.5f;

    private bool isResettingMovement;
    private void OnEnable()
    {
        PlayerInput.RightTriggerAction += RightTrigger;
        PlayerInput.LeftTriggerAction += LeftTrigger;
    }

    private void OnDisable()
    {
        PlayerInput.RightTriggerAction -= RightTrigger;
        PlayerInput.LeftTriggerAction -= LeftTrigger;
    }

    private void LeftTrigger()
    {
        StartCoroutine(Trigger("Left Trigger", "Right Trigger"));
    }

    private void RightTrigger()
    {
        StartCoroutine(Trigger("Right Trigger", "Left Trigger"));
    }

    IEnumerator Trigger(string triggerEnable, string triggerDisable)
    {
        _anim.SetBool(triggerDisable, false);
        _anim.SetBool(triggerEnable, true);
        yield return new WaitForSeconds(_attackDuration);
        _anim.SetBool(triggerEnable, false);
    }
}
