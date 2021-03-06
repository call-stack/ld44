﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameStateSO", menuName = "GameStateSO", order = 51)]
public class GameStateSO : ScriptableObject
{
    //default
    float moneyDefault = 400;
    float sceneDefault = 0;
    float jumpForceDefault = 800f;
    float maxJumpsDefault = 1;
    float walkForceDefault = 0.2f;
    float dashMaxDefault = 1;
    float dashTimeDefault = 0.12f;
    float dashSpeedDefault = 25f;
    float chestPriceDefault = 221f;

    public GameObject prefabMelee;
    public GameObject prefabTurret;
    public GameObject prefabCreeper;

    public GameObject prefabBonus;
    public GameObject prefabBullet;

    public float moneyCurrent = 0;
    public float sceneCurrent = 0;

    //another settings

    public float chestPrice = 190;

    //testScene
    public float pauseBeforeWave = 3f;
    public float pauseBeforeSpawnMin = 1f;
    public float pauseBeforeSpawnMax = 3f;

    public float mobsMaxScene = 25f;
    public float mobsMeleeSpawned = 0;
    public float mobsTurretSpawned = 0;
    public float mobsCreeperSpawned = 0;
    public float mobsCurrentCounter = 0;

    public int currentWave = 0;

    public List<float> mobsMeleeTestWave = new List<float>();
    public List<float> mobsTurretTestWave = new List<float>();
    public List<float> mobsCreeperTestWave = new List<float>();

    //Player settings
    public float jumpForce = 800f;
    public float maxJumps = 2;
    public float walkForce = 0.2f;
    public float dashMax = 2;
    public float dashTime = 0.12f;
    public float dashSpeed = 25f;

    private void OnEnable()
    {
        //Cheat();
        Reset();
    }

    private void OnDisable()
    {

    }

    void Cheat()
    {
        moneyCurrent = 1000;
        sceneCurrent = 0;
        mobsMeleeSpawned = 0;
        mobsTurretSpawned = 0;
        mobsCreeperSpawned = 0;
        mobsCurrentCounter = 0;
        mobsCurrentCounter = 0;
        currentWave = 0; //0-2
        chestPrice = 221;

        jumpForce = 800f;
        maxJumps = 2;
        walkForce = 0.2f;
        dashMax = 2;
        dashTime = 0.1f;
        dashSpeed = 25f;
    }


    public void Reset()
    {
        sceneCurrent = 0;
        mobsMeleeSpawned = 0;
        mobsTurretSpawned = 0;
        mobsCreeperSpawned = 0;
        mobsCurrentCounter = 0;
        mobsCurrentCounter = 0;
        currentWave = 0;

        moneyCurrent = moneyDefault;
        chestPrice = chestPriceDefault;
        jumpForce = jumpForceDefault;
        maxJumps = maxJumpsDefault;
        walkForce = walkForceDefault;
        dashMax = dashMaxDefault;
        dashTime = dashTimeDefault;
        dashSpeed = dashSpeedDefault;
    }


    public void ApplyBonus(string name, float value)
    {
        switch (name)
        {
            case "jumpForce": jumpForce += value; break;
            case "maxJumps": maxJumps += value; break;
            case "walkForce": walkForce += value; break;
            case "dashMax": dashMax += value; break;
            case "dashTime": dashTime += value; break;
            case "dashSpeed": dashSpeed += value; break;
        }
    }

    public void reduceMoney(float value)
    {

        if ((moneyCurrent - value) > 0)
            moneyCurrent -= value;
        else
        {
            moneyCurrent = 0;

            SceneController.instance.GameOver();
        }
    }
}


