using UnityEngine;

public class UpdateTransmitter : MonoBehaviour
{
    void Update()
    {
        var deltaTime = Time.deltaTime;
        The.InputManager.Update(deltaTime);
        The.GameState.Update(deltaTime);
        The.SceneManager.Refresh();
    }
}
