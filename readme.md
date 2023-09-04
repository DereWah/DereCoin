# DereCoin
DereCoin is an Exiled plugin for the game SCP:Secret Laboratory.
Whenever a player flips a coin, they will be awarded with a random Item / Effect.

It is possible to configure all the items, effects and changes from the configuration file, according to the structure below:

      config_items: 
		  - RewardType: item
		    Reward: Adrenaline
		    Message: You got adrenaline from gambling!
		    Chance: 30
		  - RewardType: effect
		    Reward: Blinded
		    Duration: 5
		    Message: You flipped the coin into your eyes.
		    Chance: 100

If you choose to award an "effect", you should also specify a Duration in the config. You can find a list of all the available Effects and Items as below:

## ItemTypes
-   KeycardJanitor
-   KeycardScientist
-   KeycardResearchCoordinator
-   KeycardZoneManager
-   KeycardGuard
-   KeycardMTFPrivate
-   KeycardContainmentEngineer
-   KeycardMTFOperative
-   KeycardMTFCaptain
-   KeycardFacilityManager
-   KeycardChaosInsurgency
-   KeycardO5
-   Radio
-   GunCOM15
-   Medkit
-   Flashlight
-   MicroHID
-   SCP500
-   SCP207
-   Ammo12gauge
-   GunE11SR
-   GunCrossvec
-   Ammo556x45
-   GunFSP9
-   GunLogicer
-   GrenadeHE
-   GrenadeFlash
-   Ammo44cal
-   Ammo762x39
-   Ammo9x19
-   GunCOM18
-   SCP018
-   SCP268
-   Adrenaline
-   Painkillers
-   Coin
-   ArmorLight
-   ArmorCombat
-   ArmorHeavy
-   GunRevolver
-   GunAK
-   GunShotgun
-   SCP330
-   SCP2176
-   SCP244a
-   SCP244b
-   SCP1853
-   ParticleDisruptor
-   GunCom45
-   SCP1576
-   Jailbird
-   AntiSCP207
-   GunFRMG0
-   GunA7

## Effect Types

-   AmnesiaItems
-   AmnesiaVision
-   Asphyxiated
-   Bleeding
-   Blinded
-   Burned
-   Concussed
-   Corroding
-   Deafened
-   Decontaminating
-   Disabled
-   Ensnared
-   Exhausted
-   Flashed
-   Hemorrhage
-   Invigorated
-   BodyshotReduction
-   Poisoned
-   Scp207
-   Invisible
-   SinkHole
-   DamageReduction
-   MovementBoost
-   RainbowTaste
-   SeveredHands
-   Stained
-   Vitality
-   Hypothermia
-   Scp1853
-   CardiacArrest
-   InsufficientLighting
-   SoundtrackMute
-   SpawnProtected
-   Traumatized
-   AntiScp207
-   Scanned
-   PocketCorroding







