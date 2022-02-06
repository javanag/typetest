using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public GameObject typingManager;
    public GameObject typingEventCube;

    private bool isMoving;
    private float speed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
       isMoving = true; 
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving) {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        if (isMoving && transform.position.z > -12f) {
            isMoving = false;
            Debug.Log("Stopped moving");
            typingManager.GetComponent<TypingManager>().SetTypingEvent(
                typingEventCube.GetComponent<TypingEvent>());
        }
    }
}
