using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private float size;

    [SerializeField] GameObject platform;
    // Use this for initialization

    private Vector3 lastPos;

	void Start ()
    {
        size = platform.transform.localScale.x;
        lastPos = platform.transform.position;

        for(int i = 0; i < 15; i++)
        {
            //Spawn tiles on the Z axis
            SpawnZ();
        }

        InvokeRepeating("SpawnPlatform", 2f, 0.2f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void SpawnX()
    {
        //instansiate platform and store as platform
        GameObject _platform = Instantiate(platform) as GameObject;
        //adding platfrom "size" amount aaway
        _platform.transform.position = lastPos + new Vector3(size, 0f, 0f);
        lastPos = _platform.transform.position;
    }

    private void SpawnZ()
    {
        //instansiate platform and store as platform
        GameObject _platform = Instantiate(platform) as GameObject;
        //adding platfrom "size" amount aaway
        _platform.transform.position = lastPos + new Vector3(0f, 0f, size);
        lastPos = _platform.transform.position;

    }

    private void SpawnPlatform()
    {
        //randomly spawn platform on X or Z
        int random = Random.Range(0, 6);
        if (random < 3)
        {
            SpawnX();
        }
        else
        {
            SpawnZ();
        }
    }
}
