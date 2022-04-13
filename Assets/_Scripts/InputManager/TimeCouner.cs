using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace LP.FDG.InputManager
{
    public class TimeCouner : MonoBehaviour
    {
        public float realtime;
        public float startTime;
        [SerializeField]
        Text CountDownText;
        // Start is called before the first frame update
        void Start()
        {
            realtime = startTime;
        }

        // Update is called once per frame
        void Update()
        {
            realtime -= 1 * Time.deltaTime;
            CountDownText.text = realtime.ToString("0");
            Debug.Log
            (
            "CountDownText : "
            +
            CountDownText
            );
            Debug.Log
            (
            "startTime : "
            +
            startTime
            );

            CountDownText.color = Color.black;
            if (realtime <= 0)
            {
                realtime = 0;
                Debug.Log
                (
                "realTime : "
                +
                realtime
                );
            }
        }
    }
}

