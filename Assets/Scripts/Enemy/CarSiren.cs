using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CarSiren : MonoBehaviour
{
    AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnEnable()
    {
        audioSource.Play();
    }

    void OnDisable()
    {
        audioSource.Stop();
    }
}
