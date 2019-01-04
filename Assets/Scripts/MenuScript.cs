using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    public static bool onBall = false;
    public static bool right = false;
    public static bool left = false;
    public static bool back = false;
    public  InputField alphaAngleThis;
    public  InputField V0This;



    public static InputField alphaAngle;
    public static InputField V0;
    
    private void FixedUpdate()
    {

        alphaAngle = alphaAngleThis;
        V0 = V0This;

    }

    public void OnBall()
    {
        if(alphaAngle.text != "" && V0.text != "" && float.Parse(alphaAngle.text) > 1 && float.Parse(alphaAngle.text) < 90)
        {
            onBall = true;
            SceneManager.LoadScene(1);
        }
        //Camera.main.transform.position = new Vector3(0, 2.45f, 0);
        //Camera.main.transform.rotation = Quaternion.Euler(0, 0, 0);

    }
    public void Back()
    {
        if(alphaAngle.text != "" && V0.text != "" && float.Parse(alphaAngle.text) > 1 && float.Parse(alphaAngle.text) < 90)
        {
            SceneManager.LoadScene(1);
            back = true;
        }
        
        //Camera.main.transform.position = new Vector3(0, 39.6f, -45.8f);
        //Camera.main.transform.rotation = Quaternion.Euler(25.81f, 0, 0);
    }
    public void Right()
    {
        if (alphaAngle.text != "" && V0.text != "" && float.Parse(alphaAngle.text) > 1 && float.Parse(alphaAngle.text) < 90)
        {
            SceneManager.LoadScene(1);
            right = true;
        }
        //Camera.main.transform.position = new Vector3(318.2f, 173, 311);
        //Camera.main.transform.rotation = Quaternion.Euler(25, -90, 0);
    }
    public void Left()
    {
        if (alphaAngle.text != "" && V0.text != ""  && float.Parse(alphaAngle.text) > 1 && float.Parse(alphaAngle.text) < 90)
        {
            SceneManager.LoadScene(1);
            left = true;
        }
        
        //Camera.main.transform.position = new Vector3(-318.2f, 173, 311);
        //Camera.main.transform.rotation = Quaternion.Euler(25, 90, 0);
    }

}
