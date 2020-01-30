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
    public int noOfLifts = 0;

    // For each liftObjects[i] the liftNames[i] will match
    public GameObject[] liftObjects;

    // The liftObjects textbox value will be mapped from the dictionary below
    public Dictionary<string, int> liftsAndWeights = new Dictionary<string, int>();

    // Saving the values using Unity's PlayerPrefs
    public void Save()
    {
        // Saving the number of lifts
        PlayerPrefs.SetInt("noOfLifts", noOfLifts);

        foreach(GameObject liftObject in liftObjects)
        {
            LiftTextManager liftObjectManager = liftObject.GetComponent<LiftTextManager>();
            PlayerPrefs.SetString(liftObjectManager.liftId.ToString(), liftObjectManager.liftNameUI.text);
            PlayerPrefs.SetString(liftObjectManager.liftNameUI.text, liftObjectManager.weightUI.text);
        }
    }

   void Start()
    {
        // Used toe delete all the saved values(for testing)
        //PlayerPrefs.DeleteAll();

        // Turning on all the saved lift objects
        noOfLifts = PlayerPrefs.GetInt("noOfLifts");
        for (int i = 0; i < noOfLifts; i++)
        {
            liftObjects[i].SetActive(true);
        }
    }

    public void addLift()
    {
        GameObject liftObject = liftObjects[noOfLifts++];
        liftObject.SetActive(true);
        LiftTextManager ltm = liftObject.GetComponent<LiftTextManager>();
        ltm.liftNameUI.text = liftInputArea.text;
        liftInputArea.text = "";
    }
}
