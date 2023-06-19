using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

using Unity.Netcode;

using static UnityEngine.InputSystem.InputAction;


public class NewBehaviourScript : NetworkBehaviour
{
    public GameObject SpawnPrefab;

    [SerializeField] 
    public float speed = 30;
    
    [SerializeField] 
    public float torqueSpeed = 30;

    Rigidbody rb;
    private Vector2 WalkTarget;


    public void OnMove(CallbackContext callback)
    {
        WalkTarget = callback.ReadValue<Vector2>();
    }


    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        if (IsOwner)
            CameraController.Instance.target = this.gameObject;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {

        if (!IsOwner)
            return;

        rb.AddForce(WalkTarget.y * transform.forward * speed);
        rb.AddTorque(new Vector3(0, -WalkTarget.x * torqueSpeed, 0));
    }

}
