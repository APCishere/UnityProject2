using UnityEngine;

public class TimeScaler : MonoBehaviour
{
    bool isPaused = false;

    void Update()
    {
        if (UnityEngine.InputSystem.Keyboard.current.insertKey.wasPressedThisFrame)
        {
            isPaused = !isPaused;                    // flip true/false
            Time.timeScale = isPaused ? 0f : 1f;     // 0 = frozen, 1 = normal
            Debug.Log("Switched");
        }
    }
}
