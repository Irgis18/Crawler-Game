using System.Text.RegularExpressions;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    //Vitesse a laquelle partira la flèche
    public float speed = 10f;

    //Nombre de dégat pris par la flèche
    public int damage = 1; 

    //Durée que la flèche reste pour éviter qu'elle pars à l'infinie
    public float lifetime = 5f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Playerhealth playerhealth = collision.GetComponent<Playerhealth>();
            if(playerhealth != null)
            {
                playerhealth.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}