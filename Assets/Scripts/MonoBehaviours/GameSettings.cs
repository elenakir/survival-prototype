using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public static bool isPause;

    private void Awake()
    {
        isPause = false;
    }
}
