using UnityEngine;
// source: https://www.youtube.com/watch?v=UV5tXMfVfUU
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    public AudioSource audioSource;
    public AudioClip[] random_error_sounds;
    private AudioClip current_error_sound;
    
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void PlayRandomErrorSound()
    {
        if (random_error_sounds == null || random_error_sounds.Length == 0)
        {
            Debug.LogWarning("AudioManager: random_error_sounds is not assigned!");
            return;
        }
        current_error_sound = random_error_sounds[Random.Range(0, random_error_sounds.Length)];
        audioSource.PlayOneShot(current_error_sound);
    }
}
