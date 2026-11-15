using System.Collections;
using UnityEngine;

public class SmallerRocks : MonoBehaviour
{

    private void OnEnable()
    {
        StartCoroutine(DestroyAfterTime());
    }

    private IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}