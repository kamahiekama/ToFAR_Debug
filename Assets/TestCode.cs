using System;
using System.Collections;
using System.Collections.Generic;
using TofAr.V0;
using UnityEngine;
using UnityEngine.UI;

public class TestCode : MonoBehaviour
{
    public Text text;
    public Toggle Toggle;

    private string log1 = "";
    private string log2 = "";

    // Start is called before the first frame update
    void Start()
    {
        var mgr = TofArManager.Instance;
        text.text = "UsingIos: " + mgr.UsingIos;
        TofArManager.OnDeviceOrientationUpdated += OnDeviceOrientationUpdated;
        TofArManager.OnScreenOrientationUpdated += OnScreenOrientationUpdated;
    }

    private void OnScreenOrientationUpdated(ScreenOrientation previousScreenOrientation, ScreenOrientation newScreenOrientation)
    {
        log1 += "OnScreen: " + newScreenOrientation;
    }

    private void OnDeviceOrientationUpdated(DeviceOrientation previousDeviceOrientation, DeviceOrientation newDeviceOrientation)
    {
        log2 += "OnDevice: " + newDeviceOrientation;
    }

    public void OnToggleChanged()
    {
        if (Toggle.isOn)
        {
            Screen.autorotateToLandscapeLeft = false;
            Screen.autorotateToLandscapeRight = false;
            Screen.autorotateToPortrait = false;
            Screen.autorotateToPortraitUpsideDown = false;
        }
        else
        {
            Screen.autorotateToLandscapeLeft = true;
            Screen.autorotateToLandscapeRight = true;
            Screen.autorotateToPortrait = true;
            Screen.autorotateToPortraitUpsideDown = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (log1 != "")
        {
            text.text += "\r\n" + log1;
            log1 = "";
        }
        if (log2 != "")
        {
            text.text += "\r\n" + log2;
            log2 = "";
        }
    }
}
