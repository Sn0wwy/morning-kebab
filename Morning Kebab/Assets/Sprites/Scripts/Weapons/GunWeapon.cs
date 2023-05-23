using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GunWeapon : Weapon
{
    [Header("Gun")]
    public int maxAmmo;
    public int currentAmmo { get; protected set; }

    public Transform shotPoint;

    // Start is called before the first frame update
    void Start()
    {
        this.currentAmmo = this.maxAmmo;
    }

    protected override void OnActivate()
    {
        if(this is LaserPistol)
        {
            this.currentAmmo = this.maxAmmo;
        }
        if (this.currentAmmo == 0)
            return;
        //shotPoint = new Transform(new Vector3(1, 2, 3), Quaternion.Euler(0, 45, 0));
        this.Shot(this.shotPoint.position, this.shotPoint.position);
    }

    protected abstract void Shot(Vector3 position, Vector3 direction);

}
