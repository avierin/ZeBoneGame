   M S B A M L   `   `   `  ����E  AZeBoneGame, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:ZeBoneGame
ZeBoneGame  5   	   ;"clr-namespace:ZeBoneGame.ViewModelZeBoneGame.ViewModel  5      3clr-namespace:ZeBoneGame.MyWpfZeBoneGame.MyWpf  5          ZeBoneGame.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:ZeBoneGame     5   	   1vm"clr-namespace:ZeBoneGame.ViewModel     5      .wpfclr-namespace:ZeBoneGame.MyWpf     5      -   5          �Name$  MainWindow1��5   	    � Title$ 
MainWindow��5
   	    � WindowState$ 	Maximized=�5   	   $��592.849��5   	   $��1020.644��6    � 	Resources 5       �� 
TargetType   	baseStyle �� Property �� Value �� BasedOn  	BoolToVis3   -ZeBoneGame.MyWpf.RedGreenColorToBoolConverter  BoolToGreen(   "ZeBoneGame.ViewModel.GameViewModel  boneGame��%9  &	        '�� H     7   '�� j     7   '�� �     7   &	 �     &	 �     &	 �     �� 5   
   " ��6   .�5      ��  � ��$ 40(�6)   5      �� 5   
   " ��6   8   6T   �� 5   
   " ��6   8   6S   �� 5   
   " ��6   8   6U   �� 5   
   6'     5   
   6+     5   
   6.   5      .��5      ]� ��.   5   
   ��%   &	         5      62   5       � DataContext 5    
   �� 5!      	 �� Mode$	 OneWay=�6   
 �� Source#
 [ 6$   6J   .+�5&   
   �� $	��Top=�6    �� Orientation$ 
Horizontal=�6*   $��Center=�6C   .+�5'      �� $��Stretch=�5)      $��Stretch=�5*      $��What is this bone ?��5+      �� 5-      ��5/      ��  �� Path$! Game.CurrentQuestion.Answer�y�50      �� $ 
ShowAnswer� �� 	Converter# [ ��51      �� $ LastAnswerValid�# [ �� 53      $	��100(�54      $�� ��55      57      �� 58   
   $	��Top=�6   $ 
Horizontal=�6*   $��Center=�6C    59      �� $ Game.CurrentQuestion�.+�5:      �� $��Stretch=�6   $��Stretch=�5;      $	��500��5=      $	��420��6   $��	0,0,0.4,0q�6*   ��5<      �� $ ImageLocaltion[0]�5=   *   �� 5?      $��Stretch=�5@      $��Stretch=�5A      $	��500��5C      $	��420��6   $��	0,0,0.4,0q�6*   ��5B      �� $ ImageLocaltion[1]�5C   *   5D      �� 5F   
   $��Bottom=�6   .+�5G      ��  �� TextAlignment$ Center=�6    �� TextWrapping$
 Wrap=�6.   ��6B   �� $ 
UserAnswer��� 5H      $��Ok��6   ��6#   �� *ValidateAnswer+y�5I      �� $ ShowOkButton�# [ �� 5J      $
��Next��6   ��6%   �� *GoToNextQuestion+y�5K      �� $ 
ShowAnswer�# [ �� 5L      $	��Top=�6   $��Stretch=�5M      $��Stretch=�5N      
���  ����5O      �� $ CurrentStatus�5P      5Q      5S      5T      