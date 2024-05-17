using UnityEngine;

public class AudioManager : MonoBehaviour {
    public static AudioManager instance;

    public AudioSource musicSource;
    public AudioSource effectsSource;

    public AudioClip[] musicClips;
    public AudioClip[] effectClips;

    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("AudioManager instantiated");
        } else {
            Destroy(gameObject);
        }
    }

    public void PlayMusic(int index) {
        if (index >= 0 && index < musicClips.Length) {
            musicSource.clip = musicClips[index];
            musicSource.Play();
        }
    }

    public void PlayEffect(int index) {
        if (index >= 0 && index < effectClips.Length) {
            effectsSource.PlayOneShot(effectClips[index]);
        }
    }

    public void SetMusicVolume(float volume) {
        musicSource.volume = volume;
    }

    public void SetEffectsVolume(float volume) {
        effectsSource.volume = volume;
    }

    public void PlayPickupSound() {
        PlayEffect(0); // Assuming index 0 is for the pickup/drop sound
    }

    public void PlayDropSound() {
        PlayEffect(0); // Reusing the same sound as pickup for drop
    }
}
