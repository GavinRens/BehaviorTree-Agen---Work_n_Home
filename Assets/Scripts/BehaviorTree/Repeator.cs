using UnityEngine;


// Must be the parent of one selector or sequence node
public class Repeator : Node
{
    float duration;
    float elapsed;
    float previousTime;

    public Repeator(string n, float d, Node p = null) : base(n, p)
    {
        duration = d;
        elapsed = 0;
    }


    public override Status Process()
    {
        if (elapsed < duration)
        {
            // Manage repeator duration
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
            
            Status childStatus = children[0].Process();
            switch (childStatus)
            {
                case Status.RUNNING:
                    return Status.RUNNING;
                case Status.SUCCESS:
                    return Status.RUNNING;
                default:
                    return Status.FAILURE;
            }
        }
        else
        {
            elapsed = 0;
            return Node.Status.SUCCESS;
        }
    }
}
