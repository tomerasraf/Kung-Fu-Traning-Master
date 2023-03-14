using System.Collections;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    public static PlayerAnim Instance;

    [SerializeField]
    Animator _anim;
    [SerializeField]
    float _attackDuration = 0.5f;
    [SerializeField]
    GameObject playerSkin;
    [SerializeField]
    GameObject playerBlindFold;
    [SerializeField]
    GameObject playerRagdoll;
    [SerializeField]
    Rigidbody ragdollRb;

    private float torqueForce = 5000f;

    private void Awake()
    {
        Instance = this;
    }

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

    public void PlayerExplode(Vector3 force)
    {
        _anim.enabled = false;
        playerSkin.SetActive(false);
        playerBlindFold.SetActive(false);
        playerRagdoll.SetActive(true);

        ragdollRb.AddForce(force, ForceMode.VelocityChange);

        ragdollRb.AddTorque(new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)) * torqueForce, ForceMode.Acceleration);
    }
    private void LeftTrigger()
    {
        StartCoroutine(TriggerAttackAnim("Left Trigger", "Right Trigger"));
    }

    private void RightTrigger()
    {
        StartCoroutine(TriggerAttackAnim("Right Trigger", "Left Trigger"));
    }

    IEnumerator TriggerAttackAnim(string triggerEnable, string triggerDisable)
    {
        _anim.SetBool(triggerDisable, false);
        _anim.SetBool(triggerEnable, true);
        yield return new WaitForSeconds(_attackDuration);
        _anim.SetBool(triggerEnable, false);
    }
}
