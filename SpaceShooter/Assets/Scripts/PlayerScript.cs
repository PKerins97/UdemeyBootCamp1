using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.5f;
    [SerializeField]
    private float _powerSpeed = 8.0f;
    [SerializeField]
    private GameObject _laser;
    [SerializeField]
    private GameObject _tripleShotPrefab;
    private float _laserOffset = 1.05f;
    [SerializeField]
    private float _fireRate = 0.5f;
    private float _canFire = -1f;
    [SerializeField]
    private int _lives = 3;
    private ManagerScript _manager;
    
    [SerializeField]
    private bool _isTripleShotActive = false;
    [SerializeField]
    private bool _isSpeedUpActive = false;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        _manager = GameObject.Find("Manager").GetComponent<ManagerScript>();
        

        if (_manager == null)
        {
            Debug.Log("No Manager got");
        }
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            HandleFire();
        }
        
 
    }

    void HandleMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //transform.Translate(Vector3.right * horizontalInput * _speed * Time.deltaTime);
        //transform.Translate(Vector3.up * verticalInput * _speed * Time.deltaTime);
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        if (_isSpeedUpActive == true)
        {
            transform.Translate(direction * _powerSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(direction * _speed * Time.deltaTime);
        }
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.93f, 0 ),0);

        if (transform.position.x >= 11.31)
        {
            transform.position = new Vector3(-11.17f, transform.position.y, 0);
        }
        else if(transform.position.x <= -11.32)
        {
            transform.position = new Vector3(11.31f, transform.position.y, 0);
        }
    }

    void HandleFire()
    {
        Vector3 offset = new Vector3(0, _laserOffset, 0);
        _canFire = Time.time + _fireRate;
       
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_isTripleShotActive == true)
            {
                Instantiate(_tripleShotPrefab, transform.position, Quaternion.identity);
            }

            else
                Instantiate(_laser, transform.position + offset, Quaternion.identity);
        }
        
    }

    public void HandleDamage()
    {
        _lives -= 1;

        if(_lives < 1)
        {
            _manager.OnPlayerDeath();
            Destroy(this.gameObject);
        }
    }

   public void TripleShotActive()
    {
        _isTripleShotActive = true;
        StartCoroutine(TripleShotPowerDownRoutine());

    }

    public void SpeedUpActive()
    {
        _isSpeedUpActive = true;
        StartCoroutine(SpeedPowerDownRoutine());

    }
    IEnumerator TripleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        _isTripleShotActive = false;
    }
    
    IEnumerator SpeedPowerDownRoutine()
    {
        yield return new WaitForSeconds(10.0f);
        _isSpeedUpActive = false;
    }
}
