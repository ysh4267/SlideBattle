using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour {
    Rigidbody rigidbody;
    EnumEnemyStatus currentStatus;
    Collision latestCollision;
    Animator animator;
    [SerializeField] float speedLimit;
    [SerializeField] float power;
    [SerializeField] float bounceVelocityMultiplier;
    [SerializeField] float stopVelocityDivider;
    private void Start() {
        currentStatus = EnumEnemyStatus.MOVE;
        rigidbody = gameObject.GetComponent<Rigidbody>();
        animator = gameObject.GetComponent<Animator>();
    }

    private void Update() {
        float x= transform.rotation.x;
        float z = transform.rotation.z;
        Quaternion newrotation = new Quaternion(x,transform.rotation.y,z,transform.rotation.w);
        transform.rotation = newrotation;
    }

    private void FixedUpdate() {
        switch (currentStatus) {
            case EnumEnemyStatus.MOVE:
                MoveEnemy();
                break;
            case EnumEnemyStatus.COLLIDE_WITH_PLAYER:
                CollidePlayerToEnemy();
                break;
            case EnumEnemyStatus.COLLIDE_WITH_ENEMY:
                CollideEnemyToEnemy();
                break;
            case EnumEnemyStatus.COLLIDE_WITH_PILLAR:
                CollideEnemyToPillar();
                break;
            case EnumEnemyStatus.BOUNCE:
                Bounce();
                break;
            case EnumEnemyStatus.STOP:
                StopThisObject();
                SetWalkingAnimation();
                break;
            default:
                break;
        }
    }
    private void StopThisObject() {
        rigidbody.velocity *= stopVelocityDivider;
        currentStatus = EnumEnemyStatus.MOVE;
    }
    private void CollidePlayerToEnemy() {
        Vector3 velocity = latestCollision.relativeVelocity*bounceVelocityMultiplier;
        velocity.y = 0;
        rigidbody.velocity = velocity;
        currentStatus = EnumEnemyStatus.BOUNCE;
    }
    private void CollideEnemyToEnemy() {
        Vector3 velocity = latestCollision.relativeVelocity;
        velocity.y = 0;
        rigidbody.velocity = velocity;
        currentStatus = EnumEnemyStatus.BOUNCE;
    } 
    private void CollideEnemyToPillar() {
        Vector3 collisionPoint = latestCollision.contacts[0].point;
        Vector3 objectPosition = latestCollision.gameObject.transform.position;
    
        Vector3 directionVector = new Vector3();
    
        directionVector = Vector3.Reflect(latestCollision.relativeVelocity.normalized, (collisionPoint - objectPosition).normalized) * -1;
        directionVector.y = 0;
        float remainPower = latestCollision.relativeVelocity.magnitude / directionVector.magnitude;
        rigidbody.velocity = directionVector * remainPower ;
    
        currentStatus = EnumEnemyStatus.MOVE;
    }
    private void Bounce() {
        if (rigidbody.velocity.magnitude < 0.1f) {
            currentStatus = EnumEnemyStatus.MOVE;
        }
    }
    private void MoveEnemy() {
        if (rigidbody.velocity.magnitude < speedLimit) {
            rigidbody.AddForce(gameObject.transform.forward.normalized * power);
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

    private void UpdateLatestCollision(Collision collision) {
        latestCollision = collision;
    } 
    private void OnCollisionEnter(Collision collision) {

        UpdateLatestCollision(collision);

        if (collision.gameObject.tag == "Player") {
            currentStatus = EnumEnemyStatus.COLLIDE_WITH_PLAYER;
            SetFlyingAnimation();
            CollidePlayerToEnemy();
        }
        else if (collision.gameObject.tag == "Enemy") {
            if (currentStatus == EnumEnemyStatus.BOUNCE) {
                currentStatus = EnumEnemyStatus.STOP;
            }
            else{
                currentStatus = EnumEnemyStatus.COLLIDE_WITH_ENEMY;
                SetFlyingAnimation();
            }
        }
         else if(collision.gameObject.tag == "Pillar") {
             currentStatus = EnumEnemyStatus.COLLIDE_WITH_PILLAR;
            CollideEnemyToPillar();

        }
        else if (collision.gameObject.tag == "ProtectZone") {
            Destroy(gameObject);
        }
    }
}
