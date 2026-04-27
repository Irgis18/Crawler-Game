using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 3;

    public Rigidbody2D rigibody;

    public Animator animator;

    public SpriteRenderer spriterenderer;

    private Vector2 movement;

    public Playerhealth playerhealth;
    // Update is called once per frame
    void Update()
    {
        if (playerhealth.isAlive)
        {
              //Prend les valeur d'entré de Horizontal et Vertical genre zqsd
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        //évite qu'il est une accumulation de vitesse quand on marche en diagonal 
        movement = movement.normalized;
        //Permet transformer notre vecteur2 en une valeur à virgule
        animator.SetFloat("Speed",movement.sqrMagnitude);
        //Si le movement x et inférieur à 0 il y aura un flip sur l'axe x
        if(movement.x != 0)
        {
            spriterenderer.flipX = movement.x < 0;
        }
        }
      
    }


    //La vitesse ne dépend pas des fps donc il y aura pas de fps = vitesse
    void FixedUpdate()
    {
        rigibody.linearVelocity = movement * moveSpeed;
    }
}
