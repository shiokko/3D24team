using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basket : MonoBehaviour
{
    public GameObject prefab_raw;

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("vege"))
        {
            var vegeScript = other.GetComponent<raw_vege>();
            vegeScript.MoveOutOfBasket();
            Instantiate(prefab_raw, transform.position, Quaternion.identity);
        }
    }
}
