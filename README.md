# CSCI-352-Project
Repo for the project
Authors: Jordan Taylor and Mason Bearden.
Date: 03 / 12 / 2021
Battle of the Professor

Project: RPG Game where you play as a student taking a computer science class. You taverse a map and play events which come in the form of questions. You are assigned stats at default values and can increase them or decrease them. Doing so will make the final confrontation with the professor harder/easier. The professor plays similarly to the events throughout the map, but with more questions and stat implementation.

Design: We went with a simple button layout with buttons for movement in 4 directions, 3 buttons for answers and another for checking entered text. There is also a button for Exiting, along with a main start menu which allows for creation of a new game, loading a game, or Exiting from the application. The map itself is consisting of Black and White rectangle to show a map where white spaces are moveable and black spaces are walls. Questions come in two varieties with pick a choice quesitons, and enter an answer questions.

Coding: We used 2 design patterns, Observer and Singleton. The observer adds children of Gamestate into an observer where they can be notified during events. Through this, theya re saved and the stats are updated using an interface, IGamestate. The Singleton uses the IGameState and Gamestate classes to create an Instance where all calsses can speak to each other. This is used in the main driver of the project named state. this field calls methods from IGamestate to add functionality to Character children.

Additional Notes: All the questions are loosely based on computer science information, with some exceptions and are taken from this class. Events can be skipped, and the game can be beaten even if all stats are set to 0. The game is just much easier if your stats are higher. It is possible to lose with maximum stats as well.
