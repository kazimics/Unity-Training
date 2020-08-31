using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject pipeObject;
    public GameObject floor;
    private bool stopSpawn = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnPipe());
    }


    private IEnumerator SpawnPipe()
    {
        yield return new WaitForSeconds(3.0f);
        while (stopSpawn == false)
        {
            Vector2 posPipeSpawn = new Vector2(3.5f, Random.Range(-1f, 1.22f));
            GameObject newPipe = Instantiate(pipeObject, posPipeSpawn, Quaternion.identity);
            newPipe.transform.parent = transform;
            yield return new WaitForSeconds(4.5f);
        }
    }
}
