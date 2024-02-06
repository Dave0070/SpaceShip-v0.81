using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpaceShip : MonoBehaviour
{

    Rigidbody spaceshipRB;

    //INP
    float verticalMove;
    float horizontalMove;
    float mouseInputX;
    float mouseInputY;
    float rollInput;


    //SM
    [SerializeField]
    float speedMulti = 1;
    [SerializeField]
    float speedMultAngle = 0.5f;
    [SerializeField]
    float speedRollMultAngel = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
       spaceshipRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       verticalMove = Input.GetAxis("Vertical");
       horizontalMove = Input.GetAxis("Horizontal");
       rollInput = Input.GetAxis("Roll");

       mouseInputX = Input.GetAxis("Mouse X");
       mouseInputY = Input.GetAxis("Mouse Y");
    }

    void FixedUpdate()
    {

        spaceshipRB.AddForce(spaceshipRB.transform.TransformDirection(Vector3.forward) * verticalMove * speedMulti, ForceMode.VelocityChange);

        spaceshipRB.AddForce(spaceshipRB.transform.TransformDirection(Vector3.right) * horizontalMove * speedMulti, ForceMode.VelocityChange);

        spaceshipRB.AddTorque(spaceshipRB.transform.right * speedMultAngle * mouseInputY * -1, ForceMode.VelocityChange);
        spaceshipRB.AddTorque(spaceshipRB.transform.up * speedMultAngle * mouseInputX, ForceMode.VelocityChange); 

         spaceshipRB.AddTorque(spaceshipRB.transform.forward * speedRollMultAngel * rollInput, ForceMode.VelocityChange);

    }
}
