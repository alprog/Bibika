
using UnityEngine;
using System.Diagnostics;
using Unity.VisualScripting;

public class SceneManager : Singleton<SceneManager>
{
    public void Refresh()
    {

        foreach (var car in The.GameState.Cars)
        {
            car.DrawDebug();
        }
       

        //Debug.DrawLine(start, end, Color.red, );
    }
}
