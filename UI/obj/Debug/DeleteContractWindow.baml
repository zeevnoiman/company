   M S B A M L   `   `   `  ����=  9UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:UIUI  5   	       UI.DeleteContractWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   "localclr-namespace:UI     5   	     � Title$  Delete a contract:��5   	   $	��550��6$   $	��497��61   $	��550��6=   $	��500��6M   ���	#FF191616��5	      �� 5
   
    �� EndPoint$ 0.5,1&�6    �� 
StartPoint$ 0.5,0&�6/   .��5      �  � Color$ Black��6    � Offset$ 0Q�6)   � 5      $ 	#FF0A4DDC��6   $ 0.687Q�6-   5      .��5      �  J� RenderTransformOrigin$ 0.569,0.352&�6   .+�5   
   �� -   5         ��Name$ boxContractNumber��5      $
��Left=�6-   $��23��6H    �� TextWrapping$
 Wrap=�6T   $�� ��6h   $	��Top=�6p   $	��120��6�   $��
131,71,0,0q�6�    �� 
IsReadOnly . 6�   �� 5   
   -   5        $ boxEmployerID��5      $
��Left=�6)   $��23��6D   $
 Wrap=�6P   $�� ��6d   $	��Top=�6l   $	��120��6�   $��131,110,0,0q�6�    . 6�   �� 5   
   -   5        $ boxEmployeeID��5      $
��Left=�6)   $��23��6D   $
 Wrap=�6P   $�� ��6d   $	��Top=�6l   $	��120��6�   $��131,146,0,0q�6�    . 6�   �� 5   
   $��14(�6   $	��Top=�6"   $
��Left=�6:   ���	#FF80FF00$��	Underline{�6l   $��10,23,-10,446q�6�   Contract details:6�   �� 5   
   -   5        	 ��Name$	 labelContractNumber��5      $��Contract Number:��6-   ���	#FF00FFF3$
��Left=�6_   $	��Top=�6z   $��0,71,0,0q�6�   $��12(�6�   $ 2.144,0.477&�6�   �� 5   
   -   5        $	 labelEmployerID��5      $��Employer ID:��6)   ���	#FF00FFF3$
��Left=�6W   $	��Top=�6r   $��	1,107,0,0q�6�   $��12(�6�   $ 2.144,0.477&�6�   �� 5   
   -   5        $	 labelEmployeeID��5      $��Employee ID:��6)   ���	#FF00FFF3$
��Left=�6W   $	��Top=�6r   $��	1,143,0,0q�6�   $��12(�6�   $ 2.144,0.477&�6�   �� 5   
   -   5        $	 labelContracts��5      $��All contracts:��6(   ���	#FF80FF00$
��Left=�6X   $	��Top=�6s   $��
295,18,0,0q�6�   $��14(�6�   $ 2.144,0.477&�6�   �� 5   
   -   5        
 ��Name$
 labelDeleteContract��5      $��Delete contract��6.   $
��Left=�6H   $��Center=�6c   $	��120��6~   $��174,457,0,37q�6�   $ 
-0.08,0.65&�6�   $��25��6�   ���	#FFA2B8F1
������� � Cursor$	 Pen��6  �� 5   
   -	   5        $
 closeButton��5      $��Close��6&   $
��Left=�66   $��Center=�6Q   $	��100��6l   $��337,440,0,20q�6x   $ 
-0.08,0.65&�6�   $��25��6�   ���	#FFA2B8F1
�������6�   �� 5   
   -
   5         ��Name$ listBoxContracts��5      $
��Left=�6,   $	��303��6G   $	��Top=�6T   $	��152��6l   $��
295,49,0,0q�6x   ���	#FFABF0E66�   5      5      