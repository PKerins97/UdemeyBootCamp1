using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.5f;
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
        transform.Translate(direction * _speed * Time.deltaTime);

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
        
        //if space key pressed fire 1 laser
        //if triple is active = true
        //fire 3 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_isTripleShotActive == true)
            {
                Instantiate(_tripleShotPrefab, transform.position, Quaternion.identity);
            }

            else
                Instantiate(_laser, transform.position + offset, Quaternion.identity);
        }
        //else
        //fire 1

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
        //tripleShotActive
        //start power down coroutine
        _isTripleShotActive = true;
        StartCoroutine(TripleShotPowerDownRoutine());

    }
    IEnumerator TripleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        _isTripleShotActive = false;
    }
    //IENumerator TripleShotPowerDownRoutine
    //wait 5
    //set triple to false
}
