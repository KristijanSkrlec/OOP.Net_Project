   M S B A M L   `   `   `  ����T  PWinPresentationFoundation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:WinPresentationFoundationWinPresentationFoundation  5   	   -    'WinPresentationFoundation.RankingWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:WinPresentationFoundation     5   	   -   5          � Title$  Rankings��5   	   $	��600��6   $	��400��6'    � WindowStartupLocation$ CenterScreen=�6J   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��0.5* �6   �� 5      $��2* �6   �� 5      $
��0.5* �6   �� 5      $��2* �6   �� 5      $��2* �6    � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   �� -   5        $��	lbRepInfo��5      $��Center=�6!   $��0��6>   $��0��6K   $��2��6[   .��6o   Selected representation:6�   �� 5   
   -   5        $��lbRepresentation��5   3   $��1��6   $��2��6   6M   �� 5   
   -   5        $��lbInfo��5      $��Center=�6   $��2��6;   $��0��6H   $��2��6X   
���  ��.��6}   Fetching Data6�   �� 5   
   -   5        $��	lbPlayers��5   3   $��3��6   $��2��6   6F   �� 5   
   -   5        $��btnRankGoals��5      $��4��6%   $��45��62   $	��150��6>   $	��Top=�6J   $��25q�6b   .��6�   Rank By Goals Scored6�   �� 5   
   -   5        $��btnRankYellow��5      $��4��6&   $��45��63   $	��150��6?   $��Bottom=�6K   $��25q�6f   .��6�   Rank By Yellow Cards6�   �� 5   
   -   5        $��pbPlayer��5      $��4��6    $��1��6-   $��20q�6=   $��Uniform=�6I   $��Resources/NoImage.png��6[   6|   5!      5"      