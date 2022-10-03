namespace TEST2
{
    public class Task1 : Node
    {
        public Task1(string name, Node parent) : base(name, parent) { }

        public override Status Process()
        {
            BT_AgentController.actionStatusText.text = "Task 1";
            return Status.SUCCESS;
        }
    }
}