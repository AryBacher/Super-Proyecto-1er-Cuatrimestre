using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public Text txt_timeTime;
    float customTime;

    // Start is called before the first frame update
    void Start()
    {
        customTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float time = Time.time;

        //txt_timeTime.text = "Tiempo Transcurrido: " +time.ToString() + " Segundos";
        txt_timeTime.text = "Tiempo Transcurrido: " +Mathf.Floor(time).ToString() + " Segundos";
        customTime += Time.deltaTime;
    }
}
