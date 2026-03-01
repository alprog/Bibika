
using UnityEngine;

public class Car
{
    public Vector2 Size;
    public float Height;
    public Vector2 Position;
    public float Rotation;
    public float Speed;
    public bool Ride;

    public void Randomize()
    {
        Rotation = Random.Range(0f, Mathf.PI * 2);

        Size.x = Random.Range(1.0f, 2.0f);
        Size.y = Random.Range(0.2f, 0.8f);
        Height = 0.5f;

        var radius = Mathf.Max(Size.x, Size.y) / 2;

        float x = Random.Range(radius, 10f - radius);
        float y = Random.Range(radius, 10f - radius);
        Position = new Vector2(x, y);
    }

    public void Update(float deltaTime)
    {
        float acceleration = Ride ? 3f : -5f;
        Speed += acceleration * deltaTime;
        Speed = Mathf.Clamp(Speed, 0, 10.0f);

        if (Speed > 0)
        {
            var direction = new Vector2(Mathf.Cos(Rotation), Mathf.Sin(Rotation));
            Position += direction * Speed * deltaTime;
        }
    }

    public void DrawDebug()
    {
        The.LineDrawer.Rect(Position, Size, Rotation, Color.red);
    }
}

