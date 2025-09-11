using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupScript : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3f;
    private PlayerScript _player;

    //ID for powerups
    [SerializeField] //0 = triple shot, 1 = Speed, 2 = Shield
    private int powerupID;
        // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if(transform.position.y < -6)
        {
            Destroy(this.gameObject);
        }

    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
                   
           switch(powerupID)
            {
                case 0:
                    _player.TripleShotActive();
                    break;

                case 1:
                    _player.SpeedUpActive();
                    break;

                case 2:
                    _player.ShieldActive(); ;
                    break;

                default:
                    Debug.Log("Default");
                    break;
            }
            Destroy(this.gameObject);
        }
    }
}
