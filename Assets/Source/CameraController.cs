using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 Position = new Vector3(0, 10, -1);
    public Vector3 LookAtPosition = Vector3.zero;

    void Update()
    {
        GetComponent<Transform>().LookAt(LookAtPosition);
        GetComponent<Transform>().position = Position;
    }
}
