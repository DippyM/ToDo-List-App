   M S B A M L   `   `   `  ����  todolist    TodoApp.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  
MainWindow��5   	   $	��500��6   $	��800��6)   .��5      � .+�5   
   �� -   5         ��Name$ 	TodoInput��5      $��Zadej úkol��5      
�������$
��Left=�5
      $��23��6-   $��	10,10,0,0q�5      $	��Top=�6%   $	��200��6=   5      �� 5   
   -   5        $ TodoDescription��5      $��Popis úkolu��5      
�������$
��Left=�5      $��50��6-   $��	10,40,0,0q�5      $	��Top=�6%   $	��330��6=   5      (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ DueDatePicker��5      $
��Left=�5      $��
220,10,0,0q�5      $	��Top=�5      $	��120��5         SelectedDateFormat$
 Long=�5      �� 5"   
   -   5        $��Přidat��5"      $
��Left=�6"   $	��Top=�6=   $��75��6U   $��
350,10,0,0q�6`   6t   �� 5#   
   -   5        $��Označit jako hotové��5#      $
��Left=�6/   $	��Top=�6J   $	��150��6b   $��
350,50,0,0q�6n   6�   �� 5$   
   -   5        $��	Odstranit��5$      $
��Left=�6%   $	��Top=�6@   $��75��6X   $��
350,90,0,0q�6c   6w   �� 5'   
   -   5         ��Name$ TodoListBox��5'      $
��Left=�5(   
   $	��358��5)   
   $��
10,100,0,0q�5*   
   $	��Top=�5+   
   $	��330��5,   
    �� SelectionMode$ Single=�5-   
   5/   
   �� 53   
   $��Hotové úkoly��6   $
��Left=�6'   $	��Top=�6B   $��
475,74,0,0q�6Z    J� RenderTransformOrigin$ 0.186,0.618&�6n   R� 54   
   -   5         R�Name$ CompletedTreeView��54      $
��Left=�55      $	��357��56      $��475,101,0,0q�57      $	��Top=�58      $	��300��6+   67   59      5:      