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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            BrakeObject();
            GameManager.instance.DecreaseChances();
            Destroy(this);
        }
    }

    public void BrakeObject()
    {
        _flyingObject.SetActive(false);
        _brokenObject.SetActive(true);

        Destroy(gameObject, 3f);
    }

    void ThrowObject()
    {
        _rigidbody.AddForce(new Vector3(0, 1, -1) * _flyingForce, ForceMode.Impulse);
        _rigidbody.AddTorque(new Vector3(1, 1, 1) * _flyingForce, ForceMode.Impulse);
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
