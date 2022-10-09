using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR
{
    public class AnimationTaskVersion2 : MonoBehaviour
    {
        TaskManager TaskManager;
        Animator anim;
        float animNormalize;

        // Start is called before the first frame update
        public void PlayAnim()
        {
            TaskManager = GameObject.Find("TaskManager").GetComponent<TaskManager>();
            anim = GetComponent<Animator>();
            anim.Play(TaskManager.TaskList[TaskManager.currentTaskIndex].ifObjectHasAnimation, -1, 0f);
            print("Normalized Value : " + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
            StartCoroutine(WaitingProcess());
        }

        public void Interact()
        {
            print("Anim done");
            TaskManager.CheckTask(this.gameObject);
        }

        IEnumerator WaitingProcess()
        {
            yield return new WaitForSeconds(1f);

            //animNormalize++;
            while (anim.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1)
            {
                yield return new WaitForSeconds(0.01f);
                print(animNormalize);
            }

            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
            {
                print("Berhasil");
                Interact();
            }

        }
    }
}