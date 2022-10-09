using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR
{
    public class IdleTask : MonoBehaviour
    {
        public int idleTime;
        TaskManager TaskManager;
        // Start is called before the first frame update
        void Start()
        {
            TaskManager = GameObject.Find("TaskManager").GetComponent<TaskManager>();
            StartCoroutine(ProcessTime());
        }
        public void Interact()
        {
            Debug.Log("Idle Task Completed");
            TaskManager.CheckTask(this.gameObject);
        }

        IEnumerator ProcessTime()
        {
            yield return new WaitForSeconds(idleTime);
            Interact();
        }
    }
}
