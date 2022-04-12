using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LP.FDG.InputManager
{
    public class AudioManager : MonoBehaviour
    {
        private AudioSource audioSource;
        [SerializeField]
        private AudioClip audionClip;
        [SerializeField]
        private Button btnPlay;
        [SerializeField]
        private Button btnStop;

        // Start is called before the first frame update
        void Start()
        {
            audioSource = GetComponent<AudioSource>();
            btnPlay.onClick.AddListener(Play);
            btnStop.onClick.AddListener(Stop);
            
        }
        public void Play()
        {
            AudioMachine.instance.SoundPlayBTNon();
            audioSource.clip = audionClip;
            audioSource.loop = true;
            audioSource.Play();
        }
        public void Stop()
        {
            AudioMachine.instance.SoundPlayBTNoff();
            audioSource.Stop();
            audioSource.clip = null;
            audioSource.loop = false;
        }
        // Update is called once per frame

    }
}

