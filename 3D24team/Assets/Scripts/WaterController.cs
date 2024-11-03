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

    // 碰撞檢測
    private void OnTriggerEnter2D(Collider2D collider)
    {
        // 檢查碰撞的物件是否具有 raw_vege 腳本
        raw_vege washable = collider.gameObject.GetComponent<raw_vege>();
        if (washable != null)
        {
            StartCoroutine(WashObjectAfterDelay(washable));  // 啟動協程
        }
    }

    // 等待2秒後設置 isWashed 為 true
    private IEnumerator WashObjectAfterDelay(raw_vege washable)
    {
        StartWaterFlow();
        yield return new WaitForSeconds(2f);  // 等待 2 秒
        washable.isWashed = true;  // 設置 isWashed 為 true
        StopWaterFlow();
    }

}
