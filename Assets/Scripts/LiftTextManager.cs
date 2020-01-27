using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LiftTextManager : MonoBehaviour
{
    public string liftName;
    public TextMeshProUGUI liftNameUI;
    public TMP_InputField weightUI;
    // Start is called before the first frame update
    void Start()
    {
        liftNameUI.text = liftName;
        weightUI.text = PlayerPrefs.GetString(liftName);
    }
}
