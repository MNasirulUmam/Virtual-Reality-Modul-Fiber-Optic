using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR
{
    public class ManualGrabTask : MonoBehaviour
    {
        TaskManager TaskManager;
        public int TaskNumber;
        // Start is called before the first frame update
        void Start()
        {
            TaskManager = GameObject.Find("TaskManager").GetComponent<TaskManager>();
        }

        public void Grab()
        {
            if (TaskManager.currentTaskIndex == TaskNumber)
            {
                Debug.Log("Go to Task" + (TaskNumber + 1));
                TaskManager.CheckTask(this.gameObject);
            }
        }
    }
}