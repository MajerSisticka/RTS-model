using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LP.FDG.InputManager
{
    public class AudioMachine : MonoBehaviour
    {
        public static AudioMachine instance;
        AudioSource audioSource;
        [SerializeField]
        AudioClip[] clipSound;
        // Start is called before the first frame update
        private void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                instance = this;
            }
        }
        void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }
        public void SoundPlayBTNon()
        {
            audioSource.clip = clipSound[0];
            audioSource.Play();
        }
        public void SoundPlayBTNoff()
        {
            audioSource.clip = clipSound[1];
            audioSource.Play();
        }
    }
}