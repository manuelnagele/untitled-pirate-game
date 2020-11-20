using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    [Header("Main Stats")]
    [SerializeField]
    [Tooltip("Force with which Projectile is fired")]
    private float projectileForce;
    public float ProjectileForce {
        get {
            return projectileForce;
        } set {
            projectileForce = value;
        }
    }

    [SerializeField]
    [Tooltip("Damage per Shot, distributed across all Projectiles fired")]
    private int damage;
    public int Damage {
        get {
            return damage;
        } set {
            damage = value;
        }
    }
    [SerializeField]
    [Tooltip("Damage per Shot, distributed across all Projectiles fired")]
    private int projectilesPerShot;
    public int ProjectilesPerShot {
        get {
            return projectilesPerShot;
        } set {
            projectilesPerShot = value;
        }
    }

    private float damagePerProjectile;
    public float DamagePerProjectile {
        get {
            return damagePerProjectile;
        }
        set {
            damagePerProjectile = value;
        }
    }

    [SerializeField]
    [Tooltip("Determines the spread around the Crosshair")]
    [Range(1,100)]
    private float accuracy;
    public float Accuracy {
        get {
            return accuracy;
        } set {
            accuracy = value;
        }
    }
    [SerializeField]
    [Tooltip("")]
    private _SpreadType spreadType;
    public _SpreadType SpreadType {
        get {
            return spreadType;
        } set {
            spreadType = value;
        }
    }

    [SerializeField]
    [Tooltip("Cooldown between shots")]
    private float fireRate;
    public float FireRate {
        get {
            return fireRate;
        } set {
            fireRate = value;
        }
    }
    [SerializeField]
    [Tooltip("")]
    private float weaponCooldown;
    public float WeaponCooldown {
        get {
            return weaponCooldown;
        } set {
            weaponCooldown = value;
        }
    }
    [SerializeField]
    [Tooltip("Projectile Used")]
    private GameObject projectile;
    public GameObject Projectile {
        get {
            return projectile;
        } set {
            projectile = value;
        }
    }
    [SerializeField]
    [Tooltip("Model Used")]
    private GameObject turret;
    public GameObject Turret {
        get {
            return turret;
        } set {
            turret = value;
        }
    }
    [SerializeField]
    [Tooltip("Model Used")]
    private Transform muzzle;
    public Transform Muzzle {
        get {
            return muzzle;
        } set {
            muzzle = value;
        }
    }

    [SerializeField]
    [Tooltip("")]
    private _WeaponState weaponState;
    public _WeaponState WeaponState {
        get {
            return weaponState;
        } set {
            weaponState = value;
        }
    }
    public enum _SpreadType {
        Random,
        Circle
    };
    public enum _WeaponState {
        Ready,
        Cooldown
    };

    void Start() {
        WeaponState = _WeaponState.Ready;
        DamagePerProjectile = Damage / ProjectilesPerShot;
    }

    void Update() {
        if(!Ready()) {
            AdjustCooldown();
        }
    }

     private void AdjustCooldown() {
        weaponCooldown -= Time.deltaTime;
         if(weaponCooldown <= 0) {
               weaponState = _WeaponState.Ready;
               weaponCooldown = 0;
         }
     }

     public void OnCooldown() {
        weaponState = _WeaponState.Cooldown;
        weaponCooldown = fireRate;
     }

     public bool Ready() {
         return (weaponState == _WeaponState.Ready);
     }
}