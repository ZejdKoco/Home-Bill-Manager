   M S B A M L   `   `   `  ����G  CBill Manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Bill_ManagerBill_Manager  5   	       Bill_Manager.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Bill_Manager     5   	     � Title$
  Main��5   	   $	��410��6   $	��700��6&   $	��410��65   $	��700��6E   .��5	      � $
��Left=�6   $	��Top=�6'   $	��370��6?   $	��690��6M    � ColumnDefinitions 5
   
   �� 5      $	��53* �6   �� 5      $	��62* �6   .+�5   
   (  "System.Windows.Controls.DatePicker  -   5          Name$ datum��5      $
��Left=�6$   $��
22,212,0,0q�6?   $	��Top=�6S   $	��216��6k      SelectedDateFormat$ Short=�6w   6�   �� 5   
   -   5         ��Name$ vrsteRacuna��5      $
��Left=�6'   $	��171��6B   $��	22,21,0,0q�6O   $	��Top=�6b   $	��216��6z   �� 5   
   -   5         ��Name$ dodajRacunButton��5      $��Add New��6+   $
��Left=�6=   $��
22,303,0,0q�6X   $	��Top=�6l   $	��216��6�   6�   �� 5   
   -   5         ��Name$ vrijednostRacunaText��5      $
��Left=�60   $��23��6K   $��
22,253,0,0q�6W    �� TextWrapping$
 Wrap=�6k   $��Cijena��6   $	��Top=�6�   $	��216��6�   6�   �� 5   
   -   5        $ dodajVrstuRacuna��5      $��Add Bill Type��6+   $
��Left=�6C   $��
278,62,0,0q�6^   $	��Top=�6r   $	��110��6�   $��2��6�   �� 5   
   -   5        $ prikazRacuna��5      $
��Left=�6(   $	��261��6C   $��	97,62,0,0q�6P   $	��Top=�6c   $	��240��6{   $��1��6�     5   
   -   5        $ datumA��5      $
��Left=�6%   $��	97,17,0,0q�6@   $	��Top=�6S   $��1��6k   6{     5   
   -   5        $ datumB��5      $
��Left=�6%   $��
235,17,0,0q�6@   $	��Top=�6T   $��1��6l   6|   �� 5   
   -	   5        $ deleteSelectedBtn��5      $��Delete Selected��6,   $
��Left=�6F   $��278,216,0,0q�6a   $	��Top=�6v   $	��110��6�   $��2��6�   6�   �� 5   
   -
   5        $ deleteAllBtn��5      $��
Delete All��6'   $
��Left=�6<   $��278,303,0,0q�6W   $	��Top=�6l   $	��110��6�   $��2��6�   6�   �� 5   
   -   5        $ deleteBufferBtn��5      $��Delete in Buffer��6*   $
��Left=�6E   $��278,261,0,0q�6`   $	��Top=�6u   $	��110��6�   $��2��6�   6�   �� 5   
   $
��Save��6   $
��Left=�6    $��278,130,0,0q�6;   $	��Top=�6P   $	��110��6h   $��2��6t   �� 5   
   -   5        $ 
LoadButton��5      $
��Load��6%   $
��Left=�64   $��278,172,0,0q�6O   $	��Top=�6d   $	��110��6|    J� RenderTransformOrigin$ 0.492,1.917&�6�   $��2��6�   6�   �� 5   
   -   5        $ dodajVrstuRacunaText��5      $
��Left=�60   $��24��6K   $��
278,17,0,0q�6W   $
 Wrap=�6k   $	��Top=�6   $	��110��6�   $��Vrsta Racuna��6�   $��2��6�   6�   �� 5   
   -   5        $ obrisiVrstuRacuna��5      $��X��6,   $
��Left=�68   $��20��6S   $��
243,21,0,0q�6_   $	��Top=�6s   $��20��6�   6�   �� 5   
   -   5        	 ��Name$	 	statusBar��5      $
��Left=�6'   $��22��6B   $��	0,348,0,0q�6N   $	��Top=�6a   $	��690��6y   $��2��6�   5      5      