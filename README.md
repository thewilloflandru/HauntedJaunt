# HauntedJaunt -- CS 410 Assignment 2
## Team Members (in alphabetical order)
* Ethan Cha
* Spencer Davis
* Peter Warila
* Daniel Willard

## Roles / Contributions
### Peter Warila
Implemented Setup, Player Character, Environment, and original repo.
### Ethan Cha
Implemented additional functionalities (Linear Interpolation and Particle Effects)
## Additional Functionality
### Dot Product
...
### Linear Interpolation
Gargoyles automatically rotate every 10 seconds using Slerp (spherical linear interpolation), which turns them into rotating sentries that search for the player depending on the direction they are currently facing at that point in time. Configurable in Gargoyle prefab. The gargoyles will rotate by default every 10 seconds defined by Wait Time, which is affected by Rotation Speed from 0 to 1, 0.5 by default, and how much it will rotate is defined by Rotate Angle, 120 by default. 
### Particle Effects
Basic particle effects were added to the lights to look like flames coming off of it. They will sometimes emit particles at random.
