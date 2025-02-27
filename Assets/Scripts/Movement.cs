using UnityEngine;

public class Movement : MonoBehaviour
{
    //object variables
    public CharacterController controller;
    
    //movement variables 
    public float speed = 20f;
    public float gravity = -1000f; //I want a stronger pull down
    public float jumpHeight = 20f;
    Vector3 velocity;
    bool isGrounded;
    

    void Start()
    {
        Cursor.visible = false;
    }
   
    void Update()
    {

        //if the player is on the ground and velocity is less than 0...
        isGrounded = controller.isGrounded;

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // normal velocity when on ground
        }
        
        //get input for movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        

        //use input to turn into direction (in the way that the player is facing)

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        //impliment the jump - if space key is pressed and player is on the ground...
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); //some math equation to jump in the air
        }


        //applying gravity

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
