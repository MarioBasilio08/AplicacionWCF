   M S B A M L   `   `   `  ���� I  ECRUD.ViewModel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG4clr-namespace:CRUD.ViewModel;assembly=CRUD.ViewModelCRUD.ViewModel  D @CRUD.View, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:CRUD.View	CRUD.View    CRUD.View.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  =vm4clr-namespace:CRUD.ViewModel;assembly=CRUD.ViewModel  _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  #localclr-namespace:CRUD.View    � Title$  
MainWindow��$	��450��$	��800�� � 	Resources "   CRUD.ViewModel.MainViewModel   MainViewModel��%   &	          .���  � DataContext ��  �� Source# [   � ColumnDefinitions �� $��* ��� $��2* � � RowDefinitions �� $��* ��� $��3* �.+�� $��0��$��0��
����ح�.+��  � Cursor$  �� �� $��* ��� $��3* � �� $��* ��� $��* �.+��� $��0��$��0��$	��Id:��$��Center=�$��Center=��� $��1��$��0��$��Edad:��$��Center=�$��Center=��� -    ��Name$ TextId��$��0��$��1��$��Center=� �� TextWrapping$
 Wrap=�$��Center=�$	��120��)  #MaterialDesignThemes.Wpf.HintAssist	   Hint$	 0��$  ������ *Id+
 �� UpdateSourceTrigger$
 PropertyChanged=�{��� *IsTextBoxEnabled+�� -   $ TextAge��$��1��$��1��$��Center=�$
 Wrap=�$��Center=�$	��120��$	 18������ *Age+$
 PropertyChanged=�� $��1��$��0��
�������.+��  �� $��* ��� $��4* � �� $��* ��� $��* �.+��� $��0��$��0��$��Nombre:��$��Center=�$��Center=��� $��1��$��0��$��Email:��$��Center=�$��Center=��� -   $ TextName��$��0��$��1��$��Center=�$
 Wrap=�$��Center=�$	��360��$	 Andrés Basilio������ *Name+$
 PropertyChanged=��� -   $ 	TextEmail��$��1��$��1��$��Center=�$
 Wrap=�$��Center=�$	��360��$	 andres.basilio@outlook.es��$  ������ *Email+$
 PropertyChanged=�� $��0��$��1��$��2��
������ �� $��3* ��� $	��.8* �.+�&   System.Windows.Controls.DataGrid  -     Name$ 	dgPersons��   AutoGenerateColumns .     CanUserAddRows .     
IsReadOnly . ���� *Lista+ �� SelectedItem �� *SelectedPerson+*  $Microsoft.Xaml.Behaviors.Interaction   Triggers +  %Microsoft.Xaml.Behaviors.EventTrigger     	EventName$ MouseDoubleClick��*  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command �� *DoubleClickCommand+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,	  &System.Windows.Controls.DataGridColumn 	  Header$ ID�� 	  Width5
  /System.Windows.Controls.DataGridLengthConverter$ *
 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
EmployeeID+  $ Nombre��$ 4*
  �� *EmployeeName+  $
 Edad��$ *
  �� *Age+  $ Email��$ 4*
  �� *Email+� $��1�� �� $��* ��� $��* ��� $��* �.+��� -    ��Name$ BGuardar��$��0��$��Center=�$��Center=����� *SaveCommand+.����  �� Orientation$ 
Horizontal=�$��Center=�.+�'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ ContentSave=�$��0,0,5,0q��� $��Guardar���� -   $ BNuevo��$��1��$��Center=�$��Center=����� *
NewCommand+.���� $ 
Horizontal=�$��Center=�.+�  $ NewBox=�$��0,0,5,0q��� $��Nuevo���� -   $ 	BEliminar��$��2��$��Center=�$��Center=����� *DeleteCommand+{��� *IsButtonEnabled+.���� $ 
Horizontal=�$��Center=�.+�  $ Delete=�$��0,0,5,0q��� $��Eliminar��