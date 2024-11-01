using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class Bus : MonoBehaviour
{
    private bool isAboard;

    void Start()
    {
        isAboard = false;
    }

    // Take the bus to Scene2 after SunFall scene is loaded
    public void TakeToScene2()
    {
        if (!isAboard)
        {
            isAboard = true;
            LoadScene2Async();
        }
    }

    private async void LoadScene2Async()
    {
        // Load the SunFall scene asynchronously and wait until it's loaded
        AsyncOperation loadSunFall = SceneManager.LoadSceneAsync("SunFall");
        Debug.Log("Loading SunFall scene");
        while (!loadSunFall.isDone)
        {
            await Task.Yield();
        }

        // Wait for 2 seconds before loading Scene2
        await Task.Delay(2000);

        // Load Scene2 asynchronously and wait until it's loaded
        AsyncOperation loadScene2 = SceneManager.LoadSceneAsync("Scene2");
        Debug.Log("Loading Scene2");
        while (!loadScene2.isDone)
        {
            await Task.Yield();
        }

        isAboard = false;
        Debug.Log("Arrived at Scene2");
    }
}
