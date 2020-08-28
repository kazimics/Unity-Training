using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefabs;
    [SerializeField]
    private GameObject[] powerups;
    [SerializeField]
    private GameObject enemyContainer;
    private bool stopSpawn = false;

    public void StartSpawning()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnTripleShotRoutine());
    }

    IEnumerator SpawnEnemyRoutine()
    {
        yield return new WaitForSeconds(2f);
        while (stopSpawn == false)
        {
            Vector3 posTpSpawn = new Vector3(Random.Range(-12.6f, 4.4f), 7, 0);
            GameObject newEnemy = Instantiate(enemyPrefabs, posTpSpawn, Quaternion.identity);
            newEnemy.transform.parent = enemyContainer.transform;
            yield return new WaitForSeconds(1.5f);
        }
    }

    IEnumerator SpawnTripleShotRoutine()
    {
        yield return new WaitForSeconds(2f);
        while (stopSpawn == false)
        {
            Vector3 posTpSpawn = new Vector3(Random.Range(-12.6f, 4.4f), 7, 0);
            int randomPowerupIndex = Random.Range(0, 3);
            Instantiate(powerups[randomPowerupIndex], posTpSpawn, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(3.0f, 8.0f));
        }
    }

    public void OnPlayerdie()
    {
        stopSpawn = true;
    }
}