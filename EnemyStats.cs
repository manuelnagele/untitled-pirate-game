using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    /// Player Vitals Getter & Setter
    [Header("Enemy Vitals")]
    [SerializeField]
    [Tooltip("Max possible Health of Enemy")]
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
    [Tooltip("Current Enemy Health")]
     private int health;
     public int Health {
         get {
             return health;
         }
         set {
             if (value < 0) {
                 health = 0;
             } else if (value >= maxHealth) {
                 health = maxHealth;
             } else {
                 health = value;
             }
         }
     }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
