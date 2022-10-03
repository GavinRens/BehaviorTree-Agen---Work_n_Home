using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoosePathLeaf : Node
{
    GameObject path;


    public ChoosePathLeaf(string name, GameObject path) : base(name)
    {
        this.path = path;
    }

    public override Status Process()
    {
        if (path.GetComponent<PathBehavior>().open)
            return Status.SUCCESS;
        else
            return Status.FAILURE;
    }
}
