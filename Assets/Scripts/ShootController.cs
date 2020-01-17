using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField]
    private float maxForce;

    [Header("References")]
    [SerializeField]
    private Button selectedButton;
    [SerializeField]
    private ForceSlider forceSlider;

    private void Start()
    {
        forceSlider.Initialize(maxForce);
    }

    public void Select(Button button)
    {
        selectedButton = button;
    }

    public void ExecuteShot(Vector3 target)
    {
        if (selectedButton == null)
            return;

        var buttonPosition = selectedButton.transform.position;
        var direction = target - buttonPosition;
        var shootForce = direction.normalized * forceSlider.Value;

        selectedButton.Shoot(shootForce);
    }
}