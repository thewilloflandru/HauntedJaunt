# HauntedJaunt -- CS 410 Assignment 2
## Team Members (in alphabetical order)
* Ethan Cha
* Spencer Davis
* Peter Warila
* Daniel Willard

## Roles / Contributions
### Peter Warila
Implemented Setup, Player Character, Environment, and original repo.
### Spencer Davis
Implemented Enemies and Game Over functionality.
### Ethan Cha
Implemented additional functionalities
### Daniel Willard
Implemented The Camera, Ending the Game, Audio
## Additional Functionality
### Dot Product
Ghosts will know if the player is close by behind them. If they are, they will stop, wait, then suddenly turn around. The detection is powered by the dot product calculations, where if the dot product is less than -0.9 and are close to them (a small area behind them), they will interrupt their current AI path to stop and turn. 
### Linear Interpolation
Gargoyles automatically rotate every 10 seconds using Slerp (spherical linear interpolation), which turns them into rotating sentries that search for the player depending on the direction they are currently facing at that point in time. Configurable in Gargoyle prefab. The gargoyles will rotate by default every 10 seconds defined by Wait Time, which is affected by Rotation Speed from 0 to 1, 0.5 by default, and how much it will rotate is defined by Rotate Angle, 120 by default. 

The ghosts also use Slerp to turn around smoothly if the player is detected behind them.
### Particle Effects
Basic particle effects were added to the lights to look like flames coming off of it. They will sometimes emit particles at random.
