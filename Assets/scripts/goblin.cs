using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goblin : MonoBehaviour
{
    [SerializeField] private float movementDist;

    [SerializeField] private float speed;

    private bool movingLeft;

    private float leftEdge;

    private float rightEdge;
    // Start is called before the first frame update
    void Start()
    {
        leftEdge = transform.position.x - movementDist;
        rightEdge = transform.position.x + movementDist;
    }

    // Update is called once per frame
    void Update()
    {
        if (movingLeft == true)
        {
            transform.localScale = new Vector3(4,4,1);
        }
        else if (movingLeft == false)
        {
            transform.localScale = new Vector3(-4,4,1);
        }

        if (movingLeft)
        {
            if (transform.position.x > leftEdge)
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y ,  transform.position.z);
            }
            else
            {
                movingLeft = false;
            }
        }
        else
        {
            if (transform.position.x < rightEdge)
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
            {
                movingLeft = true;
            }
        }
    }
}
