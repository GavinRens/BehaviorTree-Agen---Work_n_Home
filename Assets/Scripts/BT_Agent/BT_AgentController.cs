using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

//using TEST1;
//using TEST2;
//using TEST3;


public class BT_AgentController : MonoBehaviour
{
    public GameObject factoryEntrance;
    public GameObject factoryFloor;
    public GameObject houseEntrance;
    public GameObject sittingRoom;
    public GameObject bedroom;
    public GameObject actionStatus;
    public GameObject path1Marker;
    public GameObject path2Marker;
    public GameObject path3Marker;
    public static TextMeshPro actionStatusText;
    public Node currentNode;
    public bool traveling;
    
    private BehaviorTree tree;
    private NavMeshAgent navMeshAgent;
    private Node.Status treeStatus = Node.Status.RUNNING;
    

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        navMeshAgent.stoppingDistance = 1.9f;

        actionStatusText = actionStatus.GetComponent<TextMeshPro>();

        traveling = false;

        Time.timeScale = 3f;  // used for testing only

        tree = new BehaviorTree();
        
        Repeator liv_Rep = new Repeator("liv_Rep", float.PositiveInfinity);
        Sequencer liv_Seq = new Sequencer("liv_Seq and Rest");
        Sequencer work = new Sequencer("Working");
        GotoLeaf gotoWork_2ndHalf = new GotoLeaf("Goto Work", factoryEntrance, navMeshAgent, this.gameObject, work);
        GotoLeaf goinFactory = new GotoLeaf("Go into Factory", factoryFloor, navMeshAgent, this.gameObject, work);
        Repeator work_rep = new Repeator("Work Repeator", 20f);
        Sequencer make_or_rest = new Sequencer("Make and Rest");
        AssembleLeaf assemble = new AssembleLeaf("Assemble Widget", 1f, work);
        TakeBreakLeaf takeBreak = new TakeBreakLeaf("Take a Break", 1f, work);
        GotoLeaf leaveFactory = new GotoLeaf("Leaving Factory", factoryEntrance, navMeshAgent, this.gameObject, work);
        Sequencer home = new Sequencer("Homing");

        Selector gotoHome_1stHalf = new Selector("Goto Home");
        Selector gotoWork_1stHalf = new Selector("Goto Work");
        
        Sequencer path1Seq = new Sequencer("path1Seq");
        Sequencer path2Seq = new Sequencer("path2Seq");
        Sequencer path3Seq = new Sequencer("path3Seq");
        ChoosePathLeaf tryPath1 = new ChoosePathLeaf("tryPath1", path1Marker);
        ChoosePathLeaf tryPath2 = new ChoosePathLeaf("tryPath2", path2Marker);
        ChoosePathLeaf tryPath3 = new ChoosePathLeaf("tryPath3", path3Marker);
        GotoLeaf path1_1stHalf = new GotoLeaf("Via Path 1", path1Marker, navMeshAgent, this.gameObject, gotoHome_1stHalf);
        GotoLeaf path2_1stHalf = new GotoLeaf("Via Path 2", path2Marker, navMeshAgent, this.gameObject, gotoHome_1stHalf);
        GotoLeaf path3_1stHalf = new GotoLeaf("Via Path 3", path3Marker, navMeshAgent, this.gameObject, gotoHome_1stHalf);

        GotoLeaf gotoHome_2ndHalf = new GotoLeaf("Goto Home", houseEntrance, navMeshAgent, this.gameObject, home);
        GotoLeaf goinHouse = new GotoLeaf("Go in House", sittingRoom, navMeshAgent, this.gameObject, home);
        Repeator home_rep = new Repeator("Home Repeator", 10f);
        Sequencer play_or_eat = new Sequencer("Play and Eat");
        PlayLeaf play = new PlayLeaf("Playing", 1f, play_or_eat);
        EatLeaf eat = new EatLeaf("Eating", 1f, play_or_eat);
        GotoLeaf gotoBedroom = new GotoLeaf("Goto Bedroom", bedroom, navMeshAgent, this.gameObject, home);
        SleepLeaf sleep = new SleepLeaf("Sleeping", 5f, home);
        GotoLeaf leaveHouse = new GotoLeaf("Leave House", houseEntrance, navMeshAgent, this.gameObject, home);

        tree.AddChild(liv_Rep);
        liv_Rep.AddChild(liv_Seq);
        liv_Seq.AddChild(work);
        liv_Seq.AddChild(home);

        work.AddChild(gotoWork_1stHalf);
        work.AddChild(gotoWork_2ndHalf);
        work.AddChild(goinFactory);
        work.AddChild(work_rep);
        work.AddChild(leaveFactory);

        path1Seq.AddChild(tryPath1);
        path1Seq.AddChild(path1_1stHalf);
        path2Seq.AddChild(tryPath2);
        path2Seq.AddChild(path2_1stHalf);
        path3Seq.AddChild(tryPath3);
        path3Seq.AddChild(path3_1stHalf);

        gotoHome_1stHalf.AddChild(path1Seq);
        gotoHome_1stHalf.AddChild(path2Seq);
        gotoHome_1stHalf.AddChild(path3Seq);

        gotoWork_1stHalf.AddChild(path1Seq);
        gotoWork_1stHalf.AddChild(path2Seq);
        gotoWork_1stHalf.AddChild(path3Seq);
        
        home.AddChild(gotoHome_1stHalf);
        home.AddChild(gotoHome_2ndHalf);
        home.AddChild(goinHouse);
        home.AddChild(home_rep);
        home.AddChild(gotoBedroom);
        home.AddChild(sleep);
        home.AddChild(leaveHouse);

        work_rep.AddChild(make_or_rest);
        make_or_rest.AddChild(takeBreak);
        make_or_rest.AddChild(assemble);

        home_rep.AddChild(play_or_eat);
        play_or_eat.AddChild(play);
        play_or_eat.AddChild(eat);



        // TEST 1: Test leaf tasks with duration
        //Sequence seq = new Sequence("Do tasks 1 and 2", tree);
        //Task1 t1 = new Task1("Task1", 5, seq);
        //Task2 t2 = new Task2("Task2", 6, seq);
        //PrintFin pf = new PrintFin("PrintFin", seq);

        //seq.AddChild(t1);
        //seq.AddChild(t2);
        //seq.AddChild(pf);
        //tree.AddChild(seq);



        // TEST 2: Test Repeater node
        //Sequence seq = new Sequence("Do tasks 1, 2, 3", tree);
        //Repeator rep = new Repeator("Repeating tasks 1 and 2", 5, seq);
        //Task1 t1 = new Task1("Task1", seq);
        //Task2 t2 = new Task2("Task2", seq);
        //Task3 t3 = new Task3("Task3", seq);

        //seq.AddChild(rep);
        //rep.AddChild(t1);
        //rep.AddChild(t2);
        //seq.AddChild(t3);
        //tree.AddChild(seq);



        // TEST 3: Test Repeater node
        //Sequence seq = new Sequence("Do tasks 1, 2, 3", tree);
        //Repeator rep = new Repeator("Repeating tasks 1 and 2", 10, seq);
        //Task1 t1 = new Task1("Task1", 2, rep);
        //Task2 t2 = new Task2("Task2", 2, rep);
        //PrintFin pf = new PrintFin("PrintFin", seq);

        //seq.AddChild(rep);
        //rep.AddChild(t1);
        //rep.AddChild(t2);
        //seq.AddChild(pf);
        //tree.AddChild(seq); 


        tree.PrintTree();
    }


    // Update is called once per frame
    void Update()
    {
        if (treeStatus != Node.Status.SUCCESS)
            treeStatus = tree.Process();
    }
}
