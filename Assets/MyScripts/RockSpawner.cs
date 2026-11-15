using System.Collections;
using UnityEngine;

public class RockSpawer : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _rockPrefab;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            Instantiate(_rockPrefab, _spawnPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(5f);
        }

    }
}