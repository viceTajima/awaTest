using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.UI;

public class TestTest : MonoBehaviour
{
    public TextMesh textMesh1;
    public TextMesh textMesh2;
    public TextMesh textMesh3;
    public TextMesh textMesh4;

    public Text text1;
    public Text text2;
    public Text text3;
    public Text text4;

    [DllImport("__Internal")]
    private static extern void WatchDeviceorientation();
    [DllImport("__Internal")]
    private static extern void WatchDevicemotion();
    [DllImport("__Internal")]
    private static extern void GetGeolocation();

    [DllImport("__Internal")]
    private static extern string TestGetGyro();

    // Start is called before the first frame update
    void Start()
    {
        WatchDeviceorientation();
        WatchDevicemotion();
    }

    private float getGeolocationInterval = 1.0f;
    private float getGeolocationTimer = 0.0f;
    private bool isGetGeolocation = false;

    public float testFPS = 0;

    private void Update()
    {
        testFPS = 1.0f / Time.deltaTime;
        //if(isGetGeolocation == true)
        //{
        //    getGeolocationTimer = getGeolocationInterval;
        //}
        //else
        //{
        //    if (getGeolocationTimer > 0.0f)
        //    {
        //        getGeolocationTimer -= Time.deltaTime;
        //    }
        //    else
        //    {
        //        GetGeolocation();
        //        isGetGeolocation = true;
        //    }
        //}
    }

    private void LateUpdate()
    {
        //float subTimer = Time.deltaTime;
        //while(subTimer > 0.0f)
        //{
        //    if(timer > 0.0f)
        //    {
        //        if(timer > subTimer)
        //        {
        //            SpeedMove(subTimer);
        //            timer -= subTimer;
        //            subTimer = 0.0f;
        //        }
        //        else
        //        {
        //            SpeedMove(timer);
        //            subTimer -= timer;
        //            timer = 0.0f;
        //        }
        //    }
        //    else
        //    {
        //        if (acceleration.Count > 0)
        //        {
        //            Vector4 tetete = acceleration.Dequeue();
        //            speed += (
        //                    cameraTr.right * tetete.x +
        //                    cameraTr.forward * tetete.y +
        //                    cameraTr.up * tetete.z
        //                );
        //            timer = tetete.w;
        //        }
        //        else
        //        {
        //            subTimer = 0.0f;
        //        }
        //    }
        //}

        //if (timer > 0.0f)
        //{
        //    if(timer > Time.deltaTime)
        //    {
        //        float subDeltaTime = timer - Time.deltaTime;
        //
        //        SpeedMove(subDeltaTime);
        //
        //        timer -= Time.deltaTime;
        //    }
        //    else
        //    {
        //        SpeedMove(timer);
        //
        //        timer = 0.0f;
        //    }
        //}
        //else
        //{
        //    if (acceleration.Count <= 0) return;
        //    Vector4 tetete = acceleration.Dequeue();
        //    //speed += new Vector3(tetete.x, tetete.y, tetete.z);
        //    speed += (
        //            cameraTr.right * tetete.x +
        //            cameraTr.forward * tetete.y +
        //            cameraTr.up * tetete.z
        //        );
        //    timer = tetete.w;
        //}
    }

    public void SpeedMove(float time)
    {
        cameraTr.position += speed * time;

        speed *= Mathf.Max(0.0f, (1.0f - time));

        //cameraTr.position += (
        //        cameraTr.right * speed.x +
        //        cameraTr.forward * speed.y +
        //        cameraTr.up * speed.z
        //    ) * time;
    }

    public void TestText1()
    {
        isGetGeolocation = false;
    }

    public Transform cameraTr;
    public Transform cameraParent1;
    public Transform cameraParent2;
    public Transform cameraParent3;

    private Quaternion teteteRotate = Quaternion.identity;

    public void TestText2(string text)
    {
        string[] rotations = text.Split(',');

        teteteRotate = Quaternion.Inverse(new Quaternion(float.Parse(rotations[0]), float.Parse(rotations[1]), float.Parse(rotations[2]), float.Parse(rotations[3])));

        cameraTr.rotation = teteteRotate;

        //Quaternion rotateX = Quaternion.AngleAxis(float.Parse(rotations[1]), Vector3.left);
        //Quaternion rotateY = Quaternion.AngleAxis(float.Parse(rotations[2]), Vector3.down);
        //Quaternion rotateZ = Quaternion.AngleAxis(float.Parse(rotations[0]), Vector3.forward);
        //
        //cameraTr.rotation = rotateY * rotateX * rotateZ;

        //cameraParent1.localEulerAngles = Vector3.forward * float.Parse(rotations[0]);
        //cameraParent2.localEulerAngles = Vector3.left * float.Parse(rotations[1]);
        //cameraParent3.localEulerAngles = Vector3.up * float.Parse(rotations[2]);

        //cameraTr.eulerAngles = new Vector3(
        //    float.Parse(rotations[1]) * -1.0f,
        //    float.Parse(rotations[2]) * -1.0f,
        //    float.Parse(rotations[0]));

    }

    private Vector3 speed = Vector3.zero;
    private float timer = 0.0f;

    private Queue<Vector4> acceleration = new Queue<Vector4>();

    public Transform moveChecker;

    public List<Vector3> testCheck = new List<Vector3>();

    public Transform testCircle;

    public void TestText3(string text)
    {
        string[] textsplit = text.Split(',');

        Vector3 aaaaaa = new Vector3(
                    float.Parse(textsplit[0]),
                    float.Parse(textsplit[1]),
                    float.Parse(textsplit[2]));

        moveChecker.localPosition = aaaaaa;

        Vector3 a = (
                cameraTr.right * (float)Math.Truncate(double.Parse(textsplit[0]) * 10) * 0.1f * -1.0f +
                cameraTr.forward * (float)Math.Truncate(double.Parse(textsplit[1]) * 10) * 0.1f * -1.0f +
                cameraTr.up * (float)Math.Truncate(double.Parse(textsplit[2]) * 10) * 0.1f * -1.0f
            );

        testCheck.Add(a);
        Vector3 sum = Vector3.zero;
        foreach (Vector3 vector3 in testCheck)
        {
            sum += vector3;
        }
        Vector3 hei = sum / testCheck.Count;
        text3.text = hei.x.ToString("f5") + " , " + hei.y.ToString("f5") + " , " + hei.z.ToString("f5") + " , " + hei.magnitude.ToString("f5");

        float test = float.Parse(textsplit[4]);
        testCircle.localScale = Vector3.one * test;

        //if (a.magnitude < test) a = Vector3.zero;

        float dt = float.Parse(textsplit[3]) / float.Parse(textsplit[6]);
        text4.text = dt.ToString() + " : " + testFPS.ToString();
        Vector3 dx = (0.5f * a * dt * dt + speed * dt) * 1.0f;
        //speed = a * dt + (speed * ((a.magnitude >= test) ? 1.0f : Mathf.Max(1.0f - dt * float.Parse(textsplit[5]), 0.0f)));
        speed = a * dt + speed;

        text1.text = speed.x.ToString("f5") + " , " + speed.y.ToString("f5") + " , " + speed.z.ToString("f5") + " , " + speed.magnitude.ToString("f5");
        text2.text = a.x.ToString("f5") + " , " + a.y.ToString("f5") + " , " + a.z.ToString("f5") + " , " + a.magnitude.ToString("f5");

        cameraTr.position += dx;

        textMesh3.text = textsplit[4];
        textMesh4.text = textsplit[5];

        //speed += (
        //        cameraTr.right * float.Parse(textsplit[0]) +
        //        cameraTr.forward * float.Parse(textsplit[1]) +
        //        cameraTr.up * float.Parse(textsplit[2])
        //    ) * float.Parse(textsplit[3]);
        //SpeedMove(float.Parse(textsplit[3]));

        //speed = new Vector3(
        //            float.Parse(textsplit[0]),
        //            float.Parse(textsplit[1]),
        //            float.Parse(textsplit[2]));
        //
        //SpeedMove(float.Parse(textsplit[3]));

        //acceleration.Enqueue(
        //    new Vector4(
        //            float.Parse(textsplit[0]),
        //            float.Parse(textsplit[1]),
        //            float.Parse(textsplit[2]),
        //            float.Parse(textsplit[3])
        //        )
        //    );
    }

    public void TestText4(string text)
    {
        string[] textsplit = text.Split(',');

        isGetGeolocation = false;

        textMesh1.text = System.DateTime.Now.ToString();
    }

    public void TestText5(string text)
    {
        string[] textsplit = text.Split(',');

        float r = (textsplit[4] == "1000") ? 1.0f : -1.0f;

        Vector3 a = new Vector3(
                    float.Parse(textsplit[0]) * r,
                    float.Parse(textsplit[2]) * r,
                    float.Parse(textsplit[1]) * r);

        testCheck.Add(a);
        Vector3 sum = Vector3.zero;
        foreach (Vector3 vector3 in testCheck)
        {
            sum += vector3;
        }
        Vector3 hei = sum / testCheck.Count;
        text3.text = hei.x.ToString("f5") + " , " + hei.y.ToString("f5") + " , " + hei.z.ToString("f5") + " , " + hei.magnitude.ToString("f5");

        moveChecker.localPosition = a;

        testCircle.localScale = Vector3.one * float.Parse(textsplit[5]);

        float dt = float.Parse(textsplit[3]) / float.Parse(textsplit[4]);
        text4.text = dt.ToString() + " : " + testFPS.ToString();
        Vector3 dx = (speed * dt);
        //speed = a * dt + (speed * ((a.magnitude >= test) ? 1.0f : Mathf.Max(1.0f - dt * float.Parse(textsplit[5]), 0.0f)));
        speed = a * dt + speed;

        text1.text = speed.x.ToString("f5") + " , " + speed.y.ToString("f5") + " , " + speed.z.ToString("f5") + " , " + speed.magnitude.ToString("f5");
        //text2.text = a.x.ToString("f5") + " , " + a.y.ToString("f5") + " , " + a.z.ToString("f5") + " , " + a.magnitude.ToString("f5");
        text2.text = teteteRotate.x.ToString("f5") + "," + teteteRotate.y.ToString("f5") + "," + teteteRotate.z.ToString("f5") + "," + teteteRotate.w.ToString("f5");

        cameraTr.position += dx;
    }


    public void ChecksReset()
    {
        testCheck = new List<Vector3>();
    }
}
