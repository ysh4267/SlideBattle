using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    [SerializeField] Animator animator;
    EnemyMovementController status;
    private void Start() {
        status = gameObject.GetComponent<EnemyMovementController>();
    }

    private void Update() {
        if(status.currentStatus == ENUM_ENEMY_STATUS.STOP) {
            SetWalkingAnimation();
        }   
    }

    private void SetFlyingAnimation() {
        animator.SetBool("isFlying", true);
        animator.SetBool("isWalking", false);
    }

    private void SetWalkingAnimation() {
        animator.SetBool("isFlying", false);
        animator.SetBool("isWalking", true);
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Player") {
            SetFlyingAnimation();
        }
        else if(collision.gameObject.tag == "Enemy") {
            if(collision.gameObject.GetComponent<EnemyMovementController>().currentStatus == ENUM_ENEMY_STATUS.BOUNCE) {
                SetFlyingAnimation();
            }
        }
    }
}
