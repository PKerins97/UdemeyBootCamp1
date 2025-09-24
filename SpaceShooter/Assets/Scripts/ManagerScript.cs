using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _enemyContainier;
    [SerializeField]
    private GameObject[] powerups;
    [SerializeField]
    private GameObject _speedPowerupPrefab;
    private bool _stopSpawining = false;
    
    
    // Start is called before the first frame update
    void Start()
    {
      
      
    }

   

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartSpawning()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerupRoutine());
    }

    IEnumerator SpawnEnemyRoutine()
    {
        yield return new WaitForSeconds(3.0f);
        while (_stopSpawining == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
            GameObject newEnemy = Instantiate(_enemyPrefab,posToSpawn,Quaternion.identity);
            newEnemy.transform.parent = _enemyContainier.transform;
            yield return new WaitForSeconds(5.0f);
        }
    }

    IEnumerator SpawnPowerupRoutine()
    {
        //every 3 to 7 spawn a power up
        yield return new WaitForSeconds(3.0f);
        while (_stopSpawining == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
            int randomPowerUp = Random.Range(0, 3);
            Instantiate(powerups[randomPowerUp], posToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(3f, 8f));
        }
 
    }
    public void OnPlayerDeath()
    {
        _stopSpawining = true;
    }
}
