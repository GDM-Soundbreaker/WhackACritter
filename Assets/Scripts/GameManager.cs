using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public List <GameObject> critterPrefabs;
    public float critterSpawnFrequency = 1.0f;
    public Score scoreDisplay;
    public Timer timer;
    public SpriteRenderer button;


    private float lastCritterSpawn = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //check if it is time to spawn the next critter
        float nextSpawnTime = lastCritterSpawn + critterSpawnFrequency;
		if (Time.time >= nextSpawnTime && timer.IsTimerRunning() == true)
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
            critterScript.timer = timer;

            //Update the most recent critter spawn time to now
            lastCritterSpawn = Time.time;

        }

        //update button visibility
        if (timer.IsTimerRunning() == true)
        {
            button.enabled = false;
        }
        else // if game is not running
        {
            button.enabled = true;
        }

	}

    //did they click the button?
    private void OnMouseDown()
    {
if (timer.IsTimerRunning() == false)
        {
            //start new game
            timer.StartTimer();
            scoreDisplay.ResetScore();
        }
    }
}
