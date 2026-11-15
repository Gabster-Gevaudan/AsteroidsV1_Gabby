using System.Runtime.CompilerServices;
using UnityEngine;

public class MoveShip : MonoBehaviour
{
    [SerializeField] private Transform _bullet;
    [SerializeField] private int _healthMax = 5;
    [SerializeField] private int _healthCurrent;
    [SerializeField] private float _moveForce;
    [SerializeField] private float _rotateSpeed;

    public int _score = 0;
    public ScreenFlash Flash;
    private Rigidbody2D _rb;
    public GameObject ExplosionRef;
    public ScreenShake Shake;
    public int GetHighScore()
    {
        return PlayerPrefs.GetInt("Hiscore", 0);
    }

    public void SetHighScore(int score)
    {
        PlayerPrefs.SetInt("Hiscore", score);
    }

    public void GameOver()
    {
        bool celebrateHiscore = false;
        if (_score > GetHighScore())
        {
            SetHighScore(_score);
            celebrateHiscore = true;
        }
    }

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _healthCurrent = _healthMax;
    }

    void Update()
    {
        float horis = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        ApplyThrust(vert);
        ApplyTurn(horis);

        if(Input.GetKeyDown(KeyCode.E))
        {
            Shoot();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Ouch");
    }

    private void ApplyThrust(float amount)
    {
        Vector2 thrust = transform.up * _moveForce * Time.deltaTime * amount;
        _rb.AddForce(thrust);
    }

    private void ApplyTurn(float amount)
    {
        transform.Rotate(transform.forward, _rotateSpeed * amount * Time.deltaTime);
    }

    private void Shoot ()
    {
        Instantiate(_bullet, transform.position + transform.up * 0.35f, transform.rotation);
    }

    public void TakeDamage(int damage)
    {
        _healthCurrent = _healthCurrent - damage;
        if (_healthCurrent <= 0)
        {
            Explode();
        }
        StartCoroutine(Flash.FlashRoutine());
        StartCoroutine(Shake.ShakeRoutine());
    }

    public void Explode()
    {
        Instantiate(ExplosionRef, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
