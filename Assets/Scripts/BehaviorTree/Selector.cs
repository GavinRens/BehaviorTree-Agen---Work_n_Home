
public class Selector : Node
{
    public Selector(string n, Node p = null) : base(n, p)
    {
        
    }

    public override Status Process()
    {
        //UnityEngine.Debug.Log("In Selector: " + name);
        Status childStatus = children[currentChild].Process();
        switch (childStatus)
        {
            case Status.RUNNING:
                return Status.RUNNING;
            case Status.FAILURE:
                currentChild++;
                if (currentChild >= children.Count)
                {
                    currentChild = 0;
                    return Status.FAILURE;
                }
                else
                    return Status.RUNNING;
            case Status.SUCCESS:
                currentChild = 0;
                return Status.SUCCESS;

            default: return Status.FAILURE;
        }
    }
}
