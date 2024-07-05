<h1>WindowsPet</h1>
<p>Your personal pet for Windows OS.</p> 

<br>

<h2>Features</h2>
<h3>Home</h3>
<ul>
  <li>Draggable home sprite</li>
  <li>Call pet to home</li>
</ul>

<h3>Pet</h3>
<ul>
  <li>Random wandering</li>
  <li>Chase cursor (Togglable by clicking on the pet)</li>
  <li>Locate and sit on top of focused window (If possible)</li>
  <li>Sit still</li>
  <li>Detect and sit on top of ledges</li>
</ul>

<br>

<h2>Setup</h2>
<p>To set up your own windows pet you will need to create a Config.env file which then should be placed in the applications root directory.</p>
<p>The Config.env file must contain the following attributes:</p>

<ul>
  <li><b>PET_SPRITE_WIDTH</b></li>  <p>This should be an integer containing your pets sprite width.</p>
  <li><b>PET_SPRITE_HEIGHT</b></li>  <p>This should be an integer containing your pets sprite height.</p>
  <li><b>PET_SCALE</b></li>  <p>This should be an integer containing a scale factor for your pet.</p>
  <li><b>PET_SPEED_IN_PIXELS_PER_SECOND</b></li>  <p>This should be an integer containing your pets speed in pixels per second.</p>
  
  <li><b>MIN_BEHAVIOR_STATE_TIME</b></li>  <p>This should be an integer containing minimum duration of the pets actions in milliseconds.</p>
  <li><b>MAX_BEHAVIOR_STATE_TIME</b></li>  <p>This should be an integer containing maximum duration of the pets actions in milliseconds.</p>
  
  <li><b>IDLE_ANIMATION_SPRITE_SHEET</b></li>  <p>This should be a string containing the path for your pets idle animation sprite sheet.</p>
  <li><b>IDLE_ANIMATION_FRAME_COUNT</b></li>  <p>This should be an integer containing the amount of frames contained within the idle sprite sheet.</p>
  <li><b>IDLE_ANIMATION_FRAME_DELAY</b></li>  <p>This should be an integer containing the delay between each frame in the idle animation in milliseconds.</p>
  
  <li><b>WALK_ANIMATION_SPRITE_SHEET</b></li>  <p>This should be a string containing the path for your pets walk animation sprite sheet.</p>
  <li><b>WALK_ANIMATION_FRAME_COUNT</b></li>  <p>This should be an integer containing the amount of frames contained within the walk sprite sheet.</p>
  <li><b>WALK_ANIMATION_FRAME_DELAY</b></li>  <p>This should be an integer containing the delay between each frame in the walk animation in milliseconds.</p>
  
  <li><b>HOME_SPRITE</b></li>  <p>This should be a string containing the path for your pets home sprite.</p>
  <li><b>HOME_SCALE</b></li>  <p>This should be an integer containing a scale factor for your pets home sprite.</p>
  <li><b>HOME_START_LOCATION_X</b></li>  <p>This should be an integer containing x-coordinate for your pets home start location.</p>
  <li><b>HOME_START_LOCATION_Y</b></li>  <p>This should be an integer containing y-coordinate for your pets home start location.</p>
  
  <li><b>SYSTEM_TRAY_ICON</b></li>  <p>This should be a string containing the path for your pets icon sprite.</p>
</ul>

<br>

<h2>How to use</h2>
<h3>General</h3>
<p>When everything is set up correctly, you can run the application. This will "spawn" your pet along with its home. In order to close the application you will need to take a look in the system tray, here you will find the icon you specified in your Config.env file. If you right-click this icon you will be prompted with the Exit-button, clicking this will close the application.</p>

<h3>Home</h3>
<p>At any time you will be able to click and drag the home sprite to any location and leave it there. If you feel like the pet is in the way, you can right-click the home sprite, this calls the pet to home and locks it there, you can alway release the pet by again right-clicking the home sprite.</p>

<h3>Pet</h3>
<p>The pet will act on its own acording to its behavior this includes everything mentioned above in "Features". Although the pet controlles itself, you are able to tell it never to follow your cursor, this is done by clicking the pet sprite at any time. this functions as a toggle and can be undone by again clicking the pet sprite.</p>
