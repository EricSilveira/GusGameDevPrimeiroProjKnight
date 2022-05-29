using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovimento : MonoBehaviour
{
    //Para trabalhar no Sprite Renderer definido no player
    private SpriteRenderer sprite;
    //Para trabalhar no Rigidbody definido no player no caso mexer na fisica
    private Rigidbody2D    body;
    //Para ajustar a velocidade
    public  float    speed = 10;
 
    // Start is called before the first frame update
    void Start()
    {
        //O GetComponent eh usado para pegar o objeto definido na unity
        body   = GetComponent<Rigidbody2D>(); 
        sprite = GetComponent<SpriteRenderer>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //Dentro da Unity no "project setings> input" existe a opçao Horizontal que são as setas esquerda e direita
        float move = Input.GetAxis("Horizontal");
        //O eixo y ele é matido pois é pra continuar fazendo que estava exemplo se ta caindo, se ta pulando, etc...
        body.velocity = new Vector2(move * speed, body.velocity.y);

        if ((move > 0 && sprite.flipX == true) || (move < 0 && sprite.flipX == false))
        {
            Flip();
        }
    }

    void Flip()
    {
        sprite.flipX = !sprite.flipX;
    }
}
