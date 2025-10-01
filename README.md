# PROG1: World With Interactive Props 
## Goal

In this assignment you will be using Unity to create a basic interactive virtual environment. The user can navigate around the environment and interact with various props.

While you are given complete freedom to create any kind of environment and include any kinds of props you want, keep in mind that some kind of overall story or setting that ties it all together makes the experience more compelling.

## Description
- Create a compelling environment that gives you some sense of where you are (in a city, in a building, in the wilderness, in space). You can use any assets you find, as long as you credit them.
    Create a general kind of prop you can operate on / activate, using the Unity Prefab feature.
    Create a few different instances of this prop in the scene and make sure that at least one of those uses a model that is made completely from scratch (using a 3D modeling tool like Blender and image editing program like GIMP for textures).
- When a user navigates through your environment, any prop that you come into close proximity of (use collider components), should become selected. A selected prop needs to stand out in some manner, for example by switching to a particularly bright texture or by bobbing up and down (you can use your imagination here). A 'description' of the selected prop should appear somewhere on the screen.
- A selected prop should become deselected when the user moves away.
- When the user hits the E key (a game convention for "Use") on the keyboard (if relying on Keyboard/Mouse control) while a prop is selected, you should make something happen depending on what the selected prop is. It is enough just to show a 'usage effect' text on the GUI, but feel free to improvise (e.g. trigger a behavior or change a property). TIP: The best way to approach this is to define and bind a new "Use" action in an "Input Action Asset" that is linked to the "Player Input" component of your "PlayerCapsule". This is described in a special "[TIP] Adding 'Use' Input Action Links to an external site." video.

## Hand-In
Single ZIP file that contains (1) a built Unity application for Windows or WebGL AND a (2) text file that contains credits for the assets you used, e.g. what packages they come from and which ones are your own.

