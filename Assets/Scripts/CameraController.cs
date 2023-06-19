using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class CameraController : MonoBehaviour
{
    public static CameraController Instance;

    public GameObject target;
    public float speed;

    private void Awake()
    {
        Instance = this;
    }

    private void FixedUpdate()
    {
        if(target != null)
            transform.position = Vector3.Lerp(transform.position, target.transform.position, speed);
    }

}
