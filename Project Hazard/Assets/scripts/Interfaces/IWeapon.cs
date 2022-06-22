using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon{
    List<BaseStats> Stats {get; set;}
    void PerformAttack();

}

