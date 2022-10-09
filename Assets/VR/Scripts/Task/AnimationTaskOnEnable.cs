using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR
{
    public class AnimationTaskOnEnable : MonoBehaviour
    {
        TaskManager TaskManager;
        Animator anim;
        public string animationName;
        // Start is called before the first frame update

        void OnEnable()
        {
            TaskManager = GameObject.Find("TaskManager").GetComponent<TaskManager>();
            anim = GetComponent<Animator>();
            anim.Play(animationName);
            StartCoroutine(WaitingProcess());
        }

        public void Interact()
        {
            print("Anim done");
            TaskManager.CheckTask(this.gameObject);
        }

        IEnumerator WaitingProcess()
        {
            while (anim.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1)
            {
                yield return new WaitForSeconds(0.01f);
            }

            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
                Interact();
        }
    }
}
