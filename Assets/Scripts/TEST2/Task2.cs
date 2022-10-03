namespace TEST2
{
    public class Task2 : Node
    {
        public Task2(string name, Node parent) : base(name, parent) { }

        public override Status Process()
        {
            BT_AgentController.actionStatusText.text = "Task 2";
            return Status.SUCCESS;
        }
    }
}

