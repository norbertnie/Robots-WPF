# Structure of the WPF Robots Application
## 1. Models

##### • Robot: A class representing the data model for a robot. It has Id, Name, Status, BatteryLevel, ImagePath, etc.

## 2. ViewModels

##### • RobotViewModel: This is the ViewModel for the application, which follows the MVVM (Model-View-ViewModel) pattern.

  ### Properties:
  
##### • Robots: An observable collection of Robot objects, representing all robots.
##### • VisibleRobots: An observable collection of Robot objects that are currently visible in the user interface.
##### • SelectedRobot: The currently selected robot.
##### • CurrentPage: The current page in the robot pagination.
   
  ### Commands:

##### • LoadRobotsCommand: Command to load robots from the database.
##### • UpdateRobotCommand: Command to update a robot or robots.
##### • PreviousPageCommand: Command to go to the previous page of robots.
##### • NextPageCommand: Command to go to the next page of robots.
##### • SelectPreviousRobotCommand: Command to select the previous robot in the list.
##### • SelectNextRobotCommand: Command to select the next robot in the list.

  ### Methods:
  
##### • LoadRobots(): Loads robots from the database.
##### • UpdateRobot(): Updates the selected robot or all robots if the "All" option is selected.
#### • UpdateVisibleRobots(): Updates the list of visible robots based on the selected robot and the current page.
#### • Pagination-related methods: PreviousPage(), NextPage(), SelectPreviousRobot(), SelectNextRobot(), and their conditions (CanPreviousPage(), CanNextPage(), CanSelectPreviousRobot(), CanSelectNextRobot()).

## 3. Views

  ### MainWindow.xaml: The main view of the application, which defines the user interface.
   
  It consists of two main sections:
  

**Upper Grid** with a menu, containing navigation buttons for selecting robots, buttons for loading and updating robots, and the RobotSelector control.

**Lower Grid** with robot tiles, which displays visible robots in the ItemsControl.

**RobotSelector.xaml**: A custom user control allowing the selection of a robot from a list. 

• It consists of a main button (MainButton) that displays the currently selected robot, and a popup (Popup) containing buttons for each robot.

## Application Workflow

### 1. Loading robots:

• When the application starts, the LoadRobots() method is called, which loads robot data from the database and assigns it to the Robots collection. 

### 2. Displaying robots:

• The VisibleRobots property is updated based on the selected robot (SelectedRobot) and the current page (CurrentPage). If the "All" option is selected, all robots are displayed with pagination. If a specific robot is selected, only that robot is displayed.

### 3. Navigating between robots:

• The < and > buttons allow navigation between robots in the list. Clicking these buttons updates the selected robot (SelectedRobot), which updates the displayed text and image in the RobotSelector control.

### 4. Updating robots:
   
• The buttons for loading (LoadRobotsCommand) and updating (UpdateRobotCommand) robots execute the appropriate commands. The update can pertain to a single robot or all robots, depending on the currently selected robot.

### 5. Selecting a robot from the list:
• Clicking the button in the RobotSelector control opens a popup with a list of robots. Selecting a robot updates the SelectedRobot, which closes the popup and updates the displayed text and image in the main button of the RobotSelector control.

### 6. Filtering robots:
• After selecting a robot from the list, the interface is filtered to show only the selected robot. If the "All" option is selected, all robots are displayed with pagination.

### This application uses the MVVM pattern, which allows separating business logic from the user interface logic, which is beneficial for testing and code maintenance.
