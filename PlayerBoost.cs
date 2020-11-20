using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoost : MonoBehaviour {
    PlayerStats playerStats;
     public float boostTime = 1f;
     private float remainingBoostTime = 0f;
     private float remainingBoostCooldown = 0f;
     public float boostModifier = 2f;
     public float boostCooldown = 5f;
     public BoostState boostState = BoostState.Ready;

     void Start() {
         playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
     }

     void Update() {
         CheckBoostState();
     }

     private void BoostShip() {
        playerStats.VerticalInputAcceleration *= boostModifier;
        playerStats.HorizontalInputAcceleration *= boostModifier;
        playerStats.MaxSpeed *= boostModifier;
        playerStats.MaxRotationSpeed *= boostModifier;
        remainingBoostTime = boostTime;
        boostState = BoostState.Boosting;
     }

     private void StopShipBoost() {
        playerStats.VerticalInputAcceleration /= boostModifier;
        playerStats.HorizontalInputAcceleration /= boostModifier;
        playerStats.MaxSpeed /= boostModifier;
        playerStats.MaxRotationSpeed /= boostModifier;
        boostState = BoostState.Cooldown; 
        remainingBoostCooldown = boostCooldown;
      }

     private void CheckRemainingBoostTime() {
         remainingBoostTime -= Time.deltaTime;
         if(remainingBoostTime <= 0) {
               StopShipBoost();
         }
     }

     private void CheckRemainingBoostCooldown() {
        remainingBoostCooldown -= Time.deltaTime;
         if(remainingBoostCooldown <= 0) {
               boostState = BoostState.Ready;
         }
     }

     private void CheckBoostState() {
        switch(boostState) {
           case BoostState.Ready:
            if(Input.GetButtonDown ("Boost")) {
               BoostShip();
            }
           break;
           case BoostState.Boosting:
            CheckRemainingBoostTime();
           break;
           case BoostState.Cooldown:
            CheckRemainingBoostCooldown();
           break;
        }
     }

     public enum BoostState {
        Ready,
        Boosting,
        Cooldown
     }
}