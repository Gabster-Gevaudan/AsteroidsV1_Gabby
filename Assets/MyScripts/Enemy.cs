using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;

    public void TakeDamage(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}