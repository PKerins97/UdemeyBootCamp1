using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private float _rotationspeed = 19f;
    [SerializeField]
    private GameObject _explosionPrefab;
    private ManagerScript _spawnManager;
    private AudioManager _audioManager;
    // Start is called before the first frame update
    void Start()
    {
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<ManagerScript>();
        _audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        if(_spawnManager == null)
        {
            Debug.LogError("No Spawn Manager found");
        }
        if(_audioManager == null)
        {
            Debug.LogError("no Audio Manager Found on Astroid");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        //rotate on z axis
        transform.Rotate(Vector3.forward * _rotationspeed * Time.deltaTime);
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Laser")
        {
            Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            _audioManager.ExplosionSound();
            Destroy(this.gameObject, 0.25f);
            _spawnManager.StartSpawning();
            
            
            
        }
    }
    //laser collision
    //instatiate explosion on this position
    //destroy after 3 secs
}
