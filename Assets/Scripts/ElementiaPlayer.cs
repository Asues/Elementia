///<summary>
///Team Work for Game Development Project from MT Students
///Awais Khan, Cesar Quintero Arias, Hong Ma, Sebastian Ribecky
///Coded by Hong Ma
///Email: hong.ma@tu-ilmenau.de
///2019.01.31, TU Ilmenau, Germany
///</summary>
using System.Collections.Generic;
using UnityEngine;

public class ElementiaPlayer : MonoBehaviour {
    public int HP = 400;                                                                            // current hp, will change every attack round
    public int StartHp = 400;                                                                      // HP + Monster HP, when player don't pick new attacking monster, it will const
    public bool IsMyTurn = false;                                                                //  tirgger, whether this round belongs to player
    public bool IsChangingMonster = false;                                                  // tirgger, whether player is changing monster
    public int RemainingMonsters = 2;                                                        //  how many times that player can change his attacking monster
    public ElementiaMonster AttackMonster = new ElementiaDemoMonster();    // current attacking monster
    public List<ElementiaMonster> Monsters = new List<ElementiaMonster>();  // player selected monsters
}
