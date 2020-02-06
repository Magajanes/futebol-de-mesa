using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShootMode
{
    ForceSlider,
    ButtonHold
}

public class ShootController : MonoBehaviour
{
    [Header("Parameters")]
    [Range(0.25f, 1)]
    [SerializeField]
    private float increaseRate;
    [SerializeField]
    private float maxForce;
    public ShootMode ShootMode;

    [Header("References")]
    [SerializeField]
    private Button selectedButton;
    [SerializeField]
    private ForceSlider forceSlider;

    private bool buildingShot = false;
    private float currentForce;

    public delegate void ShotAction(Vector3 target);
    public ShotAction ExecuteShot;

    private void Awake()
    {
        InputController.OnButtonUp += StopForceIncrease;
    }

    private void Start()
    {
        forceSlider.SetMaxValue(maxForce);
        SetShootMode((int)ShootMode);
    }

    public void SetShootMode(int modeIndex)
    {
        var mode = (ShootMode)modeIndex;
        ShootMode = mode;

        switch (mode)
        {
            case ShootMode.ForceSlider:
                ExecuteShot = ShootWithSlider;
                forceSlider.Value = maxForce;
                break;

            case ShootMode.ButtonHold:
                ExecuteShot = ShootWithButtonHold;
                forceSlider.Value = 0;
                break;

            default:
                break;
        }
    }

    public void Select(Button button)
    {
        selectedButton = button;
    }

    public void ShootWithSlider(Vector3 target)
    {
        if (selectedButton == null)
            return;

        selectedButton.Shoot(ShootForce(target));
    }

    public void ShootWithButtonHold(Vector3 target)
    {
        if (selectedButton == null)
            return;

        buildingShot = true;
        currentForce = 0;

        StartCoroutine(ForceCoroutine(target));
    }

    public bool IsButtonSelected(Button button)
    {
        return button == selectedButton;
    }

    public void StopForceIncrease()
    {
        buildingShot = false;
    }

    private Vector3 ShootForce(Vector3 target)
    {
        var buttonPosition = selectedButton.transform.position;
        var direction = target - buttonPosition;
        return direction.normalized * forceSlider.Value;
    }

    private IEnumerator ForceCoroutine(Vector3 target)
    {
        while (buildingShot)
        {
            currentForce += increaseRate;
            forceSlider.Value = currentForce > maxForce ? maxForce : currentForce;
            yield return null;
        }

        selectedButton.Shoot(ShootForce(target));
        forceSlider.Value = 0;
    }
}