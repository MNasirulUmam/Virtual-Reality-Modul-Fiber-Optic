using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace VR
{
    public class TriggerTaskWaitNoReset : MonoBehaviour
    {
        TaskManager TaskManager;

        [Header("Trigger")]
        public GameObject otherObject;
        public enum ObjectUsedForTrigger { Hand, Object };
        public ObjectUsedForTrigger mode;
        float timeToProcess = 0;
        public float processTime = 3;

        bool isProcessing;
        Image processIndicatorImage;

        [Header("Haptics")]
        public bool ApplyHapticsOnGrab = false;

        public enum HandUsedForTrigger { LeftHand, RightHand, BothHand };
        public HandUsedForTrigger hands;

        [Tooltip("Frequency of haptics to play on grab if 'ApplyHapticsOnGrab' is true")]
        public float VibrateFrequency = 0.6f;

        [Tooltip("Amplitute of haptics to play on grab if 'ApplyHapticsOnGrab' is true")]
        public float VibrateAmplitude = 0.3f;

        [Header("Activate Game Object")]
        public bool activateGameObject = false;
        public GameObject activatedObject;

        // Start is called before the first frame update
        void Start()
        {
            TaskManager = GameObject.Find("TaskManager").GetComponent<TaskManager>();
            processIndicatorImage = GameObject.Find("ProcessIndicator").GetComponent<Image>();
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
                            if (activateGameObject)
                            {
                                activatedObject.SetActive(true);
                            }
                            isProcessing = true;
                            StartCoroutine(ProcessTime());
                            //Interact();                           
                        }

                        break;

                    case ObjectUsedForTrigger.Object:
                        if (other.gameObject == otherObject)
                        {
                            if (activateGameObject)
                            {
                                activatedObject.SetActive(true);
                            }
                            isProcessing = true;
                            StartCoroutine(ProcessTime());
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
                        if (other.gameObject.tag == "Hand")
                        {
                            if (activateGameObject)
                            {
                                activatedObject.SetActive(false);
                            }
                            isProcessing = false;
                            StopCoroutine(ProcessTime());
                        }

                        break;

                    case ObjectUsedForTrigger.Object:
                        if (other.gameObject == otherObject)
                        {
                            if (activateGameObject)
                            {
                                activatedObject.SetActive(false);
                            }
                            isProcessing = false;
                            StopCoroutine(ProcessTime());
                        }

                        break;
                }
            }
        }

        public void Interact()
        {
            Debug.Log("Object Triggered");
            processIndicatorImage.fillAmount = 0;
            timeToProcess = 0;
            TaskManager.CheckTask(this.gameObject);
        }

        IEnumerator ProcessTime()
        {
            while (isProcessing)
            {
                timeToProcess += 0.01f;
                processIndicatorImage.fillAmount = timeToProcess / processTime;

                // Play haptics
                if (ApplyHapticsOnGrab)
                {
                    switch (hands)
                    {
                        case HandUsedForTrigger.LeftHand:
                            InputBridge.Instance.VibrateController(VibrateFrequency, VibrateAmplitude, processTime, ControllerHand.Left);
                            break;

                        case HandUsedForTrigger.RightHand:
                            InputBridge.Instance.VibrateController(VibrateFrequency, VibrateAmplitude, processTime, ControllerHand.Right);
                            break;

                        case HandUsedForTrigger.BothHand:
                            InputBridge.Instance.VibrateController(VibrateFrequency, VibrateAmplitude, processTime, ControllerHand.Left);
                            InputBridge.Instance.VibrateController(VibrateFrequency, VibrateAmplitude, processTime, ControllerHand.Right);
                            break;
                    }
                }


                if (timeToProcess >= processTime)
                {
                    Interact();
                    isProcessing = false;
                }

                yield return new WaitForSeconds(0.01f);
            }

            yield break;
        }
    }
}
