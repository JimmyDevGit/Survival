using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float time;
    public int day;
    public int woodInventory;
    public int puddleInventory;
    public int bugsInventory;
    public int unknownBerriesInventory;
    public int edibleBerriesInventory;
    public int nonPotableWaterInventory;
    public int cleanWaterInventory;
    public int baitInventory;
    public int tinderInventory;
    public int vineInventory;
    public int smallFishInventory;
    public int bigFishInventory;
    public int smallGameInventory;
    public int bigGameInventory;
    public int smallCookedMeat;
    public int largeCookedMeat;
    //harvested items
    public int ropeInventory;
    //crafted items
    public int handDrillInventory;
    public int bowDrillInventory;
    public int fishingRodInventory;
    public int fishingHookInventory;
    public int spearInventory;
    public int snareInventory;
    //crash/camp items
    public int matchesInventory;
    public int trashBagInventory;
    public int clothInventory;
    public int mapInventory;
    public int cablesInventory;
    //Perk items
    public int lighterInventory;
    public int MREInventory;
    public int largeBackpackInventory;
    public int axeInventory;
    //Traps
    public int snareTrap;
    public int spikeTrap;
    public bool snarePlaced;
    public bool rainCatcherPlaced;
    public bool spikePlaced;
    //Shelter
    public int shelterType;
    public float shelterCondition;

    public float fireTimeRemaining;

    public int emptyWaterBottlesInventory;
    public int candyBar;

    public int travelLocations1;
    public int travelLocations2;
    public bool travelLocations1Hidden;
    public bool travelLocations2Hidden;
    public int travelLocations1Distance;
    public int travelLocations2Distance;
    public int locationNumber;

    public int exploreAreaCount;
    public int gatherWoodCount;
    public bool exploreArea100;
    public bool gatherWood100;
    public int travelCount;
    public int endDay;
    public int endTravel;

    public string locationString;
    public float condition;
    public float hydration;
    public float hunger;
    public float bodyheat;
    public bool raining;
    public float sickness;

    public PlayerData(GameMan player)
    {
        time = player.time;
        day = player.day;
        woodInventory = player.woodInventory;

        locationString = player.locationString;
        condition = player.condition;
        hunger = player.hunger;
        hydration = player.hydration;
        bodyheat = player.bodyheat;
        puddleInventory = player.puddleInventory;
        bugsInventory = player.bugsInventory;
        unknownBerriesInventory = player.unknownBerriesInventory;
        edibleBerriesInventory = player.edibleBerriesInventory;
        nonPotableWaterInventory = player.nonPotableWaterInventory;
        cleanWaterInventory = player.cleanWaterInventory;
        baitInventory = player.baitInventory;
        tinderInventory = player.tinderInventory;
        vineInventory = player.vineInventory;
        smallFishInventory = player.smallFishInventory;
        bigFishInventory = player.bigFishInventory;
        smallGameInventory = player.smallGameInventory;
        bigGameInventory = player.bigGameInventory;
        smallCookedMeat = player.smallCookedMeat;
        largeCookedMeat = player.largeCookedMeat;
        ropeInventory = player.ropeInventory;
        handDrillInventory = player.handDrillInventory;
        bowDrillInventory = player.bowDrillInventory;
        fishingRodInventory = player.fishingRodInventory;
        fishingHookInventory = player.fishingHookInventory;
        spearInventory = player.spearInventory;
        snareInventory = player.snareInventory;
        snarePlaced = player.snarePlaced;
        rainCatcherPlaced = player.rainCatcherPlaced;
        spikePlaced = player.spikePlaced;
        matchesInventory = player.matchesInventory;
        trashBagInventory = player.trashBagInventory;
        clothInventory = player.clothInventory;
        mapInventory = player.mapInventory;
        cablesInventory = player.cablesInventory;
        lighterInventory = player.lighterInventory;
        MREInventory = player.MREInventory;
        largeBackpackInventory = player.largeBackpackInventory;
        axeInventory = player.axeInventory;
        snareTrap = player.snareTrap;
        spikeTrap = player.spikeTrap;
        shelterType = player.shelterType;
        shelterCondition = player.shelterCondition;
        fireTimeRemaining = player.fireTimeRemaining;

        emptyWaterBottlesInventory = player.emptyWaterBottlesInventory;
        candyBar = player.candyBar;

        travelLocations1 = player.travelLocations1;
        travelLocations2 = player.travelLocations2;
        travelLocations1Hidden = player.travelLocations1Hidden;
        travelLocations2Hidden = player.travelLocations2Hidden;
        travelLocations1Distance = player.travelLocations1Distance;
        travelLocations2Distance = player.travelLocations2Distance;
        locationNumber = player.locationNumber;

        gatherWoodCount = player.gatherWoodCount;
        exploreAreaCount = player.exploreAreaCount;
        gatherWood100 = player.gatherWood100;
        exploreArea100 = player.exploreArea100;
        travelCount = player.travelCount;
        endDay = player.endDay;
        endTravel = player.endTravel;

        raining = player.raining;
        sickness = player.sickness;
    }
}
