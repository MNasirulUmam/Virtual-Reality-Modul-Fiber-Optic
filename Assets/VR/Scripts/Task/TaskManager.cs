using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

namespace VR
{
    public class TaskManager : MonoBehaviour
    {
        private PhotonView photonView;
        public bool isOnline;
        public bool validStatus = true;
        public bool detectObjectChildColliders = false;
        [SerializeField]
        public List<Task> TaskList;

        public int currentTaskIndex = 0;
        public TextMeshProUGUI TaskName, TaskInstruction;
        //public Text TaskName, TaskName_Shd, TaskInstruction, TaskInstruction_Shd;
        public AudioClip nextStateClip;
        public AudioSource nextStateSound;
        AudioSource asc;

        public int score = 0;
        // Start is called before the first frame update
        void Start()
        {
            photonView = GetComponent<PhotonView>();
            asc = GetComponent<AudioSource>();
            UpdateTask();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnlineUpdateTask()
        {
            UpdateTask();
        }

        protected bool requestingOwnerShip = false;
        void ValidTaskUpdate()
        {
            if (TaskList[currentTaskIndex].taskObject.name != "Idle")
            {
                nextStateSound.clip = nextStateClip;
                nextStateSound.Play();
                Debug.Log("Task " + currentTaskIndex + " is Done");
            }

            /*if (TaskList[currentTaskIndex].taskObject.name == "BackToMainMenu")
            {
                SceneManager.LoadScene("Menu");
            }*/


            if (TaskList[currentTaskIndex].isCurrentTaskObjectMustDestroyed)
            {
                TaskList[currentTaskIndex].taskObject.SetActive(false);
            }

            if (TaskList[currentTaskIndex].mustDestroyedOtherObject != null)
            {
                foreach (GameObject go in TaskList[currentTaskIndex].mustDestroyedOtherObject)
                {
                    //Destroy(go);
                    go.SetActive(false);
                }
            }

            //Learn Mode atau test mode, outline akan selalu dimatikan setelah check task benar
            if (TaskList[currentTaskIndex].taskObject.GetComponent<EPOOutline.Outlinable>())
            {
                TaskList[currentTaskIndex].taskObject.GetComponent<EPOOutline.Outlinable>().enabled = false;
            }

        }

        public void CheckTask(GameObject other)
        {
            if (other == TaskList[currentTaskIndex].taskObject)
            {
                if (isOnline)
                {
                    validStatus = true;
                    photonView.RPC("RPC_ValidTask", RpcTarget.AllBuffered, validStatus);
                    photonView.RPC("RPC_AddIndex", RpcTarget.AllBuffered, currentTaskIndex);
                    //UpdateTask();
                }
                else
                {
                    if (TaskList[currentTaskIndex].taskObject.name != "Idle")
                    {
                        nextStateSound.clip = nextStateClip;
                        nextStateSound.Play();
                        Debug.Log("Task " + currentTaskIndex + " is Done");
                    }

                    /*if (TaskList[currentTaskIndex].taskObject.name == "BackToMainMenu")
                    {
                        SceneManager.LoadScene("Menu");
                    }*/


                    if (TaskList[currentTaskIndex].isCurrentTaskObjectMustDestroyed)
                    {
                        TaskList[currentTaskIndex].taskObject.SetActive(false);
                    }

                    if (TaskList[currentTaskIndex].mustDestroyedOtherObject != null)
                    {
                        foreach (GameObject go in TaskList[currentTaskIndex].mustDestroyedOtherObject)
                        {
                            //Destroy(go);
                            go.SetActive(false);
                        }
                    }

                    //Learn Mode atau test mode, outline akan selalu dimatikan setelah check task benar
                    if (TaskList[currentTaskIndex].taskObject.GetComponent<EPOOutline.Outlinable>())
                    {
                        TaskList[currentTaskIndex].taskObject.GetComponent<EPOOutline.Outlinable>().enabled = false;
                    }

                    currentTaskIndex++;
                    UpdateTask();
                }
                score++;
            }
        }

        public void UpdateTask()
        {
            TaskName.text = TaskList[currentTaskIndex].TaskName;
            TaskInstruction.text = TaskList[currentTaskIndex].TaskInstruction;
            if (TaskList[currentTaskIndex].instructionVoice)
            {
                asc.clip = TaskList[currentTaskIndex].instructionVoice;
                asc.Play();
            }

            if (TaskList[currentTaskIndex].taskObject != null)
            {
                if (!TaskList[currentTaskIndex].taskObject.activeSelf)
                {
                    TaskList[currentTaskIndex].taskObject.SetActive(true);
                }
            }

            if (TaskList[currentTaskIndex].mustActivateGameObject != null)
            {
                foreach (GameObject go in TaskList[currentTaskIndex].mustActivateGameObject)
                {
                    //Destroy(go);
                    go.SetActive(true);
                    if (TaskList[currentTaskIndex].toogleOutline)
                    {
                        if (go.GetComponent<EPOOutline.Outlinable>())
                        {
                            go.GetComponent<EPOOutline.Outlinable>().enabled = true;
                        }
                    }

                    if (TaskList[currentTaskIndex].ifChildObjectHasAnimation != null)
                    {
                        if (go.GetComponent<AnimationChildTask>())
                        {
                            go.GetComponent<AnimationChildTask>().PlayAnim();
                        }
                    }
                }
            }

            if (TaskList[currentTaskIndex].taskObject.GetComponent<EPOOutline.Outlinable>())
            {
                TaskList[currentTaskIndex].taskObject.GetComponent<EPOOutline.Outlinable>().enabled = true;
            }

            if (TaskList[currentTaskIndex].ifObjectHasAnimation != null)
            {
                if (TaskList[currentTaskIndex].taskObject.GetComponent<AnimationTaskVersion2>())
                {
                    TaskList[currentTaskIndex].taskObject.GetComponent<AnimationTaskVersion2>().PlayAnim();
                }
            }

            if (detectObjectChildColliders)
            {
                if (TaskList[currentTaskIndex].taskObject.GetComponent<NetworkedGrabbable>())
                {
                    if (TaskList[currentTaskIndex].taskObject.GetComponent<NetworkedGrabbable>().MakeChildCollidersGrabbable)
                    {
                        Collider[] cols = TaskList[currentTaskIndex].taskObject.GetComponentsInChildren<Collider>();
                        for (int x = 0; x < cols.Length; x++)
                        {
                            cols[x].enabled = true;
                        }
                    }
                    else
                    {
                        TaskList[currentTaskIndex].taskObject.GetComponent<Collider>().enabled = true;
                    }
                }

                if (TaskList[currentTaskIndex].taskObject.GetComponent<Grabbable>())
                {
                    if (TaskList[currentTaskIndex].taskObject.GetComponent<Grabbable>().MakeChildCollidersGrabbable)
                    {
                        Collider[] cols = TaskList[currentTaskIndex].taskObject.GetComponentsInChildren<Collider>();
                        for (int x = 0; x < cols.Length; x++)
                        {
                            cols[x].enabled = true;
                        }
                    }
                    else
                    {
                        TaskList[currentTaskIndex].taskObject.GetComponent<Collider>().enabled = true;
                    }
                }
            }



            validStatus = false;
        }

        [PunRPC]
        void RPC_AddIndex(int indexState)
        {
            indexState++;
            currentTaskIndex = indexState;
            UpdateTask();
        }

        [PunRPC]
        void RPC_ValidTask(bool isValid)
        {
            Debug.Log("Valid status = " + isValid);
            if (isValid)
            {
                ValidTaskUpdate();
            }

        }
    }

    [System.Serializable]
    public class Task
    {
        public string TaskName, TaskInstruction;
        public GameObject taskObject;
        public AudioClip instructionVoice;
        public GameObject[] mustDestroyedOtherObject, mustActivateGameObject;
        public bool isCurrentTaskObjectMustDestroyed;
        public string ifObjectHasAnimation;
        public string ifChildObjectHasAnimation;
        public bool toogleOutline = true;
    }

}
