using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.5f;
    [SerializeField]
    private GameObject _laser;
    private float _laserOffset = 0.8f;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();

        Vector3 offset = new Vector3(0, _laserOffset, 0);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(_laser, transform.position + offset, Quaternion.identity);
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
}
