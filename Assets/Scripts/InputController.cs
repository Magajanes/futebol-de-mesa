using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private ShootController shootController;

    private Ray ray;
    private RaycastHit hit;

    public void Initialize(ShootController shootController)
    {
        this.shootController = shootController;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            RaycastToField();
    }

    private void RaycastToField()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out hit))
        {
            //Do something
        }
    }
}
