using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameMan : MonoBehaviour
{
    public int day;
    public float time;
    public bool nightTime;
    public bool raining;
    public int travelLocations1;
    public int travelLocations2;
    public bool travelLocations1Hidden;
    public bool travelLocations2Hidden;
    public int travelLocations1Distance;
    public int travelLocations2Distance;
    //forraged items
    public int woodInventory;
    public int puddleInventory;
    public int bugsInventory;
    public int unknownBerriesInventory;
    public int edibleBerriesInventory;
    public int nonPotableWaterInventory;
    public int tinderInventory;
    public int baitInventory;
    public int vineInventory;
    public int smallFishInventory;
    public int bigFishInventory;
    public int smallGameInventory;
    public int bigGameInventory;
    public int smallCookedMeat;
    public int largeCookedMeat;
    public int cleanWaterInventory;
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
    public bool spikePlaced;
    public bool rainCatcherPlaced;
    //Shelter
    public int shelterType;
    public float shelterCondition;
    //Fire
    public float fireTimeRemaining;
    public Image campFireFlame;
    //Other
    public int emptyWaterBottlesInventory;
    public int candyBar;


    //Weights

    public float maxWeight;
    public float currentWeight;
    public float bugsWeight = 0.5f;
    public float edibleBerriesWeight = 0.5f;
    public float unknownBerriesWeight = 0.5f;
    public float tinderWeight = 0.2f;
    public float baitWeight = 0.1f;
    public float emptyWaterBottleWeight = 0.1f;
    public float fishingRodWeight = 3;
    public float fishingHookWeight = 0.2f;
    public float spearWeight = 2;
    public float matchesWeight = 0.1f;
    public float trashBagWeight = 0.5f;
    public float clothWeight = 0.5f;
    public float mapWeight = 0.5f;
    public float axeWeight = 3;
    public float smallFishWeight = 0.2f;
    public float smallCookedMeatWeight = 0.2f;
    public float bigGameWeight = 10;
    public float lighterWeight = 0.2f;
    public float candyBarWeight = 0.2f;

    //Backgrounds
    public Image mainCanvasBackground;
    public Image findCanvasBackground;
    public Image huntCanvsBackground;
    public Image craftCanvasBackground;
    public Image fireCanvasBackground;
    public Image shelterCanvasBackground;
    public Image inventoryCanvasBackground;
    public Image travelCanvasBackground;
    public Image waitCanvasBackground;
    public Image notificationBackground;
    


    public int totalItems;
    public float condition;
    public float hydration;
    public float hunger;
    public float bodyheat;
    public bool sleeping;

    public List <string> location = new List<string>();
    public string locationString;

    public Canvas rainCanvas;
    public MainCanvasButtons mainCanvasButtons;
    public TravelCanvas travelCanvas;
    public AudioManager audioManager;
    public Canvas notificationCanvas2;
    public Canvas perkItemCanvas;
    public Canvas waitCanvas;
    public Canvas deathCanvas;
    public Canvas survivedCanvas;
    public FireCanvas fireCanvasGO;
    public SurvivedCanvas survivedCanvasGO;
    public DeathCanvas deathCanvasGameObject;
    public HUD hud;
    //Wait Canvas dots
    public Image waitDot1;
    public Image waitDot2;
    public Image waitDot3;
    public TextMeshProUGUI notificationText2;
    //HUD
    public TextMeshProUGUI shelterTypeText;
    public TextMeshProUGUI shelterConditionText;
    public TextMeshProUGUI WeightText;
    public TextMeshProUGUI traps;
    public TextMeshProUGUI hudWood;
    public TextMeshProUGUI hudTinder;
    public TextMeshProUGUI hudWater;
    public TextMeshProUGUI hudNonPotableWaterText;
    public TextMeshProUGUI hudBait;
    public TextMeshProUGUI notificationText;
    public TextMeshProUGUI waitText;
    //Find Canvas;
    public int exploreAreaCount;
    public int gatherWoodCount;
    public bool exploreArea100;
    public bool gatherWood100;
    public int travelCount;
    public int endTravel;
    public int endDay;
    public bool wasNight;
    public int BGM;
    public bool mute;
    public bool muteMusic;
    public bool unmute;

    public float sickness;

    public Sprite[] backgrounds;
    public int locationNumber;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        BGM = 5;
        unmute = false;
        mute = false;
        audioManager.mute = false;
        unmute = true;
        sleeping = false;
        //change max weight after debugging
        maxWeight = 17;
        location.Add("crash site");
        location.Add("windy plateau");
        location.Add("clearing");
        location.Add("cave");
        location.Add("mountain top");
        location.Add("creek");
        location.Add("large river");
        location.Add("jungle");
        location.Add("valley");
        location.Add("large lake");
        LoadPlayer();
        if (locationNumber != 0)
        {
            SetBackgrounds();
        }
        if (nightTime == false)
        {
            wasNight = true;
        }
        else
        {
            wasNight = false;
        }
        UpdateStats();
        if(nightTime == true)
        {
            wasNight = true;
        }
        else
        {
            wasNight = false;
        }
        fireCanvasGO.ResetItems();
        audioManager.Stop("MenuBGM");
    }
    public void StartingLoot()
    {
        //Guaranteed Items
        cleanWaterInventory += 2;
        //Random Items
        int rand1 = Random.Range(0,3);
        int rand2 = Random.Range(0, 3);
        if (rand1 == 0)
        {
            cleanWaterInventory += 1;
        }
        if(rand1 == 1)
        {
            candyBar += 1;
        }
        if(rand1 == 2)
        {
            trashBagInventory += 1;
        }
        if (rand2 == 0)
        {
            cleanWaterInventory += 1;
        }
        if (rand2 == 1)
        {
            candyBar += 1;
        }
        if (rand2 == 2)
        {
            trashBagInventory += 1;
        }
    }
    //changes notification text to green
    public void Pos()
    {
        notificationText.color = new Color32(2, 138, 15, 255);
    }
    //changes notification text to red
    public void Neg()
    {
        notificationText.color = new Color32(185, 14, 10, 255);
    }
    public IEnumerator WaitScreen()
    {
        waitCanvas.enabled = true;
        yield return new WaitForSeconds(0.1f);
        waitDot1.enabled = true;
        yield return new WaitForSeconds(.3f);
        waitDot2.enabled = true;
        yield return new WaitForSeconds(.3f);
        waitDot3.enabled = true;
        yield return new WaitForSeconds(.3f);
        waitDot1.enabled = false;
        waitDot2.enabled = false;
        waitDot3.enabled = false;
        waitCanvas.enabled = false;
    }
    public void SetBackgrounds()
    {
        mainCanvasBackground.GetComponent<Image>().sprite = backgrounds[locationNumber];
        findCanvasBackground.GetComponent<Image>().sprite = backgrounds[locationNumber];
        huntCanvsBackground.GetComponent<Image>().sprite = backgrounds[locationNumber];
        craftCanvasBackground.GetComponent<Image>().sprite = backgrounds[locationNumber];
        fireCanvasBackground.GetComponent<Image>().sprite = backgrounds[locationNumber];
        shelterCanvasBackground.GetComponent<Image>().sprite = backgrounds[locationNumber];
        inventoryCanvasBackground.GetComponent<Image>().sprite = backgrounds[locationNumber];
        travelCanvasBackground.GetComponent<Image>().sprite = backgrounds[locationNumber];
    }
    public void AddTime(float timeToAdd)
    {
        waitText.text = timeToAdd.ToString() + " hr";
        StartCoroutine(WaitScreen());
        //RAIN
        if (raining == false)
        {
            if(Random.Range(0,72) == 1)
            {
                raining = true;
            }
        }
        else if (raining == true)
        {
            if(Random.Range(0,12) == 1)
            {
                raining = false;
            }
        }
        //TIME
        time = time + timeToAdd;
        if (time > 24)
        {
            time = time - 24;
            day++;
        }
        //HYDRATION
        hydration = hydration - 3 * timeToAdd;
        //HUNGER
        hunger = hunger - 1 * timeToAdd;
        //BODYHEAT
        float bodyheatMultiplier = 0;
        if (nightTime == true)
        {
            bodyheatMultiplier = bodyheatMultiplier + 3 * timeToAdd;
        }
        if(raining == true)
        {
            bodyheatMultiplier = bodyheatMultiplier + 3 * timeToAdd;
        }
        if(shelterCondition >= 25)
        {
            bodyheatMultiplier = bodyheatMultiplier - 3 * timeToAdd;
        }
        if (shelterCondition > 50)
        {
            bodyheatMultiplier = bodyheatMultiplier - 3 * timeToAdd;
        }
        if(fireTimeRemaining > 0)
        {
            bodyheatMultiplier = bodyheatMultiplier - 3 * timeToAdd;
        }
        bodyheat = bodyheat - bodyheatMultiplier;
        //Checks to make sure bodyheat doesn't go over 100
        if(bodyheat >= 100)
        {
            bodyheat = 100;
        }
        //SHELTER
        if(shelterCondition > 0)
        {
            if (shelterType == 1)
            {
                shelterCondition = shelterCondition - 2 * timeToAdd;
            }
            else if (shelterType == 2)
            {
                shelterCondition = shelterCondition - timeToAdd;
            }
        }
        else
        {
            shelterCondition = 0;
        }
        //FIRE
        if(fireTimeRemaining > 0)
        {
            fireTimeRemaining -= timeToAdd;
            if (fireTimeRemaining < 0)
            {
                fireTimeRemaining = 0;
            }
        }
        //CONDITION
        float conditionMultiplier = 0;
        if (hydration <= 0)
        {
            conditionMultiplier = conditionMultiplier + 2;
        }
        if(hunger <= 0)
        {
            conditionMultiplier = conditionMultiplier + 1;
        }
        if(bodyheat <= 0)
        {
            conditionMultiplier = conditionMultiplier + 2;
        }
        condition = condition - conditionMultiplier * timeToAdd;
        //TRAPS
        if (snarePlaced == true)
        {
            for (int i = 0; i < (int)timeToAdd; i++)
            {
                int rand = Random.Range(0, 13);
                if (rand == 1)
                {
                    //Caught small game with Trap (add sound)
                    notificationCanvas2.enabled = true;
                    notificationText2.text = "Caught small game with snare trap";
                    smallGameInventory += 1;
                }
            }
        }
        if(spikePlaced == true)
        {
            for(int i = 0; i < (int)timeToAdd; i++)
            {
                int rand = Random.Range(0, 169);
                if(rand == 1)
                {
                    //Caught big game with trap (add sound)
                    notificationCanvas2.enabled = true;
                    notificationText2.text = "Caught big game with spike trap";
                    bigGameInventory += 1;
                }
            }
        }
        //SLEEPING
        if (sleeping == true && hunger > 0 && hydration > 0 && sickness <= 0)
        {
            if(bodyheat > 0 || bodyheatMultiplier <= 0)
            {
                condition += 3 * timeToAdd;
            }
        }
        //SICKNESS
        if(sickness > 0 && sleeping == true)
        {
            sickness -= timeToAdd;
        }
        //ENDING
        if (day >= endDay)
        {
            survivedCanvas.enabled = true;
            StartCoroutine(survivedCanvasGO.SurvivedButtonDelay(true));
        }
        else if (travelCount >= endTravel)
        {
            survivedCanvas.enabled = true;
            StartCoroutine(survivedCanvasGO.SurvivedButtonDelay(false));
        }
        UpdateStats();
    }
    //SICKNESS
    public void Sick()
    {
        sickness = 8;
        hunger = 0;
        notificationCanvas2.enabled = true;
        notificationText2.text = "You got sick. Rest for 8 hours to recover";
    }
    public void UpdateStats()
    {
        if(time < 5 || time > 19)
        {
            nightTime = true;
        }
        else
        {
            nightTime = false;
        }
        if(raining == true)
        {
            rainCanvas.enabled = true;
            audioManager.Play("Rain");
        }
        else if (raining == false)
        {
            rainCanvas.enabled = false;
            audioManager.Stop("Rain");
        }
        if(condition <= 0)
        {
            deathCanvas.enabled = true;
            StartCoroutine(deathCanvasGameObject.DeathButtonDelay());
            condition = 0;
        }
        if(condition > 100)
        {
            condition = 100;
        }
        if(hydration <= 0)
        {
            hydration = 0;
        }
        if (hydration > 100)
        {
            hydration = 100;
        }
        if(hunger <= 0)
        {
            hunger = 0;
        }
        if(hunger > 100)
        {
            hunger = 100;
        }
        if(bodyheat <= 0)
        {
            bodyheat = 0;
        }
        if(bodyheat > 100)
        {
            bodyheat = 100;
        }
        if(fireTimeRemaining > 0)
        {
            campFireFlame.enabled = true;
            audioManager.Play("Fire");
        }
        else
        {
            campFireFlame.enabled = false;
            audioManager.Stop("Fire");
        }
        //DARKNESS
        if (nightTime == true)
        {
            if (unmute == true || wasNight == false && mute == false)
            {
                audioManager.Play("NightBackgroundSounds");
                audioManager.Stop("DayBackgroundSounds");
                unmute = false;
                wasNight = true;
            }
            mainCanvasBackground.GetComponent<Image>().color = new Color32(40, 40, 40, 255);
            findCanvasBackground.GetComponent<Image>().color = new Color32(40, 40, 40, 255);
            huntCanvsBackground.GetComponent<Image>().color = new Color32(40, 40, 40, 255);
            craftCanvasBackground.GetComponent<Image>().color = new Color32(40, 40, 40, 255);
            fireCanvasBackground.GetComponent<Image>().color = new Color32(40, 40, 40, 255);
            shelterCanvasBackground.GetComponent<Image>().color = new Color32(40, 40, 40, 255);
            inventoryCanvasBackground.GetComponent<Image>().color = new Color32(40, 40, 40, 255);
            travelCanvasBackground.GetComponent<Image>().color = new Color32(40, 40, 40, 255);
        }
        else if(time == 19 || time == 5)
        {
            mainCanvasBackground.GetComponent<Image>().color = new Color32(100, 100, 100, 255);
            findCanvasBackground.GetComponent<Image>().color = new Color32(100, 100, 100, 255);
            huntCanvsBackground.GetComponent<Image>().color = new Color32(100, 100, 100, 255);
            craftCanvasBackground.GetComponent<Image>().color = new Color32(100, 100, 100, 255);
            fireCanvasBackground.GetComponent<Image>().color = new Color32(100, 100, 100, 255);
            shelterCanvasBackground.GetComponent<Image>().color = new Color32(100, 100, 100, 255);
            inventoryCanvasBackground.GetComponent<Image>().color = new Color32(100, 100, 100, 255);
            travelCanvasBackground.GetComponent<Image>().color = new Color32(100, 100, 100, 255);
        }
        else if(time == 18 || time == 6)
        {
            mainCanvasBackground.GetComponent<Image>().color = new Color32(150, 150, 150, 255);
            findCanvasBackground.GetComponent<Image>().color = new Color32(150, 150, 150, 255);
            huntCanvsBackground.GetComponent<Image>().color = new Color32(150, 150, 150, 255);
            craftCanvasBackground.GetComponent<Image>().color = new Color32(150, 150, 150, 255);
            fireCanvasBackground.GetComponent<Image>().color = new Color32(150, 150, 150, 255);
            shelterCanvasBackground.GetComponent<Image>().color = new Color32(150, 150, 150, 255);
            inventoryCanvasBackground.GetComponent<Image>().color = new Color32(150, 150, 150, 255);
            travelCanvasBackground.GetComponent<Image>().color = new Color32(150, 150, 150, 255);
        }
        else
        {
            if(unmute == true ||wasNight == true && mute == false)
            {
                audioManager.Play("DayBackgroundSounds");
                audioManager.Stop("NightBackgroundSounds");
                unmute = false;
                wasNight = false;
            }
            mainCanvasBackground.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            findCanvasBackground.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            huntCanvsBackground.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            craftCanvasBackground.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            fireCanvasBackground.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            shelterCanvasBackground.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            inventoryCanvasBackground.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            travelCanvasBackground.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            notificationBackground.GetComponent<Image>().color = new Color32(85, 72, 64, 255);
        }
        //HUD
        hudWood.text = woodInventory.ToString();
        hudTinder.text = tinderInventory.ToString();
        hudWater.text = cleanWaterInventory.ToString();
        hudBait.text = baitInventory.ToString();
        hudNonPotableWaterText.text = nonPotableWaterInventory.ToString();
        if (shelterType == 0)
        {
            shelterTypeText.text = "None";
        }
        else if (shelterType == 1)
        {
            shelterTypeText.text = "Lean To";

        }
        else if (shelterType == 2)
        {
            shelterTypeText.text = "A-Frame";
        }
        if(snarePlaced == true && spikePlaced == true)
        {
            traps.text = "Snare, Spikepit";
        }
        else if(snarePlaced == true)
        {
            traps.text = "Snare";
        }
        else if(spikePlaced == true)
        {
            traps.text = "Spikepit";
        }
        else
        {
            traps.text = "None";
        }
        //BGM
        //BadBGM
        if(condition <= 50 && BGM != 1 && BGM != 4)
        {
            audioManager.Play("BadBGM");
            audioManager.Stop("MediumBGM");
            audioManager.Stop("GoodBGM");
            BGM = 1;
        }
        else if(condition > 50 && condition < 100 && BGM != 2 && BGM != 4)
        {
            audioManager.Stop("BadBGM");
            audioManager.Play("MediumBGM");
            audioManager.Stop("GoodBGM");
            BGM = 2;
        }
        else if(condition >= 100 && BGM != 3 && BGM != 4)
        {
            audioManager.Stop("BadBGM");
            audioManager.Stop("MediumBGM");
            audioManager.Play("GoodBGM");
            BGM = 3;
        }
        else if(BGM == 4)
        {
            audioManager.Stop("BadBGM");
            audioManager.Stop("MediumBGM");
            audioManager.Stop("GoodBGM");
        }
        shelterConditionText.text = shelterCondition.ToString() + "%";
        CheckWeight();
        if (largeBackpackInventory > 0)
        {
            maxWeight = 25;
        }
        WeightText.text = currentWeight + "/" + maxWeight + "kg";
        hud.locationText.text = locationString;
        hud.daysSurvived.text = day.ToString();
        hud.SetCondition((int)condition);
        hud.SetHydration((int)hydration);
        hud.SetHunger((int)hunger);
        hud.SetBodyheat((int)bodyheat);
        SavePlayer();
    }
    public void StopAllSounds()
    {
        audioManager.Stop("Rain");
        audioManager.Stop("NightBackgroundSounds");
        audioManager.Stop("DayBackgroundSounds");
        BGM = 4;
        audioManager.Stop("BadBGM");
        audioManager.Stop("MediumBGM");
        audioManager.Stop("GoodBGM");
        audioManager.Stop("Fire");
    }
    public void CheckWeight()
    {
        currentWeight = 0;
        currentWeight = woodInventory + nonPotableWaterInventory +vineInventory + ropeInventory + handDrillInventory + bowDrillInventory + cablesInventory + MREInventory + bugsWeight * bugsInventory + edibleBerriesWeight * edibleBerriesInventory + unknownBerriesWeight * unknownBerriesInventory + tinderWeight * tinderInventory + baitWeight * baitInventory + emptyWaterBottleWeight * emptyWaterBottlesInventory + fishingRodWeight * fishingRodInventory + fishingHookWeight * fishingHookInventory + spearInventory * spearWeight + snareInventory + matchesWeight * matchesInventory + trashBagWeight * trashBagInventory + clothWeight * clothInventory + mapWeight * mapInventory + axeWeight * axeInventory + smallFishInventory * smallFishWeight + bigFishInventory + smallGameInventory + bigGameInventory * bigGameWeight + smallCookedMeat * smallCookedMeatWeight + largeCookedMeat + cleanWaterInventory + lighterInventory * lighterWeight + candyBar * candyBarWeight;
}

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        if (data != null)
        {
            time = data.time;
            day = data.day;
            woodInventory = data.woodInventory;
            condition = data.condition;
            hydration = data.hydration;
            hunger = data.hunger;
            bodyheat = data.bodyheat;
            raining = data.raining;
            puddleInventory = data.puddleInventory;
            bugsInventory = data.bugsInventory;
            unknownBerriesInventory = data.unknownBerriesInventory;
            edibleBerriesInventory = data.edibleBerriesInventory;
            nonPotableWaterInventory = data.nonPotableWaterInventory;
            cleanWaterInventory = data.cleanWaterInventory;
            baitInventory = data.baitInventory;
            tinderInventory = data.tinderInventory;
            emptyWaterBottlesInventory = data.emptyWaterBottlesInventory;
            candyBar = data.candyBar;
            vineInventory = data.vineInventory;
            smallFishInventory = data.smallFishInventory;
            bigFishInventory = data.bigFishInventory;
            smallGameInventory = data.smallGameInventory;
            bigGameInventory = data.bigGameInventory;
            smallCookedMeat = data.smallCookedMeat;
            largeCookedMeat = data.largeCookedMeat;
            ropeInventory = data.ropeInventory;
            handDrillInventory = data.handDrillInventory;
            bowDrillInventory = data.bowDrillInventory;
            fishingRodInventory = data.fishingRodInventory;
            fishingHookInventory = data.fishingHookInventory;
            spearInventory = data.spearInventory;
            snareInventory = data.snareInventory;
            matchesInventory = data.matchesInventory;
            trashBagInventory = data.trashBagInventory;
            clothInventory = data.clothInventory;
            mapInventory = data.mapInventory;
            cablesInventory = data.cablesInventory;
            lighterInventory = data.lighterInventory;
            MREInventory = data.MREInventory;
            largeBackpackInventory = data.largeBackpackInventory;
            axeInventory = data.axeInventory;
            snareTrap = data.snareTrap;
            spikeTrap = data.spikeTrap;
            snarePlaced = data.snarePlaced;
            rainCatcherPlaced = data.rainCatcherPlaced;
            spikePlaced = data.spikePlaced;

            shelterCondition = data.shelterCondition;
            shelterType = data.shelterType;

            fireTimeRemaining = data.fireTimeRemaining;

            locationString = data.locationString;
            
            travelLocations1 = data.travelLocations1;
            travelLocations2 = data.travelLocations2;
            travelLocations1Hidden = data.travelLocations1Hidden;
            travelLocations2Hidden = data.travelLocations2Hidden;
            travelLocations1Distance = data.travelLocations1Distance;
            travelLocations2Distance = data.travelLocations2Distance;
            locationNumber = data.locationNumber;

            exploreAreaCount = data.exploreAreaCount;
            gatherWoodCount = data.gatherWoodCount;
            exploreArea100 = data.exploreArea100;
            gatherWood100 = data.gatherWood100;
            endDay = data.endDay;
            endTravel = data.endTravel;
            travelCount = data.travelCount;

            sickness = data.sickness;

            hud.SetCondition(data.condition);
            hud.SetHydration(data.hydration);
            hud.SetHunger(data.hunger);
            hud.SetBodyheat(data.bodyheat);
            locationString = data.locationString;
            hud.SetLocation();
            if (raining == true)
            {
                rainCanvas.enabled = true;
            }
            else if (raining == false)
            {
                rainCanvas.enabled = false;
            }
        }
        else
        {
            //If no save file exists
            time = 9;
            wasNight = false;
            mute = false;
            muteMusic = false;
            day = 0;
            endDay = Random.Range(30, 60);
            endTravel = Random.Range(25, 50);
            condition = 100;
            hydration = 100;
            hunger = 100;
            bodyheat = 100;
            sickness = 0;
            hud.SetMaxCondition(condition);
            hud.SetMaxHydration(hydration);
            hud.SetMaxHunger(hunger);
            hud.SetMaxBodyheat(bodyheat);
            travelCanvas.GenerateTraveLocations();
            locationString = location[0];
            snarePlaced = false;
            spikePlaced = false;
            rainCatcherPlaced = false;
            hud.SetLocation();
            raining = false;
            mainCanvasButtons.enabled = false;
            perkItemCanvas.enabled = true;
            locationNumber = 0;
        }
    }
}
