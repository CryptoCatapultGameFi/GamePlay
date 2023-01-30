using UnityEngine;
using UnityEngine.SceneManagement;

public class birdie2 : MonoBehaviour
{
    Vector3 startingPos;
    private Vector2 directiontoInitialPos;
    public float DirectionToInitialPosForce;
    private bool BirdWasThrown;

    float TimeSinceLaunch;
    
    AudioSource source;

    public AudioClip TensionClip;
    public AudioClip LaunchClip;


    private void Awake()
    {
        startingPos = transform.position;
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        GetComponent<LineRenderer>().SetPosition(0, transform.position);
        GetComponent<LineRenderer>().SetPosition(1, startingPos);

        if (transform.position.x <= -40
            || transform.position.y <= -17
            || transform.position.y >= 14
            || transform.position.x >= 40
            || TimeSinceLaunch >= 3f
            || Input.GetKeyDown(KeyCode.R)
            
            )
        {
            string currentLoadScene = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentLoadScene);
        }
        if (BirdWasThrown == true &&
            GetComponent<Rigidbody2D>().velocity.magnitude < 0.1f)
        {
            TimeSinceLaunch += Time.deltaTime;
        }
    }
    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        GetComponent<LineRenderer>().enabled = true;
        source.clip = TensionClip;
        source.Play();
        
    }
    private void OnMouseUp()
    {
        BirdWasThrown = true;

        GetComponent<SpriteRenderer>().color = Color.white;
        directiontoInitialPos = startingPos - transform.position;
        GetComponent<Rigidbody2D>().AddForce(directiontoInitialPos * DirectionToInitialPosForce);

        GetComponent<Rigidbody2D>().gravityScale = 1;

        GetComponent<LineRenderer>().enabled = false;
        source.clip = LaunchClip;
        source.Play();

    }

    private void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3 (newPosition.x, newPosition.y, 0);   
    }
}
