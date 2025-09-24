using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip _explosionClip;
    private AudioSource _audioSource;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        
        if(_audioSource == null)
        {
            Debug.LogError("No Audio Source On AUDIO MANAGER");
        }
    }

    
    public void ExplosionSound()
    {
        _audioSource.clip = _explosionClip;
        _audioSource.Play();
    }
}
