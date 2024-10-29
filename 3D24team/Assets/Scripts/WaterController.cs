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

    public void StartWaterFlow()  //�}���ʵe
    {
        animator.SetBool("starting", true);
        animator.SetBool("is_streaming", true);
    }
    public void StopWaterFlow()  //�����U��
    {
        animator.SetBool("is_streaming", false);
    }


}
