Midspace's SE Mod Core V4.2
======================
Space Engineers modification framework to support code based Command Chat style mods and similar mods.
----------------------

Space Engineers is a sandbox game about engineering, construction and maintenance 
of space works. Players build space ships and space stations of various sizes and 
utilization (civil and military), pilot ships and perform asteroid mining.

More details about the "Space Engineeers" game is available here:
[www.spaceengineersgame.com](http://www.spaceengineersgame.com/)


Note, this is not a mod. It is a framework. Several sample commands are included in the project 
as working examples. It should be in a working condition, sufficient run as a mod.


Visit the Keen Software House modding forums for more detail on modding Space Engineers:
http://forums.keenswh.com/?forum=325599


Working with the code.
---------------------
If you have downloaded this elsewhere, the official github repository for this code is available here:
https://github.com/midspace/Space-Engineers-Mod-Core

A copy of the game is required to work with or develop the script mod.

Working on the github repository.
The best way to work on this mod and test in Space Engineers is to create a Symbolic 
link from your Git repository directory to the Space Engineers mods folder.
Run a command prompt as Administrator, and then run the following line.

```
mklink /J "C:\Users\%USERNAME%\AppData\Roaming\SpaceEngineers\Mods\midspace sample mod" "C:\Users\%USERNAME%\Documents\GitHub\Space-Engineers-Mod-Core\midspace mod core"
```

The Symbolic link directory can be simply deleted through Windows Explorer like a normal directory.

The Space Engineers references can be established with the following Symbolic link.
```
mklink /J "C:\Program Files\Reference Assemblies\SpaceEngineers" "C:\Program Files (x86)\Steam\SteamApps\common\SpaceEngineers\Bin64"
```
