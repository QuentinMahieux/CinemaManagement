using System.Collections;
using TMPro;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    public static TextManager instance;
    [Header("Cursor Information")]
    public TMP_Text infoText;
    
    [Header("Dialogue Settings")]
    public TMP_Text dialogueText;
    private Coroutine actuelCorroutine;
    public float dialogueSpeed = 0.1f;
    
    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("There is more than one PlayerHand in scene!");
            Destroy(this);
        }
    }
    
    void Start()
    {
        infoText.text = " ";
        dialogueText.text = " ";
    }

    public void AddText(string newText)
    {
        infoText.text = newText;
    }

    public void AddDialogue(string newDialogue)
    {
        if (actuelCorroutine != null)
        {
            StopCoroutine(actuelCorroutine);
            actuelCorroutine = null;
        }
        dialogueText.text = " ";
        actuelCorroutine =  StartCoroutine(LetterIntervale(newDialogue));
    }

    IEnumerator LetterIntervale(string text)
    {
        for (int i = 0; i < text.Length; i++)
        {
            dialogueText.text += text[i];
            yield return new WaitForSeconds(dialogueSpeed);
        }
    }
}
