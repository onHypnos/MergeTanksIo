using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Transaction
{
    public int Value;
    public GameObject WhoBuy;
    
    public AbstractPerk _perk;
    
    public void Perk(AbstractPerk perk) 
    {
        _perk = perk;
    }
    
}
