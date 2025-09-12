using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private float _rotationspeed = 19f;
    [SerializeField]
    private GameObject _explosionPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
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
            
            Destroy(other.gameObject);
            Destroy(this.gameObject, 0.25f);
            Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            
        }
    }
    //laser collision
    //instatiate explosion on this position
    //destroy after 3 secs
}
