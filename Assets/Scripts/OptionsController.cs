using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField]
    private GameObject menuPanel;

    public void SetMenuPanelActive(bool active)
    {
        menuPanel.SetActive(active);
    }
}
