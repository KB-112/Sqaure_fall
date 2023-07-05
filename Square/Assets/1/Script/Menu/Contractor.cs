using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.ComponentModel;
using UnityEditor;

public class ReadOnlyInspectorAttribute : PropertyAttribute { }

[CustomPropertyDrawer(typeof(ReadOnlyInspectorAttribute))]
public class ReadOnlyInspectorDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        GUI.enabled = false;
        EditorGUI.PropertyField(position, property, label, true);
        GUI.enabled = true;
    }
}
public class Contractor : MonoBehaviour
{
    // Public variables
    public int Totalcontractor;
    public int Newcontractorvalue;
    public int contractorReductionPerplay;
    [SerializeField]
    [ReadOnlyInspector]   
    public int playButtonPressCount = 1;
    public TextMeshProUGUI scoreText;

    // PlayerPrefs keys
    private const string PressedPlayButtonKey = "PressedPlayButton";
    private const string TotalContractorKey = "TotalContractor";

    private void Start()
    {
        // Check if PlayerPrefs has the key for play button press count
        if (!PlayerPrefs.HasKey(PressedPlayButtonKey))
        {
            // Set the initial value for Totalcontractor if the key is not found
            Totalcontractor = Newcontractorvalue;
        }
        else
        {
            // Load the saved values from PlayerPrefs
            playButtonPressCount = PlayerPrefs.GetInt(PressedPlayButtonKey, playButtonPressCount);
            Totalcontractor = PlayerPrefs.GetInt(TotalContractorKey, Totalcontractor);

            // Reduce Totalcontractor based on contractorReductionPerplay
            Totalcontractor -= contractorReductionPerplay;

            // Check if Totalcontractor is zero or negative
            if (Totalcontractor <= 0)
            {
                // Set Totalcontractor to Newcontractorvalue
                Newcontractorvalue = 50;
                Totalcontractor = Newcontractorvalue;
            }
        }

        // Update the score text
        scoreText.text = Totalcontractor.ToString();
    }

    public void PlayBtnCounter()
    {
        // Increment the play button press count
        playButtonPressCount++;

        // Save the play button press count and Totalcontractor to PlayerPrefs
        PlayerPrefs.SetInt(PressedPlayButtonKey, playButtonPressCount);
        PlayerPrefs.SetInt(TotalContractorKey, Totalcontractor);

        // Reduce Totalcontractor based on contractorReductionPerplay
        Totalcontractor -= contractorReductionPerplay;

        // Save the changes to PlayerPrefs
        PlayerPrefs.Save();
    }
}

