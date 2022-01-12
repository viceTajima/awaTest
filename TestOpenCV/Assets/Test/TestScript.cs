using OpenCVForUnity.CoreModule;
using OpenCVForUnity.ImgprocModule;
using OpenCVForUnity.UnityUtils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestScript : MonoBehaviour
{
    [SerializeField] private RawImage cameraView;
    [SerializeField] private RawImage detectionView;
    [SerializeField] private RawImage bulb;
    private WebCamTexture webcamTexture;

    [SerializeField, Range(0.001f, 1.0f)] private float ratio = 1.0f;
    [SerializeField] private Slider slider;
    [SerializeField] private GameObject checkFlag;

    // Start is called before the first frame update
    void Start()
    {
        //obtain cameras avialable
        WebCamDevice[] cam_devices = WebCamTexture.devices;
        //create camera texture
        webcamTexture = new WebCamTexture(cam_devices[0].name, 480, 640, 30);
        //set raw image texture to obtain feed from camera texture
        cameraView.texture = webcamTexture;
        cameraView.material.mainTexture = webcamTexture;
        //start camera
        webcamTexture.Play();
        //start coroutine
        StartCoroutine(motionDetection());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    Mat DiffImage(Mat t0, Mat t1, Mat t2)
    {
        Mat d1 = new Mat();
        Core.absdiff(t2, t1, d1);
        Mat d2 = new Mat();
        Core.absdiff(t1, t0, d2);
        Mat diff = new Mat();
        Core.bitwise_and(d1, d2, diff);
        return diff;
    }
    private IEnumerator motionDetection()
    {
        while (true)
        {
            Mat t0 = new Mat(webcamTexture.height, webcamTexture.width, CvType.CV_8UC4);
            Utils.webCamTextureToMat(webcamTexture, t0); //obtain fram from webcam
            yield return new WaitForSeconds(0.04F);// wait for 0.04s
            yield return new WaitForEndOfFrame();// wait till end of frame
            Mat t1 = new Mat(webcamTexture.height, webcamTexture.width, CvType.CV_8UC4);
            Utils.webCamTextureToMat(webcamTexture, t1);
            yield return new WaitForSeconds(0.04F);
            yield return new WaitForEndOfFrame();
            Mat t2 = new Mat(webcamTexture.height, webcamTexture.width, CvType.CV_8UC4);
            Utils.webCamTextureToMat(webcamTexture, t2);
            yield return new WaitForSeconds(0.04F);
            yield return new WaitForEndOfFrame();


            Imgproc.cvtColor(t0, t0, Imgproc.COLOR_RGBA2GRAY);
            Imgproc.cvtColor(t1, t1, Imgproc.COLOR_RGBA2GRAY);
            Imgproc.cvtColor(t2, t2, Imgproc.COLOR_RGBA2GRAY);


            Mat final = new Mat();
            final = DiffImage(t0, t1, t2);


            Texture2D texture = new Texture2D(final.cols(), final.rows(), TextureFormat.RGBA32, false);
            try
            {
                Utils.matToTexture2D(final, texture);
                detectionView.texture = texture;
            }
            catch (Exception)
            {
            }

            int picC = webcamTexture.height * webcamTexture.width;

            Byte value = 0;
            float valueF = 0.0f;
            try
            {
                valueF = (float)Core.countNonZero(final) / (float)picC / ratio;
                value = Convert.ToByte((int)(valueF * 255));

                //value = Convert.ToByte(Core.countNonZero(final) / 1000);
            }
            catch (OverflowException)
            {
                valueF = 1.0f;
                value = 255;
            }
            bulb.color = new Color32(value, 0, 0, value);
            slider.value = valueF;
            checkFlag.SetActive(valueF >= 1.0f);
        }
    }
}
