using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShotGun : GunWeapon
{

    [Header("ShotGunProjectile")]
    public GameObject projectile;

    void awake()
    {   
    }

    protected override void Shot(Vector3 position, Vector3 direction)
    {
        float angle = (Mathf.Atan2(direction.y,direction.x) * Mathf.Rad2Deg)-90;
        var rotation = Quaternion.Euler(0,0,angle);

        var bullet = Instantiate(this.projectile,position,rotation);

        bullet.transform.rotation = Quaternion.Euler(0, 0, -183); ;

        bullet.GetComponent<SpriteRenderer>().sortingOrder = 1;

        Vector2 direccion = (this.shotPoint.position - transform.position).normalized;

        Vector3 horizontalVector = new Vector3(1.0f, 0.0f, 0.0f);

        if (GetComponent<SpriteRenderer>().flipX == true)
        {
            horizontalVector = new Vector3(-1.0f, 0.0f, 0.0f);
        }


        bullet.GetComponent<Projectile>().weapon= this;

        bullet.GetComponent<Rigidbody2D>().AddForce(horizontalVector * bullet.GetComponent<Projectile>().speed, ForceMode2D.Impulse);

        StartCoroutine(WaitAndDestroy(bullet));

    }

    IEnumerator WaitAndDestroy(GameObject bullet)
    {
        yield return new WaitForSeconds(2f);
        Destroy(bullet);
    }



}
