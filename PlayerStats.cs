using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {
    // Player Movement Getter & Setter
    [SerializeField]
    [Header("Player Movement")]
    [Tooltip("How much should the input affect acceleration")]
    [Range(0,100)]
     private float verticalInputAcceleration;
    public float VerticalInputAcceleration {
        get {
            return verticalInputAcceleration;
        } set {
            verticalInputAcceleration = value;
        }
    }

    [SerializeField]
    [Tooltip("How much should the input affect rotation")]
    [Range(0,100)]
    private float horizontalInputAcceleration;
    public float HorizontalInputAcceleration {
        get {
            return horizontalInputAcceleration;
        } set {
            verticalInputAcceleration = value;
        }
    }

    [SerializeField]
    [Tooltip("Max possible velocity the ship can accelerate towards")]
    [Range(0,100)]
     private float maxSpeed;
    public float MaxSpeed {
        get {
            return maxSpeed;
        } set {
            maxSpeed = value;
        }
    }

    [SerializeField]
    [Tooltip("Max possible rotation speed the ship can accelerate towards")]
    [Range(0,100)]
     private float maxRotationSpeed;
    public float MaxRotationSpeed {
        get {
            return maxRotationSpeed;
        } set {
            maxRotationSpeed = value;
        }
    }
    [Header("Drag")]
    [SerializeField]
    [Tooltip("How Much Drag should be applied to forwards/backwards movements. (aka Widerstand)")]    
    [Range(0,10)]
     private float velocityDrag; 
    public float VelocityDrag {
        get {
            return velocityDrag;
        } set {
            velocityDrag = value;
        }
    }

    [SerializeField]
    [Tooltip("How much Drag should be applied to Rotations. (aka Widerstand)")]
    [Range(0,10)]
     private float rotationDrag;
    public float RotationDrag {
        get {
            return rotationDrag;
        } set {
            rotationDrag = value;
        }
    }

    /// Player Vitals Getter & Setter
    [Header("Player Vitals")]
    [SerializeField]
    [Tooltip("Max possible Health of Player")]
     private int maxHealth;
    public int MaxHealth {
        get {
            return maxHealth;
        } set {
            if (value < 0) {
                maxHealth = 0;
            } else {
                maxHealth = value;
            }
        }
    }

    [SerializeField]
    [Tooltip("Current Player Health")]
     private int health;
     public int Health {
         get {
             return health;
         }
         set {
             if (value < 0) {
                 health = 0;
             } else {
                 health = value;
             }
         }
     }
     [SerializeField]
     [Header("Aiming")]
     [Tooltip("How Far Away should the Crosshair be")]
     [Range(0,10)]
      private float aimRadius;
      public float AimRadius {
         get {
             return aimRadius;
         } set {
             aimRadius = value;
         }
     }
     [Header("Abilities")]
     [SerializeField]
     [Tooltip("")]
      private float dashCooldown;
      public float DashCooldown {
         get {
             return dashCooldown;
         } set {
             dashCooldown = value;
         }
     }
     [SerializeField]
     [Tooltip("")]
      private float dashDuration;
      public float DashDuration {
         get {
             return dashDuration;
         } set {
             dashDuration = value;
         }
     }
          [SerializeField]
     [Tooltip("")]
      private float dashSpeed;
      public float DashSpeed {
         get {
             return dashSpeed;
         } set {
             dashSpeed = value;
         }
     }
}