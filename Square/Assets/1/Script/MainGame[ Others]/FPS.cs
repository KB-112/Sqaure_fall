using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class FPS : MonoBehaviour
{
    private int fps;
    [Header("FPS CONTROL")]
    public TextMeshProUGUI fpsText;
    [SerializeField] private int targetFps;

    private void Start()
    {
        Application.targetFrameRate = targetFps;
    }
    void Update()
    {         
        fps = (int)(1 / Time.deltaTime);
        fpsText.text = Mathf.Ceil(fps).ToString();
    }
}
