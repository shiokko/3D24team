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
            SceneManager.LoadSceneAsync(sceneName).completed += (AsyncOperation op) => { isAboard = false; Debug.Log("Arrived at " + sceneName); };
        }
    }
}
