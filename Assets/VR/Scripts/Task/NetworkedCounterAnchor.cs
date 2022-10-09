using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR
{
    public class NetworkedCounterAnchor : MonoBehaviour
    {
        TaskManager TaskManager;
        public static int counter = 0;
        public int limit;

        // Start is called before the first frame update
        void Start()
        {
            counter = 0;
            TaskManager = GameObject.Find("TaskManager").GetComponent<TaskManager>();
        }

        // Update is called once per frame
        void Update()
        {
            if (counter == limit)
            {
                print("Skur Kencang Semua");
                this.gameObject.SetActive(false);
                TaskManager.CheckTask(this.gameObject);
            }
        }
    }
}
