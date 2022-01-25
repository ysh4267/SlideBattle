using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeCs : MonoBehaviour
{
    float time;

    void Update()
    {
        if (time < 0.5f)
        {
            GetComponent<Image>().color = new Color(0, 0, 0, 1 - time);
        }
        else
        {
            GetComponent<Image>().color = new Color(0, 0, 0, time);
            if (time > 1f)
            {
                time = 0;
            }
        }
        time += Time.deltaTime;
    }
}
