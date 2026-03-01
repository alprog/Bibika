
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : Singleton<SceneManager>
{
    public Dictionary<Car, Actor> Actors = new Dictionary<Car, Actor>();
    public bool ActorsDirty = true;

    public GameObject Root;

    public SceneManager()
    {
        Root = new GameObject("Root");
        Root.transform.rotation = Quaternion.AngleAxis(90, Vector3.right);
    }

    public void RecreateActors()
    {
        foreach (var car in The.GameState.Cars)
        {
            if (!Actors.ContainsKey(car))
            {
                var gameobject = new GameObject("Car");
                var actor = gameobject.AddComponent<Actor>();
                actor.transform.parent = Root.transform;
                actor.Car = car;
                Actors.Add(car, actor);
                actor.Sync();
            }
        }
        ActorsDirty = false;
    }

    public void Refresh()
    {
        if (ActorsDirty)
        {
            RecreateActors();
        }

        foreach (var actor in Actors.Values)
        {
            actor.Sync();
        }

        foreach (var car in The.GameState.Cars)
        {
            car.DrawDebug();
        }
    }
}
