using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pan : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("rawBeef") || other.CompareTag("rawPork"))
        {
            StartCoroutine(ConvertToFriedVersion(other, 5));
        }
        if (other.CompareTag("rawEgg"))
        {
            StartCoroutine(ConvertToFriedVersion(other, 2));
        }
    }

    private IEnumerator ConvertToFriedVersion(Collider2D other, int stop)
    {
        yield return new WaitForSeconds(stop);

        var meatScript = other.GetComponent<rawMeat>();
        if (meatScript != null && meatScript.friedVersion != null)
        {
            Instantiate(meatScript.friedVersion, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
        }
    }
}
