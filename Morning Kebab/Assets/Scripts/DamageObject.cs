using UnityEngine;

public class DamageObject : MonoBehaviour
{
    private void onCollisionEnter2D(Collision2D collision) {
        if (collision.transform.CompareTag("Player")){
            Destroy(gameObject, 0.5f);
        }
    }
}
