using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonElevator : MonoBehaviour {
    protected bool buttonPressed;
    protected bool isMoving;
    public GameObject elevator;
    public Vector3 upPosition;
    public float waitSeconds;
    public GameObject leftDoor;
    public GameObject rightDoor;
    public float ammountToOpen;
    protected Vector3 downPosition;
    protected float startTime;
    protected float distance;
    protected bool doorsClosed;
    //protected Vector3 leftDoorPosition;
    //protected Vector3 rightDoorPosition;
    protected float startTimeDoors;

	void Start () {
        buttonPressed = false;
        isMoving = false;
        doorsClosed = true;
        downPosition = elevator.transform.position; //downPosition is default position
        upPosition += elevator.transform.parent.position;
        distance = Vector3.Distance(upPosition, downPosition);
        //rightDoorPosition = rightDoor.transform.position;
        //leftDoorPosition = leftDoor.transform.position;
	}

    public void buttonPushed()
    {
        Debug.Log("Buttonpress!");
        Debug.Log(upPosition + " down: " + downPosition);
        buttonPressed = !buttonPressed; //toggles the bool
        if (buttonPressed && !isMoving)
        {
            ElevatorUp();
        }
        else if (!buttonPressed && !isMoving)
        {
            ElevatorDown();
        }
    }

    protected void ElevatorUp()
    {
        isMoving = true;
        startTime = Time.time;
        StartCoroutine(Move(downPosition, upPosition));
    }

    protected void ElevatorDown()
    {
        isMoving = true;
        startTime = Time.time;
        StartCoroutine(Move(upPosition, downPosition));
    }

    public void OpenCloseDoor()
    {
        doorsClosed = !doorsClosed;
        if (doorsClosed) //open doors in this case
        {
            startTimeDoors = Time.time;
            StartCoroutine(OpenDoors());
        }
        else
        {
            startTimeDoors = Time.time;
            StartCoroutine(CloseDoors());
        }
    }

    IEnumerator OpenDoors()
    {
        while (leftDoor.transform.localPosition.x != ammountToOpen)
        {
            yield return new WaitForSeconds(waitSeconds);
            float distanceCovered = Time.time - startTimeDoors;
            leftDoor.transform.localPosition = Vector3.Lerp(Vector3.zero, new Vector3(ammountToOpen, 0, 0), distanceCovered/ammountToOpen);
            rightDoor.transform.localPosition = Vector3.Lerp(Vector3.zero, new Vector3(-ammountToOpen, 0, 0), distanceCovered / ammountToOpen);
        }
    }

    IEnumerator CloseDoors()
    {
        while (leftDoor.transform.localPosition.x != 0f)
        {
            yield return new WaitForSeconds(waitSeconds);
            float distanceCovered = Time.time - startTimeDoors;
            leftDoor.transform.localPosition = Vector3.Lerp(new Vector3(ammountToOpen, 0, 0), Vector3.zero, distanceCovered / ammountToOpen);
            rightDoor.transform.localPosition = Vector3.Lerp(new Vector3(-ammountToOpen, 0, 0), Vector3.zero, distanceCovered / ammountToOpen);
        }
    }

    IEnumerator Move(Vector3 startPosition, Vector3 endPosition)
    {
        while (elevator.transform.position != endPosition)
        {
            yield return new WaitForSeconds(waitSeconds);
            float distanceCovered = Time.time - startTime;
            elevator.transform.position = Vector3.Lerp(startPosition, endPosition, distanceCovered / distance);
        }
        isMoving = false;
    }
}
