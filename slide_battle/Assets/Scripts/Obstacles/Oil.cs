using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oil : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            Debug.Log("Oil enter");
            other.gameObject.GetComponent<PlayerMovementController>().SetCharacterStatus(EnumPlayerStatus.OIL_SLIP);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            Debug.Log("Oil out");
            other.gameObject.GetComponent<PlayerMovementController>().SetCharacterStatus(EnumPlayerStatus.MOVE);
        }
    }
}
