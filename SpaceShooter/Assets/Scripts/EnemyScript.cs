using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4f;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 8, 0);
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

    private void OnTriggerEnter(Collider other)
    {
        //if other is player
         //damage player
        //destroy us
        if(other.tag == "Player")
        {
            Destroy(this.gameObject);
        }

        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        //if other is laser
        //destroy us
        //Destroy laser
    }
}
