using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR
{
    public class TriggerTask : MonoBehaviour
    {
        TaskManager TaskManager;
        public enum ObjectUsedForTrigger { Hand, Object };

        public ObjectUsedForTrigger mode;
        public GameObject otherObject;

        // Start is called before the first frame update
        void Start()
        {
            TaskManager = GameObject.Find("TaskManager").GetComponent<TaskManager>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnTriggerEnter(Collider other)
        {
            if (TaskManager.TaskList[TaskManager.currentTaskIndex].taskObject == this.gameObject)
            {
                switch (mode)
                {
                    case ObjectUsedForTrigger.Hand:
                        if (other.gameObject.tag == "Hand")
                        {
                            Interact();
                        }

                        break;

                    case ObjectUsedForTrigger.Object:
                        if (other.gameObject == otherObject)
                        {
                            //StartCoroutine(ProcessTime());
                            Interact();
                        }

                        break;
                }
            }

        }

        void OnTriggerExit(Collider other)
        {
            if (TaskManager.TaskList[TaskManager.currentTaskIndex].taskObject == this.gameObject)
            {
                switch (mode)
                {
                    case ObjectUsedForTrigger.Hand:
                        if (other.gameObject.tag == "HandR" || other.gameObject.tag == "HandL")
                        {
                            Interact();
                        }

                        break;

                    case ObjectUsedForTrigger.Object:
                        if (other.gameObject == otherObject)
                        {
                            //StopCoroutine(ProcessTime());
                            Interact();
                        }

                        break;
                }
            }
        }

        public void Interact()
        {
            Debug.Log("Object Triggered");
            TaskManager.CheckTask(this.gameObject);
        }
    }
}
