using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace VR
{
    public class BackToMainMenu : MonoBehaviour
    {
        int idleTime = 2;
        TaskManager TaskManager;
        // Start is called before the first frame update
        void Start()
        {
            TaskManager = GameObject.Find("TaskManager").GetComponent<TaskManager>();
            StartCoroutine(ProcessTime());
        }

        IEnumerator ProcessTime()
        {
            yield return new WaitForSeconds(idleTime);
            SceneManager.LoadScene("Menu");
        }
    }
}
