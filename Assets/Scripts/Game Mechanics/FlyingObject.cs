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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _flyingObject.SetActive(false);
            _brokenObject.SetActive(true);
        }
    }

    void ThrowObject()
    {
        _rigidbody.AddForce(new Vector3(0, 1,-1) * _flyingForce, ForceMode.Impulse);
    }
}
