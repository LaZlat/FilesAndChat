   M S B A M L   `   `   `  ����G  CFilesAndChat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:FilesAndChat.ViewsFilesAndChat.Views  5   	   +clr-namespace:FilesAndChatFilesAndChat  68   *    $FilesAndChat.Views.ApplicationWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:FilesAndChat.Views     5   	   -local1clr-namespace:FilesAndChat     68     � Title$  Chat and Files share��5   	   $��512.8��6&   $��819.2��65    � 	Resources 5	      $  FilesAndChat.BadWordsConverter   BadWordsConverter  roundbutton �� 
TargetType A�Name �� Triggers P� Property P� Value �� 
TargetName �� Property	 �� Value��%_  &	        &	        5
   
   6#   �� 5   
   " ��6.   .R�5      � .+�5      A� $ backgroundElement��6   #��z��65   #��z��6Y   �� 5      $��Center=�6#   $��Center=�6@   5       5      P� 5       �@J�IsMouseOver . . �5      �� $ backgroundElement��6-    � ��
	 �����6L   5      5      5      
 J� InputBindings
 5      �� 5   
    �� Gesture$ Enter��5       �� Command 5      �� *SendCommand+5      .��5      � ���#1687a7 � RowDefinitions 5   
   �� 5      $��50 �6   6*   �� 5      $��* �6   6)   .+�5    
   �� $��0,5,0,0q�6    �� Orientation$ 
Horizontal=�6&   $��Right=�6?   .+�5!      �� $
��Left=�6   $��Bottom=�6/   $��18(�6J   
�������  Labs#��[ 6�   ��6k   �� *
Username+6�   �� 5"      $
��Left=�6   $��45��60   $��45��6;   #��[ 6�   ��6G   �� *LogOffCommand+��6i   ��  �� RelativeSource �� *FindAncestor+ �� AncestorType$ WindowL�.��6�   	Log off6�   5#      �� 5$   
   $��1��6   $��Center=�6"   $��
0,10,0,-10q�6F   .@�5%      �� $��Files��6   .��5'      � ���	#FFE5E5E5 � ColumnDefinitions 5(      �� 5)      $	��51* �6+   �� 5*      $
��353* �6+   �� 5+      $
��403* �6+    5-      �� 5.      $��50 �6(   66   �� 5/      $��* �6(   65   �� 50      $	��100 �6(   67   .+�53      �� $��Your files:��6   $��18(�63   $��2��6A   $��0,0,0,265.2q�6U   $��2��6j   #��[ 6{   �� 54      $��1��6    $��0,0.4,20,0.2q�6L   $��2��6b   ��6.   �� *Files+ �� View 55      �� 56      .P�57   "   �� $��	File name��6[    �� DisplayMemberBinding 61   �� *
FileName+6[   �� 58   "   $��	File path��6[    61   �� *
FilePath+6[   �� 59   "   $��Remove��61    �� CellTemplate 5:   &   �� 5;   *   .R�5<   .   �� $��Delete��5>   R   ��5<   5   �� *DataContext.DeleCommand+ �� $ ListViewL���5>   5   �� 6R   5?   +   5A   #   5B      5D      �� 5E      $	��Top=�6!   $��2��69   $ 
Horizontal=�6F   $��	0,9.8,0,0q�6_   $��2��6r   .+�5F      �� $	��100��6"   $��5,0,0,0q�6�   ��6.   �� *
FilePath+ �� UpdateSourceTrigger$ PropertyChanged=� �� ValidatesOnDataErrors . 6�   �� 5G      $	��5,0q�6C   ��6!   �� *ChooseCommand+.��6P   	Choose...6[   �� 5H      $	��5,0q�6@   ��6!   �� *
AddCommand+.��6M   Add6R   5I      �� 5J      $��2��6   $��Files from other people:��6,   $��18(�6O   $��0,0,0.2,265.2q�6]   $��2��6t   #��[ 6�   �� 5K      $��2��6   $��1��6/   $��0,0.4,0.2,0.2q�6\   ��6<   �� *	Friends+ 5L      �� 5M      .P�5N   "   �� $��Username��6[    61   �� *
Username+6[   �� 5O   "   $��	File name��6[    61   �� *
FileName+6[   5P      5R      5S      5T      �� 5U      $
��Chat��6   .��5V      � ���	#FFE5E5E5 5W      �� 5X      $	��270 �6+   �� 5Y      $��* �6+   .+�5\      � $��1��6    5]      �� 5^      $��* �6,   �� 5_      $��60 �6,   .+�5b      �� ��6"   �� *Chat+�� 5c      $��1��6%   $ 
Horizontal=�62   $��Center=�6K   $��20q�6h   .+�5d      �� $	��400��6'   ��63   �� *	Message+$ PropertyChanged=� �� 	Converter# [   . �� 5e      $��5,0,0,0q�6F   ��6&   �� *SendCommand+.��6W   Send6]   5f      5h      �� 5j      ��6   �� *	Friends+ 5k      �� 5l      .P�5m   "   �� $��Friend��6[    61   �� *
Username+6[   5n      5p      5q      5r      5s      5t      5u      