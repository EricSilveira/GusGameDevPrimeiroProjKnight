/***================== Indice do codigo para entendimento ====================***/
/*** 1.0   - Controle de animacao com variaveis no animator                   ***/
/*****                                                                        ***/
/*** 2.0   - Controle de animacao sem variaveis no animator                   ***/
/*****                                                                        ***/
/***--------------------------------------------------------------------------***/
/***---------> OBS: Nao pude colocar a animacao de ataque aqui    <-----------***/
/***------------------------------------------------------------------------- ***/
/**================== Fim Indice do codigo para entendimento =================***/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    //1.0  - Para trabalhar no Animator da Unity
    private Animator animator;
    //1.0  - Para trabalhar no Rigidbody definido no player no caso mexer na fisica
    private Rigidbody2D  body;

    void Start(){
        //1.0  - O GetComponent eh usado para pegar o objeto definido na unity
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update(){
        PlayerAnimacao();
    }

    private void PlayerAnimacao(){
        //1.0  - Ele ira colocar o valor nos "Parameters" do Animator, o Abs significa absoluto no caso todo numero ficar positivo
        animator.SetFloat("VelocityX", Mathf.Abs(body.velocity.x));
        animator.SetFloat("VelocityY", Mathf.Abs(body.velocity.y));

        //2.0  - Apenas para mostrar que é possivel fazer sem usar as transicao da unity
        //if (body.velocity.x == 0 && body.velocity.y == 0){
        //    animator.Play("Idle");
        //}
        //else if (body.velocity.x != 0 && body.velocity.y == 0){
        //    animator.Play("Walk");
        //}
        //else if (body.velocity.y != 0){
        //    animator.Play("Jump");
        //}
    }  
}
