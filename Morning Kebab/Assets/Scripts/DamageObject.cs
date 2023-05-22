using UnityEngine;

public class DamageObject : MonoBehaviour
{
    [SerializeField] private float damage;

    private GameObject player;
    private float timer;
    private bool firstContact = true;

     void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);

        if(distance < 0.2) {
            if(firstContact){
                dealDamage();
                firstContact = false;
            }
            timer += Time.deltaTime;

            if(timer > 1){
                timer = 0;
                dealDamage();
            }
        } 
    }

    /*private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }*/

    void dealDamage() {
        player.GetComponent<Health>().TakeDamage(damage);
    }
}