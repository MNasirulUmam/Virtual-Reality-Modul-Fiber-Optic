using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR
{
    public class TotalTask : MonoBehaviour
    {
        TaskManager TaskManager;
        public int checkCorrectAnswer = 0, checkTotal;
        // Start is called before the first frame update
        void Start()
        {
            TaskManager = GameObject.Find("TaskManager").GetComponent<TaskManager>();
        }

        // Update is called once per frame
        void Update()
        {
            if (checkCorrectAnswer == checkTotal)
            {
                TaskManager.CheckTask(this.gameObject);
            }
        }
    }
}
