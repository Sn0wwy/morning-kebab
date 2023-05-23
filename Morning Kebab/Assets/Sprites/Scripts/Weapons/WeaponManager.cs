using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public Weapon currentWeapon;

    public Transform weaponHolder;

    public bool hasRoomForWeapon => this.currentWeapon == null;

    [SerializeField] private float cantidadPuntos;
    [SerializeField] private Puntaje puntaje;

    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1"))
        {
            if(this.currentWeapon != null)
            {
                this.currentWeapon.Activate();
            }

        }
    }

    public void pickUpWeapon(Weapon weapon)
    {
        if(this.currentWeapon != null) {
           this.currentWeapon.weaponItemPrefab.gameObject.gameObject.SetActive(false);
           Destroy(this.currentWeapon);
        }
        if(weapon is ShotGun)
        {
            weapon.gameObject.GetComponent<Renderer>().enabled = false;
            RuntimeAnimatorController animClip = Resources.Load<RuntimeAnimatorController>("PakoWithShotgun");
            GetComponent<Animator>().runtimeAnimatorController = animClip;
        }
        if(weapon is LaserPistol)
        {
            weapon.gameObject.GetComponent<Renderer>().enabled = false;
            RuntimeAnimatorController animClip = Resources.Load<RuntimeAnimatorController>("pakoWithLaserPistolAnimator");
            GetComponent<Animator>().runtimeAnimatorController = animClip;
        }

        weapon.transform.position = this.weaponHolder.position;
        weapon.transform.rotation= this.weaponHolder.rotation;
        weapon.transform.SetParent(this.weaponHolder);

        this.currentWeapon = weapon;
        puntaje.SumarPuntos(cantidadPuntos);
    }

}
