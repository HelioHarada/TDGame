using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Bullet : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private Rigidbody2D rb;


    [Header("Attributes")]
    [SerializeField] private float bulletSpeed = 5f;
    [SerializeField]private int bulletDmg = 1;

    private Transform target;

    public void SetTarget(Transform _target)
    {
        target = _target;
    }

    public void SetBulletConfig(float speed, int dmg)
    {
        bulletSpeed = speed;
        bulletDmg = dmg;
    }

    private void FixedUpdate()
    {
        if(!target) return;
       
        Vector2 direction =  (target.position - transform.position).normalized;
        rb.velocity = direction * bulletSpeed;
      
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        col.gameObject.GetComponent<EnemyHealth>().TakeDamege(bulletDmg);
        Destroy(gameObject);
    }
}
