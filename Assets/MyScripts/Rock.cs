using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Vector2Int _rockAmount;
    [SerializeField] private Transform[] _smallerRocks;
    [SerializeField] private float _smallRockSpeed = 5f;
    [SerializeField] private IntChannel _addScoreChannel;
    [SerializeField] private int _collisionDamage = 1;
    public GameObject ExplosionRef;
    public int _scoreValue = 10;

    public void Explode()
    {
        MoveShip ship = FindObjectOfType<MoveShip>();
        if (ship != null)
        {
            ship._score += _scoreValue;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        MoveShip ship = collision.gameObject.GetComponent<MoveShip>();
        Bullet bullet = collision.gameObject.GetComponent<Bullet>();
        if (ship != null)
        {
            ship.TakeDamage(_collisionDamage);
        }
        _addScoreChannel.RaisedEvent(4);
        Instantiate(ExplosionRef, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void Update()
    {
        transform.position += Vector3.left * _speed * Time.deltaTime;
        Vector2 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPos.x < 0)
        {
            Instantiate(ExplosionRef, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        int rng = UnityEngine.Random.Range(_rockAmount.x, _rockAmount.y + 1);

        for (int i = 0; i < rng; i++)
        {
            float randomXPos = UnityEngine.Random.Range(-1f, 1f);
            float randomYPos = UnityEngine.Random.Range(-1f, 1f);

            Vector3 randomOffset = new Vector2(randomXPos, randomYPos);

            Rigidbody2D rb = Instantiate(_smallerRocks[UnityEngine.Random.Range(0, _smallerRocks.Length)], transform.position, Quaternion.identity).GetComponent<Rigidbody2D>();
           
           float randomX = UnityEngine.Random.Range(-1f, 1f);
           float randomY = UnityEngine.Random.Range(-1f, 1f);
          
           Vector2 randomVector = new Vector2(randomX, randomY);

            randomVector.Normalize();

            rb.AddForce(randomVector * _smallRockSpeed, ForceMode2D.Impulse);
        }
    }
}
