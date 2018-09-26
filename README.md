Unity app that let you:
1. Generate random map of given size and amount of obstacles
2. Choose algorithm for pathfinding - A* or BFS with early exit
3. Find the way in generated labirynth
4. Save/Load your maps

I tried to build this app basing on ScriptableObjects and Button's event calls to avoid building architecture, and focus on modular aspect.
It works nicely so far :)
Some refactoring is still strongly needed tho. 
And I think that some strong state machine as core for app is still better.
