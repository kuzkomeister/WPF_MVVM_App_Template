   M S B A M L   `   `   `  ����@  <MyWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:MyWPFMyWPF  5      3clr-namespace:MyWPF.ViewModelsMyWPF.ViewModels  5      clr-namespace:MyWPFMyWPF  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   TreeItemStackPanel  �� 
TargetType �� Property �� Value  TreeItemBook �� ItemsSource �� Path �� Triggers �� Value �� Binding �� 
TargetName	 �� ItemTemplate  ListViewItemBook
 �� Orientation  ListViewItemClientBook�� 5      F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml     5      cclr-namespace:MyWPF  5      $tclr-namespace:MyWPF.ViewModels  5      localclr-namespace:MyWPF  5      %�  &	        &	 �     7   7   &	 \    &	 �
    �� 5      "  ��6'   .�5	   
   ��  � ��$ 20��6#   �� 5
   
    �@��Orientation$ 
Horizontal=�6(   5      �� 5       64   �� $ VPeople�.R�5   
   �� 8��  .+�5      �� $��/BookIcon.png��6   $��-2,0,0,0q�6+   �� 5      $��	BookTitle��6   
���  ��$
��Bold"�6W   ��6)   �� $ VTitle�6W   5       5   
   �� 5      $
 true��6;    6   �� $ VStatus�.a�5      �� $ 	BookTitle��6    � ��
 � � �6F   5      	 5   
   �� 5      .R�5      �� 8�� .+�5      �� $��	UserImage��6   $��/UserIcon.png��6-   $��-2,0,0,0q�6D   �� 5      $��UserFam��6    
��� � ���6/   �� $ 	VLastName�6O   �� 5       $�� ��6    �� 5!      $��UserName��6    
��� � ���60   �� $ 
VFirstName�6Q   �� 5"      $�� ��6    �� 5#      $��UserOtch��6    
��� � ���60   �� $ VPatronymic�6R   �� 5$      $��	UserDefis��6    $	�� - ��61   
��� � �6<   �� 5%      $��UserID��6    
��� � ���6.   �� $	 VID�6H   5&       5(      �� 5)      $6 0Предыдущих владельцев нет��6F    6"   �� $ 
VFirstName�.a�5*      �� $ 	UserImage��6!    � y�$ Hidden=�6N   �� 5+      $ 	UserDefis��6!    � y�$ Hidden=�6N   �� 5,      $ UserFam��6!    � y�$ Hidden=�6L   �� 5-      $ UserID��6!    � y�$ Hidden=�6K   �� 5.      $ UserName��6!    � ��$ 	-20,0,0,0q�6I   5/      �� 51      $
 True��6B    6"   �� *VIsSelected+.a�52      �� $ UserName��6!    � ��
 �  ��6M   �� 53      $ UserFam��6!    � ��
 �  ��6L   �� 54      $ UserOtch��6!    � ��
 �  ��6M   �� 55      $ 	UserDefis��6!    � ��
 �  ��6N   �� 56      $ UserID��6!    � ��
 �  ��6K   57      59      5;      �� 5@      .R�5A   
   �� 
�������$��1q�6$   $��10q�68   ._�5B      �� $��10q�6   $
 
Horizontal=�6%   .+�5C      �� $��/BookIcon.Png��6   $��50��6/   $��10q�6;   �� 5D      .+�5E      �� $��txtTitle��6    $
��Bold"�6H   ��60   �� *VTitle+6H   �� 5F      ��6    �� *	VAuthor+�� 5G      $
 
Horizontal=�6!   .+�5H      �� $��Издательство:��6$   �� 5I      $
��10,0q�6D   ��6$   �� *VPublisherName+6D   5J      �� 5K      $
 
Horizontal=�6!   .+�5L      �� $��Адрес:��6$   �� 5M      $
��10,0q�6G   ��6$   �� *VPublisherAddress+6G   5N      �� 5O      $
 
Horizontal=�6!   .+�5P      �� $��Количество:��6$   �� 5Q      $
��10,0q�6<   ��6$   �� *VCount+6<   5R      5S      5T      5U      5V      �� 5Y      .R�5Z   
   �� 
�������$��1q�6$   $��10q�68   ._�5[      �� $��10q�6   $
 
Horizontal=�6%   .+�5\      �� $��/BookIcon.Png��6   $��50��6/   $��10q�6;   �� 5]      .+�5^      �� $
 
Horizontal=�6!   .+�5_      �� $
��Bold"�6<   ��6$   �� *VTitle+6<   �� 5`      $��
StatusBook��6$   $�� ��66   $
��Bold"�6>   
���  ��6P   5a      �� 5b      ��6    �� *	VAuthor+�� 5c      $
 
Horizontal=�6!   .+�5d      �� $��Издательство:��6$   �� 5e      $
��10,0q�6D   ��6$   �� *VPublisherName+6D   5f      �� 5g      $
 
Horizontal=�6!   .+�5h      �� $��Адрес:��6$   �� 5i      $
��10,0q�6G   ��6$   �� *VPublisherAddress+6G   5j      5k      5l      5m       5o   
   �� 5p      $
 True��6:    6   �� *VIsSelected+.a�5q      �� $ 
StatusBook��6    � ��$  - На руках��6A   5r      5t      5v      