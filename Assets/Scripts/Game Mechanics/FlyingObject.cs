using UnityEngine;
using MoreMountains.Feedbacks;

public class FlyingObject : MonoBehaviour
{
    [SerializeField]
    GameObject _flyingObject;
    [SerializeField]
    GameObject _brokenObject;
    [SerializeField]
    Rigidbody _flyingObjectRB;
    [SerializeField]
    float _flyingForce;
    [SerializeField]
    MMF_Player _playerFeedbacks;

    private void Start()
    {
        ThrowObject();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (GameManager.instance.isGameOver)
            return;

        if (collision.gameObject.CompareTag("Floor"))
        {
            ScoreAndCombo.instance.ResetCombo();
            GameManager.instance.DecreaseChances();
            Destroy(this);
        }
    }

    public void BrakeObject()
    {
        _playerFeedbacks.PlayFeedbacks();
        _flyingObject.SetActive(false);
        _brokenObject.SetActive(true);
        
        Destroy(gameObject, 3f);
    }

    void ThrowObject()
    {
        _flyingObjectRB.AddForce(new Vector3(0, 1 * 4 , -1 * 8) , ForceMode.Impulse);

        // Random torque to make the object spin
        _flyingObjectRB.AddTorque(new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)) * 7, ForceMode.Impulse);

    }

    // player Hands Hit Virsion
    /*   private void OnTriggerEnter(Collider other)
       {
           if (other.gameObject.CompareTag("Player"))
           {
               _flyingObject.SetActive(false);
               _brokenObject.SetActive(true);
           }
       }*/

}
