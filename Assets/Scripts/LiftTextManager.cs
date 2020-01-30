using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LiftTextManager : MonoBehaviour
{
    public int liftId;
    public TextMeshProUGUI liftNameUI;
    public TMP_InputField weightUI;
    public float incrementDecrement;

    // Start is called before the first frame update
    void Awake()
    {
        // Getting the lift name using the awake before the lift weight just in case
        liftNameUI.text = PlayerPrefs.GetString(liftId.ToString());
    }
    void Start()
    {
        // For debugging
        Debug.Log("Saved weight for id " + liftId + " is " + PlayerPrefs.GetString(liftNameUI.text));
        // Getting the lift weight
        weightUI.text = PlayerPrefs.GetString(liftNameUI.text);
    }

    // a == 1, increment
    // a == -1 decrement
    // Could have used a boolean actually...🤔
    public void plusMinus(int a)
    {
        if(a == 1)
            weightUI.text = (float.Parse(weightUI.text) + incrementDecrement).ToString();
        else
            weightUI.text = (float.Parse(weightUI.text) - incrementDecrement).ToString();
    }
}
