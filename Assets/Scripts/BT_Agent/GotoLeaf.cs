using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GotoLeaf : Node
{
    GameObject waypoint;
    private enum ActionState { IDLE, WORKING };
    private ActionState actionState = ActionState.IDLE;
    NavMeshAgent navMeshAgent;
    GameObject agent;
    BT_AgentController agentController;


    public GotoLeaf(string name, GameObject waypoint, NavMeshAgent nma, GameObject agent, Node parent) : base(name, parent)
    {
        this.waypoint = waypoint;
        this.navMeshAgent = nma;
        this.agent = agent;
        agentController = agent.GetComponent<BT_AgentController>();
    }


    private Node.Status GotoLocation(Vector3 destinatoin)
    {
        if (actionState == ActionState.IDLE)
        {
            navMeshAgent.SetDestination(destinatoin);
            actionState = ActionState.WORKING;
        }
        else if (Vector3.Distance(navMeshAgent.pathEndPosition, destinatoin) >= 2)
        {
            actionState = ActionState.IDLE;
            return Node.Status.FAILURE;
        }
        else if (Vector3.Distance(destinatoin, agent.transform.position) < 2)
        {
            actionState = ActionState.IDLE;
            return Node.Status.SUCCESS;
        }
        return Node.Status.RUNNING;
    }
    
    
    public override Status Process()
    {
        if(name == "Goto Work" || name == "via Path 1" || name == "via Path 2" || name == "via Path 3" || name == "gotoHome")
            agentController.traveling = true;
        else
            agentController.traveling = false;

        BT_AgentController.actionStatusText.text = name;
        return GotoLocation(waypoint.transform.position);
    }
}
