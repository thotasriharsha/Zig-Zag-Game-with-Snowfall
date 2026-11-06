SNOWFALL ADDED — ZIG-ZAG GAME

The project now includes Assets/Scripts/SnowfallEffect.cs.
It creates a white snow particle effect automatically when a Unity scene starts, so you do not need to add a GameObject manually.

HOW TO USE
1. Extract this ZIP file.
2. Open the Zig-Zag-Game-main folder in Unity Hub (use the Unity version recommended by the project, if shown).
3. Wait for Unity to import the assets.
4. Open Assets/Scenes/Game_Scene.unity and press Play.
5. Snow should fall automatically. If you do not see it, make sure the active scene has a camera tagged MainCamera.

To change the snowfall amount, open Assets/Scripts/SnowfallEffect.cs and edit:
  emission.rateOverTime = 170f;
Higher number = more snow; lower number = less snow.
