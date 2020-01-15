using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootController : MonoBehaviour
{
    [SerializeField]
    private Button selectedButton;

    [SerializeField]
    private Slider forceSlider;

    public void SetButton(Button button)
    {
        selectedButton = button;
    }

    public void ExecuteShot(Vector3 target)
    {
        var buttonPosition = selectedButton.transform.position;
        var direction = target - buttonPosition;
        var shootForce = direction.normalized * forceSlider.value;

        selectedButton.Shoot(shootForce);
    }
}