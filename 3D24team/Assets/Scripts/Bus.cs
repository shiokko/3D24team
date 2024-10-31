using UnityEngine;
using UnityEngine.SceneManagement;

public class Bus : MonoBehaviour
{
    private bool isAboard;

    void Start()
    {
        isAboard = false;
    }

    // Take the bus to the specified scene
    public void TakeToScene(string sceneName)
    {
        if (!isAboard)
        {
            Debug.Log("Taking the bus to " + sceneName);
            isAboard = true;
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
    }
}
