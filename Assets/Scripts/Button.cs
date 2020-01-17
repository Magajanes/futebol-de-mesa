using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private ShootController shootController;

    [SerializeField]
    private Rigidbody buttonRigidbody;

    public void InjectDependencies(ShootController shootController)
    {
        this.shootController = shootController;
    }

    public void Shoot(Vector3 shootForce)
    {
        buttonRigidbody.AddForce(shootForce, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Button"))
        {

        }
    }
}
