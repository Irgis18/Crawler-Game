using System;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public float attackRange = 1.5f;

    public int damage = 1;

    public SpriteRenderer spriteRenderer;

    public Animator animator;

    public Playerhealth playerhealth;

    public int knockbackForce = 5;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerhealth.isAlive)
        {
            PerformAttack();
        }
    }

    void PerformAttack()
    {

        animator.SetTrigger("Attack");

        Vector2 attackDirection = spriteRenderer.flipX ? Vector2.left : Vector2.right;

        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, attackRange);

        foreach(Collider2D collider in hitColliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                Vector2 directionToEnemy = (collider.transform.position - transform.position).normalized;

                if(Vector2.Dot(attackDirection, directionToEnemy) > 0)
                {
                    //retire des points de vie à l'ennemie
                    EnemyAI enemyScript = collider.GetComponent<EnemyAI>();
                    enemyScript.TakeDamage(damage);

                    Vector2 knockbackDirection = (collider.transform.position - transform.position).normalized;
                    
                    enemyScript.rb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
                }
            }
        }
    }

    public void MultiplyDamages(float damageMultiplier)
    {
        damage = (int)Math.Ceiling(damage * damageMultiplier);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
