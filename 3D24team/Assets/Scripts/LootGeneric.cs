using UnityEngine;

public class LootGeneric : MonoBehaviour
{
    // Duration of looting in seconds
    [SerializeField]
    private float duration;

    public float Duration()
    {
        return duration;
    }
}
