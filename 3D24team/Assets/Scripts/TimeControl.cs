using UnityEngine;

public class TimeControl : MonoBehaviour
{
    public float scene1Duration;
    public float scene2Duration;
    public string sceneName;

    private bool isSwitchingScene;
    private int elapsedDays;

    public int Rent => Mathf.FloorToInt(2f + Mathf.Pow(1.2f, elapsedDays));

    void Start()
    {
        isSwitchingScene = false;
        elapsedDays = 0;
    }

    void FixedUpdate()
    {
        TrySwitchScene();
    }

    void TrySwitchScene()
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
                sceneRouter.GoToScene2();
                sceneName = "Scene2";
                // TODO: We can't perform synchronization in WASM, everything is async
                clockText.Restart(scene2Duration + 2.3f);
            }
            else if (sceneName == "Scene2")
            {
                var bank = GameObject.Find("Bank").GetComponent<Bank>();
                if (bank.TryLiquidate(Rent))
                {
                    Debug.LogWarning("Bankrupted!");
                    sceneRouter.GoToSceneEnd();
                    sceneName = "SceneEnd";
                    isSwitchingScene = false;
                    return;
                }
                sceneRouter.GoToScene1();
                sceneName = "Scene1";
                clockText.Restart(scene1Duration + 2.3f);
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
