using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private float size;

    [SerializeField] GameObject platform;
    [SerializeField] GameObject coin;

    private Color color1;

    private Vector3 lastPos;

    // Use this for initialization
    void Start()
    {
        color1 = new Color(0, 0, 0);
        size = platform.transform.localScale.x;
        lastPos = platform.transform.position;

        for (int i = 0; i < 5; i++)
        {
            //Spawn tiles on the Z axis
            SpawnZ();
        }

        InvokeRepeating("SpawnPlatform", 2f, 0.2f);
    }
    void Update()
    {

    }

    private void SpawnX()
    {

        int rand = Random.Range(1, 3);
        //instansiate platform and store as platform
        GameObject _platform = Instantiate(platform) as GameObject;

        _platform.GetComponent<Renderer>().material.color = color1;



        //adding platfrom "size" amount aaway
        _platform.transform.position = lastPos + new Vector3(size, 0f, 0f);
        lastPos = _platform.transform.position;
    }

    private void SpawnZ()
    {

        //instansiate platform and store as platform
        GameObject _platform = Instantiate(platform) as GameObject;


        _platform.GetComponent<Renderer>().material.color = color1;


        //adding platfrom "size" amount aaway
        _platform.transform.position = lastPos + new Vector3(0f, 0f, size);
        lastPos = _platform.transform.position;

    }

    private void SpawnPlatform()
    {
        //randomly spawn platform on X or Z
        int random = Random.Range(0, 6);
        int coinrandom = Random.Range(0,8);
        if (random < 3)
        {
            SpawnX();
        }
        else
        {
            SpawnZ();
        }

        if (coinrandom < 3)
        {
            SpawnCoin();
        }

    }

    private void SpawnCoin()
    {
        //spawn coin above the platform
        Instantiate(coin, lastPos + Vector3.up, Quaternion.identity);

    }
}
