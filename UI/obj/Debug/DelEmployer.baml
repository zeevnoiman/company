   M S B A M L   `   `   `  ����=  9UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:UIUI  5   	       UI.DelEmployer   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   "localclr-namespace:UI     5   	     � Title$  Delete an Employer:��5      $	��516��6'   $	��497��64   $	��450��6@   $	��500��6P   ���	#FF191616��5	      �� 5
   
    �� EndPoint$ 0.5,1&�6    �� 
StartPoint$ 0.5,0&�6/   .��5      �  � Color$ Black��6    � Offset$ 0Q�6)   � 5      $ 	#FF0A4DDC��6   $ 0.687Q�6-   5      .��5      �  J� RenderTransformOrigin$ 0.569,0.352&�6   .+�5   
   �� -   5         ��Name$ employerNameBox��5      $
��Left=�6+   $��23��6F    �� TextWrapping$
 Wrap=�6R   $�� ��6f   $	��Top=�6n   $	��120��6�   $��	82,71,0,0q�6�    �� 
IsReadOnly . 6�   �� 5   
   -   5        $ employerLastNameBox��5      $
��Left=�6/   $��23��6J   $
 Wrap=�6V   $�� ��6j   $	��Top=�6r   $	��120��6�   $��
82,110,0,0q�6�    . 6�   �� 5   
   -   5        $ employerIDBox��5      $
��Left=�6)   $��23��6D   $
 Wrap=�6P   $�� ��6d   $	��Top=�6l   $	��120��6�   $��
82,148,0,0q�6�    . 6�   �� 5   
   $��14(�6   $��Center=�6"   ���	#FF80FF00$��	Underline{�6U   $��10,23,-10,446q�6q   Employer details:6�   �� 5   
   -   5        	 ��Name$	 employerNameLabel��5      $��First name:��6+   ���	#FF00FFF3$
��Left=�6X   $	��Top=�6s   $��	10,73,0,0q�6�   $��12(�6�   $ 2.144,0.477&�6�   �� 5   
   -   5        $	 employerLastNameLabel��5      $��
Last name:��6/   ���	#FF00FFF3$
��Left=�6[   $	��Top=�6v   $��
10,110,0,0q�6�   $��12(�6�   $ 2.144,0.477&�6�   �� 5   
   -   5        $	 employerIDLabel��5      $	��ID:��6)   ���	#FF00FFF3$
��Left=�6N   $	��Top=�6i   $��
10,148,0,0q�6�   $��12(�6�   $ 2.144,0.477&�6�   �� 5   
   -   5        $	 employerListLabel��5      $��All employers ID:��6+   ���	#FF80FF00$
��Left=�6^   $	��Top=�6y   $��
295,18,0,0q�6�   $��14(�6�   $ 2.144,0.477&�6�   �� 5   
   -   5        
 ��Name$
 deleteEmployer��5      $��Delete employer��6)   $
��Left=�6C   $��Center=�6^   $	��100��6y   $��194,440,0,20q�6�   $ 
-0.08,0.65&�6�   $��25��6�   ���	#FFA2B8F1
������� � Cursor$	 Pen��6  �� 5   
   -	   5         ��Name$ employersListBox��5      $
��Left=�6,   $	��303��6G   $	��Top=�6T   $	��152��6l   $��
295,49,0,0q�6x   ���	#FFABF0E66�   5      5      