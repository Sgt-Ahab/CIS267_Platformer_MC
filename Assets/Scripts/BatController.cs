//Name: David Sargent
//Date: 10-06-2026
//Desc: Controls the Bat Behavior
//Attach: Bat Parent Object
using UnityEngine;

public class BatController : MonoBehaviour
{
    //Using a simple pathfinding algo to route to player and move towards
    private GameObject player;
    private Vector2 playerLOC;
    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        playerLOC = player.transform.position;
        //move bat towards player
        transform.position = Vector2.MoveTowards(transform.position, playerLOC, speed * Time.deltaTime);
    }
}
