using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeControl : MonoBehaviour
{
    public float scene1Duration;
    public float scene2Duration;
    public string sceneName;

    private bool isSwitchingScene;

    void Start()
    {
        isSwitchingScene = false;
    }

    void FixedUpdate()
    {
        TrySwitchScene();
    }

    async void TrySwitchScene()
    {
        if (GetComponent<ClockText>().Duration == 0)
        {
            if (isSwitchingScene)
            {
                return;
            }
            isSwitchingScene = true;

            var SceneRouter = GetComponent<SceneRouter>();
            var clockText = GetComponent<ClockText>();

            // TODO: Smell code
            var panel = GameObject.Find("InventoryPanel");
            if (panel != null)
            {
                panel.SetActive(false);
            }

            if (sceneName == "Scene1")
            {
                await SceneRouter.GoToScene2();
                sceneName = "Scene2";
                clockText.Restart(scene2Duration);
            }
            else if (sceneName == "Scene2")
            {
                await SceneRouter.GoToScene1();
                sceneName = "Scene1";
                clockText.Restart(scene1Duration);
            }

            isSwitchingScene = false;
        }
    }
}
