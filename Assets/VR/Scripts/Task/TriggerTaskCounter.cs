using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR
{
    public class TriggerTaskCounter : MonoBehaviour
    {
        TaskManager TaskManager;
        TotalTask TotalTask;
        public GameObject otherObject, currentTaskObject, fixObject;

        // Start is called before the first frame update
        void Start()
        {
            TaskManager = GameObject.Find("TaskManager").GetComponent<TaskManager>();
            TotalTask = GetComponentInParent<TotalTask>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnTriggerEnter(Collider other)
        {
            if (TaskManager.TaskList[TaskManager.currentTaskIndex].taskObject == currentTaskObject)
            {
                if (other.gameObject == otherObject)
                {
                    Interact();
                }
            }

        }

        public void Interact()
        {
            Debug.Log("Object Triggered");
            TotalTask.checkCorrectAnswer++;
            otherObject.SetActive(false);
            currentTaskObject.SetActive(false);
            fixObject.SetActive(true);
        }
    }
}
