using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR
{
    public class AnimationChildTask : MonoBehaviour
    {
        TaskManager TaskManager;
        Animator anim;
        float animNormalize;
        // Start is called before the first frame update
        public void PlayAnim()
        {
            TaskManager = GameObject.Find("TaskManager").GetComponent<TaskManager>();
            anim = GetComponent<Animator>();
            anim.Play(TaskManager.TaskList[TaskManager.currentTaskIndex].ifChildObjectHasAnimation, -1, 0f);
            print("Normalized Value : " + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
        }
    }
}
