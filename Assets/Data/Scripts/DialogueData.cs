using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueData", menuName = "Scriptable Objects/DialogueData")]
public class DialogueData : ScriptableObject
{
    [field: SerializeField] public List<string> listStartDialogue { get; private set; }
    [field: SerializeField] public List<string> listEndDialogue { get; private set; }
    
    [field: SerializeField] public List<Request> listRequest { get; private set; }

    

    public DialogueDataInstance Instance()
    {
        return new DialogueDataInstance(this);
    }
}

[Serializable]
public class Request
{
    [field: SerializeField] public FoodData foodData { get; set; }
    [field: SerializeField] public bool isTake { get; set; }

}


[Serializable]
public class DialogueDataInstance
{
    public List<string> listStartDialogue;
    public List<string> listEndDialogue;
    public List<Request> listRequest;



    public DialogueDataInstance(DialogueData data)
    {
        listStartDialogue = new List<string>(data.listStartDialogue);
        listEndDialogue = new List<string>(data.listEndDialogue);
        listRequest = new List<Request>();
        foreach (var req in data.listRequest)
        {
            listRequest.Add(new Request { foodData = req.foodData, isTake = req.isTake });
        }
    }
}

