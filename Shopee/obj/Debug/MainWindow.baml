   M S B A M L   `   `   `  ����A  =Shopee, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ShopeeShopee  5   	       Shopee.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Shopee     5   	     � Title$  
MainWindow��5   	   $	��450��6   $
��1200��6)   .��5	      � .+�5
   
   �� .@�5      �� $��Tab 1��6   .��5      �  � RowDefinitions 5      �� 5      $��2* �6(   �� 5      $
��Auto �6(   �� 5      $��* �6(   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ dataGridTab1��5   <   $��0��6   $��0��6/      AutoGenerateColumns .     CanUserAddRows .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Devices��61      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6r   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6B   �� 	 �� Path$	 	DevicesID�
 �� Mode$
 TwoWay=�6r     5      $
 User��61   $ * 6o    6?   �� $	 	UserGmail�$
 TwoWay=�6o     5      $ Password��61   $ * 6w    6C   �� $	 PasswordGmail�$
 TwoWay=�6w     5      $ Status��61   $ * 6n    6A   �� $	 Status�$
 TwoWay=�6n     5      $ cookie��61   $ * 6n    6A   �� $	 Cookie�$
 TwoWay=�6n     5      $
 okok��61   $ * 6j    6?   �� $
	 OKOK�$
 TwoWay=�6j   5!      �� 5&       �� Orientation$ 
Horizontal=�6!   $��1��6:   $��Center=�6G   $��Center=�6d   $��10q�6   .+�5'      �� -   5        $��Start��5'   !   $��80��6F   $��5q�6Q   �� 5(      -   5        $��Skip setup google��5(   !   $	��120��6T   $��5q�6`   �� 5)      -   5        $��Backup��5)   !   $��80��6H   $��5q�6S   �� 5*      -   5        $��	Pull file��5*   !   $��80��6K   $��5q�6V   �� 5+      -   5        $��Format data��5+   !   $��80��6M   $��5q�6X   �� 5,      -   5        $��Backup2��5,   !   $��80��6J   $��5q�6U   �� 5-      -   5        $��Restore2��5-   !   $��80��6K   $��5q�6V   �� 5.      -	   5        $��
GetLinkImg��5.   !   $��80��6N   $��5q�6Y   �� 5/      -
   5        $��	GetCookie��5/   !   $��80��6M   $��5q�6X   �� 50      -   5        $��GetData��50   !   $��80��6K   $��5q�6V   51      �� 53      $ 
Horizontal=�6!   $��2��6:   $��Center=�6G   $��Center=�6d   $��10q�6   .+�54      �� -   5        $��	GetCookie��54   !   $��80��65   $��5q�6@   6K   �� 55      -   5        $��GetNoti��55   !   $��80��63   $��5q�6>   6I   57      �� 58      -   5        $��Tạo file login��58      $
��Left=�66   $��	692,0,0,0q�6Q   $��2��6d   $��Center=�6q   6�   �� 59      -   5        $��upImg��59      $
��Left=�6-   $��	784,0,0,0q�6H   $��2��6[   $��Center=�6h   6�   �� 5:      -   5        $��Button��5:      $
��Left=�6.   $��	842,0,0,0q�6I   $��2��6\   $��Center=�6i   6�   �� 5;      -   5         ��Name$
 tbID��5;   }   $
��Left=�6   $��
369,57,0,0q�69   $��2��6M    �� TextWrapping$
 Wrap=�6Z   $��TextBox��6n   $	��Top=�6�   $	��120��6�   5<      5>      �� 5@      $��Tab 2��6   .��5A      �  5B      �� 5C      $��* �6(   �� 5E      $
��Auto �6(   .+�5J        -   5        $ dataGridTab2��5J       .   .  $��0��6h   ��5K      �� *	FileItems+ 5L        5N      $
 Path��61   $ * 6X    6?   �� *Path+6X     5P      $ Status��61   $ * 6\    6A   �� *Status+6\   4  .System.Windows.Controls.DataGridTemplateColumn  5S      $ Button��65   $	 100 6E      CellTemplate 5T   "   �� 5U   &   .R�5V   *   �� $��Select Phone��61   ��5W   %   �� * DataContext.ShowDetailsCommand+ �� RelativeSource ��  �� AncestorType$ DataGridL���5X   %   �� 5Y   '   5[        5\      $ Rename Folder��65   $	 100 6L    5]   "   �� 5^   &   .R�5_   *   �� $��Rename��61   ��5`      �� *!DataContext.RenameFolderCommand+ �� $ DataGridL���5a      �� 5b   '   5d        5e      $ 	Add proxy��65   $	 100 6H    5f   "   �� 5g   &   .R�5h   *   �� $��Select Proxy��61   ��5i   
   �� *DataContext.ShowProxyy+ �� $ DataGridL���5j   
   �� 5k   '   5m      5o      �� 5r      -   5        $��Hiển thị thư mục��5r      $��1��68   $
��Left=�6E   $��291,10,0,10q�6`   6u   �� 5u      -   5        $��Restore��5u      $��1��6/   $
��Left=�6<   $��434,10,0,10q�6W   6l   �� 5v      -   5        $ tbPath��5v      $
��Left=�6.   $��	10,10,0,0q�6I   $��1��6\   $
 Wrap=�6i   $+��%D:\Shopee_account\Fox\BACKUPS\2f1c7d5��6}   $	��Top=�6�   $	��276��6�   5x      5y      5}      5~      5      