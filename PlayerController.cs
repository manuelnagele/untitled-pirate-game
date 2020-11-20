using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
   PlayerStats playerStats;
 
     private Vector3 velocity;
     private float zRotationVelocity;

      private GameObject player;
      public GameObject Player {
         get {
            return player;
         }
      }
      public GameObject[] turrets;
      public GameObject[] Turrets {
         get {
            return turrets;
         }
         set {
            turrets = value;
         }
      }
      public GameObject[] turretSlots;
      public GameObject[] TurretSlots {
         get {
            return turretSlots;
         }
         set {
            turretSlots = value;
         }
      }
      private GameObject crosshair;
      public GameObject Crosshair {
         get {
            return crosshair;
         }
      } 
      public GameObject ship;
      public GameObject Ship {
         get {
            return ship;
         }
      }


      void Start() {
        player = this.gameObject;
        playerStats = player.GetComponent<PlayerStats>();
        crosshair = GameObject.FindWithTag("Crosshair");
        turretSlots = GameObject.FindGameObjectsWithTag("Turret Socket");
        turrets = GameObject.FindGameObjectsWithTag("Player Turret");
      }
 
     private void FixedUpdate() {
        GetInputs();
        Move();
        LookAtCrosshair();
     }

      private void Move() {
         // apply velocity drag
        velocity = velocity * (1 - Time.deltaTime * playerStats.VelocityDrag);
        // clamp to maxSpeed
        velocity = Vector3.ClampMagnitude(velocity, playerStats.MaxSpeed);
        // apply rotation drag
        zRotationVelocity = zRotationVelocity * (1 - Time.deltaTime * playerStats.RotationDrag);
        // clamp to maxRotationSpeed
        zRotationVelocity = Mathf.Clamp(zRotationVelocity, -playerStats.MaxRotationSpeed, playerStats.MaxRotationSpeed);
        // update transform
        transform.position += velocity * Time.deltaTime;
        transform.Rotate(0, 0, zRotationVelocity * Time.deltaTime);
      }

     private void GetInputs() {
        // apply forward input
         Vector3 acceleration = Input.GetAxis("Vertical") * playerStats.VerticalInputAcceleration * transform.up;
         velocity += acceleration * Time.deltaTime;
 
        // apply turn input
        float zTurnAcceleration = -1 * Input.GetAxis("Horizontal") * playerStats.HorizontalInputAcceleration;
        zRotationVelocity += zTurnAcceleration * Time.deltaTime;
     }

    void LookAtCrosshair() {
         float rotationSpeed = 5f;
         Vector3 vectorToTarget = Crosshair.transform.position - Player.transform.position;
         float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
         angle -= 90f;
         Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
         foreach (GameObject turret in turrets) {
            turret.transform.rotation = Quaternion.Slerp(turret.transform.rotation, q, Time.deltaTime * rotationSpeed);
         }
    }
 }