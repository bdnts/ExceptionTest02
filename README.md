# ExceptionTest02 - A reproduction of the TaskCanceledException occurring between Telerk Blazor UI and MS Identity
Several folks have noticed this exception occurring while debugging applications with Telerik Blazor UI.  
If possible, it is important to know the origins of the problem.  Did the developer introduce the problem in their code? 
Or did it come from a third party?  Or is it in Blazor itself?  I was debugging a Identity problem not displaying in a TelerikWindow.
Not knowing the origin of this issue, I couldn't tell if I found the source of my problem or not. 
Through this excercise, the problem I was debugging might also have the same root, though this project is not intended to repo the original issue.
My conclusion is that this is an issue between Telerik Blazor UI and the 3.1.3 packages introduced by scaffolding Identity.

## Reproduction
* Base00.00.00 -- Built blank Telerik Blazor UI project in VS 2019 V16.5.4
* Base00.00.01 -- I added a TelerikWindow to Index
  * Cut and paste the code from https://docs.telerik.com/blazor-ui/components/window/overview#show-and-close
  * Test
    * Open and close the Window, wait no longer than 5 minutes
    * No exception thrown
* Base00.01.00 -- Scaffold MS Identity into the project
  * Scaffolding Identity
    * Override all files
      * Create custom Context
    * Use SqLite
    * Create custom User
    * Create 
    * Modify *Startup.cs*
    * Compile, clean up any errors
    * Package Manager
    * Create Migration
    * Update database
  * Test
    * Open and Close window
    * Register new user
    * Login
    * Open and close window
    * Wait no longer than 5 minutes
  * Compile and clean up any issues
  * Commit all the new files
* Base00.01.01 -- Commit modified files
  * Test
    * Open and close window
    * Do a Login
      * Received a `InvokingDisposedObject` exception, but thare many of these caught by the system.
    * Open and close the window
* Base00.01.02 - Upgraded project libraries.
  * ExceptionTest02.csjproj was scaffolded with all 3.1.1 libraries.
  * Using NuGet, updated all packages to latest, 3.1.3 libraries.
  * Test
    * Open and close window
    * Login
    * Open and close window
    * Wait no longer than 5 minutes
    * TaskCanceledException appears
  * It would appear there is an issue between Telerik Blazor UI 2.10 and the 3.1.3 packages installed by Identity Scaffolding.
  
Good to know.

    
