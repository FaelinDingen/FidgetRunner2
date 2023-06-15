using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderMovement : MonoBehaviour
{
    public float speed;
    private GameObject player;

    private void Start() {
        player = GameObject.Find("Player");
    }

    void FixedUpdate()
    {
        if (player.transform.position.x - transform.position.x > 75) {
            transform.position = new Vector3(player.transform.position.x - 75, 10, 0);
        }
        transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
    }
}
