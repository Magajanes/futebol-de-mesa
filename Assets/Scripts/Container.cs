using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    [SerializeField]
    private InputController inputController;
    [SerializeField]
    private ShootController shootController;

    private void Awake()
    {
        inputController.Initialize(shootController);
    }
}
