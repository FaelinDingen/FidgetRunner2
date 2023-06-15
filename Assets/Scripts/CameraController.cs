using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform mC;
    void Start()
    {
        mC = GameObject.Find("Player").GetComponent<Transform>();
    }

    
    void Update()
    {
        gameObject.transform.position = new Vector3(mC.position.x,mC.position.y,-10);
    }
}
