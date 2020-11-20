using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {
    PlayerController playerController;
      void Start() {
          playerController = GameObject.Find("Player").GetComponent<PlayerController>();
      }

     void Update() {
        if(Input.GetButton("Fire1")) {
               Shoot();
        }
     }

    void Shoot() {
        foreach (GameObject turret in FindShipWeapons()) {
            // find the muzzle
            Weapon weapon = turret.GetComponent<Weapon>();
            if(weapon.Ready()) {
                weapon.OnCooldown();
                GameObject weaponProjectile = weapon.Projectile;
                float projectileForce = weapon.ProjectileForce;
                Transform muzzle = weapon.Muzzle;

                for(int i = 0; i < weapon.ProjectilesPerShot; i++) {
                    GameObject projectile = Instantiate(weaponProjectile, muzzle.position, muzzle.rotation);
                    projectile.GetComponent<ProjectileController>().Damage = weapon.DamagePerProjectile;
                    Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
                    Vector3 fireDirection = muzzle.transform.up;
                    Vector3 spread = CalculateSpread(weapon.SpreadType);
                    Vector3 accuracyCoefficient = spread * (0.0001f + 1 / weapon.Accuracy) * 5;
                    rb.AddForce((fireDirection + accuracyCoefficient) * projectileForce, ForceMode2D.Impulse);
                }
            }
        }
    }

    GameObject[] FindShipWeapons() {
        return playerController.Turrets;
    }

    Transform FindMuzzleOfWeapon(GameObject weapon) {
        foreach (Transform child in weapon.transform) {
            if (child.name == "Muzzle") {
                return child;
            }
        }
        return null;
    }

    Vector3 CalculateSpread(Weapon._SpreadType spreadType) {
        switch(spreadType) {
            case Weapon._SpreadType.Random:
                return Random.insideUnitCircle;
            case Weapon._SpreadType.Circle:
                return Random.insideUnitCircle.normalized;
        }
        Debug.Log("Failed to calculate spread");
        return new Vector3(0,0,0);        
    }
}