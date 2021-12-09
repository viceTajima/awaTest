using System;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class LocationManager : MonoBehaviour
{
    [SerializeField] TextMesh RotationAlphaText;
    [SerializeField] TextMesh RotationBetaText;
    [SerializeField] TextMesh RotationGammaText;

    // JavaScript関数の宣言
    [DllImport("__Internal")]
    private static extern void WatchDeviceorientation();

    void Update()
    {
        // JavaScriptの呼び出し
        WatchDeviceorientation();
    }

    public void ShowRotation(String rotation)
    {
        string[] rotations = rotation.Split(',');

        RotationAlphaText.text = "alpha: " + rotations[0];
        RotationBetaText.text = "beta: " + rotations[1];
        RotationGammaText.text = "gamma: " + rotations[2];

        //Debug.Log(rotation);
    }
}