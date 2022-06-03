/***================== Indice do codigo para entendimento ====================***/
/*** 1.0   - Apresentar o dano na tela como texto                             ***/
/*****                                                                        ***/
/**================== Fim Indice do codigo para entendimento =================***/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageText : MonoBehaviour
{
    //1.0  - Para colocar o objeto text do canvas
    public Text damage;

    void Start(){
        //1.0  - Para destruir o objeto em 5 segundo que é o tempo da animação de subida do damage
        Destroy(gameObject, 0.5f);
    }

    //1.0  - vai receber o valor do damage jogando para o objeto
    public void SetText(string value){
        damage.text = value;
    }
}
