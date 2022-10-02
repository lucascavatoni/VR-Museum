using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ButtonChange : MonoBehaviour
{
    public GameObject ArseneClosed;
    public GameObject ArseneOpened;

    private InputDevice targetDevice;
    private bool value0;
    private bool value1;

    // Start is called before the first frame update
    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDeviceCharacteristics rightControllerCharacteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(rightControllerCharacteristics, devices);

        ArseneClosed.SetActive(true);
        ArseneOpened.SetActive(false);

        if(devices.Count > 0)
        {
            targetDevice = devices[0];
        }

        targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue);
        value0 = primaryButtonValue;
    }


    


    // Update is called once per frame
    void Update()
    {
        targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue);

        value1 = primaryButtonValue;

        if (value0 == false && value1 == true && ArseneClosed.activeInHierarchy)
        {
            ArseneClosed.SetActive(false);
            ArseneOpened.SetActive(true);
        }
        else if (value0 == false && value1 == true && ArseneOpened.activeInHierarchy)
        {
            ArseneClosed.SetActive(true);
            ArseneOpened.SetActive(false);
        }

        value0 = primaryButtonValue;
    }
}
