
using UnityEngine;

public class Car
{
    public Vector2 Size;
    public Vector2 Position;
    public float Rotation;

    public void Randomize()
    {
        Rotation = Random.Range(0f, Mathf.PI * 2);

        Size.x = Random.Range(0.5f, 2.0f);
        Size.y = Random.Range(0.5f, 2.0f);

        var radius = Mathf.Max(Size.x, Size.y) / 2;

        float x = Random.Range(radius, 10f - radius);
        float y = Random.Range(radius, 10f - radius);
        Position = new Vector2(x, y);
    }

    public void DrawDebug()
    {
        The.LineDrawer.Rect(Position, Size, Rotation, Color.red);
    }
}

