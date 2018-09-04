using UnityEngine;
using System.Collections;
using System.Threading;


public class carController : MonoBehaviour
{
    public WheelJoint2D backwheel;
    JointMotor2D motorBack;
    public float speedF;
    public float speedB;
    public float torqueF;
    public float torqueB;
    public bool TractionBack = true;
    public float carRotationSpeed;
    public ClickedScript[] ControleCar;

    void Update()
    {
        if (ControleCar[0].clickedIs == true || Input.GetAxisRaw("Vertical") == 1)
        {
            if (TractionBack)
            {
                motorBack.motorSpeed = speedF * (-1);
                motorBack.maxMotorTorque = torqueF;
                backwheel.motor = motorBack;
            }
        }
        else if (ControleCar[1].clickedIs == true || Input.GetAxisRaw("Vertical") == -1)
        {
            if (TractionBack)
            {
                motorBack.motorSpeed = speedB;
                motorBack.maxMotorTorque = torqueB;
                backwheel.motor = motorBack;
            }
        }
        else
        {
            backwheel.useMotor = false;
        }

        if (ControleCar[2].clickedIs == true || Input.GetAxisRaw("Horizontal") == -1)
        {
            GetComponent<Rigidbody2D>().AddTorque(carRotationSpeed);
        }

        if (ControleCar[3].clickedIs == true || Input.GetAxisRaw("Horizontal") == 1)
        {
            GetComponent<Rigidbody2D>().AddTorque(carRotationSpeed * (-1));
        }
    }
}