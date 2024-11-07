using System;
using TMPro;
using UnityEngine;

public class ClockText : MonoBehaviour
{
    public float timeOffset;
    public float timeScale;

    private float fromTime;

    public float Duration => Math.Max((Time.fixedTime - fromTime) * timeScale + timeOffset, 0f);

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
    /// Restart the clock with an timeOffset
    /// </summary>
    public void Restart(float timeOffset)
    {
        this.timeOffset = timeOffset;
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
