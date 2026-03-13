using TMPro;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    void OnEnable()
    {
        
    }

    public void ChangeFPS(TMP_InputField newvalue)
    {
        GameManager.instance.ChangeFPS(int.Parse(newvalue.text));
    }
}
