using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneRouter : MonoBehaviour
{
    private bool isGoing;

    void Start()
    {
        isGoing = false;
        // Optional: Make SceneRouter persistent across scenes
        // Uncomment the next line if you want the SceneRouter to persist
        // DontDestroyOnLoad(this.gameObject);
    }

    // Method to start coroutine for Scene1
    public void GoToScene1()
    {
        if (isGoing)
        {
            return;
        }
        StartCoroutine(GoToScene1Coroutine());
    }

    private IEnumerator GoToScene1Coroutine()
    {
        isGoing = true;

        // Load the SunRise scene asynchronously
        AsyncOperation loadSunRise = SceneManager.LoadSceneAsync("SunRise");
        Debug.Log("Loading SunRise and Scene1");

        // Wait until SunRise is loaded
        while (!loadSunRise.isDone)
        {
            yield return null; // Wait for the next frame
        }

        // Wait for 2 seconds
        yield return new WaitForSeconds(2f);

        // Load Scene1 asynchronously
        AsyncOperation loadScene1 = SceneManager.LoadSceneAsync("Scene1");
        while (!loadScene1.isDone)
        {
            yield return null; // Wait for the next frame
        }

        Debug.Log("Arrived at Scene1");
        isGoing = false;
    }

    // Method to start coroutine for Scene2
    public void GoToScene2()
    {
        if (isGoing)
        {
            return;
        }
        StartCoroutine(GoToScene2Coroutine());
    }

    private IEnumerator GoToScene2Coroutine()
    {
        isGoing = true;

        // Load the SunFall scene asynchronously
        AsyncOperation loadSunFall = SceneManager.LoadSceneAsync("SunFall");
        Debug.Log("Loading SunFall and Scene2");

        // Wait until SunFall is loaded
        while (!loadSunFall.isDone)
        {
            yield return null; // Wait for the next frame
        }

        // Wait for 2 seconds
        yield return new WaitForSeconds(2f);

        // Load Scene2 asynchronously
        AsyncOperation loadScene2 = SceneManager.LoadSceneAsync("Scene2");
        while (!loadScene2.isDone)
        {
            yield return null; // Wait for the next frame
        }

        Debug.Log("Arrived at Scene2");
        isGoing = false;
    }

    // Method to start coroutine for SceneEnd
    public void GoToSceneEnd()
    {
        if (isGoing)
        {
            return;
        }
        StartCoroutine(GoToSceneEndCoroutine());
    }

    private IEnumerator GoToSceneEndCoroutine()
    {
        isGoing = true;

        // Load the SceneEnd asynchronously
        AsyncOperation loadSceneEnd = SceneManager.LoadSceneAsync("SceneEnd");
        Debug.Log("Loading SceneEnd");

        // Wait until SceneEnd is loaded
        while (!loadSceneEnd.isDone)
        {
            yield return null; // Wait for the next frame
        }

        Debug.Log("Arrived at SceneEnd");
        isGoing = false;
    }
}
