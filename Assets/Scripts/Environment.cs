using UnityEngine;
using TMPro;


public class Environment : MonoBehaviour
{
    public GameObject[] Paths;
    public GameObject agent;
    
    BT_AgentController agentController;
    bool timeToShuffleOpenPath;


    void Start()
    {
        agentController = agent.GetComponent<BT_AgentController>();
        timeToShuffleOpenPath = true;
    }


    void Update()
    {
        // The open path will keep shuffling (per second) while the agent is not traveling, ie, using the paths
        if(!agentController.traveling && timeToShuffleOpenPath)
        {
            timeToShuffleOpenPath = false;
            Invoke("SetTimeToShuffle", 1f);
            ShuffleOpenPath();
        }
    }


    // Selects one of the three paths to be open at random (other two paths are closed)
    private void ShuffleOpenPath()
    {
        Transform xform;
        int index = Random.Range(0, 3);
        BlackBoard.ACTIVE_PATH = index;

        for (int i = 0; i < Paths.Length; i++)
        {
            if (i == index)
            {
                Paths[i].GetComponentInChildren<TextMeshPro>().text = "OPEN";
                for (int j = 0; j < Paths[i].transform.childCount; j++)
                {
                    if (Paths[i].transform.GetChild(j).gameObject.CompareTag("barricade")) 
                        Paths[i].transform.GetChild(j).gameObject.SetActive(false);
                }
                Paths[i].GetComponent<PathBehavior>().open = true;
            }
            else
            {
                Paths[i].GetComponentInChildren<TextMeshPro>().text = "CLOSED";
                for (int j = 0; j < Paths[i].transform.childCount; j++)
                {
                    if (Paths[i].transform.GetChild(j).gameObject.CompareTag("barricade"))
                        Paths[i].transform.GetChild(j).gameObject.SetActive(true);
                }
                Paths[i].GetComponent<PathBehavior>().open = false;
            }
        }
    }

    //private void ShuffleOpenPath()
    //{
    //    Transform[] xforms;
    //    int index = Random.Range(0, 3);
    //    BlackBoard.ACTIVE_PATH = index;

    //    for (int i = 0; i < Paths.Length; i++)
    //    {
    //        xforms = Paths[i].GetComponentsInChildren<Transform>();
    //        if (i == index)
    //        {
    //            Paths[i].GetComponentInChildren<TextMeshPro>().text = "OPEN";
    //            //barracade = Paths[i].GetComponentsInChildren<Transform>()[1];
    //            //barracade.gameObject.SetActive(false);
    //            foreach (Transform t in xforms)
    //                if (t.CompareTag("barricade"))
    //                    t.gameObject.SetActive(false);
    //            //Paths[i].GetComponentInChildren<Transform>().gameObject.SetActive(false);
    //            Paths[i].GetComponentInChildren<PathBehavior>().open = true;
    //        }
    //        else
    //        {
    //            Paths[i].GetComponentInChildren<TextMeshPro>().text = "CLOSED";
    //            //barracade = Paths[i].GetComponentsInChildren<Transform>()[1];
    //            //barracade.gameObject.SetActive(true);
    //            foreach (Transform t in xforms)
    //                if (t.CompareTag("barricade"))
    //                    t.gameObject.SetActive(true);
    //            //Paths[i].GetComponentInChildren<Transform>().gameObject.SetActive(true);
    //            Paths[i].GetComponentInChildren<PathBehavior>().open = false;
    //        }
    //    }
    //}


    // The method to invoke with a delay; the time bwix open-path suffles
    private void SetTimeToShuffle()
    {
        timeToShuffleOpenPath = true;
    }
}
