using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAiming : MonoBehaviour {
    PlayerController playerController;
    PlayerStats playerStats;

    void Start() {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;

        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
    }

    void Update() {
        Aim();
    }
      void Aim() {
         Vector3 mousePos = Input.mousePosition;
         Vector3 center = playerController.Player.transform.position;
         Vector3 objectPos = Camera.main.WorldToScreenPoint (center);
         Vector3 aimPos = (mousePos - objectPos).normalized;
         aimPos.z = 0f;
         playerController.Crosshair.transform.localPosition = transform.position + aimPos * playerStats.AimRadius;
    }
}