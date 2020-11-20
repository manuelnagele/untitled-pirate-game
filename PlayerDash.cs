using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour {
    private _DashState dashState;
    private Rigidbody2D playerRigidbody;
    private PlayerStats playerStats;
    public float cooldown;
    public float duration;
    public float speed;
    public _DashState DashState {
        get {
            return dashState;
        }
        set {
            dashState = value;
        }
    }

    void Start() {
        DashState = _DashState.Ready;
        playerRigidbody = gameObject.GetComponent<Rigidbody2D>();
        playerStats = gameObject.GetComponent<PlayerStats>();
    }

    void Update() {
        switch(DashState) {
            case _DashState.Ready:
            if(Input.GetButtonDown("Dash Left")) {
                Dash(_DashDirection.Left);
            }
            if(Input.GetButtonDown("Dash Right")) {
                Dash(_DashDirection.Right);
            }
            break;
            case _DashState.Dashing:
            CalculateDuration();
            break;
            case _DashState.Cooldown:
            StopMovement();
            CalculateCooldown();
            break;
        }
    }

    void CalculateCooldown() {
        cooldown -= Time.deltaTime;
         if(cooldown <= 0) {
               dashState = _DashState.Ready;
               cooldown = playerStats.DashCooldown;
               duration = playerStats.DashDuration;
         }
    }

    void CalculateDuration() {
        duration -= Time.deltaTime;
         if(duration <= 0) {
               dashState = _DashState.Cooldown;
         } 
    }
    void StopMovement() {
        playerRigidbody.velocity = Vector3.zero;
    }


    void Dash(_DashDirection dashDirection) {
        cooldown = playerStats.DashCooldown;
        duration = playerStats.DashDuration;
        speed = playerStats.DashSpeed;
        if(dashDirection == _DashDirection.Left) {
            playerRigidbody.AddForce(-transform.right * speed, ForceMode2D.Impulse);
        } else if (dashDirection == _DashDirection.Right) {
            playerRigidbody.AddForce(transform.right * speed, ForceMode2D.Impulse);
        }
        cooldown = playerStats.DashCooldown;
        dashState = _DashState.Dashing;
    }


    public enum _DashState {
        Ready,
        Dashing,
        Cooldown
    }

    public enum _DashDirection {
        Left,
        Right
    }
}