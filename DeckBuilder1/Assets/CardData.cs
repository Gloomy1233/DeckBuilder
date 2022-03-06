using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardData : MonoBehaviour
{
    public string name;
    public string rarity;
    public string link;
    public int hp;
    public string type;

    private void Update()
    {
        gameObject.GetComponent<SimpleTooltip>().infoLeft ="Card Name: " +name+"\n"+"Card Rarity: "+rarity+"\n"+"Card Hitpoints: "+hp;
        
    }
}
