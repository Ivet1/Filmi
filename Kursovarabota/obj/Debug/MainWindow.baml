   M S B A M L   `   `   `  ����  Kursovarabota#    GeometricShapesApp.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Geometric Shapes Drawer��5   	   $	��400��6)   $	��596��66   .��5      �� -   5         ��Name$ GeometricShapesApp��5      $��10q�6-    � Cursor$ IBeam��69   ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ Black��6   � 5	      $ 	#FF3D56BB��6    � Offset$ 1Q�61   5
      .+�5   
   �� -   5         ��Name$ ShapeSelector��5      $	��277��6*   $��25��66   .@�5      �� $��	Rectangle��6   �� 5      $��Circle��6   �� 5      $��Triangle��6   5      �� 5   
   -   5         ��Name$ 
Parameter1��5      $	��277��6&   $��25��62   $��Width / Radius��6>   �� 5   
   -   5        $ 
Parameter2��5      $	��277��6&   $��25��62   $��Height (for Rectangle)��6>   �� 5   
   -   5        $ ColorSelector��5      $	��277��6*   $��25��66   ��6B   Z� .@�5      �� $	��Red��6   �� 5      $��Green��6   �� 5      $
��Blue��6   �� 5      $��Yellow��6   �� 5      $��Black��6   �� 5      $��White��6   5      �� 5   
   -   5        	 ��Name$	 
DrawButton��5      $��
Draw Shape��6%   $	��277��6:   $��30��6F   6R   �� 5!   
   -   5        $	 ClearButton��5!      $��Clear��6&   $	��277��66   $��30��6B   
 J� RenderTransformOrigin$
 0.5,0.5&�6h   z�5"      V� 5#      .~�5$      �� �� 5%       �� AngleY$ 0Q�6$   �� 5&      T� 5'       T� Y$ 0Q�6)   5(      5*      �� 5,   
   -   5         ��Name$ ShapeContainer��5,      $	��300��6)   $	��200��65   
�������
�������$��1q�5-   $   $��Center=�68   $��Center=�5.      5/      50      