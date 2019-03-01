Made by Luke Mayo.

DebugCaller instantiates itself into the scene automagically! // BUT ONLY DURING EDITOR RUNTIME

Press back-tick (`) to open the prompt.


The commands must be entered as follows:

>*GameObject* *MonoBehaviour* *Function* *Parameter1* *Parameter2* ...


AN EXAMPLE:

>Player PlayerController SetHealth 10




Changes:

Feb 20 2019 --------------------------------------------------------------

- Now has UI
- Now supports several commands
	-	Tab / Shift+Tab to cycle through autocomplete options
	-	Press Up / Down to cycle through previous (successful) commands
- Prefab is now tagged "EditorOnly"

==========================================================================


The future:
- Functions must support
	- Strings
	- Enums
	- Arrays of intrinsic types
	- Templates
	- Classes / Structs (oof)
- Parented GameObjects must be considered.
- SetCommandLine Color? :))))
- Call static functions like Debug.Log or SceneManagement
