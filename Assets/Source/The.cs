using UnityEngine;

public static class The
{
    public static SceneManager SceneManager => SceneManager.Instance;
    public static GameState GameState => GameState.Instance;
    public static LineDrawer LineDrawer => LineDrawer.Instance;
}
