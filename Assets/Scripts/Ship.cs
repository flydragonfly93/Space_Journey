using UnityEngine;
using UnityEngine.SceneManagement;

public class Ship : MonoBehaviour
{
    private Vector3 _initialPosition;
    private bool _shipWaslaunched; // bool 's default is "false", around gravity scale: _shipWaslaunched = true;
    private float _timeSittingAround;

    [SerializeField] private float _launchPower = 500; //not Vector2 but we will use float (like decimals, negative to big big numbers, for default usage also), 
                                                       //[SerializeField] = for designer use, inspector -> Launch Power in Ship (Script)

    private void Awake()
    {
        _initialPosition = transform.position; //Reset to initialPosition
    }

    private void Update()
    {
        GetComponent<LineRenderer>().SetPosition(1, _initialPosition); //LineRenderer -> index O 
        GetComponent<LineRenderer>().SetPosition(0, transform.position); //LineRenderer -> index 1 Ship's current Position


        if (_shipWaslaunched &&       //&& and
            GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1) //Velocity = x,y Magnitude = x and y combined 
        {
            _timeSittingAround += Time.deltaTime; // frame once per second
        }
        if (transform.position.y > 10 ||  // if分 = to check the scene
            transform.position.y < -10 ||
            transform.position.x > 10 ||
            transform.position.x < -10 ||
            _timeSittingAround > 3)
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name); //LoadScene( ) = reload currentscene, (SceneManager.GetActiveScene().name) = get the current scene  
            string currentSceneName = SceneManager.GetActiveScene().name; // Wag na ito i copy,paste kasi gagamitin ung ( || ) sa if分 sa taas
            SceneManager.LoadScene(currentSceneName);
        }
    }

    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        GetComponent<LineRenderer>().enabled = true; // enable line when dragging, contrary to OnMouseUp
    }

    private void OnMouseUp()  //launching of ship
    {
        GetComponent<SpriteRenderer>().color = Color.white;


        Vector2 directionToInitialPosition = _initialPosition - transform.position;  //initial position - current position = total amount of distance

        GetComponent<Rigidbody2D>().AddForce(directionToInitialPosition * _launchPower); // Moved forward without arc, need a gravityScale = 1; 
        GetComponent<Rigidbody2D>().gravityScale = 1;
        _shipWaslaunched = true;

        GetComponent<LineRenderer>().enabled = false; // when dragging stopped, line will disappear.
    }

    private void OnMouseDrag()
    {

        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x, newPosition.y); //(Vector without z)
    }
}
