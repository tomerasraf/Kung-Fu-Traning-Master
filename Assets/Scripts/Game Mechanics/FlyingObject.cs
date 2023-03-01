using UnityEngine;

public class FlyingObject : MonoBehaviour
{
    [SerializeField]
    GameObject _flyingObject;
    [SerializeField]
    GameObject _brokenObject;
    [SerializeField]
    Rigidbody _rigidbody;
    [SerializeField]
    float _flyingForce;

    private void Start()
    {
        ThrowObject();
    }

    public void BrakeObject()
    {
        _flyingObject.SetActive(false);
        _brokenObject.SetActive(true);
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

    void ThrowObject()
    {
        _rigidbody.AddForce(new Vector3(0, 1,-1) * _flyingForce, ForceMode.Impulse);
        _rigidbody.AddTorque(new Vector3(1, 1, 1) * _flyingForce, ForceMode.Impulse);
    }
}
