/***================== Indice do codigo para entendimento ====================***/
/*** 1.0   - Movimentacao do player                                           ***/
/*****                                                                        ***/
/***--------------------------------------------------------------------------***/
/***---------> OBS: Colocado o attackCheck para colocar o objeto  <-----------***/
/***--------->      na posicao de onde estiver virado             <-----------***/
/***------------------------------------------------------------------------- ***/
/**================== Fim Indice do codigo para entendimento =================***/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovimento : MonoBehaviour
{
    /********************* Variaveis Movimentar ********************/
    //1.0  - Para trabalhar no Sprite Renderer definido no player
    private SpriteRenderer sprite;
    //1.0  - Para trabalhar no Rigidbody definido no player no caso mexer na fisica
    private Rigidbody2D    body;
    //1.0  - Para ajustar a velocidade
    public  float    speed = 8f;
    //1.0  - Para o objeto de onde efetuara o ataque
    public Transform attackCheck;


    void Start(){
        //1.0  - O GetComponent eh usado para pegar o objeto definido na unity
        body   = GetComponent<Rigidbody2D>(); 
        sprite = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate(){
        //1.0  - Dentro da Unity no "project setings> input" existe a opçao Horizontal que são as setas esquerda e direita
        float move    = Input.GetAxis("Horizontal");
        //1.0  - O eixo y ele é matido pois é pra continuar fazendo que estava exemplo se ta caindo, se ta pulando, etc...
        body.velocity = new Vector2(move * speed, body.velocity.y);

        //1.0  - Se move for positivo ele esta indo para a direita se negativo esquerda
        if ((move > 0 && sprite.flipX == true) || (move < 0 && sprite.flipX == false)){
            Flip();
        }
    }

    void Flip(){
        //1.0  - recebe a propria negacao dessta forma se tiver virado para um lado ele vira para o outro lado
        sprite.flipX = !sprite.flipX;
        //1.0  - O local position eh referente ao player, ja o position eh referente a cena, eh colocado um negativo para inverter o lado 
        attackCheck.localPosition = new Vector2(-attackCheck.localPosition.x, attackCheck.localPosition.y);
    }
}
