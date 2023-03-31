zutari-unity-2023-aidan-keown

CONTROLS

W - UP 
A - LEFT 
S - DOWN 
D - RIGHT

Q - DECREASE VELOCITY 
E - INCREASE VELOCITY

ESC - HIDE/SHOW LEVEL ONE GAME UI

METHODOLOGY

	UNITY:
		Task 1:
			The UI manager loads the loading screen overlay prefab in preparation for the loading screen. When the UI button is clicked, the load overlay introduces the next scene, Level One.
			Cube Movement and screen wrap: When either of the control buttons is pressed, the vector3 variable "_movementDir" indicates which direction the cube should move. In the FixedUpdate() function, the Rigidbody velocity is set to the product of the movement direction and the movement speed to make the cube move in any direction.
			Screen wrap: The position of the camera in world space is first obtained, and the half-width and half-height of the screen are calculated based on the camera's orthographic size and the screen aspect ratio. Then, it is checked if the position of the game object has gone beyond any of the screen boundaries using the camera position and the screen dimensions. If it has, its position is updated to wrap it around the screen. Else if statements ensure that the position of the game object is only updated once per frame, even if it has gone beyond multiple screen boundaries.
		Task 2:
			Serializable fields are created for the responses from OpenWeather (mainData[temp], WeatherData[description], OpenWeatherResponse[main and weatherdata]).
			A class is defined to hold the weather data for a single city, and a List is made to hold data for multiple cities.
			A method is used to get the weather data for a single city from the OpenWeather API, called using a string parameter, the city. The URL is constructed to call for the metric system and using a unique API Key. If any errors arise, the process breaks and throws an error. If the web request is successful, the JSON response is parsed into a variable and extracted, where it is stored as a single weather data class into the list.
			To display all the data, the individual pieces of data are parsed into a display prefab to be shown. Each game object is put into a 2D array so that it can be given grid coordinates. These grid coordinates are multiplied by the prefab's original coordinates to be displayed in a consistent grid on the screen.

	DESIGN:
		In designing the UI and UX for the task, I aimed for a clean and simple interface with a minimal color palette. To achieve this, I visualized the game's appearance before beginning the design process. This allowed me to plan more efficiently and make design choices that would be consistent with the programme's overall aesthetic. 
		Planning can be found at: https://www.figma.com/file/5FADFrjbkFDhQIblQEHfJY/Random?node-id=0%3A1&t=uKcueXDuaupEBgux-1


