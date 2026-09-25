using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
//attached to a random game object
//not to collectables themselves
public class CollectableSpawner : MonoBehaviour
{
    //These are determined where to spawn the collectables, we use empty game objects by referencing their x / y
    public GameObject lowestYSpawn;
    public GameObject highestYSpawn;
    //These are public variables to allow drag and drop prefabs
    public GameObject tealCollectable;
    public GameObject goldCollectable;
    public GameObject redCollectable;
    //random number to determine which of the collectables to spawn
    private int randomNum;
    //Which collectable to spawn
    private GameObject collectableToSpawn;

    //We need a reference to time so we can determine how often to spawn a collectable
    private float time;

    //Need a delay between spawns
    public float delay;


    // Update is called once per frame
    void Update()
    {
        //add to time; see how much time has passed since the last frame;
        time += Time.deltaTime;
        if(time > delay)
        {
            //If time greater than delay, spawn object
            spawnObject();
            //Reset timer
            time = 0f;
        }
    }
    private void spawnObject()
    {
        //get a random number to determine what object to spawn
        randomNum = Random.Range(0, 3);
        if (randomNum == 0)
        {
            //Collectable 1
            collectableToSpawn = Instantiate(tealCollectable);
        }
        else if (randomNum == 1)
        {
            //Collectable 2
            collectableToSpawn = Instantiate(goldCollectable);
        }
        else if (randomNum == 2)
        {
            //Collectabl 3
            collectableToSpawn = Instantiate(redCollectable);
        }

        //Tell the collectable where to spawn
        collectableToSpawn.transform.position = new Vector2(lowestYSpawn.transform.position.x, Random.Range(lowestYSpawn.transform.position.y, highestYSpawn.transform.position.y));
    }
}
