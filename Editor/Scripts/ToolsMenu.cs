using System.IO;
using UnityEditor;
using UnityEngine;

public static class ToolsMenu
{
    [MenuItem("Tools/Little Helpers/Open Persistent Data Folder")]
    private static void OpenPersistentDataFolder()
    {
        string basePath = Application.persistentDataPath;

        if (string.IsNullOrWhiteSpace(basePath))
        {
            Debug.LogWarning("Persistent data path is unavailable.");
            return;
        }

        string projectFolder = Path.GetFileNameWithoutExtension(Application.dataPath);
        string path = Path.Combine(basePath, projectFolder);
        Directory.CreateDirectory(path);


        EditorUtility.RevealInFinder(path);
    }
    [MenuItem("Tools/Little Helpers/Take Screenshot", false, 1)]
    private static void TakeScreenshot()
    {
        Directory.CreateDirectory(Application.dataPath + "/ScreenShots/");
        ScreenCapture.CaptureScreenshot(Application.dataPath +
            "/ScreenShots/" + ((System.DateTime.Today.ToShortDateString()).Replace("/", "-"))
            + "_" + ((System.DateTime.Now.ToFileTimeUtc().ToString()).Replace(" ", "").Replace(":", "")) + ".png", 1);
    }
}
