using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{

    [SerializeField] float movementDistance;
    [SerializeField] float speed;
    [SerializeField] SpriteRenderer spriteRenderer;
    bool movingLeft;
    float leftWaypoint;
    float rightWaypoint;
    // Start is called before the first frame update
    void Awake()
    {
        leftWaypoint = transform.position.x - movementDistance;
        rightWaypoint = transform.position.x + movementDistance;

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (movingLeft)
        {
            if (transform.position.x > leftWaypoint)
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
            {
                movingLeft = false;
            }
            spriteRenderer.flipX= true;
            
        }
        else
        {
            if (transform.position.x < rightWaypoint)
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
            {
                movingLeft = true;
            }
            spriteRenderer.flipX = false;
        }
    }
}
