using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public List <GameObject> critterPrefabs;
    public float critterSpawnFrequency = 1.0f;
    public Score scoreDisplay;

    private float lastCritterSpawn = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //check if it is time to spawn the next critter
        float nextSpawnTime = lastCritterSpawn + critterSpawnFrequency;
		if (Time.time >= nextSpawnTime)
        {
            //IT IS TIME
            //Choose a random critter to spawn
            int critterIndex = Random.Range(0, critterPrefabs.Count);
            GameObject prefabToSpawn = critterPrefabs[critterIndex];

            //Spawn critter!
            GameObject spawnedCritter = Instantiate(prefabToSpawn);

            //Get access to critter script
            Critter critterScript = spawnedCritter.GetComponent<Critter>();

            //Tell the critter object what the score is
            critterScript.scoreDisplay = scoreDisplay;


            //Update the most recent critter spawn time to now
            lastCritterSpawn = Time.time;

        }
	}
}
