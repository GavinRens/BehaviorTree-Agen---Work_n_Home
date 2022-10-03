using UnityEngine;


public class EatLeaf : Node
{
    float duration;
    float elapsed;
    float previousTime;


    public EatLeaf(string name, float duration, Node parent) : base(name, parent)
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
                float rand = Random.value;
                if (rand > 0.3f)
                {
                    elapsed = 0.0001f;
                    previousTime = Time.time;
                }
                else
                    return Node.Status.SUCCESS;
            }
            else
            {
                elapsed += Time.time - previousTime;
                previousTime = Time.time;
            }

            // Do the task
            BT_AgentController.actionStatusText.text = "Eating";

            return Node.Status.RUNNING;
        }
        else
        {
            elapsed = 0;
            return Node.Status.SUCCESS;
        }
    }
}

