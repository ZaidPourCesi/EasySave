   M S B A M L   `   `   `  ����E  AeasySaveV3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:easySaveV2
easySaveV2  5   	       easySaveV3.SavePage   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:easySaveV2     5   	     � Title$  SavePage��5   	   $	��450��6   $	��800��6'    � WindowStartupLocation$ CenterScreen=�63   .��5	      � $��Center=�6   $��Center=�6(   $��0,0,0,0q�6C   $	��800��6T   .+�5
   
   �� -   5         ��Name$ 	SaveLabel��5
      $��Center=�6(   $��0,30,0,0q�6E   $	��Top=�6W   $��30(�6o   $��	Underline{�6}   Save6�   �� 5   
   -   5         ��Name$ SourceLabel��5      $��Source path��6%   $
��Left=�6;   $��	70,80,0,0q�6V   $	��Top=�6i   $��15(�6�   �� 5   
   -   5         ��Name$ TextBoxSourcePath��5   &   
���   �$
��Left=�6A   $��25��6\   $��
80,110,0,0q�6i    �� TextWrapping$
 Wrap=�6}   $�� ��6�   $	��Top=�6�   $	��480��6�   �� 5   
   -   5        $ TargetLabel��5      $��Target path��6%   $
��Left=�6;   $��
70,140,0,0q�6V   $	��Top=�6j   $��15(�6�   �� 5   
   -   5        $ TextBoxTargetPath��5   &   
���   �$
��Left=�6A   $��23��6\   $��
80,170,0,0q�6h   $
 Wrap=�6|   $�� ��6�   $	��Top=�6�   $	��480��6�   �� 5   
   -   5        $ MirrorLabel��5      $��Mirror path��6%   $
��Left=�6;   $��
70,200,0,0q�6V   $	��Top=�6j   $��15(�6�   �� 5   
   -   5        $ TextBoxMirrorPath��5   &   
���   �$
��Left=�6A   $��23��6\   $��
80,230,0,0q�6h   $
 Wrap=�6|   $�� ��6�   $	��Top=�6�   $	��480��6�   �� 5   
   -   5        $ NameSaveLabel��5      $��Name of the save��6'   $
��Left=�6B   $��
70,260,0,0q�6]   $	��Top=�6q   $��15(�6�   �� 5   
   -	   5        $ TextBoxNameOfTheSave��5   &   
���   �$
��Left=�6D   $��23��6_   $��
80,290,0,0q�6k   $
 Wrap=�6   $�� ��6�   $	��Top=�6�   $	��480��6�   �� 5   
   -
   5         ��Name$ test01��5      $	��...��6!   $
��Left=�6/   $��580,110,0,0q�6J   $	��Top=�6_   $��40��6w   6�   �� 5   
   -   5        $ 
TargetPath��5      $	��...��6%   $
��Left=�63   $��580,170,0,0q�6N   $	��Top=�6c   $��40��6{   6�   �� 5   
   -   5        $ 
MirrorPath��5      $	��...��6%   $
��Left=�63   $��580,230,0,0q�6N   $	��Top=�6c   $��40��6{   6�   �� 5   
   -   5        $ Save_ReturnButton��5      $��Return��6,   $
��Left=�6=   $��
10,380,0,0q�6X   $	��Top=�6l   $��90��6�   $��25��6�   $��16(�6�   	� 5   
   -   5         	�Name$ MirrorSaveRadio��5      $��Mirror save��6/   $
��Left=�6E   $��220,340,0,0q�6`   $	��Top=�6u   $��18(�6�   	� 5   
   -   5        $ DifferentialSaveRadio��5      $��Differential save��65   $
��Left=�6Q   $��220,370,0,0q�6l   $	��Top=�6�   $��18(�6�   �� 5   
   -   5        $ SaveBoutton��5      $
��Save��6&   $
��Left=�65   $��530,350,0,0q�6P   $	��Top=�6e   $	��140��6}   $��35��6�   $��20(�6�   6�   5      5       