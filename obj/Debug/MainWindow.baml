   M S B A M L   `   `   `  ����?  ;WiSi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WiSiWiSi  5   	       WiSi.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:WiSi     5   	   -   5          � Title$  
MainWindow��5   	   $	��850��6   $
��1050��6)    � 
ResizeMode$ CanMinimize=�6O    � 	Resources 5
       �� 
TargetType �� Property �� Value��%w   '��       �� 5   
   " ��6   .�5      ��  � ��$ 0q�60   �� 5       � ��
 ���� 6+   5      5      .��5   
   �� -   5         ��Name$ 
MainCanvas��5      
�������|�. .+�5      ��  �� Right$ 10��6    �� Orientation$ 
Horizontal=�6+   .+�5      �� -   5        	 ��Name$	 displayLeft��5      �� 5      -   5        $	 
displayTop��5      5      �� 5      -   5        
 ��Name$

 Menu��5      .+�5      �� -   5         ��Name$ Rathaus��5      .��5      �� $0��*pack://application:,,,/images\townHall.png��6   $��60��6M   5      �� 5      -   5        $
 Haus��5      .��5      �� $-��'pack://application:,,,/images\house.png��6   $��60��6I   5      �� 5      -   5        $
 WorkerBlock��5      $ 
Horizontal=�62   .+�5       �� -	   5        $ Worker��5       .��5!      �� $.��(pack://application:,,,/images\worker.jpg��6   $��60��6N   5"      �� 5#      -
   5        $	 WorkersAnzahlText��5#       $��18(�6;   $
��Bold"�6I   5$      �� 5%      -   5        $ Kueche��5%      .��5&      �� $2��,pack://application:,,,/images/soup_spoon.jpg��6   $��60��6N   5'      �� 5(      -   5        $ 
Ressourcen��5(      .��5)      �� $2��,pack://application:,,,/images/ressources.jpg��6   $��60��6N   5*      5,      �� 5.      $ 50��6   
 �� Top$ 50��6+   .+�5/      �� -   5        $ BergBtn��5/      .��50      �� $,��&pack://application:,,,/images/Berg.png��6   $	��300��6M   51      52      �� 54   
    �� Left$ 50��6    �� Bottom$	 250��6&   .+�55      �� -   5        $ TeichBtn��55      .��56      �� $-��'pack://application:,,,/images/Teich.png��6   $	��200��6J   57      58      �� 59   
   $	 150��6   $ 50��6(   .+�5:      �� -   5        $ WaldBtn��5:      .��5;      �� $.��(pack://application:,,,/images/forest.png��6   $	��300��6K   5<      5=      �� 5>   
   $	 400��6   $
��0 30q�6(   $ 
Horizontal=�66   $��Center=�6O   .+�5?      �� -   5         ��Name$ RessourcenDisplay��5?      ��5@      �� 5A      .R�5B      $�  $� Orientation$ 
Horizontal=�65   5C      ��5E      �� 5F      .R�5G      �� .+�5H   "   �� $��SemiBold"�6B   ��6,   �� *Name+6B   �� 5I   "   
��� d ���6,   �� *Anzahl+6D   5J      5K      5M      5N      5O      5P      