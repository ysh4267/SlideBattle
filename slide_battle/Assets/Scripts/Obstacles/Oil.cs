using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oil : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            other.gameObject.GetComponent<PlayerMovementController>().SetCharacterStatus(EnumPlayerStatus.OIL_SLIP);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            other.gameObject.GetComponent<PlayerMovementController>().SetCharacterStatus(EnumPlayerStatus.MOVE);
        }
    }
}
