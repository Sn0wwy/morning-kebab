using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{

    [Header("Weapon")]
    public GameObject weaponItemPrefab;

    public float maxCooldownTime = 1f;
    public float cooldownTime;

    public bool isReady => this.cooldownTime >= maxCooldownTime;

    protected void Awake()
    {
        this.cooldownTime = this.maxCooldownTime; 
    }

    protected void Update()
    {
        if(!this.isReady)
        {
            this.cooldownTime += Time.deltaTime;
        }
    }

    public void Activate()
    {
        if(this.isReady)
        {
            this.OnActivate();
            this.cooldownTime = 0;
        }
    }

    protected abstract void OnActivate();


}
