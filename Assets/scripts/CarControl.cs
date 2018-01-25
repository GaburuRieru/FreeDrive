using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControl : MonoBehaviour {

    Rigidbody rb;

    delegate void Testinput();
    Testinput testInput;

	void Start () {
        rb = this.GetComponent<Rigidbody>();

        testInput += Steer;
        testInput += Drive;
	}
	
	void Update () {
        testInput();
	}

    float KeyboardInput()
    {
        float steer = Input.GetAxis("Steer");
        return steer;
    }

    void Steer()
    {
        float rotation = rb.rotation.eulerAngles.y;

        if (KeyboardInput() != 0)
        {
            if (KeyboardInput() < 0)
            {
                rotation -= 1f;
            }
            else rotation += 1f;

            Quaternion rotQuart = Quaternion.AngleAxis(rotation, Vector3.up);

            rb.MoveRotation(rotQuart);
        }
    }

    void Drive()
    {
        if(Input.GetButton("Accelerate"))
        {
            rb.AddRelativeForce(Vector3.forward * 30f);
        }
        else if (Input.GetButton("Brake"))
        {
            Vector3 velo = rb.velocity;
            if(velo.z > 0)
            rb.AddRelativeForce(Vector3.back * 10f);
        }
    }
}
