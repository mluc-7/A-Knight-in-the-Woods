using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [SerializeField] GameObject deathEffect;
    public float health;
    // Start is called before the first frame update
    void Start()
    {
        health = 20;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0.0f)
        {
            OnDeath();
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }
    void OnDeath()
    {
        Destroy(gameObject);
        Instantiate(deathEffect,transform.position, Quaternion.identity);
    }

        void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //collision.gameObject.GetComponent<PlayerHealth>().health--;
        }
    }
}
