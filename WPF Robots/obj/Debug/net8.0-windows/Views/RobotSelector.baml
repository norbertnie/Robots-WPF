   M S B A M L   `   `   `  ����E  AWPF Robots, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:WPF_Robots
WPF_Robots  5          WPF_Robots.RobotSelector   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:WPF_Robots     5      .��5
      � .+�5   
   �� -   5          ��Name$  
MainButton��5      $	��100��6%   $��30��61   
�������$
��Left=�5      $	��Top=�6,   .��5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� -   5         ��Name$ MainButtonText��5      $��	Wszystkie��64   $��Center=�6E   $��5q�6`   �� 5      -   5         ��Name$ MainButtonTextImage��5      $3��-pack://application:,,,/Images/robot_black.png��66   $��20��6m   $��20��6x   $��5q�6�   5      5      � 5   
   -   5         �Name$ 
RobotPopup��5       � 	StaysOpen$ False��6W    � PlacementTarget 6$   ��  �� ElementName$ 
MainButton��.��5      �� 
�������
�������$��1q�6;    �� CornerRadius$ 5��6O   	 �� Padding$	 5q�6`   ._�5      �� -   5        
 ��Name$
 RobotButtonsContainer��5      ��5      �� 5      .R�5      A�  A� Columns$ 2��6*   5      ��5      �� 5      .R�5      �� -   5        $	��100��5   %   $��30��61   $��5q�6=   
�������.��5    "   �� $ 
Horizontal=�6-   .+�5!   &   �� $��20��6I   $��20��6T   $��5q�6`   ��6,   �� *	ImagePath+6`   �� 5"   &   $��Center=�6F   $��5q�6a   ��60   �� *Name+6a   5#   #   5$      5%      5'      5(      5)      5*      5+      