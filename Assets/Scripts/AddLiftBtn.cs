using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class AddLiftBtn : MonoBehaviour
{
    // New Lift TextBox
    public TextMeshProUGUI liftInputArea;

    //
    public RectTransform content;

    //
    public GameObject liftPrefab;

    //
    public int noOfBtns = 0;

    // For each liftObjects[i] the liftNames[i] will match
    public GameObject[] liftObjects;
    public string[] liftNames;

    // The liftObjects textbox value will be mapped from the dictionary below
    public Dictionary<string, int> liftsAndWeights = new Dictionary<string, int>();

    public void Save()
    {
        foreach(GameObject liftObject in liftObjects)
        {
            LiftTextManager liftObjectManager = liftObject.GetComponent<LiftTextManager>();
            string lName = liftObjectManager.liftName;
            string lWeight = liftObjectManager.weightUI.text;
            PlayerPrefs.SetString(lName, lWeight);
            Debug.Log("Saved " + lName + " with weight " + lWeight);
        }
    }

   void Update()
    {
        
    }

    public void addLift()
    {
        Vector3 offset = new Vector3(0, noOfBtns * 110, 0);
        GameObject newLift = Instantiate(liftPrefab, content);
        newLift.transform.position -= offset;
        liftObjects[noOfBtns] = newLift;
        noOfBtns++;
    }
}
