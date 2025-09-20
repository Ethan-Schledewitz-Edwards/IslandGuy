# Tutorial activity project

---

**Name:** Ethan Schledewitz-Edwards  
**Student ID:** 100908840

---

## Short Description

I want this project to be a small survival game. The player must keep their nutrition up by eating food that spawns around the island. If the player runs out of nutrition, they will die.

---

## Singleton Usage

### Which system within your project uses a Singleton, and why did you choose this system?
Both my **HUDManager** and **FoodSpawner** systems use singletons. I chose to implement singletons for these systems because only one instance of each needs to exist at a given time, and multiple other systems will reference them.

### Do you think this design pattern is beneficial for this purpose? Explain why or why not.
- **HUDManager:** Handles all HUD functionality. Other classes can call functions on it. Only one HUD is needed, so a singleton is appropriate.
- **FoodSpawner:** Only one instance is needed, and food instances must reference the manager when consumed. A singleton ensures proper global access.

### Diagram:
<img width="1396" height="720" alt="UML" src="https://github.com/user-attachments/assets/5556c00c-3aad-4aad-b4f6-51464d730229" />


---

## External Assets

- TextMesh Pro
- Unity New Input System
