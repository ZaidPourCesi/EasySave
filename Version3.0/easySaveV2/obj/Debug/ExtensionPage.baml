   M S B A M L   `   `   `  ����E  AeasySaveV3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:easySaveV2
easySaveV2  5   	       easySaveV3.ExtensionPage   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:easySaveV2     5   	     � Title$  ExtensionPage��5   	   $	��450��6   $	��800��6,    � WindowStartupLocation$ CenterScreen=�68   .��5	      � .+�5
   
   �� -   5         ��Name$ ExtensionLabel��5
      $��Center=�6,   $��0,30,0,0q�6I   $	��Top=�6[   $��30(�6s   $��	Underline{�6�   	Extension6�   �� 5   
   -   5         ��Name$ extPrioList��5      $
��Left=�6'   $	��110��6B   $��
80,110,0,0q�6O   $	��Top=�6c   $	��300��6{   6�   �� 5   
   -   5        $ 
extBanList��5      $
��Left=�6&   $	��110��6A   $��
79,250,0,0q�6N   $	��Top=�6b   $	��300��6z   6�   �� 5   
   -   5         ��Name$ RefreshExtensionButton��5      $��Refresh��61   $
��Left=�6C   $��
541,73,0,0q�6^   $	��Top=�6r   $��75��6�   6�   �� 5   
   -   5        $ Etension_ReturnButton��5      $��Return��60   $
��Left=�6A   $��
10,380,0,0q�6\   $	��Top=�6p   $��90��6�   $��25��6�   $��16(�6�   �� 5   
   -   5        $ 
addExtPrio��5      $	��Add��6%   $
��Left=�63   $��596,163,0,0q�6N   $	��Top=�6c   $��75��6{   6�   �� 5   
   -   5         ��Name$ 
KeyExtPrio��5      $
��Left=�6&   $��23��6A   $��448,135,0,0q�6M    �� TextWrapping$
 Wrap=�6b   $�� ��6v   $	��Top=�6~   $	��120��6�   �� 5   
   -   5        $ 	KeyExtBan��5      $
��Left=�6%   $��23��6@   $��448,284,0,0q�6L   $
 Wrap=�6a   $�� ��6u   $	��Top=�6}   $	��120��6�   �� 5   
   -	   5        $ 
SuprExtBan��5      $	��Del��6%   $
��Left=�63   $��686,306,0,0q�6N   $	��Top=�6c   $��75��6{   6�   �� 5   
   -
   5        $ SuprExtPrio��5      $	��Del��6&   $
��Left=�64   $��686,163,0,0q�6O   $	��Top=�6d   $��75��6|   6�   �� 5   
   -   5        $ 	AddExtBan��5      $	��Add��6$   $
��Left=�62   $��596,306,0,0q�6M   $	��Top=�6b   $��75��6z   6�   �� 5   
   -   5        $ ValueExtPrio��5      $
��Left=�6(   $��23��6C   $��448,184,0,0q�6O   $
 Wrap=�6d   $�� ��6x   $	��Top=�6�   $	��120��6�   �� 5   
   -   5        $ ValueExtBan��5      $
��Left=�6'   $��23��6B   $��448,329,0,0q�6N   $
 Wrap=�6c   $�� ��6w   $	��Top=�6   $	��120��6�   �� 5   
   -   5         ��Name$ titleExtPrio��5      $��Prioritary extensions��6&   $
��Left=�6F   $��	70,80,0,0q�6a   $	��Top=�6t   $��15(�6�   �� 5   
   -   5        $ titleExtBan��5      $��Banned extensions��6%   $
��Left=�6A   $��
70,220,0,0q�6\   $	��Top=�6p   $��15(�6�   �� 5   
   -   5        $ nameExtPrioLabel��5      $
��Name��6*   $
��Left=�69   $��448,110,0,0q�6T   $	��Top=�6i   �� 5   
   -   5        $ ValueExtPrioLabel��5      $��	Extension��6+   $
��Left=�6?   $��448,163,0,0q�6Z   $	��Top=�6o   �� 5   
   -   5        $ nameExtBanLabel��5      $
��Name��6)   $
��Left=�68   $��448,258,0,0q�6S   $	��Top=�6h   �� 5   
   -   5        $ ValueExtBanLabel��5      $��	Extension��6*   $
��Left=�6>   $��448,303,0,0q�6Y   $	��Top=�6n   5      5      