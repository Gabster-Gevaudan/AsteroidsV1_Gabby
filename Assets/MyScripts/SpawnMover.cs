using UnityEngine;

public class SpawnMover : MonoBehaviour
{
    [SerializeField] private float _amp;

    private Vector3 _startPosition;

    void Start()
    {
        _startPosition = transform.position;
    }

    void Update()
    {
        Vector3 offset = new Vector3(0f, Mathf.Sin(Time.time), 0f) * _amp;
        transform.position = _startPosition + offset;
    }
}