using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR
{
    public class AnimationTaskEnabler : MonoBehaviour
    {
        public AnimationTaskOnEnable AnimationTaskOnEnable;
        public GameObject KolomStatic;
        // Start is called before the first frame update
        void Start()
        {
            if (AnimationTaskOnEnable != null)
            {
                AnimationTaskOnEnable.enabled = true;
            }
        }

        public void KolomStaticON()
        {
            KolomStatic.SetActive(true);
        }

        public void KolomStaticOff()
        {
            KolomStatic.SetActive(false);
        }
    }
}