using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TEST3
{
    // A task with a duration
    public class Task1 : Node
    {
        float duration;
        float elapsed;
        float previousTime;

        public Task1(string name, float duration, Node parent) : base(name, parent)
        {
            this.duration = duration;
            elapsed = 0;
        }

        public override Status Process()
        {
            if (elapsed < duration)
            {
                // Do the task
                BT_AgentController.actionStatusText.text = "Task 1";

                // Manage taks duration
                if (elapsed == 0)
                {
                    elapsed = 0.0001f;
                    previousTime = Time.time;
                }
                else
                {
                    elapsed += Time.time - previousTime;
                    previousTime = Time.time;
                }
                return Node.Status.RUNNING;
            }
            else
            {
                elapsed = 0;
                return Node.Status.SUCCESS;
            }
        }
    }
}
