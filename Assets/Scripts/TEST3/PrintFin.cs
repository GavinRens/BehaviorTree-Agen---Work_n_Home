namespace TEST3
{
    public class PrintFin : Node
    {
        public PrintFin(string name, Node parent) : base(name, parent) { }

        public override Status Process()
        {
            BT_AgentController.actionStatusText.text = "Finished !";
            return Status.SUCCESS;
        }
    }
}
