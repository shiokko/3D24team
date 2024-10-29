using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void StartWaterFlow()  //開水動畫
    {
        animator.SetBool("starting", true);
        animator.SetBool("is_streaming", true);
    }
    public void StopWaterFlow()  //水停下來
    {
        animator.SetBool("is_streaming", false);
    }


}
