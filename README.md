# Playable ad example

This is a playable ad example for a simple knife game.

There is two different folder present;

- Codebase folder has the project of the game.
- WebGL Build folder contains the last working version of the WebGL build of the game.

## Installation

This code was built and tested in Unity version `2019.4.16f1`


## Options

 You can change target rotation in many ways.

 `Forces`:  You can access this variable in the `Target` gameobject which has `TargetRotationScript` attached to it.

 - `timeToApply`: At which point in time of the game you want this force to apply.
 - `forceMagnitude`: Magnitude of the force.
 - `forceDirection`: Direction of the force (clockwise or counter-clockwise).
 - `Loop`: This controls if you want to apply forces in a loop.

`totalNumberOfKnives`: You can access this variable in the `GameManager` gameobject which has `GameManagerScript` attached to it.
- With this, you can change the total number of knives that should be thrown to finish the level.
