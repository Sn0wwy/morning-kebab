using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealObject : MonoBehaviour
{
    [SerializeField] private float healthRestored;
    [SerializeField] private float cantidadPuntos;
    [SerializeField] private Puntaje puntaje;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            puntaje.SumarPuntos(cantidadPuntos);
            collision.GetComponent<Health>().RestoreHealth(healthRestored);
        }
    }
}
