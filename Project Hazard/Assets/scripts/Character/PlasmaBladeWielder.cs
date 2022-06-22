using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaBladeWielder : BaseStats
{
    public float atkMultiplier = 0.4f;

    public float plasSwingDmg;

    void Start()
    {
        plasSwingDmg = baseAttack * atkMultiplier;
    }



}
