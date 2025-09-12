using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4f;

    private PlayerScript _player;

    //get handle for animator
    [SerializeField]
    private Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<PlayerScript>();
        //null check 
        if(_player == null)
        {
            Debug.LogError("No Player Found");
        }
        _anim = GetComponent<Animator>();
        if(_anim == null)
        {
            Debug.LogError("animator not found");
        }
        //assign component to anim
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if(transform.position.y < -5.37f)
        {
            float randomX = Random.Range(-8.97f, 8.81f);
            transform.position = new Vector3(randomX, 8, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       
        if(other.tag == "Player")
        {
            //PlayerScript player = other.transform.GetComponent<PlayerScript>();
            if(_player != null)
            {
                _player.HandleDamage();
                
            }
            //trigger anim
            _anim.SetTrigger("OnEnemyDeath");
            _speed = 0;
            Destroy(this.gameObject, 2.8f);
        }

        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            if (_player != null)
            {
                _player.AddScore(10);
  
            }
            //trigger anim
            _anim.SetTrigger("OnEnemyDeath");
            _speed = 0;
            Destroy(this.gameObject, 2.8f);
        }
    }
}
