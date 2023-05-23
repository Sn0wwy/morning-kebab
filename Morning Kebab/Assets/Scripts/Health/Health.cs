using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private bool dead;

    [Header ("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    [SerializeField] private float cantidadPuntos;
    [SerializeField] private Puntaje puntaje;
    private SpriteRenderer spriteRend;

    private void Awake() {
        currentHealth = startingHealth;
        spriteRend = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float _damage){
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        puntaje.RestarPuntos(cantidadPuntos);
        if (currentHealth > 0) {
            // Player hurt
            StartCoroutine(Invulnerability());
            // iframes

        } else {
            // Player dead
            if (!dead) {
                Destroy(gameObject);
                dead = true;
            }
        }
    }

    public void RestoreHealth(float _health){
        currentHealth = Mathf.Clamp(currentHealth + _health, 0, startingHealth);
    }

    private IEnumerator Invulnerability() {
        for (int i = 0; i < numberOfFlashes; i++){
            spriteRend.color = new Color(1,1,1, 0.55f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            
        }

    }
}