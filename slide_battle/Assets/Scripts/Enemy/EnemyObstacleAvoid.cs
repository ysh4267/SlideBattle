using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObstacleAvoid : MonoBehaviour {
    public float rotationSpeed = 10.0f;
    public float minimumDistToAvoid = 20.0f;

    [SerializeField] GameObject target;

    private void Start() {
        target = GameObject.Find("ProtectArea");
    }

    private void Update() {

        Vector3 dir = (target.transform.position - transform.position);
        dir.Normalize();
        AvoidObstacles(ref dir);
        
        var rotation = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        
    }

    public void AvoidObstacles(ref Vector3 dir) {
        RaycastHit hit;

        int layerMask = 1 << 6;

        if (Physics.BoxCast(transform.position,transform.lossyScale,transform.forward, out hit,transform.rotation, minimumDistToAvoid,layerMask)) {
            Debug.DrawRay(transform.position,transform.TransformDirection(Vector3.forward) * 10, Color.black, 5f);


            Vector3 hitNormal = hit.normal;

            hitNormal.y = 0.0f;

            dir =transform.forward + hitNormal;
        }

    }


}
