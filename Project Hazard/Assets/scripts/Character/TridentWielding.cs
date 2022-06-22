using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TridentWielding : BaseStats

{

    public float atkMultiplier = 0.9f;

    public float tridSwingDmg;

    void Start()
    {
        tridSwingDmg = BaseAttack * atkMultiplier;
    }



}
