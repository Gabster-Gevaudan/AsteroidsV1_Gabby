using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    public GameObject ExplosionRef;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Explode();
    }

    private void Explode()
    {
        Instantiate(ExplosionRef, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnEnable()
    {
        StartCoroutine(DestroyAfterTime());
    }

    private void Update()
    {
        transform.position += transform.up * _speed * Time.deltaTime;
    }

    private IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
