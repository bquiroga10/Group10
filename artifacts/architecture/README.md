**Program Organization**
--------------------------

![Diagram 1](https://github.com/bquiroga10/Group10/blob/master/artifacts/architecture/ArchitecturalDiagram.png)

![Sequence](https://github.com/bquiroga10/Group10/blob/master/artifacts/architecture/SequenceDiagram.png)

**Code Design**
-------------------------

![Class diagram](https://github.com/bquiroga10/Group10/blob/master/artifacts/architecture/ClassDiagram.PNG)

**Data Design**
-------------------------

We are using Open Trivia Database as a pool for our questions, so there is not a need for 

**Buisness Rules**
------------------------

As we are using the free version of Unity, we cannot exceed $100,000 of funding in a 12 month period

**User Interface Diagram**
------------------------

![First](https://github.com/bquiroga10/Group10/blob/master/artifacts/architecture/UserInterface.png)

![Second](https://github.com/bquiroga10/Group10/blob/master/artifacts/architecture/User%20Interface%20Diagram.png)


**Resource Management**
------------------------

Since we are using Open Trivia DB, resource management is not a factor in our build

**Security**
-------------------------

TBD

**Performance**
------------------------

TBD

**Scalability**
------------------------

Only one user will ever be playing, so Scalability is not an issue.

**Interoperability**
------------------------

This is a single player game, so there

**Internationalization/Localization**
------------------------

As this game is very text heavy, we have no plans to localize this game into other languages

**Input/Output**
------------------------

Despite being a video game, the is an input/output field with regards to reading and printing out the questiongs, how this works is TBD

**Error Processing**
------------------------

Most of the errors within the video game will be handeled within unity. The errors in regards to pulling from Open Trivia DB will have to be done manualy.

**Fault Tolerence**
------------------------

TBD

**Architectural Feasibility**
------------------------------

TBD

**Overengineering**
------------------------------

TBD

**Build-vs-Buy Decisions**
------------------------------

Unity has quite a bit of free assets in the unity store, as well as using Open Trivia DB

**Reuse**
-----------------------------

a lot of what unity offers can be considered 'pre existing software' that we uitlized while creating the game. Tile generation, pre existing assets that we can import from the asset store and use and collider physics to name a few  are all unity software options that unity offers that we can use and reuse freely.

**Change Strategy**
-----------------------------

Since all Unity projects are broken into smaller scenes. Throughout the designing process, If we need to change or add to a certain aspect of the project, we can simply go to the corresponding scene and edit it or add to it. Managing and editing scenes, whether its changing unity sprite settings (Position, scaling, sprite renderer, rigid body) or editing the coding script (for example, movement behaviour), all can be done easily by just clicking on the scene we wish to change and easily make changes to it. This becomes a simple, efficient and error free process thanks to Unity's way of organizing a project into well ordered sub-projects.
