   M S B A M L   `   `   `  ����=  9UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:UIUI  5   	   #    UI.DeleteSpecializationWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   "localclr-namespace:UI     5   	     � Title$  Delete a specialization:��5   	   $	��550��6*   $	��497��67   $	��550��6C   $	��500��6S   ���	#FF191616��5	      �� 5
   
    �� EndPoint$ 0.5,1&�6    �� 
StartPoint$ 0.5,0&�6/   .��5      �  � Color$ Black��6    � Offset$ 0Q�6)   � 5      $ 	#FF0A4DDC��6   $ 0.687Q�6-   5      .��5      �  J� RenderTransformOrigin$ 0.569,0.352&�6   .+�5   
   �� -   5         ��Name$ boxSpecName��5      $
��Left=�6'   $��23��6B    �� TextWrapping$
 Wrap=�6N   $�� ��6b   $	��Top=�6j   $	��120��6�   $��
131,71,0,0q�6�   �� 5   
   -   5        $ boxSpecNumber��5      $
��Left=�6)   $��23��6D   $
 Wrap=�6P   $�� ��6d   $	��Top=�6l   $	��120��6�   $��131,110,0,0q�6�   �� 5   
   -   5        $ boxField��5      $
��Left=�6$   $��23��6?   $
 Wrap=�6K   $�� ��6_   $	��Top=�6g   $	��120��6   $��131,146,0,0q�6�   �� 5   
   $��14(�6   $	��Top=�6"   $
��Left=�6:   ���	#FF80FF00$��	Underline{�6l   $��10,23,-10,446q�6�   Specialization details:6�   �� 5   
   -   5         ��Name$ labelSpecName��5      $��Specialization name:��6'   ���	#FF00FFF3$
��Left=�6]   $	��Top=�6x   $��0,71,0,0q�6�   $��12(�6�   $ 2.144,0.477&�6�   �� 5   
   -   5        $ labelSpecNumber��5      $��Specialization number:��6)   ���	#FF00FFF3$
��Left=�6a   $	��Top=�6|   $��	1,107,0,0q�6�   $��12(�6�   $ 2.144,0.477&�6�   �� 5   
   -   5        $ labelSpecField��5      $��Field:��6(   ���	#FF00FFF3$
��Left=�6P   $	��Top=�6k   $��	1,143,0,0q�6�   $��12(�6�   $ 2.144,0.477&�6�   �� 5   
   -   5        $ labelAllSpecs��5      $��All  specializations��6'   ���	#FF80FF00$
��Left=�6]   $	��Top=�6x   $��
295,18,0,0q�6�   $��14(�6�   $ 2.144,0.477&�6�   �� 5   
   -   5        	 ��Name$	 
deleteSpec��5      $��Delete specialization��6%   $
��Left=�6E   $��Center=�6`   $	��120��6{   $��174,457,0,37q�6�   $ 
-0.08,0.65&�6�   $��25��6�   ���	#FFA2B8F1
�������
 � Cursor$	
 Pen��6  �� 5   
   -	   5        $	 closeButton��5      $��Close��6&   $
��Left=�66   $��Center=�6Q   $	��100��6l   $��337,440,0,20q�6x   $ 
-0.08,0.65&�6�   $��25��6�   ���	#FFA2B8F1
�������6�   �� 5   
   -
   5         ��Name$ listBoxSpecs��5      $
��Left=�6(   $	��303��6C   $	��Top=�6P   $	��152��6h   $��
295,49,0,0q�6t   ���	#FFABF0E66�   5      5      