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
        if (GameManager.instance.isGameOver)
            return;

        if (collision.gameObject.CompareTag("Floor"))
        {
            ScoreAndCombo.ResetCombo();
            GameManager.instance.DecreaseChances();
            Destroy(this);
        }
    }

    public void BrakeObject()
    {
        _flyingObject.SetActive(false);
        _brokenObject.SetActive(true);

        _rigidbody.AddExplosionForce(10, transform.position, 2, 1, ForceMode.Impulse);

        Destroy(gameObject, 3f);
    }

    void ThrowObject()
    {
        _rigidbody.AddForce(new Vector3(0, 1 * 4 , -1 * 8) , ForceMode.Impulse);
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
