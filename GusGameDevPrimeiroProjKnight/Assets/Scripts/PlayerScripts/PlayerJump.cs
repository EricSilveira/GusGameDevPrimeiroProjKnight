/***================== Indice do codigo para entendimento ====================***/
/*** 1.0   - Pulo                                                             ***/
/***       necessario para qualquer um dos pulos                              ***/
/*****                                                                        ***/
/*** 1.1   - Pulo Forte e Fraco                                               ***/
/***       feito se baseando se esta segurando o botao de pulo ou soh tocou   ***/
/*****                                                                        ***/
/*** 1.2   - Pulo Extra(Pulo Duplo)                                           ***/
/***                                                                          ***/
/*****                                                                        ***/
/*** 2.0   - Pulo com LineCast                                                ***/
/***             cria uma linha do centro do player ate o objeto groundCheck  ***/
/***             problema eh que se estiver na beira da plataforma ou entre   ***/
/***             duas plataforma o objeto não toca o chao nao deixando pular  ***/
/*****                                                                        ***/
/*** 3.0   - Pulo com OverlapCircle                                           ***/
/***              cria uma esfera no objeto groundCheck                       ***/
/***              problema se definir um raio muito grande e as paredes       ***/
/***              tiverem com layer de ground vai entender que pode pular     ***/
/*****                                                                        ***/
/*** 4.0   - Pulo com IsTouchingLayers                                        ***/
/***        para este caso nem eh preciso ter o groundCheck                   ***/
/***        problema se as paredes tiverem com layer de ground vai            ***/
/***        entender que pode pular                                           ***/
/***--------------------------------------------------------------------------***/
/***---------> OBS: Descomentar o tipo de pulo que ira utilizar   <-----------***/
/***------------------------------------------------------------------------- ***/
/**================== Fim Indice do codigo para entendimento =================***/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    /*********************** Variaveis Pular ***********************/
    //1.0  - Para trabalhar no Rigidbody definido no player no caso mexer na fisica
    private Rigidbody2D body;
    //1.0  - Para setar o objeto de checagem na unity 
    public Transform groundCheck;
    //1.0  - Para dizer qual a mascara que considera chao
    public LayerMask whatIsGround;
    //1.0  - Para validar se esta no chao
    private bool isOnFloor = false;
    //1.0  - Para saber se esta pulando
    private bool isJumping = false;
    //1.0  - Para definir a forca do pulo importante alterar a gravidade para -30 no eixo y entrar no "Edit -> project Setings-> Physics2D"
    public float jumpForce = 600f;
    //1.1  - Para definir o valor negativo que eh multiplicado para que pare de subir e comece a descer
    private float down = -0.8f;
    //1.2  - Para dizer quantos pulos extras tera   
    private int extraJumps = 1;
    //3.0  - Para dizer o tamanho do raio do circulo
    public float radius = 0.3f;

    void Start(){
        //1.0  - O GetComponent eh usado para pegar o objeto definido na unity
        body = GetComponent<Rigidbody2D>();
    }

    void Update(){
        //2.0  - Eh pego a posicao do personagem, a posicao do groundCheck e se eh chao pela layer
        //isOnFloor = Physics2D.Linecast(transform.position, groundCheck.position, whatIsGround);

        //2.0  - Eh pego a posicao do groundCheck, o raio do circulo e se eh chao pela layer       
        //isOnFloor = Physics2D.OverlapCircle(groundCheck.position,radius ,whatIsGround);

        //4.0  - Eh verificado o chao pela layer       
        isOnFloor = body.IsTouchingLayers(whatIsGround);

        //1.0  - No momento em que apertar o botao de pulo(o getbuttondown ele só verifica se aperto e não se esta segurando o botão ou não)
        //1.0  - E verifica se esta no chao
        //if (Input.GetButtonDown("Jump") && isOnFloor){

        //1.2  - O extrasJumps sera validado quantos pulos a mais tem até que seja zero 
        //1.2  - (para fazer o pulo duplo foi necessario alterar o pulo simples por isso esta comentado o if acima) 
        if (Input.GetButtonDown("Jump") && extraJumps > 0){

            //1.0  - Se a condição for verdadeira vai ficar verdadeiro o esta pulando
            isJumping = true;
            //1.2  - Cada vez que passar no if ira subtrair menos um do extrasJump
            extraJumps--;
        }

        //1.2  - Quando estiver no chao vai voltar o valor inicial ao pulo extra
        if (isOnFloor){
            extraJumps = 1;
        }
    }

    private void FixedUpdate(){
        if (isJumping){
            //1.2  - Para quando estiver pulando zera o eixo y para poder pular novamente
            body.velocity = new Vector2(body.velocity.x, 0f);

            //1.0  - Quando esta pulando vai adicionar uma forca ganhando velocidade no eixo que setar
            body.AddForce(new Vector2(0, jumpForce));
            //1.0  - Coloca falso no esta pulando para que não ficar adicionando forca ao pulo direto
            isJumping = false;
        }

        //1.1  - Se esta subindo(pulando) o eixo Y vai estar maior que zero 
        //1.1  - O getbutton verifica se esta segurando o botao (nesse caso verifica se largou o botao de pulo)
        if (body.velocity.y > 0f & !Input.GetButton("Jump")){
            //1.1  - O vector up trabalha apenas com o eixo y mantendo 0 no x multiplicado por valor negativo para trazer de volta para baixo 
            body.velocity += Vector2.up * down;
        }
    }

    //3.0  - Desenhar na cor vermelha, uma esfera na posicao do ground com o tamanho do raio 
    //private void OnDrawGizmosSelected(){
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(groundCheck.position, radius);
    //}


}
