using TMPro;
using UnityEngine;

public class PointCointer : MonoBehaviour
{ 
    public static PointCointer instance;
    public int numberStar;
    public TMP_Text pointText;
    void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        numberStar = 0;
    }

    void Update()
    {
        pointText.text = numberStar.ToString();
    }

    public void AddPoint(int number)
    {
        numberStar += number;
    }
}
