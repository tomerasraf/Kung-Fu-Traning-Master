using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenObjects : MonoBehaviour
{
    [SerializeField]
    Rigidbody[] brokenPieces;

    private void Start()
    {
        foreach (var piece in brokenPieces)
        {
            piece.AddForce(0, 0, -1 * 6, ForceMode.Impulse);
        }
    }
}
