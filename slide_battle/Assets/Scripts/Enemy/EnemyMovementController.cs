using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour {
    Rigidbody rigidbody;
    public ENUM_ENEMY_STATUS currentStatus;
    Collision latestCollision;
    [SerializeField] float speedLimit;
    [SerializeField] float power;
    [SerializeField] float bounceVelocityMultiplier;
    [SerializeField] float stopVelocityDivider;
    private void Start() {
        currentStatus = ENUM_ENEMY_STATUS.MOVE;
        rigidbody = gameObject.GetComponent<Rigidbody>();

    }

    private void Update() {
       float x= transform.rotation.x;
       float z = transform.rotation.z;
       Quaternion newrotation = new Quaternion(x,transform.rotation.y,z,transform.rotation.w);
       transform.rotation = newrotation;
    }

    private void FixedUpdate() {
        switch (currentStatus) {
            case ENUM_ENEMY_STATUS.MOVE:
                MoveEnemy();
                break;
            case ENUM_ENEMY_STATUS.COLLIDE_WITH_PLAYER:
                CollidePlayerToEnemy();
                break;
            case ENUM_ENEMY_STATUS.COLLIDE_WITH_ENEMY:
                CollideEnemyToEnemy();
                break;
            case ENUM_ENEMY_STATUS.COLLIDE_WITH_PILLAR:
                CollideEnemyToPillar();
                break;
            case ENUM_ENEMY_STATUS.BOUNCE:
                Bounce();
                break;
            case ENUM_ENEMY_STATUS.STOP:
                StopThisObject();
                break;
            default:
                break;
        }
    }
    private void StopThisObject() {
        rigidbody.velocity *= stopVelocityDivider;
        currentStatus = ENUM_ENEMY_STATUS.MOVE;
    }
    private void CollidePlayerToEnemy() {
        Vector3 velocity = latestCollision.relativeVelocity*bounceVelocityMultiplier;
        velocity.y = 0;
        rigidbody.velocity = velocity;
        currentStatus = ENUM_ENEMY_STATUS.BOUNCE;
    }
    private void CollideEnemyToEnemy() {
        Vector3 velocity = latestCollision.relativeVelocity;
        velocity.y = 0;

        rigidbody.velocity = velocity *-1;

        currentStatus = ENUM_ENEMY_STATUS.BOUNCE;
    } 
    private void CollideEnemyToPillar() {
        Vector3 collisionPoint = latestCollision.contacts[0].point;
        Vector3 objectPosition = latestCollision.gameObject.transform.position;
    
        Vector3 directionVector = new Vector3();
    
        directionVector = Vector3.Reflect(latestCollision.relativeVelocity.normalized, (collisionPoint - objectPosition).normalized) * -1;
        directionVector.y = 0;
        float remainPower = latestCollision.relativeVelocity.magnitude / directionVector.magnitude;
        rigidbody.velocity = directionVector * remainPower ;
    
        currentStatus = ENUM_ENEMY_STATUS.MOVE;
    }
    private void Bounce() {
        if (rigidbody.velocity.magnitude < 0.1f) {
            currentStatus = ENUM_ENEMY_STATUS.MOVE;
        }
    }
    private void MoveEnemy() {
        if (rigidbody.velocity.magnitude < speedLimit) {
            rigidbody.AddForce(gameObject.transform.forward.normalized * power);
        }
    }

    private void UpdateLatestCollision(Collision collision) {
        latestCollision = collision;
    } 
    private void OnCollisionEnter(Collision collision) {

        UpdateLatestCollision(collision);

        if (collision.gameObject.tag == "Player") {
            currentStatus = ENUM_ENEMY_STATUS.COLLIDE_WITH_PLAYER;
            CollidePlayerToEnemy();
        }
        else if (collision.gameObject.tag == "Enemy") {
            if (currentStatus == ENUM_ENEMY_STATUS.BOUNCE) {
                currentStatus = ENUM_ENEMY_STATUS.STOP;
            }
            else if (collision.gameObject.GetComponent<EnemyMovementController>().currentStatus == ENUM_ENEMY_STATUS.BOUNCE) { 
                currentStatus = ENUM_ENEMY_STATUS.COLLIDE_WITH_ENEMY;
            }
        }
         else if(collision.gameObject.tag == "Pillar") {
             currentStatus = ENUM_ENEMY_STATUS.COLLIDE_WITH_PILLAR;
            CollideEnemyToPillar();
        }
    }
}
