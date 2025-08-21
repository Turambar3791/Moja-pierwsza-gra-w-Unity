using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heart : MonoBehaviour
{
    [SerializeField] private Transform player;

    private float offsetX, offsetY;
    // Start is called before the first frame update
    void Start()
    {
        offsetX = transform.position.x - player.position.x;
        offsetY = transform.position.y - player.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x + offsetX, player.position.y + offsetY, transform.position.z);
    }
}
