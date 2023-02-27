using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    [SerializeField]
    Animator anim;
    [SerializeField]
    float _smoothRotation = 5f;
    [SerializeField]
    float _smoothTransition = 5f;

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

    private void Update()
    {
        TransitionAnimation();
        ReturnIdleState();
    }

    private void TransitionAnimation()
    {
        if (anim.GetFloat("Movement") > 0)
        {
            // rotate the player smoothly to the left by 90 degrees
            TurnPlayer(90);
        }
        else if (anim.GetFloat("Movement") < 0)
        {
            TurnPlayer(-90);
        }
        else
        {
            TurnPlayer(0);
        } 
    }

    private void TurnPlayer(float angle)
    {
        Quaternion Turn = Quaternion.Euler(0, angle, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, Turn, _smoothRotation * Time.deltaTime);
    }

    private void ReturnIdleState()
    {
        if (anim.GetFloat("Movement") > 0.1f)
        {
            anim.SetFloat("Movement", 0, _smoothTransition, Time.deltaTime);
        }
        else if (anim.GetFloat("Movement") < -0.1f)
        {
            anim.SetFloat("Movement", 0, _smoothTransition, Time.deltaTime);
        }
        else
        {
            anim.SetFloat("Movement", 0);
        }
    }

    private void LeftTrigger()
    {
        anim.SetFloat("Movement", -1);
    }

    private void RightTrigger()
    {
        anim.SetFloat("Movement", 1);
    }
}
