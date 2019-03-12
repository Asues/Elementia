///<summary>
///Team Work for Game Development Project from MT Students
///Awais Khan, Cesar Quintero Arias, Hong Ma, Sebastian Ribecky
///Coded by Hong Ma
///Email: hong.ma@tu-ilmenau.de
///2019.01.31, TU Ilmenau, Germany
///</summary>
using Vuforia;
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Gloabal values for different use
/// </summary>
public class GlobalValues : MonoBehaviour {

    public bool TestModule = false;     // should off, other weise every coin toss will the player(who last finish pick monsters) win
    public static GlobalValues Instance;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(Instance);
    }

    /// <summary>
    /// Get the trackable Image with vuforia
    /// </summary>
    /// <returns>The first trackable image.</returns>
    public TrackableBehaviour GetFirstTrackableImage()
    {
        StateManager sm = TrackerManager.Instance.GetStateManager();

        // Query the StateManager to retrieve the list of
        // currently 'active' trackables
        //(i.e. the ones currently being tracked by Vuforia)
        IEnumerable<TrackableBehaviour> activeTrackables = sm.GetActiveTrackableBehaviours();

        foreach (TrackableBehaviour tb in activeTrackables)
        {
            // the trackable name ist the name of vuforia's card name
            // like the card name: FireDemon, this name must the same with the vufoira database card name
            return tb;
        }
        return null;
    }

    /// <summary>
    /// From the capture image to get the monster
    /// </summary>
    /// <returns>Elementia Monster</returns>
    /// <param name="monsterCard">Monster Card Image</param>
    public ElementiaMonster GetMonster(TrackableBehaviour monsterCard)
    {
        switch (monsterCard.TrackableName)
        {
            case ElementiaMonsterNames.FireDemon:
                return new ElementiaFireDemon();
            case ElementiaMonsterNames.Dragon:
                return new ElementiaDragon();
            case ElementiaMonsterNames.Whale:
                return new ElementiaWhale();
            case ElementiaMonsterNames.Elf:
                return new ElementiaElf();
            case ElementiaMonsterNames.Wizard:
                return new ElementiaWizzard();
            case ElementiaMonsterNames.Bee:
                return new ElementiaBee();
            case ElementiaMonsterNames.Skeleton:
                return new ElementiaSkeleton();
            case ElementiaMonsterNames.Mouse:
                return new ElementiaMouse();
            case ElementiaMonsterNames.Demo:
                return new ElementiaDemoMonster();
            default:
                return new ElementiaDemoMonster();
        }
    }
    
    /// <summary>
    /// Get Elementia monster
    /// </summary>
    /// <param name="name">monster name</param>
    /// <returns></returns>
    public ElementiaMonster GetMonster(string name)
    {
        switch (name)
        {
            case ElementiaMonsterNames.FireDemon:
                return new ElementiaFireDemon();
            case ElementiaMonsterNames.Dragon:
                return new ElementiaDragon();
            case ElementiaMonsterNames.Whale:
                return new ElementiaWhale();
            case ElementiaMonsterNames.Elf:
                return new ElementiaElf();
            case ElementiaMonsterNames.Wizard:
                return new ElementiaWizzard();
            case ElementiaMonsterNames.Bee:
                return new ElementiaBee();
            case ElementiaMonsterNames.Skeleton:
                return new ElementiaSkeleton();
            case ElementiaMonsterNames.Mouse:
                return new ElementiaMouse();
            case ElementiaMonsterNames.Demo:
                return new ElementiaDemoMonster();
            default:
                return new ElementiaDemoMonster();
        }
    }
}
