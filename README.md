# Zombie Survival

This project was developed with the purpose of learning Unity and delivered for college assignment. Developed using Unity 2020.3.30f1.

## Gameplay

You, as a player are a first person controller (FPS) starting with an MP-5. Zombies are being spawned within a specific radius around the player (camera game object). Your job is to kill every zombie that is chasing you. Killing one zombie will grant **1 score point**.

**Zombie chasing:**
 - zombies are chasing the player (setting destination every frame)
 - zombies are assigned nav mesh agent component in order to follow the player 
 - if the zombies are reaching the player's collider, then it will play an attack animation and deal **5 damage**, the player's max. health is **100**

**Zombie spawner mechanism:**
 - there will be another zombie spawned each **10 seconds**
   - this interval will decrease based on the time you are staying alive, **down to 5 seconds**
 - the zombie will be spawned everywhere around the player within a radius of **10 yards** (can be changed by changing the gameobject's script field)
 - each zombie's Y position will be established usign RayCast to the ground

**Zombie drop**
- on death of each zombie, there is a percentage of dropping one of the following utilities:
  - **30% chance** to drop a **health pickup**, which will restore 10 health points to the player
  - **40% chnance** to drop a **collection of bullets**, which will refill the player's current weapon
- on death of each zombie, there is a percentage of dropping one of the following weapons:
  - **after 20 seconds of elapsed time played**:
    - 35% Assault Rifle
  - **after 40 seconds of elapsed time played**:
    - 30% Shotgun
  - **after 100 seconds of elapsed time played**:
    - 25% Minigun
  - **after 120 seconds of elapsed time played**:
    - 20% Rocket Launcher

*(!) Only one utility and only one weapon can be dropped on each death event.*

## Scoreboard

Within the main menu screen, the player can cange it's name by going to **Settings**.  The name is being used to save the player within the **Firebase Realtime Database**. The scoreboard can be seen by clicking the **Scoreboard** from the main menu.

## References

Free assets have been used from **Unity Assets Store**:
 - [Inverse Kinematics](https://assetstore.unity.com/packages/tools/animation/inverse-kinematics-1829)
 - [Flooded Grounds (Map)](https://assetstore.unity.com/packages/3d/environments/flooded-grounds-48529)
 - [Basic Motions (Anmations)](https://assetstore.unity.com/packages/3d/animations/basic-motions-free-pack-25900)
 - [Zombie Animation Pack](https://assetstore.unity.com/packages/3d/animations/zombie-animation-pack-free-150219)
 - [Modern Zombies (Models)](https://assetstore.unity.com/packages/3d/characters/humanoids/modern-zombie-free-58134)

## License
MIT License

Copyright (c) 2022 Sebastian Deme

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
