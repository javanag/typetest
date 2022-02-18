using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Used to make sure that the canvas under the TypingManager is always
// turned towards the main camera.
public class Billboard : MonoBehaviour
{
	public Transform camTransform;

	Quaternion originalRotation;

    void Start()
    {
        originalRotation = transform.rotation;
    }

    void Update()
    {
     	transform.rotation = camTransform.rotation * originalRotation;
    }
}
