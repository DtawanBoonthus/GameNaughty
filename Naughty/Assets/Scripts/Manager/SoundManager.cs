using System;
using UnityEngine;
using Utilities;

namespace Manager
{
    public class SoundManager : MonoSingleton<SoundManager>
    {
        [Serializable]
        public class SoundClip
        {
            public Sound sound;
            public AudioClip audioClip;
            public bool loop = false;
            
            [HideInInspector] public float soundVolume;
            [HideInInspector] public float soundVolumeBGM = 0.2f;
            [HideInInspector] public AudioSource audioSource;
        }

        public enum Sound
        {
            BGM,
            Click,
            Throw,
            Walk
        }

        [SerializeField] private SoundClip[] soundClips;

        public void Play(Sound sound)
        {
            var soundClip = GetSoundClip(sound);
            
            if (soundClip.audioSource == null)
            {
                soundClip.audioSource = gameObject.AddComponent<AudioSource>();
            }

            soundClip.audioSource.clip = soundClip.audioClip;
            soundClip.soundVolume = UIManager.Instance.SoundLevel;

            if (soundClip.sound == Sound.BGM)
            {
                soundClip.audioSource.volume = soundClip.soundVolumeBGM;
            }

            if (soundClip.sound != Sound.BGM)
            {
                soundClip.audioSource.volume = soundClip.soundVolume;
            }

            soundClip.audioSource.loop = soundClip.loop;
            soundClip.audioSource.Play();
        }

        public void Stop(Sound sound)
        {
            var soundClip = GetSoundClip(sound);

            soundClip.audioSource.Stop();
        }

        protected override void Awake()
        {
            base.Awake();
            
            Debug.Assert(soundClips != null && soundClips.Length != 0, "Sound clips need to be setup");
        }

        private void Start()
        {
            Play(Sound.BGM);
        }

        private SoundClip GetSoundClip(Sound sound)
        {
            foreach (var soundClip in soundClips)
            {
                if (soundClip.sound == sound)
                {
                    return soundClip;
                }
            }

            return null;
        }
    }
}