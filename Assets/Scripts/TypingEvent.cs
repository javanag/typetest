using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TypingEvent : MonoBehaviour
{
    // The text that will be shown when the typing event occurs.
    public string typingPrompt;
    
    // Determines the time (ms) for the player to complete the prompt.
    // If 0, will act as untimed, no timer indication will be shown.
    public uint eventTime = 0;

    // The object whose position transform will be used to spawn the text.
    public GameObject positionObject;

    // These methods will be called by the TypingManager after a typing event
    // concludes. To be implemented by TypingEvent children, specific to each
    // instance.
    public abstract void Pass();
    public abstract void Fail();
}
