using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private bool dead;
    [SerializeField] private float cantidadPuntos;
    [SerializeField] private puntaje puntaje;

    private void Awake() {
        currentHealth = startingHealth;
    }

    public void TakeDamage(float _damage){
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        puntaje.RestarPuntos(cantidadPuntos);
        if (currentHealth > 0) {
            // Player hurt
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
}
