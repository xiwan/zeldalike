using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    public float thrust;
    public float knockTime;
    public float damage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Player"))
        {
            Rigidbody2D hit = other.GetComponent<Rigidbody2D>();
            if (hit != null)
            {
                Vector2 difference = hit.transform.position - transform.position;
                difference = difference.normalized * thrust;
                hit.AddForce(difference, ForceMode2D.Impulse);
                if (other.gameObject.CompareTag("Enemy") && other.isTrigger)
                {
                    var enemy = other.GetComponent<Enemy>();
                    if (enemy.currentState != EnemyState.stagger)
                    {
                        enemy.Knock(knockTime, damage);
                    }
                }
                if (other.gameObject.CompareTag("Player") && other.isTrigger)
                {
                    var player = other.GetComponent<Player>();
                    if (player.currentState != PlayerState.stagger)
                    {
                        player.Knock(knockTime, damage);
                    }    
                }
            }
        }

        else if (other.gameObject.CompareTag("breakable") && this.gameObject.CompareTag("Player"))
        {
            other.GetComponent<Pot>().Smash();
        }
    }


}
