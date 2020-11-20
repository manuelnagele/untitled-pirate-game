using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private float destroyProjectileAfter = 2f;
    public float remainingTimeUntilDestruction = 0;
    
    private float damage = 0f;
    public float Damage {
        get {
            return damage;
        }
        set {
            damage = value;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        remainingTimeUntilDestruction = destroyProjectileAfter;
    }

    // Update is called once per frame
    void Update()
    {
        CheckRemainingTime();
    }
    
    private void CheckRemainingTime() {
        remainingTimeUntilDestruction -= Time.deltaTime;
        if(remainingTimeUntilDestruction <= 0) {
            Destroy(this.gameObject);
        }
     }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.SendMessage("ApplyDamage", Damage);
        }
        Destroy(this.gameObject);
    }
}
