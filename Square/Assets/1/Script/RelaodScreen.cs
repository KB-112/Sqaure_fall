using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RelaodScreen : MonoBehaviour
{

    public void O()
    {
        SceneManager.LoadScene("Scene");
        Debug.Log("scene Loaded");
    }

}
