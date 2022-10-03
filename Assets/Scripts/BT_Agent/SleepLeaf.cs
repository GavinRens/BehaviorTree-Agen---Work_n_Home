using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SleepLeaf : Node
{
    float duration;
    float elapsed;
    float previousTime;


    public SleepLeaf(string name, float duration, Node parent) : base(name, parent)
    {
        this.duration = duration;
        elapsed = 0;
    }


    public override Status Process()
    {
        if (elapsed < duration)
        {
            // Manage task duration
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

            // Do the task
            BT_AgentController.actionStatusText.text = "Sleeping";

            return Node.Status.RUNNING;
        }
        else
        {
            elapsed = 0;
            return Node.Status.SUCCESS;
        }
    }
}

