[EN](README.md)

# 👾 АРКАНОИД

## 🎲 ГЕЙМПЛЕЙ

<div align="center">
  
https://github.com/user-attachments/assets/aed7f745-424f-44c1-8c6f-9723d00f84fc
  
</div>

## ⚙️ ИГРОВЫЕ МЕХАННИКИ

### Шарик

<img align="left" src="https://github.com/user-attachments/assets/c91af8f4-7924-46f5-bdb3-5853429efafb" width="5%" />

[__ШАРИК__](Assets/Scripts/Ball.cs)  
вы можете установить его скорость в [BallManager](Assets/Scripts/BallManager.cs)   
Все объекты "ball" хранятся в виде List

### Платформа

<img align="left" src="https://github.com/user-attachments/assets/424e93c9-432e-41e1-b80f-5a817e029862" width="15%" />

[__ПЛАТФОРМА__](Assets/Scripts/Platform.cs)  
Мяч отскакивает от платформы в том направлении, в котором он упал на платформу


### Кирпичи

<img align="left" src="https://github.com/user-attachments/assets/b2e8a913-0713-442e-8f88-42a6b849377b" width="5%" />
<img align="left" src="https://github.com/user-attachments/assets/d19285d8-de0c-4e3e-9dca-504e01880ea5" width="5%" />
<img align="left" src="https://github.com/user-attachments/assets/9a19066f-317f-45ed-a5fc-a6852f3bdb1c" width="5%" /><br /><br /><br />

__1, 2, 3 удара для уничтожения, соответственно, фотографиям__  
* Вы также можете задать цвет кирпичей одного типа в [BrickManager](Assets/Scripts/BrickManager.cs) (via the scene).

* Удары мяча по кирпичам прописаны в [Brick](Assets/Scripts/Brick.cs) (AppplyCollisionLogic).

### Баффы/Дебаффы

<img align="left" src="https://github.com/user-attachments/assets/ef17aec0-d90e-4981-87de-308a710d7988" width="5%" />

[__МУЛЬТИШАРИК__](Assets/Scripts/Bonuses/MultiBall.cs)  
Текущее количество шаров становится в 3 раза больше

<img align="left" src="https://github.com/user-attachments/assets/656e3b92-8da5-43b5-bc86-a398ea5dfdc9" width="5%" />

[__PLUS__](Assets/Scripts/Bonuses/Plus.cs)  
Платформа становится в 2 раза шире, чем первоначально

<img align="left" src="https://github.com/user-attachments/assets/664bc16a-b2e6-42fa-8717-ccbef1d77d20" width="5%" />

[__MINUS__](Assets/Scripts/Bonuses/Plus.cs)  
Платформа становится в 2 раза уже, чем была изначально

Скрипт для подбора бонусов - [Click](Assets/Scripts/Bonuses/Collect.cs) 

### Генерация уровней

<img align="left" src="https://github.com/user-attachments/assets/88571866-ff70-4af9-b04b-8d17a877c96b" width="25%" />

__Все происходит в скрипте [BrickManager](Assets/Scripts/BrickManager.cs)  
1 Вы устанавливаете значения maxRows и maxCols.  
2 Затем в файле [levels](Assets/Resources/levels.txt) Введите матрицу уровней, где цифры указывают на тип кирпича.  
3 Далее, после запуска, кирпичи начинают появляться с позиции initialBricksSpawnPositionX и initialBricksSpawnPositionY.  
4 Расстояние между строками задается в переменной shiftAmountX, между столбцами - в постоянной переменной shiftAmountY__  

Сам текстовый файл считывается в приватном LoadLevelsData List<>  

### Если вы хотите протестировать игру, скачайте папку [Build](Build/) к себе и запустите файл [Arkanoid.exe](Build/Arkanoid.exe)







