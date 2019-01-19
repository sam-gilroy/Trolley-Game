Put these files...

"82-C# Singleton-NewSingleton.cs.txt"
"81-C# Script-NewBehaviourScript.cs" 

in this directory... (yes, replace)

"...\Unity\Unity\Editor\Data\Resources\ScriptTemplates"

before launching.

This will add a namespace to all new scripts, and allow you to construct
singletons by rightclicking in the project folders, and clicking "C# Singleton".



Basic Overview:
---------------------------------------------------------------------------------------------------
Audio:
	AudioManager -- singleton that uses AudioObjects
	AudioObject -- a cleaner object to handle clips with

Health
	HealthComponent -- uh?...

Hitbox
	Hitbox -- hitbox Class (2D)
	HitboxData -- ScriptableObject for hitboxes
	HitboxParams -- The parameters needed when spawning a hitbox
	HitboxFactory -- a singleton that Spawns hitboxes

ObjectPool
	ObjectPool<T> -- Inherit from this with a Factory class with the type you want to pool.
	AObjectPoolable -- Inherit from this with poolable objects

Particles
	ParticleManager -- Particle Managing Singleton w/Factory Functions / pooling
	ParticleBehaviour -- attach this to prefabbed particles
	ParticleObject -- pass this to particlemanager to spaw na particle -- uses ParticleBehaviour

PlayerBaseScripts
	PlayerManager -- Singleton that has a reference to the player (niche.)
	UPlayer -- Inherit from this, and you have a player! (Slipped into Unreal naming convention for a sceond...)

PlayerBaseScripts/2D
	CameraController2D -- Slippery Lerping Camera 
	PlatformingController -- Basic 2D movement
	PlatformingPlayer -- UPlayer with a PlatformingController

Presentation
	Presenter -- Inherit from this if you want to present a series of information
	Dialogue -- A Presenter that scrolls text and makes noise
	Cutscene -- A cutscene running script -- Put as many function calls in this things events as you want!

Projectile
	Protectile -- Protectile Class (2D)
	ProtectileData -- ScriptableObject for Protectiles
	ProtectileParams -- The parameters needed when spawning a Protectile
	ProtectileFactory -- a singleton that Spawns Protectiles
	(All these classes have a 3D version)

ReorderableList -- Arrays can now be reordered!

Trigger 
	TriggerVolume2D -- a cube you can put in your 2D scene to be triggered on collision with soemthing
	TriggerVolume3D -- a cube you can put in your 3D scene to be triggered on collision with soemthing

Singleton
	Singleton<T> -- Inheritable Singleton
	ISingleton -- interface that derived singletons must implement :( this was dumb if u see a better way lemme know