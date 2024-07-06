# Struktura aplikacji WPF Robots
## 1.	Modele (Models)

##### •	Robot: Klasa reprezentująca model danych dla robota. Posiada Id, Name, Status, BatteryLevel, ImagePath itp.

## 2.	Modele Widoków (ViewModels)

##### •	RobotViewModel: Jest to ViewModel dla aplikacji, który stosuje wzorzec MVVM (Model-View-ViewModel).

  ### Właściwości:   
  
##### •	Robots: Obserwowalna kolekcja obiektów Robot, reprezentująca wszystkie roboty.
##### •	VisibleRobots: Obserwowalna kolekcja obiektów Robot, które są aktualnie widoczne w interfejsie użytkownika.
##### •	SelectedRobot: Aktualnie wybrany robot.
##### •	CurrentPage: Aktualna strona w paginacji robotów.
   

  ### Polecenia (Commands):

##### •	LoadRobotsCommand: Polecenie ładowania robotów z bazy danych.
##### •	UpdateRobotCommand: Polecenie aktualizacji robota lub robotów.
##### •	PreviousPageCommand: Polecenie przejścia do poprzedniej strony robotów.
##### •	NextPageCommand: Polecenie przejścia do następnej strony robotów.
##### •	SelectPreviousRobotCommand: Polecenie wyboru poprzedniego robota na liście.
##### •	SelectNextRobotCommand: Polecenie wyboru następnego robota na liście.

  ### Metody:
  
##### •	LoadRobots(): Ładuje roboty z bazy danych.
##### •	UpdateRobot(): Aktualizuje wybranego robota lub wszystkie roboty, jeśli wybrana jest opcja "Wszystkie".
#### •	UpdateVisibleRobots(): Aktualizuje listę widocznych robotów na podstawie wybranego robota i bieżącej strony.
#### •	Metody związane z paginacją: PreviousPage(), NextPage(), SelectPreviousRobot(), SelectNextRobot(), oraz ich warunki (CanPreviousPage(), CanNextPage(), CanSelectPreviousRobot(), CanSelectNextRobot()).

## 3.	Widoki (Views)

  ### 	MainWindow.xaml: Główny widok aplikacji, który definiuje interfejs użytkownika.
   
  Składa się z dwóch głównych sekcji:
  

**Górna siatka (Grid)** z menu, zawierająca przyciski nawigacyjne do wybierania robotów, przyciski do ładowania i aktualizowania robotów oraz kontrolkę RobotSelector.

**Dolna siatka (Grid)** z kafelkami robotów, która wyświetla widoczne roboty w kontrolce ItemsControl.

**RobotSelector.xaml**: Niestandardowa kontrolka użytkownika, umożliwiająca wybór robota z listy. 

•	Składa się z przycisku głównego (MainButton), który wyświetla aktualnie wybranego robota, oraz popupu (Popup) zawierającego przyciski dla każdego robota.

## Sposób działania aplikacji

### 1.	Ładowanie robotów:

•	Po uruchomieniu aplikacji, wywoływana jest metoda LoadRobots(), która ładuje dane robotów z bazy danych i przypisuje je do kolekcji Robots. 

### 2.	Wyświetlanie robotów:

•	Właściwość VisibleRobots jest aktualizowana na podstawie wybranego robota (SelectedRobot) oraz bieżącej strony (CurrentPage). Jeśli wybrana jest opcja "Wszystkie",
  	  wyświetlane są wszystkie roboty z paginacją. Jeśli wybrany jest konkretny robot, wyświetlany jest tylko ten robot.

### 3.	Nawigacja między robotami:

   •	Przyciski < i > umożliwiają nawigację między robotami w liście. Po ich kliknięciu, aktualizowany jest wybrany robot (SelectedRobot), co powoduje aktualizację wyświetlanego
  	  tekstu oraz obrazu w kontrolce RobotSelector.


### 4.	Aktualizacja robotów:
   
  •	Przyciski do ładowania (LoadRobotsCommand) i aktualizowania (UpdateRobotCommand) robotów wykonują odpowiednie polecenia. Aktualizacja może dotyczyć pojedynczego robota lub wszystkich robotów, w zależności od tego, który robot jest aktualnie wybrany.

### 5.	Wybór robota z listy:
•	Kliknięcie na przycisk w kontrolce RobotSelector otwiera popup z listą robotów. Po wybraniu robota, aktualizowany jest SelectedRobot, co powoduje zamknięcie popupu i aktualizację
  wyświetlanego tekstu oraz obrazu w przycisku głównym kontrolki RobotSelector.

### 6.	Filtracja robotów:
•	Po wybraniu robota z listy, interfejs jest filtrowany, aby pokazać tylko wybranego robota. Jeśli wybrana jest opcja "Wszystkie", wyświetlane są wszystkie roboty z paginacją.

### Aplikacja ta korzysta z wzorca MVVM, co umożliwia oddzielenie logiki biznesowej od logiki interfejsu użytkownika, co jest korzystne dla testowania i utrzymania kodu.
