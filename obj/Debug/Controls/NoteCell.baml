   M S B A M L   `   `   `  ����D  @Note-Tote, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Note_Tote.ControlsNote_Tote.Controls  5      !    Note_Tote.Controls.NoteCell   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:Note_Tote.Controls     5      $	��200��5      $	��200��6   .��5
      �� 
�������$��3q�6"     �� CornerRadius$  8��66   
���   � �� Padding$ 4q�6[   $��4q�6g   ._�5   
   �  � RowDefinitions 5      �� 5      $	��.5* �6    �� 5      �� 5      �� 5      .+�5      �� -   5         ��Name$ CellNum��5      $��0��5      $	��Top=�5      $
��Left=�5       K� ZIndex$ 10��5      $��10��5      $��15(�5      �� 5       -   5         ��Name$ 	UpdateBtn��5"      $��0��5!      $��🖍️��5#      $	��Top=�5$      $��Right=�5%      $ 10��5&      $��12(�5'      $��0q�5(      
������ 5)      �� 5+      -   5        $ 	DeleteBtn��5-      $��0��5,      $��🗑️��5.      $	��Top=�5/      $��Right=�50      $��0,0,20,0q�51      $ 10��52      $��12(�53      
������ $��0q�55      56      �� 59      -   5        $ NoteNameTxt��5:      $��1��5;      $#��Note nemaa;lkjfgnva;sdlfnvga;��5<      $��15(�5=      $
��Wrap=�5>      $��CharacterEllipsis=�5?       �� LineStackingStrategy$ BlockLineHeight=�5@       �� 
LineHeight$ 15��5A      $��32��5B      �� 5E      -   5        $ NoteDescTxt��5F      $��2��5G      $��10(�5H      $����;alkgnva;vlknna;gboaer;gblnas;ghbnfd;ghblnjfe;gbns;fgnbs;egnjs;erna;lgvjnka;glna;g;alnvk;zlng;rlkjgnlzjknilgkfdnblksdhblshjbglksa��5I      $
��Wrap=�5J      $��CharacterEllipsis=�5K      $ BlockLineHeight=�5L      $ 10��5M      $��34��5N      � 5Q      $��3��6    � ColumnDefinitions 5R      �� 5S      �� 5T      .+�5V      �� $��0��6   $	��.75q�6)   
���   �$��0q�6S   $ 0q�6^   $  3��6j   ._�5W      �  5X      �� 5Y      �� 5Z      .+�5\      �� -   5        	 ��Name$	 StartDateLabel��5]      $	��Top=�5^      $��10(�5_      $��0��5`      $��
Start Date��5a      �� 5c      -   5        $ StartDateTxt��5d      $��1��5e      $��Bottom=�5f      $��10(�5g      
 �� Padding$
 3q�5h      $��
01/27/1994��5i      5k      5m      �� 5n      $��1��6   $	��.75q�6)   
���   �$  3��6S   ._�5o      �  5p      �� 5q      �� 5r      .+�5t      �� -   5        $	 DueDateLabel��5u      $	��Top=�5v      $��10(�5w      $��0��5x      $��Due Date��5y      �� 5{      -	   5        $ 
DueDateTxt��5|      $��Bottom=�5}      $��1��5~      $��10(�5      $
 3,1,3,1q�5�      $��
01/27/1994��5�      5�      5�      5�      5�      5�      5     