
public class Leaf : Node
{
    public enum LeafStatus { IDLE, RUNNING }
    public LeafStatus leafStatus;
    public delegate Status Tick();
    public Tick ProcessMethod;


    public Leaf(string n, Tick pm, Node p = null) : base(n, p)
    {
        ProcessMethod = pm;
        leafStatus = LeafStatus.IDLE;
    }

    public override Status Process()
    {
        if (ProcessMethod != null)
            return ProcessMethod();
        return Status.FAILURE;
    }
}
