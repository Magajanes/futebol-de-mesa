using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputController : MonoBehaviour
{
    private ShootController shootController;
    private List<RaycastResult> results = new List<RaycastResult>();

    private Ray ray;
    private RaycastHit hit;

    public void InjectDependencies(ShootController shootController)
    {
        this.shootController = shootController;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            RaycastToButton();

        if (Input.GetMouseButtonDown(1))
            RaycastToField();
    }

    private void RaycastToButton()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out hit))
        {
            if (PointerOverUI())
                return;

            var targetButton = hit.collider.GetComponent<Button>();

            if (targetButton == null)
                return;

            shootController.Select(targetButton);
        }
    }

    private void RaycastToField()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (PointerOverUI())
                return;

            var target = hit.collider.GetComponent<Button>();

            if (target != null)
                return;

            shootController.ExecuteShot(hit.point);
        }
    }


    private bool PointerOverUI()
    {
        var eventData = new PointerEventData(EventSystem.current);
        eventData.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        results.Clear();
        EventSystem.current.RaycastAll(eventData, results);

        return results.Count > 0;
    }
}
