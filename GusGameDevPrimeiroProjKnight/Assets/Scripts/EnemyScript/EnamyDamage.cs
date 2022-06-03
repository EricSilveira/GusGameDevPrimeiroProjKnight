/***================== Indice do codigo para entendimento ====================***/
/*** 1.0   - Dano recebido do player                                          ***/
/*****                                                                        ***/
/**================== Fim Indice do codigo para entendimento =================***/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnamyDamage : MonoBehaviour
{
    //1.0   - Para colocar o objeto da unity text
    public GameObject damageText;

    //1.0   - Neste caso o metodo sera chamado pela classe PlayerAttack com o valor e criara o objeto de damage e enviara o valor para a classe DamageText
    public void EnemyHit(string value)
    {
        if (damageText != null){
            //1.0   - Para clonar o objeto do texto na posicao do inimigo e  
            var damage = Instantiate(damageText, transform.position, Quaternion.identity);
            //1.0   - Ele chama a funcao com o valor que vem na entrada do metodo
            damage.SendMessage("SetText", value);
        }
    }
}
