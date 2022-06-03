/***================== Indice do codigo para entendimento ====================***/
/*** 1.0   - Ataque do player                                                 ***/
/*****                                                                        ***/
/***--------------------------------------------------------------------------***/
/***---------> OBS: Colocado a animacao de ataque aqui            <-----------***/
/***------------------------------------------------------------------------- ***/
/**================== Fim Indice do codigo para entendimento =================***/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //1.0  - Para trabalhar no Sprite Renderer definido no player
    private SpriteRenderer sprite;
    //1.0  - Para definir o tempo entre um ataque e outro
    private float timeNextAttack;
    //1.0  - Para definir o local do ataque colocado o objeto
    public Transform attackCheck;
    //1.0  - Para identificar a layer
    public LayerMask layerEnemy;
    //1.0  - Para definir o raio
    public float radiusAttack;    
    //1.0  - Para trabalhar no Rigidbody definido no player no caso mexer na fisica
    private Rigidbody2D body;
    //1.0  - Para trabalhar no Animator da Unity
    private Animator animator;

    void Start(){
        //1.0  - O GetComponent eh usado para pegar o objeto definido na unity
        sprite = GetComponent<SpriteRenderer>();
        body   = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update(){
        //1.0  - Verifica se o tempo de intervalo do ataque ja passou, caso tenha passado verifica se foi pressionado o botao control esquerdo e se o player ta parado
        //1.0  - Senao ele subtrai do tempo de intervalo ate ser possivel realizar novo ataque
        if (timeNextAttack <= 0) { 
            if (Input.GetButtonDown("Fire1") && body.velocity == new Vector2(0,0)) {
                animator.SetTrigger("Attack");
                timeNextAttack = 0.2f;
                //AttackPlayer(); <<- chamada feita por evento da animacao na plataforma unity
            }
        } else {
            timeNextAttack -= Time.deltaTime;
        }
    }

    private void AttackPlayer(){
        //1.0  - Ira retornar um array de collider, usado isto pois pode haver mais de um inimigo naquela area, validando a posicao, o raio e a layer
        Collider2D[] enemiesAttack = Physics2D.OverlapCircleAll(attackCheck.position, radiusAttack, layerEnemy);
        //1.0  - Por ser uma lista eh necessario fazer um laco para selecionar um por um  em cada passagem no laco efetuara uma chamada para a classe EnemyDamage
        for (int i= 0; i < enemiesAttack.Length; i++){
            enemiesAttack[i].SendMessage("EnemyHit", "13");
            Debug.Log(enemiesAttack[i].name);
        }
    }

    //1.0  - Desenhar na cor azul, uma esfera na posicao do attackCheck com o tamanho do raio 
    private void OnDrawGizmosSelected(){
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(attackCheck.position, radiusAttack);
    }
}
