/*using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public Transform spawnPos;
    public GameObject floor, top, obs1, obs2;
    GameObject spawn;

    Vector3 floorPos;
    Vector3 topPos;

    private float time;
    private float obsTime;


    // Start is called before the first frame update
    void Start()
    {
        //initializing starting floor and top
        spawn = Instantiate(floor, new Vector3(0f, 0f, 0f), floor.transform.rotation) as GameObject;
        spawn = Instantiate(top, new Vector3(0f, 5f, 0f), top.transform.rotation) as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        floorPos = new Vector3(0, 0, spawnPos.position.z + 20f);
        floorPos = new Vector3(0, 5f, spawnPos.position.z + 20f);
        spawnPos.position = floorPos;

        //if 0 makes floor if 1 makes top
        int rand = Random.Range(0, 2);

        time = Time.deltaTime;

        //time before floor and top starts spawning
        if (time >= 2)
        {
            //generating floor
            if(rand == 0)
            {
                Vector3 newPos = new Vector3(Random.Range(-4, 4), 0, Random.Range(floorPos.z - 1, floorPos.z + 1));
                spawn = Instantiate(floor, newPos, transform.rotation) as GameObject;
            }
            //generating top
            if (rand == 1)
            {
                Vector3 newPos = new Vector3(Random.Range(-4, 4), 5f, Random.Range(topPos.z - 1, topPos.z + 1));
                spawn = Instantiate(top, newPos, transform.rotation) as GameObject;
            }
            time = 0;
        }
        

    }
}
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform c;
    Vector3 ceilPos;
    Vector3 floorPos;
    public GameObject floor;
    public GameObject top;
    public GameObject obs;
    public GameObject obs2;
    private float time = 2;
    private float time2 = 3;

    GameObject f;
    void Start()
    {
        f = Instantiate(floor, new Vector3(0f, 0f, 0f), floor.transform.rotation) as GameObject;
        f = Instantiate(top, new Vector3(0f, 6.5f, 0f), top.transform.rotation) as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        floorPos = new Vector3(0, 0f, c.position.z + 21f);
        ceilPos = new Vector3(0, 6.5f, c.position.z + 22f);
        transform.position = floorPos;
        int x = Random.Range(1, 3);

        time += Time.deltaTime;
        if (time >= 2)
        {

            if (x == 1)
            {
                Vector3 d = new Vector3(Random.Range(-4, 4), 0f, Random.Range(floorPos.z - 1, floorPos.z + 1));
                f = Instantiate(floor, d, transform.rotation) as GameObject;
            }
            else if (x == 2)
            {
                Vector3 d = new Vector3(Random.Range(-4, 4), 7f, Random.Range(ceilPos.z -1, ceilPos.z + 1));
                f = Instantiate(top, d, transform.rotation) as GameObject;
            }
            time = 0;
        }

        time2 += Time.deltaTime;
        if (time2 >= 3)
        {
            int z = Random.Range(1, 3);
            if (z == 1)
            {
                if (x == 1)
                {
                    Vector3 d = new Vector3(Random.Range(-4, 4), .75f, Random.Range(-1 + floorPos.z, 1 + floorPos.z));
                    f = Instantiate(obs, d, transform.rotation) as GameObject;
                }
                else if (x == 2)
                {
                    Vector3 d = new Vector3(Random.Range(-4, 4), 5.5f, Random.Range(-1 + ceilPos.z, 1 + ceilPos.z));
                    f = Instantiate(obs, d, transform.rotation) as GameObject;
                }
            }

            if (z == 2)
            {
                if (x == 1)
                {
                    Vector3 d = new Vector3(Random.Range(-4, 4), .5f, Random.Range(-1 + floorPos.z, 1 + floorPos.z));
                    f = Instantiate(obs2, d, transform.rotation) as GameObject;
                }
                else if (x == 2)
                {
                    Vector3 d = new Vector3(Random.Range(-4, 4), 6.5f, Random.Range(-1 + ceilPos.z, 1 + ceilPos.z));
                    f = Instantiate(obs2, d, transform.rotation) as GameObject;
                }
            }
            time2 = 0;
        }

    }
}
