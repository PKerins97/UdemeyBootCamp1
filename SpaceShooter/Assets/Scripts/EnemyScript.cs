using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3f;

    private PlayerScript _player;
    [SerializeField]
    private GameObject _laserPrefab;
    private float _fireRate = 3.0f;
    private float _canFire = -1;
    //get handle for animator
    [SerializeField]
    private Animator _anim;
    private AudioManager _audioManager;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<PlayerScript>();
        _audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
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
        
        if(_audioManager == null)
        {
            Debug.LogError("No Audio Manager found on ENEMY");
        }
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();

        if (Time.time > _canFire)
        {

            _fireRate = Random.Range(2f, 6f);
            _canFire = Time.time + _fireRate;
            GameObject enemyLaser = Instantiate(_laserPrefab, transform.position, Quaternion.identity);
            LaserScript[] lasers = enemyLaser.GetComponentsInChildren<LaserScript>();
            for (int i = 0; i < lasers.Length; i++)
            {
                
                lasers[i].AssignEnemyLaser();
            }
        }
    }
    void HandleMovement()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < -8f)
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
            _audioManager.ExplosionSound();
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
            _audioManager.ExplosionSound();
            Destroy(GetComponent<Collider2D>());
            Destroy(this.gameObject, 2.8f);
        }
    }
}
