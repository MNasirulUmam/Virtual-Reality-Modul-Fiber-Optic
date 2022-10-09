using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR
{
    public class SimpleTask : MonoBehaviour
    {
        TaskManager TaskManager;
        // Start is called before the first frame update
        void Start()
        {
            TaskManager = GameObject.Find("TaskManager").GetComponent<TaskManager>();
        }

        // Update is called once per frame
        public void NextState()
        {
            Debug.Log("Go To Next State");
            TaskManager.CheckTask(this.gameObject);
        }
    }
}