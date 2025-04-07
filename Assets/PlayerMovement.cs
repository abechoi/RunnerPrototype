using UnityEngine; // Import Unity's core library

// This defines a class named "PlayerMovement" which extends "MonoBehaviour" 
// MonoBehaviour is a base class required for Unity scripts to function properly.
public class PlayerMovement : MonoBehaviour
{
    // Speed of the player's forward movement
    public float speed = 5f;
    
    // The horizontal distance between lanes
    public float laneDistance = 2.5f; 
    
    // Tracks the player's current lane (0 = left, 1 = middle, 2 = right)
    private int lane = 1; 

    // Reference to the CharacterController component
    private CharacterController controller;

    // The Start() method is called once when the game begins
    void Start()
    {
        // Get the CharacterController component attached to this GameObject
        controller = GetComponent<CharacterController>();
    }

    // The Update() method is called every frame (about 60 times per second)
    void Update()
    {
        // Move the player forward continuously
        Vector3 move = Vector3.forward * speed * Time.deltaTime;
        controller.Move(move);

        // Handle left and right movement when arrow keys are pressed
        if (Input.GetKeyDown(KeyCode.LeftArrow) && lane > 0) // Move left
        {
            lane--;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && lane < 2) // Move right
        {
            lane++;
        }

        // Calculate the target lane position based on lane index
        Vector3 targetPosition = new Vector3((lane - 1) * laneDistance, transform.position.y, transform.position.z);
        
        // Smoothly move the player to the target lane using Lerp (linear interpolation)
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 10);
    }
}
