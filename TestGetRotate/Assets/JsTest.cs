﻿using System;
using UnityEngine;
using System.Runtime.InteropServices;

public class JsTest : MonoBehaviour
{

    [DllImport("__Internal")]
    private static extern void Hello();

    [DllImport("__Internal")]
    private static extern void HelloString(string str);

    [DllImport("__Internal")]
    private static extern void PrintFloatArray(float[] array, int size);

    [DllImport("__Internal")]
    private static extern int AddNumbers(int x, int y);

    [DllImport("__Internal")]
    private static extern string StringReturnValueFunction();

    [DllImport("__Internal")]
    private static extern void BindWebGLTexture(int texture);

    [DllImport("__Internal")]
    private static extern void WatchDeviceorientation();

    // スタート時に呼ばれる
    void Start()
    {
        // 関数呼び出し
        Hello();

        // 数値型の引数と戻り値
        int result = AddNumbers(5, 7);
        Debug.Log(result);

        // 数値型以外の型の引数
        float[] myArray = new float[10];
        PrintFloatArray(myArray, myArray.Length);

        // 文字列型の引数
        HelloString("This is a string.");

        // 文字列の戻り値
        Debug.Log(StringReturnValueFunction());

        // WebGLテクスチャのバインド
        var texture = new Texture2D(0, 0, TextureFormat.ARGB32, false);
        BindWebGLTexture(texture.GetNativeTextureID());


        WatchDeviceorientation();
    }

    public TextMesh textMesh1;
    public TextMesh textMesh2;
    public TextMesh textMesh3;
    public void ShowRotation(String rotation)
    {
        string[] rotations = rotation.Split(',');

        textMesh1.text = "alpha: " + rotations[0];
        textMesh2.text = "beta: " + rotations[1];
        textMesh3.text = "gamma: " + rotations[2];
    }
}