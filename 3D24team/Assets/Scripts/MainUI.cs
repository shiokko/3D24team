using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUI : MonoBehaviour
{
    private static bool isInitialized = false;

    void Awake()
    {
        if (isInitialized)
        {
            return;
        }
        isInitialized = true;
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("Scene1");
    }
}
