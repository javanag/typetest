using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypingManager : MonoBehaviour
{
    public TMP_Text textComponent;

    private TypingEvent currentTypingEvent;

    // Tracks position of user input in word as typing occurs.
    private int typingCaret = -1;
    private string currentPrompt;
    private bool playerMadeTypo = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        string playerInput = Input.inputString;
        if (typingCaret < 0 || !Input.anyKeyDown || playerInput.Length < 1) {
            return;
        }

        for (int i = 0; i < playerInput.Length && typingCaret < currentPrompt.Length; i++) {
            if (playerInput[i] == currentPrompt[typingCaret]) {
                playerMadeTypo = false;
                typingCaret++;
            } else {
                playerMadeTypo = true;
                break;
            }
        }

        UpdateTextMesh();

        // Pass
        if (typingCaret == currentPrompt.Length) {
            ResetTypingEvent();
            currentTypingEvent.Pass();
        }
    }

    public void SetTypingEvent(TypingEvent typingEvent) {
        currentTypingEvent = typingEvent;
        currentPrompt = typingEvent.typingPrompt;
        textComponent.text = typingEvent.typingPrompt;
        typingCaret = 0;
        playerMadeTypo = false;

        Vector3 newTextCanvasPosition
            = typingEvent.positionObject.transform.position;

        textComponent.transform.parent.position = newTextCanvasPosition;
    }

    private void ResetTypingEvent() {
        typingCaret = -1;
        textComponent.text = "";
        playerMadeTypo = false;
    }

    private void UpdateTextMesh () {
        textComponent.ForceMeshUpdate();
        var textInfo = textComponent.textInfo;

        // Stage colour changes based on correctness and position in word.
        for (int i = 0; i < textInfo.characterCount; i++) {
            var charInfo = textInfo.characterInfo[i];

            var meshInfo = textInfo.meshInfo[charInfo.materialReferenceIndex];
            for (int j = 0; j < 4; j++) {
                var index = charInfo.vertexIndex + j;

                if (i < typingCaret) {
                    meshInfo.colors32[index] = Color.green;
                } else if (i == typingCaret && playerMadeTypo) {
                    meshInfo.colors32[index] = Color.red;
                }
            }
        }

        // Commit changes to visible text mesh.
        for (int i = 0; i < textInfo.meshInfo.Length; i++) {
            var meshInfo = textInfo.meshInfo[i];
            meshInfo.mesh.vertices = meshInfo.vertices;
            meshInfo.mesh.colors32 = meshInfo.colors32;
            textComponent.UpdateGeometry(meshInfo.mesh, i);
        }
    }
}
