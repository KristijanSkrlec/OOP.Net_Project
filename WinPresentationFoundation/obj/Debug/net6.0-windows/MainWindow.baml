   M S B A M L   `   `   `  ����T  PWinPresentationFoundation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:WinPresentationFoundationWinPresentationFoundation  5   	   *    $WinPresentationFoundation.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:WinPresentationFoundation     5   	   -   5          � Title$  	Main Menu��5   	   $	��400��6   $	��600��6(    � WindowStartupLocation$ CenterScreen=�6K   .��5	      �  � RowDefinitions 5
   
   �� 5      $��* �6   �� 5      $��2* �6   �� 5      $��2* �6    � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   �� -   5        $��lbAllPlayers��5   g   $��Center=�6   $��Center=�6-   $��1��6J   $��0��6W   6!  �� 5   
   -   5        $��lbFavPlayers��5      $��Center=�6   $��Center=�6-   $��0��6J   $��1��6W   $��65��6g   $	��215��6s   69  �� 5   
   -   5        $��lbInfo��5      $��Center=�6   $��Center=�69   $
��Bold"�6V   
���  ��$��0��6y   $��2��6�   .��6�   Fetching Data6�   �� 5   
   -   5        $��pbPlayer��5      $��1��6    $��1��6-   6?   �� 5   
   -   5        $��btnRankings��5      $��2��6$   $��2��61   $��50��6A   $��75��6M   $��15q�6X   $��Center=�6d   $
��Left=�6   .��6�   
Rankings6�   �� 5   
   -   5        $��
btnLineups��5      $��2��6#   $��2��60   $��50��6@   $��75��6L   $��15q�6W   $��Center=�6c   $��Center=�6~   .��6�   	Lineups6�   �� 5   
   -   5        $��btnSettings��5      $��2��6$   $��2��61   $��50��6A   $��75��6M   $��15q�6X   $��Center=�6d   $��Right=�6   .��6�   
Settings6�   5       5!      