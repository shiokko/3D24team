using System;
using TMPro;
using UnityEngine;

public class ClockText : MonoBehaviour
{
    public float offset;
    public float timeScale;

    private float fromTime;

    public float Duration => Math.Max((Time.fixedTime - fromTime) * timeScale + offset, 0f);

    void Start()
    {
        Restart();
    }

    public void Restart()
    {
        fromTime = Time.fixedTime;
        UpdateText();
    }

    /// <summary>
    /// Restart the clock with an offset
    /// </summary>
    public void Restart(float offset)
    {
        this.offset = offset;
        Restart();
    }

    void FixedUpdate()
    {
        UpdateText();
    }

    void UpdateText()
    {
        var duration = Mathf.FloorToInt(Duration);
        var minutes = duration / 60;
        var seconds = duration % 60;
        GetComponent<TextMeshProUGUI>().text = $"{minutes:00}:{seconds:00}";
    }
}
