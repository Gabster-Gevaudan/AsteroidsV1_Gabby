using System.Collections;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    [SerializeField] private float _shakeAmount = 0.7f;
    [SerializeField] private float _shakeDelay = 1.0f;
    [SerializeField] private float _interactions = 2f;

    public IEnumerator ShakeRoutine()
    {
        Vector3 originalPos = transform.position;
        for (int n = 0; n < _interactions; n++)
        {
            Vector3 pos = Random.insideUnitCircle * _shakeAmount;
            transform.position = transform.position + pos;
            yield return new WaitForSeconds(_shakeDelay);
        }
        transform.position = originalPos;
        yield return null;
    }
}
