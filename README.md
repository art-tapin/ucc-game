# Team Software Project. Final Report [Team 7]

---

Anna Kramar

Artem Tuipin

Colin Morgan

Daniil Klieshchov

Ivan O’Herlihy

Rheena Blas

---

![https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/image2.png](https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/image2.png)

# Table of Contents

[Credits](#Credits)

[Introduction](#Introduction)

[Game Mechanics](#GameMechanics)

2.1 [2D Platformer](#2DPlatformer)

2.2 [Animator](#Animator)

2.3 [Rain System](#RainSystem)

2.4 [Dialogue System](#DialogueSystem)

2.5 [Lighting System](#LightingSystem)

&ensp; 2.5.1 [Spotlight focusing](#SpotlightFocusing)

&ensp; 2.5.2 [Light blinking](#LightBlinking)

2.6 [Main Character Asset](#MainCharacterAsset)

2.7 [Parallax Effect](#ParallaxEffect)

2.8 [Follow Camera](#FollowCamera)

2.9 [Day/Night transition](#Day/NightTransition)

&ensp; 2.9.1 [Moving Moon and Sun](#MovingMoonandSun)

2.10 [Cut Scene](#CutScene)

2.11 [Game Object Interactions](#GameObjectInteractions)

2.12 [Main Menu](#MainMenu)

&ensp; 2.12.1 [Play](#Play)

&ensp; 2.12.2 [Scenes](#Scenes)

&ensp; 2.12.3 [Options](#Options)

2.13 [Character Selection](#CharacterSelection)

2.14 [PauseMenu](#PauseMenu)

2.15 [QuizCanvas](#QuizCanvas)

2.16 [Puzzle](#Puzzle)

2.17 [Sunset](#Sunset)

2.18 [Audio](#Audio)

2.19 [Triggers](#Triggers)

[Development](#Development)

3.1 [Agile/Kanban](#Agile/Kanban)

&ensp; 3.1.1 [Task Delegation](#TaskDelegation)

&ensp; 3.1.2 [Testing/Reviewing](#Testing/Reviewing)

&ensp; 3.1.3 [GitKraken](#GitKraken)

3.2 [Art Design and Development](#ArtDesignandDevelopment)

&ensp; 3.2.1 [Storyboard](#Storyboard)

&ensp; 3.2.2 [Asset Research](#AssetResearch)

&ensp; &ensp; 3.2.2.1 [Pixel Art Architecture Research](#PixelArtArchitectureResearch)

&ensp; &ensp; 3.2.2.2 [Background Art Research](#BackgroundArtResearch)

&ensp; &ensp; 3.2.3 [Sprites](#Sprites)

&ensp; 3.2.4 [Animations](#Animations)

&ensp; 3.2.5 [Tilesets](#Tilesets)

3.3 [Creative Development](#CreativeDevelopment)

&ensp; 3.3.1 [Storyline/Narrative](#Storyline/Narrative)

&ensp; &ensp; 3.3.1.1 [Opening Scene](#OpeningScene)

&ensp; &ensp; 3.3.1.2 [TV Game Show Scene](#TVGameShowScene)

&ensp; &ensp; 3.3.1.3 [WacDonalds Job Interview Scene](#WacDonaldsJobInterviewScene)

&ensp; &ensp; 3.3.1.4 [WacDonalds Mini-Game Scene](#WacDonaldsMini-GameScene)

&ensp; &ensp; 3.3.1.5 [Laptop Quest Scene](#LaptopQuestScene)

[Index](#Index)

4.1 [Terminology](#Terminology)


## Credits <a name="Credits"></a>

| Anna Kramar | Cinematics |
| --- | --- |
| Artem Tiupin | Artist |
| Colin Morgan | Game Design |
| Daniil Klieshchov | Lighting |
| Ivan O’Herlihy | Coder |
| Rheena Blas | Coder |
| ChatGPT | Terminology |

# Introduction <a name="Introduction"></a>

With regard to instructions in the design brief, the team has chosen to develop a 2D side-scroller game with a heavy emphasis on narrative and cinematic features. Our vision is to create a fun, interactive game that deals with themes around life as a student entering university for the first time, following the protagonist on his first big adventure with homage to retro games made by Nintendo and Sega such as Mario Bros and Sonic The Hedgehog.

The images below (Fig. 1.1 and 1.2) provide a snapshot from our concept stage to the current work-in-progress.

![https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/image9.png](https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/image9.png)

Fig. 1.1 Concept Art

![https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/image38.png](https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/image38.png)

Fig. 1.2 Current Development Art

# Game Mechanics <a name="GameMechanics"></a>

## 2.1 2D Platformer <a name="2DPlatformer"></a>

Figure 2.1.1 shows a screenshot of a current work-in-progress of the prologue scene’s bedroom. The art assets displayed are a collection of GameObjects and Tilemaps connected up to the necessary tilemap and composite colliders, rigidbody physics and platform effectors to allow a sprite to move around the map and interact with objects such as the door and light switches.

![https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/image26.png](https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/image26.png)

Fig. 2.1.1 2D Prologue Bedroom Scene WIP

## 2.2 Animator <a name="Animator"></a>

The animator component is used to assign animations to a sprite using references to the animator controller. Figure 2.2.1 shows a set of animation transitions for the player sprite. Each animation is activated by using player input on the PlayerMovement script (C#) via an enum reference called ‘State’ of type int.

![https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/image29.jpg](https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/image29.jpg)

Fig. 2.2.1 Animator Finite State Machine

## 2.3 Rain System <a name="RainSystem"></a>

Figure 2.3.1 is a screenshot of a prototype rain animation developed using Unity’s particle system. The particle system allows the developer to simulate animation effects like smoke, clouds, and moving liquids. The Unity particle system simulates and renders many small images or Meshes, called particles, to produce a visual effect. The system simulates every particle collectively to create the impression of the complete effect.

![https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/image4.png](https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/image4.png)

Fig. 2.3.1 Particle Effects System

## 2.4 Dialogue System <a name="DialogueSystem"></a>

A dialogue will play a central role in our narrative. Figure 2.4.1 shows a demonstration of a simple dialogue event that is being developed. This is an event system controlled via the DialogueManager Class which avoids the use of singleton classes for dialogue events. It works by creating a Gizmo GameObject and adding it to the scene. Then by attaching a Script Component called TextTrigger and a box collider to this gizmo, it turns into an interactive object that the player sprite can activate by walking over it. The TextTrigger is a class that allows for the editing of dialogue within the IDE inspector. In the inspector, we have created an input field for the text for the dialogue and a queue data structure for storing a list of sentences.

![https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/image16.png](https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/image16.png)

Fig. 2.4.1 Dialogue System

## 2.5 Lighting System <a name="LightingSystem"></a>

We consider lighting to be an important feature of the game’s atmosphere and narrative. Figure 2.5.1 shows a sprite rendered using a spotlight placed above it, casting a cinematic light onto the 2D sprite. The light was implemented by using unity’s shaders and point light components in the game objects.

![https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/image28.png](https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/image28.png)

Fig. 2.5.1 Rendered lighting coming from the monitor

![https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/image17.png](https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/image17.png)

Fig. 2.5.2 Rendered lighting coming from the ceiling lights

### 2.5.1 Spotlight Focusing <a name="SpotlightFocusing"></a>

One of the exciting features that have been added to the "Who Wants to be a Millionaire" scene is the "spotlight focusing" feature. This feature enables the rotation of light objects, allowing them to focus on specific objects in the scene. The spotlight-focusing feature has significantly improved the quality of the scene, making it more engaging and immersive for the audience.

Implementing the spotlight-focusing feature required the rewriting of some of the Unity rotation methods to enable the proper functioning of the feature. However, the efforts put into rewriting these methods were worth it, as the spotlight-focusing feature provides a realistic and visually appealing effect to the scene. The feature helps to highlight the critical objects in the scene and directs the audience's attention towards them, enhancing the storytelling aspect of the scene.

![Focusing.png](https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/Focusing.png)

Fig. 2.5.1.1 Spotlights focused on the main character and his father

### 2.5.2 Light Blinking <a name="LightBlinking"></a>

The light blinking script creates the effect of the lamp flickering on and off. This feature has significantly improved the quality of the scene, emphasizing the fact that the location is not ideal, especially for work, but the main character has to work there to earn money.

To achieve the desired effect, the light blinking script was implemented using a simple random packet in Unity and C# coroutines. The script randomly toggles the state of the light, turning it on and off at different intervals, simulating the effect of a flickering lamp. This feature adds an extra layer of realism to the scene, contributing to the immersive experience for the audience.

**You can observe this feature only during the gameplay.**

## 2.6 Main Character Asset <a name="MainCharacterAsset"></a>

We have created two-pixel art characters to represent the gender options - a boy and a girl using the open-source image editing software, GIMP. Both characters have unique design features and outfits that are consistent with the overall aesthetic of the game. This will give players the ability to personalise their gaming experience by choosing a gender of a character that they can truly identify with. The user will be able to choose between a boy or a girl character.

![https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/image23.png](https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/image23.png)

Fig. 2.6.1 Girl Character

## 2.7 Parallax Effect <a name="ParallaxEffect"></a>

We have implemented a parallax effect with three layers to enhance the visual depth and realism of the game world. The parallax effect works by creating an illusion of depth by moving background elements at a slower pace than the foreground elements, giving the player a sense of movement and immersion. Our implementation features three separate layers, each with its own distinct movement, adding to the overall visual impact of the game world.

![https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/image13.png](https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/image13.png)

Fig. 2.7.1 Parallax Effect

## 2.8 Follow Camera <a name="FollowCamera"></a>

The camera follows the player’s movement in a smooth and dynamic manner. When the player moves forward, the camera moves to the right, allowing the player to see more of what lies ahead. When the player moves backwards, the camera moves to the left. Additionally, when the player jumps or moves upwards, the camera moves up to follow him. This camera system enhances the player’s experience and allows them to focus on the game elements without any distractions. The camera’s movement is well-coordinated with the player’s actions, creating a seamless and immersive gaming experience.

![https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/image35.png](https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/image35.png)

Fig. 2.8.1 Follow Camera

## 2.9 Day/Night Transition <a name="Day/NightTransition"></a>

Day/Night transition feature was implemented to improve the game narrative, showing how time flies during the college years.

The main logic of the mechanic in the script is where we keep track of time in the game. So, in the time between 21-22 we have dusk, so we decrease the intensity of global light and during dawn (in our case 6-7 o’clock) we increase the light respectively.

![https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/image33.png](https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/image33.png)

Fig. 2.9.1 Game scene at night

![https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/image6.png](https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/image6.png)

Fig. 2.9.2 Game scene during the day

### 2.9.1 Moving Moon and Sun <a name="MovingMoonandSun"></a>

Dynamic sun and moon system changes sun and moon positions and appearances according to the time of day. This feature has been incorporated into the day/night transition script and is responsible for animating the movements of the sun and moon, as well as their appearance and disappearance.

This system has significantly improved the overall quality of the first cutscene, providing a more immersive and engaging experience for the viewers. The dynamic movements of the sun and moon create a more realistic and believable environment, enhancing the visual appeal of the scene. The feature also contributes to the storytelling aspect of the project by helping to establish a sense of time and place, which helps to contextualize the events of the story. In summary, the implementation of the moving sun and moon feature has been a significant improvement to the project, both in terms of its technical and artistic aspects.

![Untitled](https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/Untitled.png)

Fig. 2.9.1.1 Different positions of sun/moon

## 2.10 Cut Scene <a name="CutScene"></a>

We have created a dynamic cut scene that will start in the first scene in the game. This cut scene is on “awake mode”, which means that it will be the first thing that player sees when he starts the game. In the beginning, the scene shows a TV screen with the main menu. The camera then zooms out to reveal the entire scene, where the TV screen is on the player’s table. It establishes the game’s atmosphere and setting, while also providing an opening sequence that captures player’s attention from the very beginning.

![https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/image37.png](https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/image37.png)

Fig. 2.10.1 Introduction cutscene

## 2.11 Game Object Interactions <a name="GameObjectInteractions"></a>

By implementing an abstract class called Interactable, we were able to create a generic system that provides interactivity to any Game Object. It works by using two class methods OnTriggerEnter2D and OnTriggerExit2D. When the player collides with the Game Object it will trigger the OnTriggerEnter2D, and when it exits the collision it will trigger the OntriggerExit2D method. The system opened many possibilities and was used in in-scene travel, light switches, object interactions and specific puzzles.

## 2.12 Main Menu <a name="MainMenu"></a>

Inspired by the commodore64, the Main Menu scene displays buttons for *Play*, *Scenes*, *Options* and *Quit*. The button in which the mouse is hovering over will be highlighted for the user’s and developer’s (for debugging) convenience.

### 2.12.1 Play <a name="Play"></a>

Once the player presses the *Play* button, it automatically goes to the order laid out in the build settings, which is the Character Selection (2.13).

### 2.12.2 Scenes <a name="Scenes"></a>

Pressing the *Scenes* button allows the selection of the scene. It is also helpful for debugging to skip the earlier scenes. This menu is linked to the Scene Menu script in which the buttons where the scenes are listed are connected to.

### 2.12.3 Options <a name="Options"></a>

*Options* allows the user to change the volume, graphics level and exit out full screen. The volume is attached to the built-in audio mixer in Unity that reads in the value from the slider. The graphics is connected to a dropdown menu that is in sync with the graphics Unity offers to the player. The full screen is a toggle using the checkmark.

The *Back* button in both the Options and Scene Selection returns to the initial menu shown in Figure 2.13 (Left). This is triggered by an onClick() event in which the grouped menu screens are set in the Boolean whether it is set active or not.

![https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/image18.png](https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/image18.png)

![https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/image24.png](https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/image24.png)

![https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/image39.png](https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/image39.png)

Fig. 2.12.1 Initial Main Menu display (first) Scene Selection interface (second). Options Interface (third).

## 2.13 Character Selection <a name="CharacterSelection"></a>

After the selection of ****Play**** button on the Main Menu, the user is able to choose a character, ***Boy*** or ****Girl****. For the convenience of the developers, the selection is restricted to two. The selection of either character shows the correlated sprite allocated to each. It does not cease the flow of the game but enables a better user experience.

## 2.14 PauseMenu <a name="PauseMenu"></a>

The pause menu is in a similar style to the main menu. This is triggered by the escape button specified on the pause menu script. The music, animations, character are stopped and are resumed upon pressing the resume or simply by pressing the escape button again.

![Untitled](https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/Untitled%201.png)

Fig. 2.14.1 PauseMenu UI.

## 2.15 QuizCanvas <a name="QuizCanvas"></a>

QuizCanvas contains the placeholders of the questions and answers in which the developers are able to add to from the quizManager. The quizManager is a gameObject which has a script attached to it that controls what text will replace the *New Text* for the questions and answers on the *Button,* specified on the inspector (Fig 2.15.2). This was made accessible from a *Questions* and *AnswerData* classes*.* It also allows the confirmation of the selected answer, enabling/disabling the buttons when a prompt shows, and even the highlighting of the correct answer.

![https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/image14.png](https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/image14.png)

![https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/image1.png](https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/image1.png)

Fig. 2.15.1 QuizCanvas User Interface layout evolution. Top the first version. The bottom current version that imitates the *Who Wants To Be A Millionaire* layout.

In keeping with the humour of the satyric game, we have also designed the quiz to change the correct answer via quizManager through a boolean, *keepCorrectAnswer* from *Questions* to prevent the user from picking the correct answer. It is toggleable, however, to allow the developers to plan when it will be implemented.

![Untitled](https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/Untitled%202.png)

Fig. 2.15.2 Quiz Manager inspector.

## 2.16 Puzzle <a name="Puzzle"></a>

The Door puzzle was a simple trial and error-based game implemented at the end of the game in the Dungeon scene. The player must choose between two doors, on the left or the right, in order to progress. If the player chose the wrong door they would be transported back to the start. Clues were provided by placing different coloured statues beside each door, to give the player something to remember in case they fail and choose the wrong door. Considering that there are only 6 doors, this puzzle is quite straightforward and doesn’t take much time to complete. Figure 2.16.1 below shows an overall view of the puzzle.

![puzzle.png](https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/puzzle.png)

Fig 2.16.1 Puzzle scene

## 2.17 Sunset <a name="Sunset"></a>

This feature was added to the scene to depict the character working the night shift to earn more money. In order to achieve this effect, a combination of the "timeline" and "emitter/receiver" features in Unity were utilized to enable communication between the timeline and the sun game object. This was necessary to enable the changing of the sun's color as it moved from one position to another. Overall, the implementation of the sunset feature adds an extra layer of realism to the scene and enhances the storytelling experience for the viewer.

![Sunset_1.png](https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/Sunset_1.png)

Fig. 2.17.1 Sun after triggering Sunset script

![Sunset_2.png](https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/Sunset_2.png)

Fig. 2.17.2 Sun after triggering Sunset script

## 2.18 Audio <a name="Audio"></a>

All audio contained in the game is from free license sources or mixed by our team. Sound effects, ambience, and game music were all carefully curated to achieve the best effect. Some audio found online was quite choppy and contained lots of clipping, but the music was very good. In order to fix this problem Audacity’s spectrogram tool was used to clean up the audio. Figure 2.18.1 below shows the spectrogram with some defects in the file. The long vertical purple lines were clipping sounds that would pop during play. These could be removed quickly in order to clean the sound. Figure 2.18.2 shows a cleaned version of the file which was then looped to achieve desired length.

![spectrogram.png](https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/spectrogram.png)

Fig 2.18.1 ‘Dirty’ Spectrogram

![spectrogram finished.png](https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/spectrogram_finished.png)

Fig 2.18.2 ‘Cleaned’ Spectrogram

## 2.19 Triggers <a name="Triggers"></a>

Triggers are game objects that contain 2D box colliders that are used to trigger scripts/events/sprites etc. These were used heavily in scene two to achieve a specific flow of events, animations, script activations and music activations/deactivations.

# Development <a name="Development"></a>

## 3.1 Agile/Kanban <a name="Agile/Kanban"></a>

From initial brainstorming to prototyping and testing, the team followed a Kanban style scheduling system. Given the short time frame for delivering this project, a simplified view was taken with a strict level of tracking for each task. Tasks were generalised into Design, Engineering and Administrative. Design tasks related to any art, UI or mini-game development, Engineering tasks related to specific mechanics/logic required for these designs and Administrative tasks related to team organisation and report writing.

The Kanban board contained status cards for each of these three main sections where tasks were placed. Tasks statuses are as follows:

- Not Started
- In Development
- Testing
- Reviewing
- Done

Figure 3.1.1 shows the Design team’s kanban board used to schedule tasks accordingly. Each task was assigned certain properties i.e. Status, Assignee, Deadline, Requirements and Team.

![https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/image3.png](https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/image3.png)

Fig. 3.1.1 Kanban Board (Design Section)

### 3.1.1 Task Delegation <a name="TaskDelegation"></a>

Tasks were discussed each Monday during meetings as the team organised a weekly plan. Each task was taken on a voluntary basis. Though each member was responsible for specific tasks they could choose, they generally worked under the auspices of a leading member of the Design team or engineering team member.

### 3.1.2 Testing/Reviewing <a name="Testing/Reviewing"></a>

Once a feature task was developed, the team gathered onsite or online to test and review. This mostly pertained to animations and game mechanics e.g. testing a jumping and running animation on the PlayerMovement script. Considering the scope of the project and the bulk of prototyping, it was useful to relay information to each team member during meetings and coding sessions where the team could take an easy hands-on approach to problem-solving and bug fixing.

### 3.1.3 GitKraken <a name="GitKraken"></a>

During development, each member of the team was responsible for pulling the current state of the development environment and pushing their changes appropriately. This was facilitated by the use of GitKraken and Git Large File Storage. The GitKraken client is an intuitive GUI and Git CLI, providing the team with a toolset for version control. Git Large File Storage is a tool used by GitKraken to replace large files such as images and audio samples with text pointers inside Git, while storing the file contents on the remote GitHub server.

## 3.2 Art Design and Development <a name="ArtDesignandDevelopment"></a>

The overall shared artistic vision took time to settle as each member worked to explore ideas and relay these to the team, however, all members were in agreement that the format and direction of the art should be 32x32 pixel resolution with a little leeway i.e. not conforming exactly to this standard at all times depending on the animation/graphical effect required. Most ideas were recorded and presented using sketches and concept art during brainstorming sessions. These sessions were stimulating but also quite demanding as working towards an artistic vision took a lot of creative flexibility and thought. Each session was highly productive and gave us a strong path forward but as with any creative endeavour, the risk of scope creep was ever-present which sometimes led to more questions than answers.

### 3.2.1 Storyboard <a name="Storyboard"></a>

A storyboard is a powerful tool for visualising the plot and gameplay of a video game. As the main technique for writing the game’s story, a storyboard consists of a sequence of sketches or illustrations that showcase the various game elements, from the characters and environment to the game mechanics and objectives. We used storyboards, so game designers could a clearer picture of how the game will look and play, allowing them to make more informed decisions about the game’s design and mechanics.

To create a storyboard, a [Storyboarder by Wonder Unit](https://wonderunit.com/storyboarder/) was used. All sketches were drawn by hand.

![https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/image32.png](https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/image32.png)

Screenshot 3.2.1.1 Storyboarder workflow.

Here you can see some boards of the storyboard for the Prologue scene of the game:

![https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/image8.png](https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/image8.png)

Board 3.2.1.2 The MC room.

![https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/image19.png](https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/image19.png)

Board 3.2.1.3 The MC room with game mechanics notes.

![https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/image7.png](https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/image7.png)

Board 3.2.1.4 The outline of the map.

![https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/image40.png](https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/image40.png)

Board 3.2.1.5 “Who wants to be a ~~millionaire~~ student” mini-game in the kitchen.

### 3.2.2 Asset Research <a name="AssetResearch"></a>

Having properly matching assets in a game, especially one that includes familiar places, is crucial for immersing players and creating a believable world. In the end, only several assets were created with UCC in mind. This was caused by the decision to make the game more abstract and less stuck to one location. It allowed us to create more generic locations, add more levels and concentrate more on game mechanics.

### 3.2.2.1 Pixel Art Architecture Research <a name="PixelArtArchitectureResearch"></a>

Artistic development included prototyping with some well-known places, such as the UCC quad, UCC church, Gaol walk, and others, to see how they look and feel in the game world. As it was mentioned earlier, only a few assets are referencing to UCC, such as paintings:

![Untitled](https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/Untitled%203.png)

Fig. 3.2.2.1.1 UCC Quad Painting

![Untitled](https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/Untitled%204.png)

Fig. 3.2.2.1.2 Shandon Tower Painting

However, finding the right resolution for the assets has been a challenge. We are still working on finding the optimal balance between detail and performance, as this is crucial to ensuring the game runs smoothly and looks amazing to players. Taking into account the time limitations and overall level of a game dev experience, it is likely that we’ll stick to 32x32 as the safest and most popular resolution. Figures 3.1 and 3.2 show some stylistic approaches taken for 2D pixel art based on images of the university’s campus. The sprites below were planned to be used in the final Scenes of the game.

![https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/image30.png](https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/image30.png)

Fig. 3.2.2.1.3 Main Quad

![https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/image21.png](https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/image21.png)

Fig 3.2.2.1.4 UCC Church

To obtain a such a result, the following steps were taken:

1. Taking reference photos of the place.
2. Merging photos together in a way to get the 2D foreground.
3. Transforming merged photos using an open-source library, [Pixel it](https://github.com/giventofly/pixelit)
4. Manually making final corrections using Aseprite - software for creating pixel art.

### 3.2.2.2 Background Art Research <a name="BackgroundArtResearch"></a>

The artwork is a big part of the game development and we’ve quickly realised that it is impossible for one digital artist to draw all the art works, so we came to the conclusion to use only critically important art works, such as main characters, animations, quest items, and interactable objects. Most of the generic background sprites that we use in the game are public domain sprites downloaded from [https://opengameart.org/](https://opengameart.org/) and [https://itch.io](https://itch.io/)

![https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/image36.png](https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/image36.png)

Fig 3.2.2.2.1 Potential beach background for the first draft of the scene.

![https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/image25.png](https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/image25.png)

Fig 3.2.2.2.2 Houses for populating the city

### 3.2.3 Sprites <a name="Sprites"></a>

For the creation of sprites in our game, we employed the software tool Aseprite. In addition, select sprites, often in the form of sprite sheets, were procured from publicly accessible online resources. Our development team strictly adheres to the use of sprites that are licensed under open licensing conditions. Presented below are several examples of sprite sheets showcasing the artistic work for the Prologue scene.

![https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/image15.png](https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/image15.png)

Sprite sheet. 3.2.3.1. Kitchen location

![https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/image10.png](https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/image10.png)

Sprite sheet 3.2.3.2. Living room location

![https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/image34.png](https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/image34.png)

Sprite sheet  3.2.3.3 MC bedroom

### 3.2.4 Animations <a name="Animations"></a>

The built-in animator within the Aseprite software was utilised to create the animations for our project. The main tool for creating sprites and spritesheet animations was Aseprite. Here you can see the example of a day-to-day workflow:

![ezgif.com-video-to-gif(1).gif](https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/ezgif.com-video-to-gif(1).gif)

Fig. 3.2.4.1 Gif animation of a workflow (creating Boy Run Animation spritesheet)

Presented below are several examples of the resultant works.

**Main Character animations:**

**Boy**

![https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/image22.png](https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/image22.png)

Sprite sheet 3.2.4.2 Character’s idle animation

![Untitled](https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/Untitled%205.png)

Sprite sheet 3.2.4.3 Character’s run animation

![Untitled](https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/Untitled%206.png)

Sprite sheet 3.2.4.4 Character’s sleep animation

**Girl**

![https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/image20.png](https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/image20.png)

Sprite sheet 3.2.4.5 Character’s idle animation

![Untitled](https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/Untitled%207.png)

Sprite sheet 3.2.4.6 Character’s sleep animation

**Side Character idle animation:**

![Untitled](https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/Untitled%208.png)

Sprite sheet 3.2.4.7 Darth Vader (aka Father) idle animation.

![Untitled](https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/Untitled%209.png)

Sprite sheet 3.2.4.8 Wacdonald’s Manager Bowser idle animation

**Interior animation**:

![https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/image12.png](https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/image12.png)

Sprite sheet 3.2.4.9 Opening curtain animation

![Untitled](https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/Untitled%2010.png)

Sprite sheet 3.2.4.10 Arcade Machine idle animation

![Untitled](https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/Untitled%2011.png)

Sprite sheet 3.2.4.11 Calendar Animation

### 3.2.5 Tilesets <a name="Tilesets"></a>

The Aseprite software was utilised to construct tilesets, which were subsequently employed in establishing the environment and background for the house interior. The ensuing examples provide a visual depiction of this process.

![https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/image11.png](https://filedn.eu/lfgrnWJ01yfHacQuQP84g4X/Team%20Software%20Project%20-%20Team%207%20-%20V3/image11.png)

Fig. 3.2.5.1 Walls and doors Tileset.

## 3.3 Creative Development <a name="CreativeDevelopment"></a>

The direction of this game took many turns during the early stages of development, but a general theme of ‘student life and experience’ was agreed upon as our main design brief. During brainstorming sessions for what story we wanted to develop, we took a fluidic and modular approach to the creative design by trying not to lock into a specific plotline. Instead, our team used rough drafts as a springboard for ideas that provided a ‘flow’ for creative conversations and decision-making. These rough drafts were scenes or experiences of student life that we would like to capture in a humorous way. Throughout each meeting and brainstorming session, improvisation was a highly positive technique, as some of the best ideas came from the spur of the moment. We would generally try to capture a teammate’s idea and expand on it, rather than taking a dismissive/negative view. When it came to looking back over our discussions we had a wealth of ideas to choose from, and thus we were able to reduce our scope to what we thought was feasible.

### 3.3.1 Storyline/Narrative <a name="Storyline/Narrative"></a>

### 3.3.1.1 Opening Scene <a name="OpeningScene"></a>

Our take on the theme of ‘student life and experience’ was quickly formed into a game idea that would explore the life of a student entering university for the first time. Initially opening with a scene focused on the main character spending his free time during the summer playing video games in his bedroom. Regarding concept art figure 4.2.1.1, it shows our protagonist at his desk, with a timelapse animation that would show the days flying by using a day/night transition and a calendar and clock animation also adding to that effect.

After this animation, our protagonist would then find themself in the room awaiting input from the player. After a prompt, the protagonist would be guided to a door leading downstairs to a dialogue with their father where the plot would be advanced.

### 3.3.1.2 TV Game Show Scene <a name="TVGameShowScene"></a>

A dialogue with their father would lead the protagonist to be forced to choose UCC via a “Who Wants To Be A Millionaire” mini-game, where the father character takes on the role of the game host and asks the protagonist a set of ‘fixed’ multi-choice questions, with the player being unable to choose certain answers, referring satirically to his father’s stubbornness. After this scene, the player would be guided through the protagonist’s monologue to seek a summer job in order to pay for his college laptop.

### 3.3.1.3 WacDonalds Job Interview Scene <a name="WacDonaldsJobInterviewScene"></a>

After leaving his house in search of work, our protagonist finds himself in front of “WacDonald’s”, a restaurant run by the Mario Bros villain Bowser. After noticing a “Staff Wanted” sign, the protagonist is guided to enter the restaurant and trigger a job interview. This again will be a scripted set of multi-choice questions. After agreeing to some awful working conditions, the protagonist gets his uniform and is segued into a Mario Bros-themed mini-game.

### 3.3.1.4 WacDonalds Mini-Game Scene <a name="WacDonaldsMini-GameScene"></a>

The protagonist enters the kitchen of the WacDonalds restaurant and is met by a coworker who instructs them on how to play the game. The player then must receive an order at the front counter from a customer, then go back to the kitchen and gather the order according to the spec (any amount of burgers, fries or drinks). If they make a mistake, the player can dump the order and start again. The player is under a time limit before the customer walks away or starts to complain.

Once the player has collected enough money from serving customers, it will trigger the protagonist into a ‘burned out’ state where their movement is slower and the orders start to multiply until the protagonist passes out on the floor and is ultimately fired by his boss. The scene will fade to black after a brief dialogue with the Bowser character.

### 3.3.1.5 Laptop Quest Scene <a name="LaptopQuestScene"></a>

This scene opens with the protagonist triggering a monologue about a difficult search for a laptop. The protagonist had learned of a shady laptop salesman, and so has decided to find his store. After arriving in front of the store, the protagonist enters and triggers a dialogue with the owner who turns out to be the Sonic The Hedgehog villain Dr. Robotnik.

After a brief dialogue with the shop owner, the protagonist is sent on a dungeon quest to find the last laptop available.

# Index <a name="Index"></a>

## 4.1 Terminology <a name="Terminology"></a>

| Terms | Definitions |
| --- | --- |
| Animator | Animator is a component that controls the movement and behaviour of objects in a game or application. It allows us to create complex animations by defining keyframes and transitions between them. |
| Aseprite | Aseprite is a proprietary, source-available image editor designed primarily for pixel art drawing and animation. |
| Box Collider | Box collider is a component that defines a rectangular box-shaped boundary around a game object. It is used to detect collisions with other objects and trigger events in response. |
| Component | Component is a modular piece of functionality that provides specific behaviour or features. Components can range from basic functionality, like a Transform component that controls the position, rotation, and scale of an object, to more complex functionality, like an Animator component that controls animations. |
| Composite Collider | Composite Collider combines multiple colliders into a single to optimise collision detection for complex objects that require multiple colliders. We use it to reduce the number of collision checks needed. |
| Dope Sheet | Dope sheet is a tool used to visualise and edit keyframes over time. It provides a detailed view of an animation’s timing and helps to refine the motion of animated objects. |
| GameObject | GameObject is a virtual object that represents anything from a character to a light. It has a position, rotation, and scale. |
| Git Kraken | Git Kraken provides an intuitive graphical user interface for managing Git repositories. It allows us to visually track changes, collaborate with others, and manage our code using a range of features. |
| Git LFS | Git LFS allows for efficient handling of large files, such as media assets, in a Git repository. It works by replacing large files with small text pointers, allowing Git to store and manage only the pointers instead of the entire file. |
| Gizmos | Gizmos are simple visual tools that help us debug and develop games. They are small shapes and lines drawn in the Scene View to help visualise the position, size, and orientation of game objects and other components. |
| Hierarchy | Hierarchy is a panel that lists all game objects in a scene, showing their parent-child relationships. It’s used to organise and manipulate game objects by creating, deleting, moving, and renaming them, and is a key tool for managing the contents of a scene. |
| Inspector | Inspector is a panel that displays the properties and components of a select Game Object. It allows us to view and modify attributes like position and material. |
| Layers | Layers categorise game objects into groups for collision detection and filtering. They allow users to include or exclude specific objects from physics simulations and organisation. |
| Materials | Materials are assets that define the visual appearance of game objects, controlling properties like colour, texture, and lighting. They’re used to apply surfaces to Game Objects, created and edited using the Material Editor, and assigned via the Inspector panel. |
| MC | Main Character |
| Parallax | Parallax is a visual effect that creates an illusion of depth by moving foreground and background elements at different speeds. This gives the impression of depth and can enhance the immersion and visual appeal of a game. |
| Platform Effector | The Platform Effector in Unity is a tool that modifies how game objects interact with a platform in 2D games. It’s used in platforming games to create surfaces for the player to jump from or stand on. |
| Player | Refers to the user or player of the game. |
| Prefabs | Prefabs are reusable game object templates that can be easily saved and duplicated across different levels or scenes. They allow users to create a Game Object with a specific set of components and properties that can be easily modified and updated, affecting all instances of it. |
| Protagonist | Refers to the main character of the game. |
| RigidBody2D Physics | Adding a Rigidbody2D component to a sprite puts it under the control of the physics engine. By itself, this means that the sprite will be affected by gravity and can be controlled from scripts using forces. |
| Scenes | Scenes contain the objects of your game. They can be used to create a main menu, individual levels, and anything else. Think of each unique Scene file as a unique level. In each Scene, you will place your environments, obstacles, and decorations, essentially designing and building your game in pieces. |
| Sprite Sheet | A sprite sheet is a collection of images that are organised into a grid or sequence, and are used in games to create animations or display different states of an object (such as a character walking, jumping, or standing still). |
| Sprite Editor | Sprite Editor is a tool that allows you to edit the individual images, or “sprites,” that make up a sprite sheet. |
| Storyboarder | Storyboarder, at the highest level, is a drawing organizer. It makes drawing and ordering drawings simpler. You could do this with a stack of paper and a pencil. |
| Tilemap | The Tilemap component is a system which stores and handles Tile Assets for creating 2D levels. |
| Tilesets | In Unity, a tileset is a collection of small, usually square images that can be used to create levels or environments in 2D games. Each image in a tileset is called a “tile,” and these tiles can be arranged and combined in different ways to create the game world. |
| Tile Palette | The Palette tools used to paint Tiles onto Tilemaps can also be used to edit the placement of Tiles in the Palette itself. |
