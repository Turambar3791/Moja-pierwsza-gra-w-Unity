using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eyes : MonoBehaviour
{
    [SerializeField] private float movementDist;

    [SerializeField] private float speed;

    private bool movingTop;

    private float topEdge;

    private float bottomEdge;
    // Start is called before the first frame update
    void Start()
    {
        topEdge = transform.position.y + movementDist;
        bottomEdge = transform.position.y - movementDist;
    }

    // Update is called once per frame
    void Update()
    {
        if (movingTop)
        {
            if (transform.position.y > bottomEdge)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, transform.position.z);
            }
            else
            {
                movingTop = false;
            }
        }
        else
        {
            if (transform.position.y < topEdge)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);
            }
            else
            {
                movingTop = true;
            }
        }
    }
}
