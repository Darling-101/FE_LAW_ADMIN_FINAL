   M S B A M L   `   `   `  ����M  IFE_ADMIN_LAW_FINAL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:FE_LAW_FINALFE_LAW_FINAL  5   	       FE_LAW_FINAL.LoginWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   
   &localclr-namespace:FE_LAW_FINAL  5   	   -   5           MaterialDesignBody#���   5      $��Regular"�5      $��13(�5	      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5
         TextRenderingMode$
 Auto=�5        MaterialDesignPaper#���  5        MaterialDesignFont#���  5        LoginVM � DataContext# [ 5   	    � Title$ Login Window��5   	   $	��530��6   $	��510��6+    � 
ResizeMode$ NoResize=�5   	   .��5      � ��5   
   �� 5       �� ImageSource$ /bg_login.jpg��6   .+�5   
   � $	��242��6   $	��332��6   .+�5      �� -   5         ��Name$ username��5   �   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Tên đăng nhập��6   $��1q�6E   
������
������� �� TextWrapping$
 Wrap=�6�   $��0,117,0,183q�6�   $��Center=�6�   $��14(�6�   �� 5      -   5        $ visiblePassword��5   �   $ Mật khẩu��6   $��1q�6@   
������
�������$
 Wrap=�6�   $��0,165,0,135q�6�   $��Center=�6  $��14(�6&  $y�Hidden=�64  G� 5      -   5        	 G�Name$	 password��5   �   $ Mật khẩu��6   $��2q�6D   $��Center=�6s   
 G� PasswordChar$
 *��6�   
�������
������$��	0,166,0,0q�6�   $	��Top=�6�   $	��242��6	  $y�Visible=�6  $��31��6*  $��Center=�66  $��14(�6X  �� 5      -   5         ��Name$ showPassword��5   &    � Cursor$
 Hand��6   $��Hiển thị mật khẩu��6<   
�������$
��Left=�6k   $��	7,214,0,0q�6�   $	��Top=�6�   6�   5      �� 5   
   $��Đăng nhập��6   
�������$��Center=�67   $��	0,130,0,0q�6T   $	��Top=�6g   $
��Bold"�6   $��24(�6�   �� 5   
   $��LAW88��6   
�������$��Center=�63   $��0,27,0,0q�6P   $	��Top=�6b   $
��Bold"�6z   $��36(�6�   $��64��6�   $	��137��6�   $
|�True��6�   ��6�   Z� 6�   �� 5!   
   -   5        $��Đăng nhập��5!      $
 Hand��6%   $��Center=�63   
������
�������$��	0,337,0,0q�6{   $	��Top=�6�   $	��242��6�   $��44��6�   $��16(�6�   $
��Bold"�6�   6�   5#      5$      