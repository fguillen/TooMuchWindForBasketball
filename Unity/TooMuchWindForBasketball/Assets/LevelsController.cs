using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable] public class Level
{
    [SerializeField] string name;
    [SerializeField] public Vector2 leavesSpawnerTimeFrequency;
    [SerializeField] public Vector2 bsrSpawnerTimeFrequency;
    [SerializeField] public Vector2 peopleSpawnerTimeFrequency;
    [SerializeField] public Vector2 carsSpawnerTimeFrequency;
    [SerializeField] public Vector2 ubahnSpawnerTimeFrequency;
    [SerializeField] public Vector2 windForce;
    [SerializeField] public bool leavesOnCameraEnabled;
    [SerializeField] public bool buildingsWindTargetEnabled;
    [SerializeField] public bool basketWindTargetEnabled;
}

public class LevelsController : MonoBehaviour
{
    [SerializeField] LeavesSpawnerController[] leavesSpawners;
    [SerializeField] LeavesSpawnerController[] bsrSpawners;
    [SerializeField] LeavesSpawnerController[] peopleSpawners;
    [SerializeField] LeavesSpawnerController[] carsSpawners;
    [SerializeField] LeavesSpawnerController[] ubahnSpawners;
    [SerializeField] WindController windController;
    [SerializeField] BuildingController[] buildingControllers;
    [SerializeField] BasketController basketController;
    [SerializeField] int levelIndex;
    [SerializeField] Level level0;
    [SerializeField] Level level1;
    [SerializeField] Level level2;
    [SerializeField] Level level3;
    [SerializeField] Level level4;
    [SerializeField] Level level5;
    [SerializeField] Level level6;
    [SerializeField] Level level7;
    [SerializeField] Level level8;
    [SerializeField] Level level9;
    [SerializeField] Level level10;
    [SerializeField] Level level11;
    [SerializeField] Level level12;
    [SerializeField] Level level13;

    Level actualLevel;

    Level[] levels;

    bool isInitialized;


    void Awake()
    {
        print("Awake");
        levels = new Level[] { level0, level1, level2, level3, level4, level5, level6, level7, level8, level9, level10, level11, level12, level13 };
        isInitialized = true;
    }

    void Start()
    {
        print("Start");
        SetLevel(0);
    }

    void OnValidate()
    {
        print("OnValidate");

        if(isInitialized)
        {
            print("OnValidate in");
            SetLevel(levelIndex);
        }
    }

    void SetLevel(int level)
    {
        this.levelIndex = level;
        print("levelIndex: " + this.levelIndex);
        actualLevel = levels[this.levelIndex];

        SetSpawnersFrequency(leavesSpawners, actualLevel.leavesSpawnerTimeFrequency);
        SetSpawnersFrequency(bsrSpawners, actualLevel.bsrSpawnerTimeFrequency);
        SetSpawnersFrequency(peopleSpawners, actualLevel.peopleSpawnerTimeFrequency);
        SetSpawnersFrequency(carsSpawners, actualLevel.carsSpawnerTimeFrequency);
        SetSpawnersFrequency(ubahnSpawners, actualLevel.ubahnSpawnerTimeFrequency);

        windController.SetForceLimits(actualLevel.windForce.x, actualLevel.windForce.y);

        SetBuildingsWindTargetEnabled(buildingControllers, actualLevel.buildingsWindTargetEnabled);
        SetBasketWindTargetEnabled(basketController, actualLevel.basketWindTargetEnabled);

        LeavesOnTheCameraController.instance.SetActive(actualLevel.leavesOnCameraEnabled);
    }

    void SetSpawnersFrequency(LeavesSpawnerController[] spawnerControllers, Vector2 frequency)
    {
        foreach (var spawnerController in spawnerControllers)
        {
            spawnerController.SetFrequency(frequency.x, frequency.y);
        }
    }

    void SetBuildingsWindTargetEnabled(BuildingController[] buildingControllers, bool value)
    {
        foreach (var buildingController in buildingControllers)
        {
            buildingController.WindTargetEnabled(value);
        }
    }

    void SetBasketWindTargetEnabled(BasketController basketController, bool value)
    {
        basketController.WindTargetEnabled(value);
    }
}
