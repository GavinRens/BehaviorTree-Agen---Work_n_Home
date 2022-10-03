using System.Collections.Generic;


public class Node
{
    public enum Status { SUCCESS, RUNNING, FAILURE }
    public Status status;
    public List<Node> children = new List<Node>();
    public int currentChild = 0;
    public string name; 
    public Node parent;
    

    public Node(string name, Node parent = null)
    {
        this.name = name;
        this.parent = parent;
    }


    public void AddChild(Node n)
    {
        children.Add(n);
    }


    /// <summary>
    /// Contains the main logic for each kind of node (i.e. internal or leaf).
    /// Typically needs to be overridden.
    /// </summary>
    /// <returns></returns>
    public virtual Status Process()
    {
        return children[currentChild].Process();
    }
}
