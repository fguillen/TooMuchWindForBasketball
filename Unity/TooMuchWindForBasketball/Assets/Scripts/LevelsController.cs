using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable] public class Level
{
    [SerializeField] public string name;
    [SerializeField] public Vector2 leavesSpawnerTimeFrequency;
    [SerializeField] public Vector2 bsrSpawnerTimeFrequency;
    [SerializeField] public Vector2 peopleSpawnerTimeFrequency;
    [SerializeField] public Vector2 carsSpawnerTimeFrequency;
    [SerializeField] public Vector2 ubahnSpawnerTimeFrequency;
    [SerializeField] public Vector2 windForce;
    [SerializeField] public bool leavesOnCameraEnabled;
    [SerializeField] public bool buildingsWindTargetEnabled;
    [SerializeField] public bool windIndicatorWindTargetEnabled;
    [SerializeField] public bool basketWindTargetEnabled;
    [SerializeField] public bool playerWindTargetEnabled;

    [SerializeField] public bool startEndScene;
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
    [SerializeField] WindIndicatorController windIndicatorController;
    [SerializeField] PlayerController playerController;
    [SerializeField] EndSceneController endSceneController;
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
    [SerializeField] Level level14;
    [SerializeField] Level level15;
        [SerializeField] Level level16;

    Level actualLevel;

    Level[] levels;

    bool isInitialized;


    void Awake()
    {
        print("Awake");
        levels = new Level[] { level0, level1, level2, level3, level4, level5, level6, level7, level8, level9, level10, level11, level12, level13, level14, level15, level16 };
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

        LeavesOnTheCameraController.instance.SetActive(actualLevel.leavesOnCameraEnabled);

        SetBuildingsWindTargetEnabled(buildingControllers, actualLevel.buildingsWindTargetEnabled);
        SetWindIndicatorWindTargetEnabled(windIndicatorController, actualLevel.windIndicatorWindTargetEnabled);
        SetBasketWindTargetEnabled(basketController, actualLevel.basketWindTargetEnabled);
        SetPlayerWindTargetEnabled(playerController, actualLevel.playerWindTargetEnabled);

        if(actualLevel.startEndScene)
            endSceneController.StartEndScene();

        CanvasController.instance.RenderLevelName(actualLevel.name);
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
            buildingController?.WindTargetEnabled(value);
        }
    }

    void SetBasketWindTargetEnabled(BasketController basketController, bool value)
    {
        basketController?.WindTargetEnabled(value);
    }

    void SetWindIndicatorWindTargetEnabled(WindIndicatorController windIndicatorController, bool value)
    {
        windIndicatorController?.WindTargetEnabled(value);
    }

    void SetPlayerWindTargetEnabled(PlayerController playerController, bool value)
    {
        playerController?.WindTargetEnabled(value);
    }
}
