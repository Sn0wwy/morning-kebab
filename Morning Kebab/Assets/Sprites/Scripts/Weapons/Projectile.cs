using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [Header("Projectile")]
    public float speed = 1;

    [HideInInspector]
    public Weapon weapon;

    void awake()
    {
        var body = this.GetComponent<Rigidbody2D>();
        body.velocity = this.transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Boss")) {
            other.GetComponent<Health>().TakeDamage(1);
        } else {

            if (other.gameObject.GetComponent<EnemyShoot>() != null)
            {
                other.gameObject.SetActive(false);
                if(weapon is ShotGun)
                {
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
