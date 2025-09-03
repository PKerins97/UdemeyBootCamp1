using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupScript : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3f;
    private PlayerScript _player;
        // Start is called before the first frame update
    void Start()
    {
      transform.position =  new Vector3(0, 6f, 0);
        _player = GameObject.Find("Player").GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //move down at speed of three (adjust in inspector)
        //destroy when leave the screen
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if(transform.position.y < -6)
        {
            Destroy(this.gameObject);
        }

    }

    //On trig collision
    //collected by player
    //on collection destroy
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            //communicate with player script 
            _player.TripleShotActive();
            Destroy(this.gameObject);
        }
    }
}
