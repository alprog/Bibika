
using UnityEngine;

public class Actor : MonoBehaviour
{
    public Car Car;

    public void Sync()
    {
        var transform = GetComponent<Transform>();
        transform.localPosition = Car.Position;
        transform.localRotation = Quaternion.AngleAxis(Car.Rotation * Mathf.Rad2Deg, new Vector3(0, 0, 1));

        var boxCollider = this.EnsureComponent<BoxCollider>();
        boxCollider.center = new Vector3(0, 0, -Car.Height / 2);
        boxCollider.size = new Vector3(Car.Size.x, Car.Size.y, Car.Height);
    
        var lineRenderer = this.EnsureComponent<LineRenderer>();
        if (lineRenderer.positionCount < 3)
        {
            CreateBoundBox(lineRenderer);
        }

        bool IsHovered = Car == The.InputManager.HoveredObject;

        Color color = IsHovered ? Color.green : Color.yellow;
        lineRenderer.startColor = color;
        lineRenderer.endColor = color;
    }

    void CreateBoundBox(LineRenderer lineRenderer)
    {
        Vector3 e = new Vector3(Car.Size.x / 2, Car.Size.y / 2, Car.Height);

        Vector3[] corners = new Vector3[8]
        {
            new Vector3(-e.x, -e.y, 0),
            new Vector3( e.x, -e.y, 0),
            new Vector3( e.x,  e.y, 0),
            new Vector3(-e.x,  e.y, 0),

            new Vector3(-e.x, -e.y, -e.z),
            new Vector3( e.x, -e.y, -e.z),
            new Vector3( e.x,  e.y, -e.z),
            new Vector3(-e.x,  e.y, -e.z),

        };

        Vector3[] lines = new Vector3[]
        {
            corners[0], corners[1], corners[5], corners[1], 
            corners[2], corners[6], corners[2], corners[3],
            corners[7], corners[3], corners[0], corners[4], 
            corners[5], corners[6], corners[7], corners[4],

        };

        float lineWidth = 0.03f;
        
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.useWorldSpace = false;
        lineRenderer.positionCount = lines.Length;
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;        
        lineRenderer.SetPositions(lines);
    }
}
