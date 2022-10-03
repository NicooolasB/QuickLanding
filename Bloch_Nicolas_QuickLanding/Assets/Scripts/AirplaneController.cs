using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AirplaneController : MonoBehaviour
{
    public GameManager gameManager;
    public Joystick joystick;
    private Rigidbody rb;
    public float forwardFlySpeed = 5f;
    public float YawAmount = 40;
    private float Yaw;
    private bool canFly = true;
    private float horizontalInput;
    private float verticalInput;

    //a collider used for the end of the game
    public GameObject landingZone;
    bool gameFinished = false;
    


    private void Awake() {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touches.Length != 0  || Input.GetMouseButton(0))
        {
            //inputs
            horizontalInput = joystick.Horizontal;
            verticalInput = joystick.Vertical;
        }
    }

    private void FixedUpdate() 
    {
        if(canFly){
            //move forward
            transform.position += transform.forward * forwardFlySpeed * Time.deltaTime;


            //turn yaw, pitch and roll
            Yaw += horizontalInput * YawAmount * Time.deltaTime;
            float pitch = Mathf.Lerp(0,20,Mathf.Abs(verticalInput)) * Mathf.Sign(verticalInput);
            float roll = Mathf.Lerp(0,20,Mathf.Abs(horizontalInput)) * -Mathf.Sign(horizontalInput);

            //apply rotation
            transform.localRotation = Quaternion.Euler(Vector3.up * Yaw + Vector3.right * pitch + Vector3.forward * roll);
        }

        else{
            //brake
            if(forwardFlySpeed > 0.05f){
                forwardFlySpeed -= 2* forwardFlySpeed * Time.deltaTime; 
                transform.position += transform.forward * forwardFlySpeed * Time.deltaTime;
                transform.localRotation = Quaternion.Euler(Vector3.up * 0 + Vector3.right * 0 + Vector3.forward * 0);
            }
            else{
                if(!gameFinished){
                    finishGame();
                }
            }

        }
    }

    public void finishGame()
    {
        gameFinished = true;
        forwardFlySpeed = 0f;
        rb.isKinematic = true;
        if(landingZone != null){ 
            gameManager.GameFinish(landingZone.name);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Ground"){
            canFly = false;
            landingZone = other.gameObject;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Obstacle"){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }


}
