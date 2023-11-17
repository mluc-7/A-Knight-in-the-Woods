using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [SerializeField] GameObject deathEffect;
    public int health;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            OnDeath();
        }
    }

    public void TakeDamage(int damage)
    {
        health =-damage;
    }
    void OnDeath()
    {
        Destroy(gameObject);
        Instantiate(deathEffect,transform.position, Quaternion.identity);
    }
}
