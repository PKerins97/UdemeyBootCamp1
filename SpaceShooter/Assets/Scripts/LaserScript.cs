using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    [SerializeField]
    private float _laserSpeed = 3f;
   // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * _laserSpeed * Time.deltaTime);

        if(transform.position.y >= 8.57)
        {
            Destroy(this.gameObject);
        }
    }
}
