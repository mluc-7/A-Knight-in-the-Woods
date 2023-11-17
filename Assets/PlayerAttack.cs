using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float moveSpeed = 5f;
    public int attackDamage = 10;
    public float attackForce = 300f;

    private bool isAttacking = false;
    public Collider2D rightSwordCollider;
    public Collider2D leftSwordCollider;
    public Collider2D[] hitEnemies;

    void Start()
    {
        rightSwordCollider.gameObject.SetActive(false);
        leftSwordCollider.gameObject.SetActive(false);
    }

    void Update()
    {
        if (!isAttacking)
        {
            // Check for mouse click
            if (Input.GetMouseButtonDown(0))
            {
                StartCoroutine(Attack());
            }
        }
    }

    IEnumerator Attack()
    {
        isAttacking = true;


        // Enable the sword collider
        if (this.GetComponent<HeroKnight>().m_facingDirection == -1)
        {
            leftSwordCollider.gameObject.SetActive(true);
        }
        else
        {
            rightSwordCollider.gameObject.SetActive(true);
        }

        yield return new WaitForSeconds(0.1f); // Adjust this value based on your attack animation duration

        // Deal damage to enemies
        DealDamage();

        // Disable the sword collider
        rightSwordCollider.gameObject.SetActive(false);
        leftSwordCollider.gameObject.SetActive(false);



        isAttacking = false;
    }

    void DealDamage()
    {
        // Example: Check for enemies in the attack range and deal damage
        
        if (this.GetComponent<HeroKnight>().m_facingDirection == -1)
        {
            hitEnemies = Physics2D.OverlapCircleAll(leftSwordCollider.bounds.center, leftSwordCollider.bounds.extents.x);
        }
        else
        {
            hitEnemies = Physics2D.OverlapCircleAll(rightSwordCollider.bounds.center, rightSwordCollider.bounds.extents.x);
        }

        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.CompareTag("Enemy"))
            {
                // Deal damage to the enemy
                enemy.GetComponent<EnemyController>().TakeDamage(attackDamage);
            }

            // Apply force to the enemy
            Rigidbody2D enemyRb = enemy.GetComponent<Rigidbody2D>();
            if (enemyRb != null)
            {
                Vector2 forceDirection = enemy.transform.position - transform.position;
                forceDirection.Normalize();
                enemyRb.AddForce(forceDirection * attackForce, ForceMode2D.Impulse);
            }
        }
    }
}
