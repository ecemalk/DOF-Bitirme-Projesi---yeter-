using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class yenidenbasla : MonoBehaviour
{
    // Start is called before the first frame update
    public void YenidenBasla()
    {

        SceneManager.LoadScene(1);


    }
    
    public void CisikButonu()
    { Application.Quit();
    }

}
