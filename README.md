# BehaviorTree - Work-n-Home
 An agent using a behavior tree to traveling bwix work and home.
 
## Description
A framework for controlling agents in Unity (3D real-time engine).
The agent is supposed to goto work, where it assembles widgets and takes breaks in between. Then the agent must go home, where it plays and eats for a while, then sleeps in the bedroom. Then the agent goes to work and the cycle continues. A behavior tree is used for all the control - no planning occurs.

This environment is the almost the same as the one used in my project where a hybrid (BDI / Reward Machine) controller is used. However, here i have three paths that the agent must choose between, depending on which path is open (only one is open at a time). This addition is made to illustrate the use of a Selector node.

### The Behavior Tree

Here is a pictorial representation of the behavior tree used in this project.

![BehaviorTreeDiagram](https://user-images.githubusercontent.com/41202408/193812477-90a43a03-6703-4bde-b6ab-e65a193c8361.png)

A red node with a curved arrow is a Repeator. A Repeator must have a single Selector (pink node), Sequencer (blue node) or Leaf (green node) as child.

## Video

[BT_Work_n_Home_002.webm](https://user-images.githubusercontent.com/41202408/193794383-e68cece9-b7f5-4eaa-b94a-d9861b8ade9f.webm)


## Installation
- The project is developed with Unity Editor version 2021.3.3f1 and C# version 9.0 on a Windows operating system.

- The project can be cloned from [GitHub](https://github.com/GavinRens/BehaviorTree-Agen---Work_n_Home).

- In your command line interface, run `git clone <URL>` in the local directory of your choice, where `<URL>` is the url displayed under Code -> HTTPS of the GitHub repo landing page.

- Then, 'Open' the project in your Unity Hub. (Find the project folder in Windows Explorer.)

- Once the project has opened in the Unity editor, select the EatPrayDanceSleep scene in Assets/Scenes of the editor.

- The scene is now playable.

## Usage / API Reference
 
## Parameters
Found in Parameters.cs



## Environment design
I strongly recommend that you become familiar with the two separate agent architectures that combine to make this hybrid architecture before working with this architecture.

The agent should be designed on paper first. This is an iterative process that should be done before any coding. When implementing the agent with code, some inconsistencies might be noticed. These can then be fixed during programming.

1. Start by thinking what the agent is expected to do; what should its behavior be?
2. Then decide what features will make up a state.
3. Decide on the tasks (goals) that need to be pusued, their relative importance, their compatability, and how the agent will decide how far it is from fully achieving each goal.
4. Decide what actions the agent will be able to do, e.g., `GoWork`, `GoinFactory`, `Make_n_Rest` or `AssembleWidget` to achieve its various goals. And define which actions will be used in which phase of the agent's behavior.
5. Design the transition function.
6. Deciding on the observations and designing the reward machine (RM) can be done together: transitions in the RM depend on observations, and when a transition in the RM happens, a reward is output. Note, transitions in the RM are not transitions between (environment) states.
7. Design `GetObservation` and `GetRealObservation` so that the observation made for a given action performed in a given state causes the desired transition in the RM. The reason why actions are not used to trigger RM transitions is because different action-state pairs might produce the same observation, i.e., we want the agent to get the same reward (at a particular/active RM node) for the same observation, independent of action and state. For instance, in `state_13` the agent observes `axe_in_hand` after performing a 'Get_Axe' spell on an axe five meters away, and in `state_42` the agent observes `axe_in_hand` after picking up an axe.
8. Activate the ModelValidation game object in the Unity hierarchy to validate that the transition function is a true probability distribution. Tip: Just while running the model validator, choose state feature parameters that generate less than one or two thousand states; if there are too many states, the validator will take very long to finish. With the model validator deactivated, the normal number of states can be used (within computation limits). Play the scene to check the output in the console. There is no output from ModelValidation.cs, if and only if the models are good. Designing the transition function can be tricky, and it is perhaps a weakness of MDP-based architectures when this function has to be designed by hand.

## References


## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

## License
[MIT](https://choosealicense.com/licenses/mit/)


