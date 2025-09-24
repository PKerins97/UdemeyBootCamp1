using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    [SerializeField]
    private float _laserSpeed = 6f;
    private bool _isEnemyLaser = false;
   // Update is called once per frame
    void Update()
    {
       if(_isEnemyLaser == false)
        {
            MoveUp();
        }
       else 
        {
            MoveDown();
        }
    }

    void MoveUp()
    {
        transform.Translate(Vector3.up * _laserSpeed * Time.deltaTime);

        if (transform.position.y > 8.57f)
        {
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            Destroy(this.gameObject);
        }
    }

    void MoveDown()
    {
        transform.Translate(Vector3.down * _laserSpeed * Time.deltaTime);

        if (transform.position.y < -8f)
        {
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            Destroy(this.gameObject);
        }
    }

    public void AssignEnemyLaser()
    {
        
        _isEnemyLaser = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && _isEnemyLaser == true)
        {
            PlayerScript player = GetComponent<PlayerScript>();
            if(player != null)
            {
                player.HandleDamage();
            }
        }
    }
}
