using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.PackageManager.Requests;
using UnityEditor.PackageManager;

[InitializeOnLoad]
public class ProjectSetupEditor : EditorWindow
{
    public static ProjectSetupEditor Instance { get; private set; }
    public static bool IsOpen
    {
        get { return Instance != null; }
    }

    static bool DoCheckFirstRun = true;
    static bool FirstRun = true;

    static bool ShowedFirstRunWindow = false;

    static Texture logo;
    static GUIStyle rt;

    static ProjectSetupEditor()
    {
        if (DoCheckFirstRun)
        {
            EditorApplication.update += CheckFirstRun;
        }
    }

    static void CheckFirstRun()
    {

        // Only call this once
        EditorApplication.update -= CheckFirstRun;

        // Open Window on first load
        FirstRun = !EditorPrefs.HasKey("FirstRun");
        if (FirstRun)
        {
            DoFirstRun();
        }
    }

    void OnEnable()
    {
        Instance = this;

        //logo = Resources.Load("400") as Texture;
    }

    public static void DoFirstRun()
    {

        EditorPrefs.SetBool("FirstRun", true);

        ShowedFirstRunWindow = true;

        ProjectSetupEditor window = (ProjectSetupEditor)GetWindow(typeof(ProjectSetupEditor));
        window.Show();

        FirstRun = false;
    }

    [MenuItem("XR Simulation Framework/Initial Project Setup")]
    public static void ShowWindow()
    {

        const int width = 1100;
        const int height = 440;

        var x = (Screen.currentResolution.width - width) / 2;
        var y = (Screen.currentResolution.height - height) / 2;

        GetWindow<ProjectSetupEditor>("Initial Project Setup").position = new Rect(x, y, width, height);

    }

    void OnGUI()
    {

        // Sanity check on rich text style
        if (rt == null)
        {
            rt = new GUIStyle(EditorStyles.label);
            rt.richText = true;
        }

        // Logo / Info
        // Logo / Info
        GUILayout.BeginHorizontal();

        if (logo)
        {
            GUILayout.Label(logo);
        }

        GUILayout.Label("\nThis instruction will show you how to setup the project for your simulation.\n \nAfter you import the simulation framework, you need to install the following dependency assets : \n", rt);

        GUILayout.FlexibleSpace();

        GUILayout.EndHorizontal();


        // First Time Check
        if (ShowedFirstRunWindow)
        {
            EditorGUILayout.HelpBox("This appears to be your fist time installing XR Simulation Framework - You can follow this instruction to setup your simulation project!", MessageType.Info);
            EditorGUILayout.Separator();
        }

        GUILayout.Label("Project Setup Insruction : ", EditorStyles.boldLabel);
        EditorGUILayout.LabelField("1. Install new Input System from Package Manager if you are using Unity 2020 or above", rt);
        EditorGUILayout.LabelField("2. Install PUN 2 asset from Unity Asset Store", rt);
        EditorGUILayout.LabelField("3. Install Photon Voice asset from Unity Asset Store", rt);
        EditorGUILayout.LabelField("4. Switch build platfrom into Android, since this simulation just support Oculus Quest 2.", rt);
        EditorGUILayout.LabelField("5. Add XR Plugin Management for Oculus Quest (Edit->Project Settings->XR Plugin Management)", rt);
        EditorGUILayout.LabelField("6. This is optional, if you want to use Oculus Integration from Unity Asset Store, import the integration file on VR/Oculus Integration folder and update Oculus XR from package manager.)", rt);
    }

    public static void DrawUILine(Color color, int thickness = 1, int padding = 10)
    {
        Rect r = EditorGUILayout.GetControlRect(GUILayout.Height(padding + thickness));
        r.height = thickness;
        r.y += padding / 2;
        r.x -= 2;
        r.width += 6;
        EditorGUI.DrawRect(r, color);
    }

    static string GetLabel(bool active)
    {
        if (active)
        {
            return "<color=green><b>True</b></color>";
        }

        return "<color=gray><b>False</b></color>";
    }
}
