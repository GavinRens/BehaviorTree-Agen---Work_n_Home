using UnityEngine;


// A conditional node; the first child of a Sequencer
public class ChoosePathLeaf : Node
{
    GameObject path;


    public ChoosePathLeaf(string name, GameObject path) : base(name)
    {
        this.path = path;
    }


    public override Status Process()
    {
        //Debug.Log("path.GetComponent<PathBehavior>().open: " + path.GetComponent<PathBehavior>().open);
        if (path.GetComponent<PathBehavior>().open)
            return Status.SUCCESS;
        else
            return Status.FAILURE;
    }
}
