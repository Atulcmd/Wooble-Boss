using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshot : MonoBehaviour
{
    public string screenshotFolder = "Screenshots";

    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    void CaptureScreenshot()
    {
        // Create a folder if it doesn't exist
        string folderPath = System.IO.Path.Combine(Application.persistentDataPath, screenshotFolder);
        if (!System.IO.Directory.Exists(folderPath))
        {
            System.IO.Directory.CreateDirectory(folderPath);
        }

        // Generate a unique file name using a timestamp
        string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
        string screenshotFileName = "Screenshot_" + timestamp + ".png";

        // Combine the file name and the folder path where the screenshot will be saved
        string screenshotPath = System.IO.Path.Combine(folderPath, screenshotFileName);

        // Capture the screenshot and save it to the specified file path
        ScreenCapture.CaptureScreenshot(screenshotPath);

        // Print a message to the console to indicate that the screenshot has been captured
        Debug.Log("Screenshot captured and saved to: " + screenshotPath);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            // Capture the screenshot and save it to the specified file path
            CaptureScreenshot();
        }
    }
}
