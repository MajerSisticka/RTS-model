using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LP.FDG.InputManager
{
    public class AudioChar : MonoBehaviour
    {
        private AudioSource _Audionsource;
        [SerializeField]
        AudioClip clipClick;
        [SerializeField]
        private bool isActiveGameOn;
        [SerializeField]
        private bool isActiveGameOff;
        [SerializeField]
        private bool Click;
        [SerializeField]
        GameObject Audio;

        private void Start()
        {
            if(!isActiveGameOn)
            {
                isActiveGameOn = false;
                Debug.Log
                (
                "isActiveGameOn : "
                +
                isActiveGameOn
                );
            }
            else
            {
                isActiveGameOn = true;
                Debug.Log
                (
                "isActiveGameOn : "
                +
                isActiveGameOn
                );
            }
            if (isActiveGameOff)
            {
                isActiveGameOff = true;
                Debug.Log
                (
                "isActiveGameOff : "
                +
                isActiveGameOff
                );
            }
            else
            {
                isActiveGameOn = false;
                Debug.Log
                (
                "isActiveGameOff : "
                +
                isActiveGameOff
                );
            }
        }
        private void Update()
        {
            _Audionsource = Audio.GetComponent<AudioSource>();
            if (Input.GetMouseButtonDown(0))
            {
                if (Click)
                {
                    _Audionsource.clip = clipClick;
                    _Audionsource.loop = true;
                    _Audionsource.pitch = 1.20f;
                    _Audionsource.Play();
                    isActiveGameOn = true;
                    Debug.Log
                    (
                    "isActiveGameOn : "
                    +
                    isActiveGameOn
                    );

                }
                else
                {
                    _Audionsource.clip = null;
                    _Audionsource.loop = false;
                    _Audionsource.pitch = 0;
                    _Audionsource.Stop();
                    isActiveGameOff = false;
                    Debug.Log
                    (
                    "isActiveGameOff : "
                    +
                    isActiveGameOff
                    );
                }
            }
            else
            {
                if (!Click)
                {
                    _Audionsource.clip = null;
                    _Audionsource.loop = false;
                    _Audionsource.pitch = 0;
                    _Audionsource.Stop();
                    isActiveGameOff = false;
                    Debug.Log
                    (
                    "isActiveGameOff : "
                    +
                    isActiveGameOff
                    );
                }
                else
                {
                    _Audionsource.clip = clipClick;
                    _Audionsource.loop = true;
                    _Audionsource.pitch = 1.20f;
                    _Audionsource.Play();
                    isActiveGameOn = true;
                    Debug.Log
                    (
                    "isActiveGameOn : "
                    +
                    isActiveGameOn
                    );
                }
            }

            
        }
    }
}

