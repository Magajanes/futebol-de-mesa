using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField]
    private Rigidbody buttonRigidbody;

    public void Shoot(Vector3 shootForce)
    {
        buttonRigidbody.AddForce(shootForce, ForceMode.Impulse);
    }
}
