using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private bool horizontalMovement;
    [SerializeField]
    private bool verticalMovement;
    [SerializeField]
    private bool moveLeft;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveLeft = true;
    }

    // Update is called once per frame
    void Update()
    {
        movePlatform();
    }

    private void movePlatform()
    {
        //check to see if the platform needs to hoirzontal or vertical
        if(horizontalMovement)
        {
            //move platform to the left
            if(moveLeft)
            {
                //This type of movement is set off of framerate.
                //Need to get the movement into units of time
                //This needs to be multiplied by time.deltatime so we are moving
                //the object with time and not framerate.
                //We do not do this with player, because velocity is already in a time metric
                transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);
            }
            //move platform to the right
            else
            {
                //This type of movement is set off of framerate.
                //Need to get the movement into units of time
                //This needs to be multiplied by time.deltatime so we are moving
                //the object with time and not framerate.
                //We do not do this with player, because velocity is already in a time metric
                transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("MoveWallLeftBound"))
        {
            moveLeft = false;
        }
        else if (collision.gameObject.CompareTag("MoveWallRightBound"))
        {
            moveLeft = true;
        }    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //We want to parent the platform to the player
            //This makes the player move with the platform
            collision.gameObject.transform.SetParent(gameObject.transform);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(null);

        }
    }
}
