# BehaviorTree - Work-n-Home
 An agent using a behavior tree to travel bwix work and home.
 
 
## Description

A framework for controlling agents in Unity (3D real-time engine).
The agent is supposed to goto work, where it assembles widgets and takes breaks in between.
Then the agent must go home, where it plays and eats for a while, then sleeps in the bedroom.
Then the agent goes to work and the cycle continues.
A behavior tree is used for all the control - no planning occurs.

This environment is almost the same as the one used in my project where a hybrid (BDI / Reward Machine) controller is used [GitHub](https://github.com/GavinRens/Hybrid-Agent---Work-n-Home).
However, here i have three paths that the agent must choose between, depending on which path is open (only one is open at a time).
This addition is made to illustrate the use of a Selector node.

The code for the behavior tree API is based on the [tutorial](https://learn.unity.com/project/behaviour-trees?courseId=5dd851beedbc2a1bf7b72bed) by Penny De Byl. However,
(1) my leaf nodes directly extend the Node class, whereas Penny's leaf nodes extend the Leaf class, which is extends the Node class. Also, she uses delegates to pass methods to the leaves, which can be convenient, but inflexible.
(2) i designed my own repeator node (see the API section below for details).


### The Behavior Tree

Here is a pictorial representation of the behavior tree used in this project.

![BehaviorTreeDiagram](https://user-images.githubusercontent.com/41202408/193812477-90a43a03-6703-4bde-b6ab-e65a193c8361.png)

A red node with a curved arrow is a Repeator.
A Repeator must have a single Selector (pink node), Sequencer (blue node) or Leaf (green node) as child.
In the picture above, the subtrees routed at the Selector nodes are identical. In practice, we can reuse the nodes in these subtrees; see the picture below.

![BehaviorTreeDiagram2](https://user-images.githubusercontent.com/41202408/193861574-01a8c770-ddfb-4653-acee-3beb1b5436bf.png)


## Video

[BT_Work_n_Home_002.webm](https://user-images.githubusercontent.com/41202408/193794383-e68cece9-b7f5-4eaa-b94a-d9861b8ade9f.webm)


## Installation

- The project is developed with Unity Editor version 2021.3.9f1 and C# version 9.0 on a Windows operating system.

- The project can be cloned from [GitHub](https://github.com/GavinRens/BehaviorTree-Agent---Work-n-Home).

- In your command line interface, run `git clone <URL>` in the local directory of your choice, where `<URL>` is the url displayed under Code -> HTTPS of the GitHub repo landing page.

- Then, 'Open' the project in your Unity Hub. (Find the project folder in Windows Explorer.)

- Once the project has opened in the Unity editor, select the EatPrayDanceSleep scene in Assets/Scenes of the editor.

- The scene is now playable.


## Usage / API Reference
 
- Create a sequencer node with Sequencer(). As arguments, the constructor takes any string as a name, and an optional pointer to a parent node.
- Create a selector node with Selector(). As arguments, the constructor takes any string as a name, and an optional pointer to a parent node.
- Create a repeator node with Repeator(). As arguments, the constructor takes any string as a name, float as duration (in seconds) of the repetition, and an optional pointer to a parent node.
- Leaf nodes must be designed by the programmer. They extend the Node class. Any data required for processing a leaf is passed as argument, except if the data is global, in which case the data can be accessed from a global 'blackboard' or something similar.
- Start with `tree = new BehaviorTree();`
- Create all tree nodes.
- Create the tree structure by using `p.AddChild(c);`, where `c` is the child node of parent node `p`.
- `tree.PrintTree();` prints the tree structure in the console.

 
## Behavior Tree Design

There are many tutorials on behavior trees.
I recommend the one by Penny De Byl (see link above). 
More resources can be found [here](https://towardsdatascience.com/designing-ai-agents-behaviors-with-behavior-trees-b28aa1c3cf8a) and [here](https://www.youtube.com/watch?v=aR6wt5BlE-E).


## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

## License
[MIT](https://choosealicense.com/licenses/mit/)


