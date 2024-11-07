using System;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeControl : MonoBehaviour
{
    public float scene1Duration;
    public float scene2Duration;
    public string sceneName;

    private bool isSwitchingScene;
    private int elapsedDays;

    void Start()
    {
        isSwitchingScene = false;
        elapsedDays = 0;
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

            var clockText = GetComponent<ClockText>();
            var sceneRouter = GetComponent<SceneRouter>();

            // TODO: Smell code
            var inventory = GameObject.Find("Inventory").transform.Find("InventoryPanel").gameObject;
            inventory.SetActive(false);

            if (sceneName == "Scene1")
            {
                var store = GameObject.Find("Store").transform.Find("StorePanel").gameObject;
                store.SetActive(false);
                await sceneRouter.GoToScene2();
                sceneName = "Scene2";
                clockText.Restart(scene2Duration);
            }
            else if (sceneName == "Scene2")
            {
                var rent = Mathf.FloorToInt(2f + Mathf.Pow(1.2f, elapsedDays));
                var bank = GameObject.Find("Bank").GetComponent<Bank>();
                if (bank.TryLiquidate(rent))
                {
                    Debug.LogWarning("Bankrupted!");
                    await sceneRouter.GoToSceneEnd();
                    sceneName = "SceneEnd";
                    isSwitchingScene = false;
                    return;
                }
                await sceneRouter.GoToScene1();
                sceneName = "Scene1";
                clockText.Restart(scene1Duration);
                PastOneDay();
            }

            isSwitchingScene = false;
        }
    }

    void PastOneDay()
    {
        elapsedDays++;
        Debug.Log($"Day {elapsedDays}");

        var inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
        inventory.DecreaseItemLives();
    }
}
