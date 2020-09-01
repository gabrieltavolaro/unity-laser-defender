using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    // Configuration Parameters
    [SerializeField] float moveSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        // Get 'x' movement
        float deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float newXPos = transform.position.x + deltaX;

        // Get 'y' movement
        float deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        float newYPos = transform.position.y + deltaY;

        // Add to position
        transform.position = new Vector2(newXPos, newYPos);
    }
}
