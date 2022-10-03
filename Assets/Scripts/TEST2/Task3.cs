namespace TEST2
{
    public class Task3 : Node
    {
        public Task3(string name, Node parent) : base(name, parent) { }

        public override Status Process()
        {
            BT_AgentController.actionStatusText.text = "Task 3";
            return Status.SUCCESS;
        }
    }
}