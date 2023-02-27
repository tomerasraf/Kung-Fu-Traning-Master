using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    [SerializeField]
    Animator anim;
    [SerializeField]
    float _attackDelay = 1f;
    [SerializeField]
    float _smoothRotation = 5f;

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
        KeyboardInput();
        FaceDiraction();
    }

    private void FaceDiraction()
    {
        if (anim.GetBool("Left Trigger"))
        {
            FaceLeftDiraction();
        }
        else if (anim.GetBool("Right Trigger"))
        {
            FaceRightDiraction();
        }
        else
        {
            FaceForwardDiraction();
        }
    }

    private void KeyboardInput()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            RightTrigger();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            LeftTrigger();
        }
    }

    private void LeftTrigger()
    {
        StartCoroutine(AttackLeftDelay());
    }

    private void RightTrigger()
    {
        StartCoroutine(AttackRightDelay());
    }

    private void FaceLeftDiraction()
    {
        Quaternion LeftRotation = Quaternion.Euler(0, -90, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, LeftRotation, _smoothRotation * Time.deltaTime);
    }

    private void FaceRightDiraction()
    { 
        Quaternion RightRotation = Quaternion.Euler(0, 90, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, RightRotation, _smoothRotation * Time.deltaTime);
    }

    private void FaceForwardDiraction() 
    {
        Quaternion ForwardRotation = Quaternion.Euler(0, 0, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, ForwardRotation, _smoothRotation * Time.deltaTime);
    }

IEnumerator AttackLeftDelay()
    {
        anim.SetBool("Right Trigger", false);
        anim.SetBool("Left Trigger", true);
        yield return new WaitForSeconds(_attackDelay);
        anim.SetBool("Left Trigger", false);
    }

    IEnumerator AttackRightDelay()
    {
        anim.SetBool("Left Trigger", false);
        anim.SetBool("Right Trigger", true);
        yield return new WaitForSeconds(_attackDelay);
        anim.SetBool("Right Trigger", false);
    }


}
