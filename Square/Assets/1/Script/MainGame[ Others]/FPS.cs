using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class FPS : MonoBehaviour
{
    public TextMeshProUGUI fpsText;
    public int fps{ get; private set; }


    private void Start()
    {
        Application.targetFrameRate = 60;
    }
    void Update()
    {
      



       
         fps = (int)(1 / Time.deltaTime);
        fpsText.text = Mathf.Ceil(fps).ToString();
    }
}
