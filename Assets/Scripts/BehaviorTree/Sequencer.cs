
public class Sequencer : Node
{
    public Sequencer(string n, Node p = null) : base(n, p) { }


    public override Status Process()
    {
        Status childStatus = children[currentChild].Process();
        switch (childStatus)
        {
            case Status.RUNNING:
                return Status.RUNNING;
            case Status.FAILURE:
                currentChild = 0;
                return Status.FAILURE;
            case Status.SUCCESS:
                currentChild++;
                if (currentChild >= children.Count)
                {
                    currentChild = 0;
                    return Status.SUCCESS;
                }
                else
                    return Status.RUNNING;
            default: return Status.FAILURE;
        }
    }
}
