using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    [SerializeField]
    private InputController inputController;
    [SerializeField]
    private ShootController shootController;
    [SerializeField]
    private OptionsController optionsController;
    [SerializeField]
    private List<Button> buttons = new List<Button>();

    private void Awake()
    {
        inputController.InjectDependencies(shootController);

        foreach (var button in buttons)
        {
            button.InjectDependencies(shootController);
        }
    }
}
