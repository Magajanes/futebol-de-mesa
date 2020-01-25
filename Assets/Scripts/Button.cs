using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private const float ANGLE_THRESHOLD = 45;

    private float collisionShift;
    private ShootController shootController;

    [Range(0, 0.02f)]
    [SerializeField]
    private float shiftAmount;
    [SerializeField]
    private Rigidbody buttonRigidbody;

    public bool IsSelected
    {
        get
        {
            return shootController.IsButtonSelected(this);
        }
    }

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
        if (!IsSelected)
            return;

        if (collision.gameObject.CompareTag("Button"))
        {
            var delta = collision.transform.position - transform.position;
            var buttonVelocity = buttonRigidbody.velocity;
            var alpha = Vector3.Dot(delta.normalized, buttonVelocity.normalized);
            var collisionSpeed = (1 - alpha) * buttonVelocity.magnitude;
            var angle = Vector3.Angle(buttonVelocity, delta);

            if (angle < ANGLE_THRESHOLD)
            {
                collisionShift = shiftAmount * angle * buttonVelocity.magnitude;
            }
            else
            {
                collisionShift = (shiftAmount / angle) * buttonVelocity.magnitude;
            }

            var shiftDirection = Vector3.Cross(Vector3.up, buttonVelocity.normalized);
            var reference = Mathf.Sign(-Vector3.Dot(delta, shiftDirection));

            var finalVelocity = (buttonVelocity.normalized * collisionSpeed)
                + reference * (shiftDirection * collisionShift);

            buttonRigidbody.velocity = finalVelocity;
        }
    }
}
