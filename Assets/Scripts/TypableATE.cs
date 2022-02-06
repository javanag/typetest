using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypableATE : TypingEvent
{
    public Vector3 rotate;
    public GameObject typingManager;
    public GameObject nextTypingEventObject;

    private bool typeEventPassed = false;

    void Update() {
        if (typeEventPassed) {
            transform.Rotate(rotate * Time.deltaTime);
        }
    }

    public override void Pass() {
        typeEventPassed = true;
        typingManager.GetComponent<TypingManager>().SetTypingEvent(
            nextTypingEventObject.GetComponent<TypingEvent>()
        );
    }

    public override void Fail() {

    }
}
