using UnityEngine;

public class DamageObject : MonoBehaviour
{
    public static bool isKebab;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            Destroy(collision.gameObject);
        }
    }
}