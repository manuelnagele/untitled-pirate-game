using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private EnemyStats enemyStats;
    public RectTransform healthBar;


    // Start is called before the first frame update
    void Start()
    {
        enemyStats = gameObject.AddComponent<EnemyStats>();
        enemyStats.MaxHealth = 100;
        enemyStats.Health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.sizeDelta = new Vector2(enemyStats.Health * 2, healthBar.sizeDelta.y);

        if(enemyStats.Health <= 0) {
            Die();
        }
    }



    void ApplyDamage(int damage) {
        enemyStats.Health -= damage;
    }

    void Die() {
        Destroy(this.gameObject);
    }
}
