
using UnityEngine;
using System.Collections.Generic;

public class LineDrawer : Singleton<LineDrawer>
{
    public void Rect(Vector2 center, Vector2 size, float rotation, Color color)
    {
        var points = new List<Vector3>{
            new Vector3( 0.5f, 0.5f, 0),
            new Vector3( -0.5f, 0.5f, 0 ),
            new Vector3( -0.5f, -0.5f, 0 ),
            new Vector3( 0.5f, -0.5f, 0)
        };

        var Matrix = Matrix4x4.TRS(
            new Vector3(center.x, center.y, 0),
            Quaternion.Euler(0, 0, rotation * Mathf.Rad2Deg), 
            new Vector3(size.x, size.y, 1)
        );

        for (int i = 0; i < points.Count; i++)
        {
            points[i] = ToWorld(Matrix.MultiplyPoint(points[i]));
        }

        for (int i = 0; i < points.Count; i++)
        {
            Debug.DrawLine(points[i], points[(i + 1) % points.Count], color);
        }
    }

    public void Line(Vector3 start, Vector3 end, Color color)
    {
        Debug.DrawLine(start, end, color);
    }

    private Vector3 ToWorld(Vector3 point)
    {
        return new Vector3(point.x, point.z, point.y);
    }
}
