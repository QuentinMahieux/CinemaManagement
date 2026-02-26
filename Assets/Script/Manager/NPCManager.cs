using System;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public DialogueData dialogueData;
    public DialogueDataInstance dialogueDataInstance;
    
    private int actualIndex = 0;

    private bool isDialogue;
    private bool isStartDialogue;
    private bool isEndDialogue;

    private void OnEnable()
    {
        dialogueDataInstance = dialogueData.Instance();
        isStartDialogue = true;
    }

    public void StartDialogue()
    {
        PlayerController.instance.rb.isKinematic = true;
        isDialogue = true;
        if (isStartDialogue)
        {
            NextDialogue(dialogueDataInstance.listStartDialogue, actualIndex);
        }
        else if (isEndDialogue)
        {
            NextDialogue(dialogueDataInstance.listEndDialogue, actualIndex);
        }
    }

    void EndDialogue()
    {
        if (isEndDialogue)
        {
            Destroy(gameObject);
        }
        PlayerController.instance.rb.isKinematic = false;
        isDialogue = false;
        isStartDialogue = !isStartDialogue;
        isEndDialogue = !isEndDialogue;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && isDialogue)
        {
            actualIndex++;
            StartDialogue();
        }
    }

    void NextDialogue(List<string> actualDialogue, int index = 0)
    {
        if (actualDialogue.Count <= index)
        {
            EndDialogue();
            return;
        }
        TextManager.instance.AddDialogue(actualDialogue[index]);
    }
}
