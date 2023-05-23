using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponItem : MonoBehaviour
{
    public GameObject weaponPrefab;

    void Start()
    {
        Invoke("ActivePickUpMode", 1f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        WeaponManager manager= other.GetComponent<WeaponManager>();
        var newWeapon = Instantiate(this.weaponPrefab);
        manager.pickUpWeapon(newWeapon.GetComponent<Weapon>());
        Destroy(this.gameObject);
        
    }

}
