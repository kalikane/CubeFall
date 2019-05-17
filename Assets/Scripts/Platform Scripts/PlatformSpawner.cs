using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour {

    //here we spaw all the kinds of platefor ms
    //for spawn a plateform we need :
    // a timer :plateform_Spawn_Timer
    // we need also to count the plateform spawned :plateform_Spawn_Count
    public GameObject platformPrefab;
    public GameObject spikePlatformPrefab;
    public GameObject[] movingPlatforms;
    public GameObject breakablePlatform;


    //temps pour génerer une platefor
    public float plateform_Spawn_Timer = 1.8f;
    private float current_Platform_Spawn_timer;

    private int plateform_Spawn_Count;

    public float min_X = -2, max_X = 2;



	// Use this for initialization
	void Start () {
        //initialisation du current_Platform_Spawn_timer
        current_Platform_Spawn_timer = plateform_Spawn_Timer;
    }

    // Update is called once per frame
    void Update () {
        SpawnPlatforms();

    }

    //in this function we going to start spawning all the platform
    void SpawnPlatforms()
    {
        current_Platform_Spawn_timer += Time.deltaTime;
        if (current_Platform_Spawn_timer >= plateform_Spawn_Timer)
        {
            plateform_Spawn_Count++;
            //je recupère le composant position
            Vector3 temp = transform.position;
            temp.x = Random.Range(min_X, max_X);

            //il faut maintenant que le programme génère un type de plateforme
            //il faut noter qu'une plateforme est un gameObject
            GameObject newPlatform = null;

            if (plateform_Spawn_Count < 2)
            {
                //nous allons pondre la platefrom avec la methode instantiate
                //Quaternion.identity corresponds to "no rotation" - the object is perfectly aligned with the world or parent axe
                newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
                
            } else if (plateform_Spawn_Count == 2)
            {
                if (Random.Range(0,2) > 0)
                {
                    newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);

                }
                else
                {
                    newPlatform = Instantiate(
                        movingPlatforms[Random.Range(0, movingPlatforms.Length)],
                        temp, Quaternion.identity);
                }
            } else if(plateform_Spawn_Count == 3)
            {
                if (Random.Range(0, 2) > 0)
                {
                    newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);

                }
                else
                {
                    newPlatform = Instantiate(spikePlatformPrefab,temp, Quaternion.identity);
                }
            }else if (plateform_Spawn_Count == 4)
            {
                if (Random.Range(0, 2) > 0)
                {
                    newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);

                }
                else
                {
                    newPlatform = Instantiate(breakablePlatform, temp, Quaternion.identity);
                }

                //reinitialisation de plateform_Spawn_Count
                plateform_Spawn_Count = 0;
            }

            //je suis entrain de dire que son parent est plateform Spawner 
            //et donc les plateformes générées vont apparaitre sous
            //platform spawner
            if(newPlatform)
            newPlatform.transform.parent = transform;

            current_Platform_Spawn_timer = 0f;
        }
      
    }
}
