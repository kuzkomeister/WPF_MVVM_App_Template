   M S B A M L   `   `   `  ����@  <MyWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:MyWPF.ConvertersMyWPF.Converters  5   	        MyWPF.Views.FormClientInfo   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:MyWPF.Converters     5   	     � Title$,  &Информация о клиенте��5   	    � 
ResizeMode$ NoResize=�6&    � Icon$ /UserIcon.png��5	   	   $	��450��5
   	   $	��400��6    � 	Resources 5      &   MyWPF.Converters.OffsetConverter   ListViewOffsetConverter��%   &	          5   
   6    5      .��5      � .+�5   
   �� $��30q�6   .+�5      �� 
�������$��1q�6(   ._�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� 
���   �$��1q�61   ._�5      �� $��/UserIcon.png��6    $��50��67   5      �� 5      $
��10,0q�6!   .+�5      �� $ 
Horizontal=�6%   .+�5      �� $��Фамилия:��6(   $
��Bold"�68   �� 5      $	��5,0q�6C   ��6(   �� *	VLastName+6C   5      �� 5      $ 
Horizontal=�6%   .+�5      �� $��Имя:��6(   $
��Bold"�64   �� 5      $	��5,0q�6D   ��6(   �� *
VFirstName+6D   5      �� 5       $ 
Horizontal=�6%   .+�5!      �� $��Отчество:��6(   $
��Bold"�69   �� 5"      $	��5,0q�6E   ��6(   �� *VPatronymic+6E   5#      5$      5%      5&      �� 5(      
�������$��1q�6(   $��0,10,0,0q�6<   ._�5)      �� ��6   ��  �� RelativeSource ��  �� AncestorType" � �� Path$ ActualHeight� �� 	Converter# [  	 �� ConverterParameter$
	 -175��.��5*      ��   ListViewItemClientBook#��[ 6>   $
 �� IsSynchronizedWithCurrentItem$

 TrueY�6u   ��6   �� *VBooks+6u   5+      5,      5-      5.      5/      