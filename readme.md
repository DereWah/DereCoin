# DereCoin
DereCoin is an Exiled plugin for the game SCP:Secret Laboratory.
Whenever a player flips a coin, they will be awarded with a random Item / Effect.

It is possible to configure all the items, effects and changes from the configuration file, according to the structure below:

		coin_items:
		  - item: Adrenaline
		    chance: 30
		    message: 'You got adrenaline from gambling!'
      		  - item: GunA7
		    chance: 30
		    message: '{player}, you got a really weird gun from this coin...'
		  coin_effects:
		  - effect:
		    # The effect type
		      type: MovementBoost
		      # The effect duration
		      duration: 10
		      # The effect intensity
		      intensity: 200
		      # If the effect is already active, setting to true will add this duration onto the effect.
		      add_duration_if_active: false
		      # Indicates whether the effect should be enabled or not
		      is_enabled: true
		    chance: 30
		    message: 'speed'


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







