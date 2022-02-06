using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypableBTE : TypingEvent
{
    public Vector3 rotate;
    private bool typeEventPassed = false;

    void Update() {
        if (typeEventPassed) {
            transform.Rotate(rotate * Time.deltaTime);
        }
    }

    public override void Pass() {
        typeEventPassed = true;
    }

    public override void Fail() {

    }
}
