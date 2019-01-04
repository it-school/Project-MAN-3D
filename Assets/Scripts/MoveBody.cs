using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoveBody : MonoBehaviour
{
    public Text stopBttnText;
    private bool paused;
    public Text timeText;
    public Text hText;
    public Text distText;
    public static Camera cam = new Camera();
    public GameObject body;
    public static float alpha;
    public static float V0;
    public static double tp;
    public const double g = 9.8;
    public static float hMax;
    public static float Dist;
    public const int DirSize = 100;
    public const float FromRadToDegree = Mathf.PI / 180;
    public float[] dirY = new float[DirSize];
    public float[] dirZ = new float[DirSize];
    public Transform[] waypoints = new Transform[DirSize];
    [HideInInspector]
    public int waypointIndex = 1;
    public float speed = 100000f;

    public static bool startFly = false;

    private void Awake()
    {
        alpha = float.Parse(MenuScript.alphaAngle.text);
        V0 = float.Parse(MenuScript.V0.text);
        
    }

    private void Start()
    {
        SetValues();
        if (MenuScript.right == true)
        {
            Camera.main.transform.position = new Vector3(95, 28, 72);
            Camera.main.transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        else if (MenuScript.back == true)
        {
            Camera.main.transform.position = new Vector3(0, 39.6f, -45.8f);
            Camera.main.transform.rotation = Quaternion.Euler(25.81f, 0, 0);
        }
        else if (MenuScript.onBall == true)
        {
            Camera.main.transform.position = new Vector3(0, 2.45f, 0);
            Camera.main.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (MenuScript.left == true)
        {
            Camera.main.transform.position = new Vector3(-95f, 28, 72);
            Camera.main.transform.rotation = Quaternion.Euler(0, 90, 0);
        }
    }

    public void StartFlyBttn()
    {
        startFly = true;

    }

    private void Update()
    {

        if(paused)
        {
            Time.timeScale = 0;
            stopBttnText.text = "Continue";
        }

        if(!paused)
        {
            Time.timeScale = 1;
            stopBttnText.text = "Stop";
        }

        if (startFly == true)
        {
            Move();
            timeText.text = "Время: \n" + (System.Math.Round(tp / 100 * waypointIndex, 2)) + "сек";
            hText.text = "Высота: \n" + (System.Math.Round(hMax / 100 * waypointIndex, 2)) + "м";
            distText.text = "Расстояние: \n" + (System.Math.Round(Dist / 100 * waypointIndex, 2)) + "м";

        }
    }

    private void Move()
    {
        if(MenuScript.onBall == true)
        {
            if (waypointIndex <= waypoints.Length - 1)
            {
                body.transform.position = Vector3.MoveTowards(body.transform.position, waypoints[waypointIndex].transform.position, Time.deltaTime * speed);
                Camera.main.transform.position = Vector3.MoveTowards(body.transform.position, waypoints[waypointIndex].transform.position, Time.deltaTime * speed);

                if (body.transform.position == waypoints[waypointIndex].transform.position)
                {
                    waypointIndex += 1;
                }
            }
        }
        else
        {
            if (waypointIndex <= waypoints.Length - 1)
            {
                body.transform.position = Vector3.MoveTowards(body.transform.position, waypoints[waypointIndex].transform.position, Time.deltaTime * speed);
                //Camera.main.transform.position = Vector3.MoveTowards(body.transform.position, waypoints[waypointIndex].transform.position, Time.deltaTime * speed);

                if (body.transform.position == waypoints[waypointIndex].transform.position)
                {
                    waypointIndex += 1;
                }
            }
        }
            
        }

    private void SetValues()
    {
        dirZ[0] = 1;
        dirY[0] = 2.48f;
        tp = 2 * V0 * Mathf.Sin(alpha * FromRadToDegree) / g;
        hMax = (float)((V0 * V0 / (2 * g)) * Mathf.Sin(alpha * FromRadToDegree) * Mathf.Sin(alpha * FromRadToDegree));
        Dist = (float)((V0 * V0 / g) * Mathf.Sin(2 * alpha * FromRadToDegree));

        for (int i = 1; i < DirSize; i++)
        {
            dirZ[i] = (float)((V0 * Mathf.Cos(alpha * FromRadToDegree) * (tp / DirSize * (i))));
            dirY[i] = (float)((Mathf.Tan(alpha * FromRadToDegree) * dirZ[i] - (g / (2 * V0 * V0 * Mathf.Cos(alpha * FromRadToDegree) * Mathf.Cos(alpha * FromRadToDegree))) * dirZ[i] * dirZ[i]) + 1f);
            waypoints[i].transform.position = new Vector3(body.transform.position.x, dirY[i] + 0.5f, dirZ[i]);
        }
        
    }

    public void PauseFly()
    {
        paused = !paused;
    }

    public void Again()
    {
        SceneManager.LoadScene(0);
        startFly = false;
        MenuScript.onBall = false;
        MenuScript.right = false;
        MenuScript.left = false;
        MenuScript.back = false;
    }

}