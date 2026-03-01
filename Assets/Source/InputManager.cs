using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Video;

public class InputManager : Singleton<InputManager>
{
    public Car HoveredObject;

    public void Update(float deltaTime)
    {
        var mousePosition = Mouse.current.position.ReadValue();
        var ray = Camera.main.ScreenPointToRay(mousePosition);

        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            HoveredObject = hitInfo.collider.GetComponent<Actor>().Car;
        }
        else
        {
            HoveredObject = null;
        }

        var clicked = Mouse.current.leftButton.wasPressedThisFrame;
        if (clicked && HoveredObject != null)
        {
            HoveredObject.Ride = !HoveredObject.Ride;
        }
    }
}
