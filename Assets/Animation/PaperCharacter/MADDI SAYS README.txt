# Animator Setup Overview

// - FIRST OF ALL, Add the model to the scene but before you do anything anything else, in Paper's Animator Component, press the + button to add the controller to the model, select 'Paper_Control' go to the PaperCharacter's Scripts Folder & add the scripts 'ParentToChild', 'DestroyOnEvent' 'TriggerDeathAnimation' & 'PlayVFXOnEvent' to the Paper Game Object - as in drag them to Paper's Inspector (Make sure it's under the Animator Component).

- SECOND, go to the PaperCharacter's Scripts Folder & add the scripts 'ParentToChild', 'DestroyOnEvent' 'TriggerDeathAnimation' & 'PlayVFXOnEvent' to the Paper Game Object - as in drag them to Paper's Inspector (Make sure it's under the Animator Component).

-THIRD, add the HitFlashEffect script Component to 'Paper_geo_combined' Object

-FOUR, Add the 'WhiteSmokeVFX' to Paper in Hierachy

The Animator is set up with the following logic:


## Default Animation

- Paper_Idle is the default animation that's played on entry. The character will stay in this idle state until a trigger is called.


## Trigger-Based Animations

The following animations are played bv triggers via parameters in the Animator:

1. **Hit Animation**:
   - Trigger Name: `PlayHit`
   - Description: Plays the `Paper_Hit` animation.
   - Includes VFX: White Flash material.

2. **Attack Animation**:
   - Trigger Name: `PlayAttack`
   - Description: Plays the `Paper_Attack` animation.

3. **Death Animation**:
   - Trigger Name: `PlayDeath`
   - Description: Plays the `Paper_Death` animation.
   - Includes VFX: White smoke and model disappearing effect.

`Paper_Hit` and `Paper_Attack` automatically return to Paper_Idle after completing their animations.

`Paper_Death` does not transition back; the character stays in the death state.


## Testing the Animator

To manually test the animations in Unity:

- Enter Play Mode.

- Open the Animator window and select the character GameObject.

- Select the triggers (PlayHit, PlayAttack, PlayDeath) from the Parameters tab to play the animations and to confirm they work correctly.

Let me know how it goes, Maddi 