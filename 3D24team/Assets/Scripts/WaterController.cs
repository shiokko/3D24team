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

    // �I���˴�
    private void OnTriggerEnter2D(Collider2D collider)
    {
        // �ˬd�I��������O�_�㦳 raw_vege �}��
        raw_vege washable = collider.gameObject.GetComponent<raw_vege>();
        if (washable != null)
        {
            StartCoroutine(WashObjectAfterDelay(washable));  // �Ұʨ�{
        }
    }

    // ����2���]�m isWashed �� true
    private IEnumerator WashObjectAfterDelay(raw_vege washable)
    {
        StartWaterFlow();
        yield return new WaitForSeconds(2f);  // ���� 2 ��
        washable.isWashed = true;  // �]�m isWashed �� true
        StopWaterFlow();
    }

}
