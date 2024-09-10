[RU](ruREADME.md)

# 👾 ARKANOID

## 🎲 GAMEPLAY

<div align="center">
  
https://github.com/user-attachments/assets/aed7f745-424f-44c1-8c6f-9723d00f84fc
  
</div>

## ⚙️ GAME MECHANICS

### Ball

<img align="left" src="https://github.com/user-attachments/assets/c91af8f4-7924-46f5-bdb3-5853429efafb" width="5%" />

[__BALL__](Assets/Scripts/Ball.cs)  
you can set its speed in [BallManager](Assets/Scripts/BallManager.cs)   
All the "ball" objects are stored in a List

### Platform

<img align="left" src="https://github.com/user-attachments/assets/424e93c9-432e-41e1-b80f-5a817e029862" width="15%" />

[__PLATFORM__](Assets/Scripts/Platform.cs)  
The ball bounces off the platform in the direction in which it fell onto the platform


### Bricks

<img align="left" src="https://github.com/user-attachments/assets/b2e8a913-0713-442e-8f88-42a6b849377b" width="5%" />
<img align="left" src="https://github.com/user-attachments/assets/d19285d8-de0c-4e3e-9dca-504e01880ea5" width="5%" />
<img align="left" src="https://github.com/user-attachments/assets/9a19066f-317f-45ed-a5fc-a6852f3bdb1c" width="5%" /><br /><br /><br />

__1, 2, 3 strikes to destroy, respectively, the photo__  
* You can also set the color of bricks of the same type in [BrickManager](Assets/Scripts/BrickManager.cs) (via the scene).

* The blows of the ball on the bricks are written in [Brick](Assets/Scripts/Brick.cs) (AppplyCollisionLogic).

### Buffs/Debuffs

<img align="left" src="https://github.com/user-attachments/assets/ef17aec0-d90e-4981-87de-308a710d7988" width="5%" />

[__MULTIBALL__](Assets/Scripts/Bonuses/MultiBall.cs)  
The current number of balls becomes 3 times more

<img align="left" src="https://github.com/user-attachments/assets/656e3b92-8da5-43b5-bc86-a398ea5dfdc9" width="5%" />

[__PLUS__](Assets/Scripts/Bonuses/Plus.cs)  
The platform becomes 2 times wider than originally

<img align="left" src="https://github.com/user-attachments/assets/664bc16a-b2e6-42fa-8717-ccbef1d77d20" width="5%" />

[__MINUS__](Assets/Scripts/Bonuses/Plus.cs)  
The platform becomes 2 times narrower than it was originally

The script for the selection of bonuses - [Click](Assets/Scripts/Bonuses/Collect.cs) 

### Level generation

<img align="left" src="https://github.com/user-attachments/assets/88571866-ff70-4af9-b04b-8d17a877c96b" width="25%" />

__Everything happens in the script [BrickManager](Assets/Scripts/BrickManager.cs)  
1 You set maxRows and maxCols.   
2 Then in the file [levels](Assets/Resources/levels.txt) Enter the level matrix, where the numbers indicate the type of brick.  
3 Next, after the launch, the bricks begin to spawn from the position of initialBricksSpawnPositionX and initialBricksSpawnPositionY.  
4 The distance between rows is set in the shiftAmountX variable, between columns in the permanent shiftAmountY__  

The text file itself is read in a private LoadLevelsData List<>  

### If you want to test the game, download the [Build](Build/) folder to yourself and run the file [Arkanoid.exe](Build/Arkanoid.exe)

<div align="center"> <br />
  
<img src="https://github.com/user-attachments/assets/ad593b94-de65-465a-b574-2874393ea3ca" width="7%" />

</div>









