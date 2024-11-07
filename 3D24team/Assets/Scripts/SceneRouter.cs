using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class SceneRouter : MonoBehaviour
{
    private bool isGoing;

    void Start()
    {
        isGoing = false;
    }

    public async Task GoToScene1()
    {
        if (isGoing)
        {
            return;
        }
        isGoing = true;

        // Load the SunRise scene asynchronously and wait until it's loaded
        var loadSunRise = SceneManager.LoadSceneAsync("SunRise");
        Debug.Log("Loading SunRise and Scene1");
        while (!loadSunRise.isDone)
        {
            await Task.Yield();
        }

        // Wait for 2 seconds before loading Scene1
        await Task.Delay(2000);

        // Load Scene1 asynchronously and wait until it's loaded
        var loadScene1 = SceneManager.LoadSceneAsync("Scene1");
        while (!loadScene1.isDone)
        {
            await Task.Yield();
        }

        isGoing = false;
        Debug.Log("Arrived at Scene1");
    }

    public async Task GoToScene2()
    {
        if (isGoing)
        {
            return;
        }
        isGoing = true;

        // Load the SunFall scene asynchronously and wait until it's loaded
        var loadSunFall = SceneManager.LoadSceneAsync("SunFall");
        Debug.Log("Loading SunFall and Scene2");
        while (!loadSunFall.isDone)
        {
            await Task.Yield();
        }

        // Wait for 2 seconds before loading Scene2
        await Task.Delay(2000);

        // Load Scene2 asynchronously and wait until it's loaded
        var loadScene2 = SceneManager.LoadSceneAsync("Scene2");
        while (!loadScene2.isDone)
        {
            await Task.Yield();
        }

        isGoing = false;
        Debug.Log("Arrived at Scene2");
    }
}
