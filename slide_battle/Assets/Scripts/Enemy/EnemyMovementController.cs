using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour
{
    Rigidbody rigidbody;
    EnumEnemyStatus currentStatus;
    [SerializeField] float speedLimit;
    public float power;
    //public Collision latestCollision;
    private void Start()
    {
        currentStatus = EnumEnemyStatus.MOVE;
        rigidbody = gameObject.GetComponent<Rigidbody>();

    }

    private void FixedUpdate()
    {
        switch (currentStatus) {
            case EnumEnemyStatus.MOVE:
                MoveEnemy();
                break;
            case EnumEnemyStatus.COLLIDE_BY_OTHER:
                //BounceByOther();
                break;
            case EnumEnemyStatus.STOP:
                StopThisObject();
                break;
            default:
                break;
        }
    }
    private void StopThisObject() {

    }
    private void BounceByOther() {

    }
    private void MoveEnemy() {
        if(rigidbody.velocity.magnitude < speedLimit) {
            rigidbody.AddForce(gameObject.transform.forward.normalized * power);
        }
    }
    
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player") {//Æ¨°Ü³ª±â
            currentStatus = EnumEnemyStatus.COLLIDE_BY_OTHER;
            Vector3 velocity = collision.relativeVelocity;
            velocity.y = 0;
            rigidbody.velocity = velocity;
        }
        else if (collision.gameObject.tag == "Enemy") {

            if (currentStatus == EnumEnemyStatus.COLLIDE_BY_OTHER) {
                Debug.Log("hit enemy to enemy");
                rigidbody.velocity = new Vector3(0, 0, 0);
                currentStatus = EnumEnemyStatus.MOVE;
            }
            else {
                Debug.Log("hit by enemy");
                Vector3 velocity = collision.relativeVelocity;
                velocity.y = 0;
                rigidbody.velocity = velocity;
            }
        }
        else if (collision.gameObject.tag == "ProtectZone") {
            Destroy(gameObject);
        }
    }
}
