using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace VR
{
    [CanEditMultipleObjects]
    public class TaskManagerEditor : MonoBehaviour
    {
        [MenuItem("GameObject/XR Simulation Framework/Simulation Function/Task Manager", false, 32)]
        private static void AddTaskManager(MenuCommand menuCommand)
        {
            // Create and add a new Grabbable Object in the Scene
            GameObject TaskManager = Instantiate(Resources.Load("TaskManager", typeof(GameObject))) as GameObject;
            TaskManager.name = "TaskManager";

            GameObjectUtility.SetParentAndAlign(TaskManager, menuCommand.context as GameObject);

            Undo.RegisterCreatedObjectUndo(TaskManager, "Created TaskManager " + TaskManager.name);
            Selection.activeObject = TaskManager;
        }

        [MenuItem("GameObject/XR Simulation Framework/Simulation Function/XR Simulation Player", false, 33)]
        private static void AddPlayer(MenuCommand menuCommand)
        {
            // Create and add a new Grabbable Object in the Scene
            GameObject XRSimulationPlayer = Instantiate(Resources.Load("XRSimulationPlayer", typeof(GameObject))) as GameObject;
            XRSimulationPlayer.name = "XR Simulation Player";

            GameObjectUtility.SetParentAndAlign(XRSimulationPlayer, menuCommand.context as GameObject);

            Undo.RegisterCreatedObjectUndo(XRSimulationPlayer, "Created TaskManager " + XRSimulationPlayer.name);
            Selection.activeObject = XRSimulationPlayer;
        }
    }
}
