using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR
{
    public class ChooseTaskCounter : MonoBehaviour
    {
        TaskManager TaskManager;
        int checkCorrectAnswer;
        // Start is called before the first frame update
        void Start()
        {
            TaskManager = GameObject.Find("TaskManager").GetComponent<TaskManager>();
        }

        public void addCounter()
        {
            checkCorrectAnswer++;
            if (checkCorrectAnswer == 14)
            {
                Debug.Log("APD Selesai");
                TaskManager.CheckTask(this.gameObject);
            }
        }
    }
}
