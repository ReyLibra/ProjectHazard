using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem:MonoBehaviour {


public int AttributePoints;



public int XP;
public int currentLevel;


public void Update()

{
    OnKillDrone();
    OnKillTank();
}

public void OnKillTank()
{
  
  UpdateXpTank(5);  
  
}

public void OnKillDrone()
{
  UpdateXpDrone(5);
    
}

public void UpdateXpDrone(int xp)
{
XP += xp;
int curlvl = (int)(0.1f * Mathf.Sqrt(XP));

if(curlvl != currentLevel)
{
    currentLevel = curlvl;
    
}

int xpNextLevel = 100 * (currentLevel + 1) * (currentLevel +1);
int differenceXP = xpNextLevel - (100 * currentLevel * currentLevel);


}

public void UpdateXpTank(int xp)
{
XP += xp;
int curlvl = (int)(0.1f * Mathf.Sqrt(XP));

if(curlvl != currentLevel)
{
    currentLevel = curlvl;
}

int xpNextLevel = 100 * (currentLevel + 1) * (currentLevel +1);
int differenceXP = xpNextLevel - (100 * currentLevel * currentLevel);


}
}