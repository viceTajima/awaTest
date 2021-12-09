using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class TestTest : MonoBehaviour
{
    public TextMesh textMesh1;
    public TextMesh textMesh2;
    public TextMesh textMesh3;
    public TextMesh textMesh4;

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
    private void Update()
    {
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

    public void TestText2(string text)
    {
        string[] rotations = text.Split(',');

        cameraTr.rotation = Quaternion.Inverse(new Quaternion(float.Parse(rotations[0]), float.Parse(rotations[1]), float.Parse(rotations[2]), float.Parse(rotations[3])));

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

    public void TestText3(string text)
    {
        string[] textsplit = text.Split(',');

        Vector3 aaaaaa = new Vector3(
                    float.Parse(textsplit[0]),
                    float.Parse(textsplit[1]),
                    float.Parse(textsplit[2]));

        moveChecker.localPosition = aaaaaa;

        Vector3 a = (
                cameraTr.right * float.Parse(textsplit[0]) * -1.0f +
                cameraTr.forward * float.Parse(textsplit[1]) * -1.0f +
                cameraTr.up * float.Parse(textsplit[2]) * -1.0f
            );

        float test = float.Parse(textsplit[4]);

        if (a.magnitude < test) a = Vector3.zero;

        float dt = float.Parse(textsplit[3]);
        Vector3 dx = (0.5f * a * dt * dt + speed * dt) * 10.0f;
        speed = a * dt + (speed * ((a.magnitude >= test) ? 1.0f : Mathf.Max(1.0f - dt * float.Parse(textsplit[5]), 0.0f)));

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
}
