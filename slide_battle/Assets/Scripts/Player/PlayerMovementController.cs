using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour {
    private new Rigidbody rigidbody;

    public EnumPlayerStatus currentStatus;
    public float speedLimit;
    public float power = 1.0f;

    Vector3 touchStartPosition;
    Vector3 touchEndPosition;
    Vector3 directionVector;
    [SerializeField] Transform PlayerSpawnPosition;
    public float curveSpeedDivider;

    public float explosionDelay;
    float explosionDelayTimer;

    private void Start() {
        currentStatus = EnumPlayerStatus.IDLE;
        rigidbody = gameObject.GetComponent<Rigidbody>();
        directionVector = new Vector3(0, 0, 0);
    }

    public void SetCharacterStatus(EnumPlayerStatus newStatus) {
        currentStatus = newStatus;
    }

    private void Update() {
        explosionDelayTimer -= Time.deltaTime;
        if (IsControllerActive()) {
            TryGetPlayerInput();
        }
    }
    private void FixedUpdate() {
        if (Observers.GetInstance().panelHandler.GetCurrentPanelStatus() == ENUM_PANEL_STATUS.IN_GAME) {
            RunPlayer();
        }
        else
        {
            rigidbody.velocity = new Vector3(0, 0, 0);
            directionVector = new Vector3(0,0,0);
            transform.position = PlayerSpawnPosition.position;
            
        }
    }

    void RunPlayer() {
        switch (currentStatus) {
            case EnumPlayerStatus.MOVE:
                MovePlayer();
                break;
            case EnumPlayerStatus.REFLECTED_BY_OBSTACLE:
                SlowDownPlayer();
                break;
            case EnumPlayerStatus.OIL_SLIP:
                AddForceToPlayer();
                break;
            default:
                break;
        }
    }

    void MovePlayer() {
        AddForceToPlayer();
    }

    void SlowDownPlayer() {
        if (rigidbody.velocity.magnitude <= 0.001) {
            rigidbody.velocity = new Vector3(0, 0, 0);
            currentStatus = EnumPlayerStatus.IDLE;
        }
        rigidbody.velocity *= 0.99f;

    }

    void AddForceToPlayer() {
        if (rigidbody.velocity.magnitude < speedLimit) {
            rigidbody.AddForce(directionVector * power);
        }
    }

    void TryGetPlayerInput() {
        if (Input.touches.Length > 0) {
            if (Input.touches[0].phase == TouchPhase.Began) {
                touchStartPosition = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Moved) {
                currentStatus = EnumPlayerStatus.MOVE;
                touchEndPosition = Input.touches[0].position;

                directionVector = (touchEndPosition - touchStartPosition).normalized;
                directionVector.z = directionVector.y;
                directionVector.y = 0.0f;

                rigidbody.velocity *= curveSpeedDivider;
            }
        }
    }

    void InitExplosionDelay() {
        explosionDelayTimer = explosionDelay;
    }


    void ReflectByObstacle(Collision collision) {
        Vector3 collisionPoint = collision.contacts[0].point;
        Vector3 objectPosition = collision.gameObject.transform.position;

        directionVector = Vector3.Reflect(collision.relativeVelocity.normalized, (collisionPoint - objectPosition).normalized) * -1;
        directionVector.y = 0;
        float remainPower = collision.relativeVelocity.magnitude / directionVector.magnitude;
        rigidbody.velocity = directionVector * remainPower;

        currentStatus = EnumPlayerStatus.REFLECTED_BY_OBSTACLE;
    }

    bool IsControllerActive() {
        if (currentStatus == EnumPlayerStatus.OIL_SLIP) return false;
        if (Observers.GetInstance().panelHandler.GetCurrentPanelStatus() != ENUM_PANEL_STATUS.IN_GAME) return false;

        return true;
    }

    private void OnCollisionEnter(Collision collision) {
        switch (collision.gameObject.tag) {
            case "Pillar":
                Debug.Log("player pillar!");
                SoundMgr.GetInstance().PlayHitPillarSound();
                ReflectByObstacle(collision);
                break;
            case "Enemy":
                if (collision.relativeVelocity.magnitude >= speedLimit * 0.9f && explosionDelayTimer <= 0.0f) {
                    InitExplosionDelay();
                    SoundMgr.GetInstance().PlayHitMaxSound();
                    if (VibeMgr.GetInstance().VibeOn)
                    {
                        Vibration.Vibrate(500);
                    }
                    Debug.Log("Explode!");
                    GameObject explode = Instantiate(Resources.Load<GameObject>("Prefabs/Explosion"));
                    explode.transform.position = gameObject.transform.position;
                }
                else
                {
                    SoundMgr.GetInstance().PlayHitSound();
                }
                break;
            case "Hole":
                Destroy(gameObject);
                break;
        }

    }

}
