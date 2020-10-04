using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    private bool _stopSpawn = false;
    
    [SerializeField]
    private GameObject _enemyContenedor;
    [SerializeField]
    private GameObject _PowerContenedor;
    void Start()
    {
        StartCoroutine(SpawnRoutine());
        StartCoroutine(SpawnPowerUp());

    }

    void Update()
    {
        
    }
    IEnumerator SpawnRoutine()
    {
        while(_stopSpawn == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
            GameObject newEnemy = Instantiate(_enemyPrefab, posToSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemyContenedor.transform;
            yield return new WaitForSeconds(5.0f);
        }
    }

    IEnumerator SpawnPowerUp(){
        while(_stopSpawn == false)
        {
        Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
        GameObject power = Instantiate(_PowerContenedor, posToSpawn, Quaternion.identity);
        power.transform.parent = _PowerContenedor.transform;
        yield return new WaitForSeconds(5.0f);
        }
    }

    public void OnplayerDeath(){
        _stopSpawn = true;
    }
}