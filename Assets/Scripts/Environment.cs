using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Environment : MonoBehaviour
{
    public GameObject[] Paths;
    bool timeToShuffleOpenPath;
    public GameObject agent;
    BT_AgentController agentController;


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


    private void ShuffleOpenPath()
    {
        int index = Random.Range(0, 3);
        for (int i = 0; i < Paths.Length; i++)
            if (i == index)
            {
                BlackBoard.ACTIVE_PATH = i;
                Paths[i].GetComponentInChildren<TextMeshPro>().text = "OPEN";
                Paths[i].GetComponentInChildren<Transform>().gameObject.SetActive(false);
                Paths[i].GetComponentInChildren<PathBehavior>().open = true;
            }
            else
            {
                Paths[i].GetComponentInChildren<TextMeshPro>().text = "CLOSED";
                Paths[i].GetComponentInChildren<Transform>().gameObject.SetActive(true);
                Paths[i].GetComponentInChildren<PathBehavior>().open = false;
            }
    }


    private void SetTimeToShuffle()
    {
        timeToShuffleOpenPath = true;
    }
}
