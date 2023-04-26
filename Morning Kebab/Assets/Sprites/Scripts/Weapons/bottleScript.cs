using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bottleScript : Weapon
{
    public Transform gfx;
    protected override void OnActivate()
    {
        StartCoroutine(this.Animate());
    }

    IEnumerator Animate()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = -1;

        this.gfx.localRotation = Quaternion.Euler(0, 0, -100);

        yield return new WaitForSeconds(this.maxCooldownTime * 0.9f);

        this.gfx.localRotation = Quaternion.Euler(0, 0, 0);
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;

    }


}
