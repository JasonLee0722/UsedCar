/ * = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = * /  
 / *   D B M S   n a m e :             M i c r o s o f t   S Q L   S e r v e r   2 0 0 8                                         * /  
 / *   C r e a t e d   o n :           2 0 1 6 / 3 / 1 5   1 7 : 2 1 : 3 7                                                       * /  
 / * = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = * /  
  
  
 i f   e x i s t s   ( s e l e c t   1  
                         f r o m     s y s o b j e c t s  
                       w h e r e     i d   =   o b j e c t _ i d ( ' B u y e r ' )  
                         a n d       t y p e   =   ' U ' )  
       d r o p   t a b l e   B u y e r  
 g o  
  
 i f   e x i s t s   ( s e l e c t   1  
                         f r o m     s y s o b j e c t s  
                       w h e r e     i d   =   o b j e c t _ i d ( ' C a r ' )  
                         a n d       t y p e   =   ' U ' )  
       d r o p   t a b l e   C a r  
 g o  
  
 i f   e x i s t s   ( s e l e c t   1  
                         f r o m     s y s o b j e c t s  
                       w h e r e     i d   =   o b j e c t _ i d ( ' C a r C o n f i g ' )  
                         a n d       t y p e   =   ' U ' )  
       d r o p   t a b l e   C a r C o n f i g  
 g o  
  
 i f   e x i s t s   ( s e l e c t   1  
                         f r o m     s y s o b j e c t s  
                       w h e r e     i d   =   o b j e c t _ i d ( ' C a r P i c ' )  
                         a n d       t y p e   =   ' U ' )  
       d r o p   t a b l e   C a r P i c  
 g o  
  
 i f   e x i s t s   ( s e l e c t   1  
                         f r o m     s y s o b j e c t s  
                       w h e r e     i d   =   o b j e c t _ i d ( ' C a r T e s t ' )  
                         a n d       t y p e   =   ' U ' )  
       d r o p   t a b l e   C a r T e s t  
 g o  
  
 i f   e x i s t s   ( s e l e c t   1  
                         f r o m     s y s o b j e c t s  
                       w h e r e     i d   =   o b j e c t _ i d ( ' D e a l I n f o ' )  
                         a n d       t y p e   =   ' U ' )  
       d r o p   t a b l e   D e a l I n f o  
 g o  
  
 i f   e x i s t s   ( s e l e c t   1  
                         f r o m     s y s o b j e c t s  
                       w h e r e     i d   =   o b j e c t _ i d ( ' M o d u l e A c t i o n ' )  
                         a n d       t y p e   =   ' U ' )  
       d r o p   t a b l e   M o d u l e A c t i o n  
 g o  
  
 i f   e x i s t s   ( s e l e c t   1  
                         f r o m     s y s o b j e c t s  
                       w h e r e     i d   =   o b j e c t _ i d ( ' R o l e A c t i o n ' )  
                         a n d       t y p e   =   ' U ' )  
       d r o p   t a b l e   R o l e A c t i o n  
 g o  
  
 i f   e x i s t s   ( s e l e c t   1  
                         f r o m     s y s o b j e c t s  
                       w h e r e     i d   =   o b j e c t _ i d ( ' S e l l e r ' )  
                         a n d       t y p e   =   ' U ' )  
       d r o p   t a b l e   S e l l e r  
 g o  
  
 i f   e x i s t s   ( s e l e c t   1  
                         f r o m     s y s o b j e c t s  
                       w h e r e     i d   =   o b j e c t _ i d ( ' S y s t e m M o d u l e ' )  
                         a n d       t y p e   =   ' U ' )  
       d r o p   t a b l e   S y s t e m M o d u l e  
 g o  
  
 i f   e x i s t s   ( s e l e c t   1  
                         f r o m     s y s o b j e c t s  
                       w h e r e     i d   =   o b j e c t _ i d ( ' S y s t e m R o l e ' )  
                         a n d       t y p e   =   ' U ' )  
       d r o p   t a b l e   S y s t e m R o l e  
 g o  
  
 i f   e x i s t s   ( s e l e c t   1  
                         f r o m     s y s o b j e c t s  
                       w h e r e     i d   =   o b j e c t _ i d ( ' S y t e m U s e r ' )  
                         a n d       t y p e   =   ' U ' )  
       d r o p   t a b l e   S y t e m U s e r  
 g o  
  
 i f   e x i s t s   ( s e l e c t   1  
                         f r o m     s y s o b j e c t s  
                       w h e r e     i d   =   o b j e c t _ i d ( ' U s e r R o l e ' )  
                         a n d       t y p e   =   ' U ' )  
       d r o p   t a b l e   U s e r R o l e  
 g o  
  
 / * = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = * /  
 / *   T a b l e :   B u y e r                                                                                                   * /  
 / * = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = * /  
 c r e a t e   t a b l e   B u y e r   (  
       i d                                       i n t                                     n o t   n u l l ,  
       n a m e                                   n v a r c h a r ( 5 0 )                   n u l l ,  
       c a r d N o                               v a r c h a r ( 5 0 )                     n u l l ,  
       p h o n e                                 v a r c h a r ( 5 0 )                     n o t   n u l l ,  
       j o b                                     n v a r c h a r ( 5 0 )                   n u l l ,  
       a d d r e s s                             n v a r c h a r ( 5 0 )                   n u l l ,  
       c o n s t r a i n t   P K _ B U Y E R   p r i m a r y   k e y   ( i d )  
 )  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' pN�[' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' B u y e r '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' �YT' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' B u y e r ' ,   ' c o l u m n ' ,   ' n a m e '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' ���N��' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' B u y e r ' ,   ' c o l u m n ' ,   ' c a r d N o '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' Kb:g�S' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' B u y e r ' ,   ' c o l u m n ' ,   ' p h o n e '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' L�N' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' B u y e r ' ,   ' c o l u m n ' ,   ' j o b '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' 0W@W' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' B u y e r ' ,   ' c o l u m n ' ,   ' a d d r e s s '  
 g o  
  
 / * = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = * /  
 / *   T a b l e :   C a r                                                                                                       * /  
 / * = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = * /  
 c r e a t e   t a b l e   C a r   (  
       i d                                       i n t                                     n o t   n u l l ,  
       s e l l e r I d                           i n t                                     n o t   n u l l ,  
       b u y e r I d                             i n t                                     n u l l ,  
       i s s u e D a t e                         d a t e t i m e                           n o t   n u l l ,  
       m i l e a g e                             f l o a t ( 4 )                           n o t   n u l l ,  
       i s s u e A d d r e s s                   n v a r c h a r ( 5 0 )                   n o t   n u l l ,  
       g e a r B o x                             v a r c h a r ( 5 0 )                     n o t   n u l l ,  
       E S                                       v a r c h a r ( 5 0 )                     n o t   n u l l ,  
       N J                                       d a t e t i m e                           n o t   n u l l ,  
       J Q X                                     d a t e t i m e                           n o t   n u l l ,  
       S Y X                                     d a t e t i m e                           n o t   n u l l ,  
       t r a n s f e r T i m e s                 i n t                                     n u l l ,  
       d e s c r i b e                           n v a r c h a r ( 5 0 0 )                 n u l l ,  
       p r i c e                                 d e c i m a l ( 8 , 2 )                   n o t   n u l l ,  
       d e a l S t a t e                         f l o a t ( 4 )                           n u l l ,  
       d e a l P r i c e                         d e c i m a l ( 8 , 2 )                   n u l l ,  
       s a l e S t a t e                         i n t                                     n u l l ,  
       s a l e P r i c e                         d e c i m a l ( 8 , 2 )                   n u l l ,  
       L S C                                     i n t                                     n u l l ,  
       n e w C a r                               i n t                                     n u l l ,  
       a d d T i m e                             d a t e t i m e                           n u l l ,  
       c o n s t r a i n t   P K _ C A R   p r i m a r y   k e y   ( i d )  
 )  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' f����W,g�Oo`' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' h�S e l l e r . i d ' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r ' ,   ' c o l u m n ' ,   ' s e l l e r I d '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' h�B u y e r . i d ' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r ' ,   ' c o l u m n ' ,   ' b u y e r I d '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' 
NLr�eg' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r ' ,   ' c o l u m n ' ,   ' i s s u e D a t e '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' ̑zpe' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r ' ,   ' c o l u m n ' ,   ' m i l e a g e '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' 
NLr0W' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r ' ,   ' c o l u m n ' ,   ' i s s u e A d d r e s s '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' ꁨR0Kb�R' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r ' ,   ' c o l u m n ' ,   ' g e a r B o x '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' �c>eh�Q' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r ' ,   ' c o l u m n ' ,   ' E S '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' t^�h0Rg' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r ' ,   ' c o l u m n ' ,   ' N J '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' �N:_i�0Rg' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r ' ,   ' c o l u m n ' ,   ' J Q X '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' FUNi�0Rg' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r ' ,   ' c o l u m n ' ,   ' S Y X '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' Ǐ7b!kpe' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r ' ,   ' c o l u m n ' ,   ' t r a n s f e r T i m e s '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' f����c��' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r ' ,   ' c o l u m n ' ,   ' d e s c r i b e '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' f�;N�b�N�N	�' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r ' ,   ' c o l u m n ' ,   ' p r i c e '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' 1 : b�N  0 :   &T' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r ' ,   ' c o l u m n ' ,   ' d e a l S t a t e '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' �[E�b�N�N<h�N	�' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r ' ,   ' c o l u m n ' ,   ' d e a l P r i c e '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' 1 : M��N%`.U  0 :   &T' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r ' ,   ' c o l u m n ' ,   ' s a l e S t a t e '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' M��Nё���N	�' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r ' ,   ' c o l u m n ' ,   ' s a l e P r i c e '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' 1 : �~Kbf�  0 : &T' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r ' ,   ' c o l u m n ' ,   ' L S C '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' 1 : �Q�ef�  0 : &T' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r ' ,   ' c o l u m n ' ,   ' n e w C a r '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' �Oo`U_eQ�e��' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r ' ,   ' c o l u m n ' ,   ' a d d T i m e '  
 g o  
  
 / * = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = * /  
 / *   T a b l e :   C a r C o n f i g                                                                                           * /  
 / * = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = * /  
 c r e a t e   t a b l e   C a r C o n f i g   (  
       i d                                       i n t                                     n o t   n u l l ,  
       c a r I d                                 i n t                                     n u l l ,  
       f i r m                                   n v a r c h a r ( 5 0 )                   n u l l ,  
       c l a s s                                 v a r c h a r ( 5 0 )                     n u l l ,  
       i t e m N a m e                           v a r c h a r ( 5 0 )                     n u l l ,  
       g e a r B o x                             v a r c h a r ( 5 0 )                     n u l l ,  
       c a r B o d y                             v a r c h a r ( 5 0 )                     n u l l ,  
       L W H                                     v a r c h a r ( 5 0 )                     n u l l ,  
       w h e e l B a s e                         i n t                                     n u l l ,  
       I D T C B                                 f l o a t ( 4 )                           n u l l ,  
       C W                                       f l o a t ( 4 )                           n u l l ,  
       d i s p l a c e m e n t                   f l o a t ( 4 )                           n u l l ,  
       i n t a k e T y p e                       v a r c h a r ( 5 0 )                     n u l l ,  
       e n g i n e T y p e                       v a r c h a r ( 5 0 )                     n u l l ,  
       f u l l P o w e r                         i n t                                     n u l l ,  
       M T                                       i n t                                     n u l l ,  
       f u e l T y p e                           v a r c h a r ( 5 0 )                     n u l l ,  
       f u e l M o d e                           i n t                                     n u l l ,  
       S W                                       v a r c h a r ( 5 0 )                     n u l l ,  
       E S                                       v a r c h a r ( 5 0 )                     n u l l ,  
       d r i v e T y p e                         v a r c h a r ( 5 0 )                     n u l l ,  
       b o o s t M o d e                         v a r c h a r ( 5 0 )                     n u l l ,  
       F S M                                     v a r c h a r ( 5 0 )                     n u l l ,  
       R S M                                     v a r c h a r ( 5 0 )                     n u l l ,  
       P B M                                     v a r c h a r ( 5 0 )                     n u l l ,  
       F T S                                     v a r c h a r ( 5 0 )                     n u l l ,  
       R T S                                     v a r c h a r ( 5 0 )                     n u l l ,  
       M D A B                                   v a r c h a r ( 5 0 )                     n u l l ,  
       A D A B                                   v a r c h a r ( 5 0 )                     n u l l ,  
       F S A B                                   v a r c h a r ( 5 0 )                     n u l l ,  
       R S A B                                   v a r c h a r ( 5 0 )                     n u l l ,  
       F H A B                                   v a r c h a r ( 5 0 )                     n u l l ,  
       R H A B                                   v a r c h a r ( 5 0 )                     n u l l ,  
       T P M S                                   v a r c h a r ( 5 0 )                     n u l l ,  
       c a r L o c k                             v a r c h a r ( 5 0 )                     n u l l ,  
       I S O F I X                               v a r c h a r ( 5 0 )                     n u l l ,  
       A B S                                     v a r c h a r ( 5 0 )                     n u l l ,  
       E S P                                     v a r c h a r ( 5 0 )                     n u l l ,  
       s u n r o o f                             v a r c h a r ( 5 0 )                     n u l l ,  
       v i s t a S u n r o o f                   v a r c h a r ( 5 0 )                     n u l l ,  
       H I D                                     v a r c h a r ( 5 0 )                     n u l l ,  
       L E D                                     v a r c h a r ( 5 0 )                     n u l l ,  
       a u t o H e a d L i g h t                 v a r c h a r ( 5 0 )                     n u l l ,  
       f r o n t F o g                           v a r c h a r ( 5 0 )                     n u l l ,  
       F P W                                     v a r c h a r ( 5 0 )                     n u l l ,  
       R P W                                     v a r c h a r ( 5 0 )                     n u l l ,  
       E A M                                     v a r c h a r ( 5 0 )                     n u l l ,  
       m i r r o r H e a t                       v a r c h a r ( 5 0 )                     n u l l ,  
       l e a t h e r S e a t                     v a r c h a r ( 5 0 )                     n u l l ,  
       s e a t H e a t                           v a r c h a r ( 5 0 )                     n u l l ,  
       a i r S e a t                             v a r c h a r ( 5 0 )                     n u l l ,  
       M F L                                     v a r c h a r ( 5 0 )                     n u l l ,  
       C C S                                     v a r c h a r ( 5 0 )                     n u l l ,  
       G P S                                     v a r c h a r ( 5 0 )                     n u l l ,  
       b a c k R a d a r                         v a r c h a r ( 5 0 )                     n u l l ,  
       B I S                                     v a r c h a r ( 5 0 )                     n u l l ,  
       A C S                                     v a r c h a r ( 5 0 )                     n u l l ,  
       c o n s t r a i n t   P K _ C A R C O N F I G   p r i m a r y   k e y   ( i d )  
 )  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' f���M�n' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r C o n f i g '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' C a r I n f o . i d ' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r C o n f i g ' ,   ' c o l u m n ' ,   ' c a r I d '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' �SFU' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r C o n f i g ' ,   ' c o l u m n ' ,   ' f i r m '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' B �~f�' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r C o n f i g ' ,   ' c o l u m n ' ,   ' c l a s s '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' 5 	 i t e m N a m e 	 v a r c h a r 	 5 0 	 0 	 	 	 	 �W,g�Spe0�S�R:g�Spe0�^�v�S6R�R' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r C o n f i g ' ,   ' c o l u m n ' ,   ' i t e m N a m e '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' ꁨR0Kb�R' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r C o n f i g ' ,   ' c o l u m n ' ,   ' g e a r B o x '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' f����~�g' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r C o n f i g ' ,   ' c o l u m n ' ,   ' c a r B o d y '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' ��[ؚ( m m ) ' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r C o n f i g ' ,   ' c o l u m n ' ,   ' L W H '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' t�ݍ( m m ) ' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r C o n f i g ' ,   ' c o l u m n ' ,   ' w h e e l B a s e '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' L�Ng�{�[�y( L ) ' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r C o n f i g ' ,   ' c o l u m n ' ,   ' I D T C B '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' teY(�ϑ( K G ) ' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r C o n f i g ' ,   ' c o l u m n ' ,   ' C W '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' �cϑ( L ) ' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r C o n f i g ' ,   ' c o l u m n ' ,   ' d i s p l a c e m e n t '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' �6q8Tl0�mn��X�S' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r C o n f i g ' ,   ' c o l u m n ' ,   ' i n t a k e T y p e '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' L 4 0V 6 ' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r C o n f i g ' ,   ' c o l u m n ' ,   ' e n g i n e T y p e '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       '  g'Yl��R( P s ) ' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r C o n f i g ' ,   ' c o l u m n ' ,   ' f u l l P o w e r '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       '  g'Ymb�w( N * m ) ' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r C o n f i g ' ,   ' c o l u m n ' ,   ' M T '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' }l�l0�g�l' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r C o n f i g ' ,   ' c o l u m n ' ,   ' f u e l T y p e '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' �Y�9 3 ( # ) ' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r C o n f i g ' ,   ' c o l u m n ' ,   ' f u e l M o d e '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' �O�l�e_' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r C o n f i g ' ,   ' c o l u m n ' ,   ' S W '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' �c>eh�Q' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r C o n f i g ' ,   ' c o l u m n ' ,   ' E S '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' q��R�e_' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r C o n f i g ' ,   ' c o l u m n ' ,   ' d r i v e T y p e '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' �R�R{|�W' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r C o n f i g ' ,   ' c o l u m n ' ,   ' b o o s t M o d e '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' MR�`c{|�W' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r C o n f i g ' ,   ' c o l u m n ' ,   ' F S M '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' T�`c{|�W' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r C o n f i g ' ,   ' c o l u m n ' ,   ' R S M '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' {�f�6R�R{|�W' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r C o n f i g ' ,   ' c o l u m n ' ,   ' P B M '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' MRn�΀ĉ<h' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r C o n f i g ' ,   ' c o l u m n ' ,   ' F T S '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' Tn�΀ĉ<h' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r C o n f i g ' ,   ' c o l u m n ' ,   ' R T S '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' ;N~�v�l�V  hM�/ �e 
       ' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r C o n f i g ' ,   ' c o l u m n ' ,   ' M D A B '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' oR~�v�l�V' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r C o n f i g ' ,   ' c o l u m n ' ,   ' A D A B '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' MR�c�Ol�V' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r C o n f i g ' ,   ' c o l u m n ' ,   ' F S A B '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' T�c�Ol�V' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r C o n f i g ' ,   ' c o l u m n ' ,   ' R S A B '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' MR�c4Y�l�V' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r C o n f i g ' ,   ' c o l u m n ' ,   ' F H A B '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' T�c4Y�l�V' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r C o n f i g ' ,   ' c o l u m n ' ,   ' R H A B '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' ΀�S�hKm' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r C o n f i g ' ,   ' c o l u m n ' ,   ' T P M S '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' f��Q-N�c�' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r C o n f i g ' ,   ' c o l u m n ' ,   ' c a r L o c k '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' ?Q�z�^i�c�S' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r C o n f i g ' ,   ' c o l u m n ' ,   ' I S O F I X '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' 2��b{k�|�~' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r C o n f i g ' ,   ' c o l u m n ' ,   ' A B S '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' f���3z�[�|�~' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r C o n f i g ' ,   ' c o l u m n ' ,   ' E S P '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' 5u�R)Y�z' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r C o n f i g ' ,   ' c o l u m n ' ,   ' s u n r o o f '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' hQof)Y�z' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r C o n f i g ' ,   ' c o l u m n ' ,   ' v i s t a S u n r o o f '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' ll'Yop' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r C o n f i g ' ,   ' c o l u m n ' ,   ' H I D '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' L E D 'Yop' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r C o n f i g ' ,   ' c o l u m n ' ,   ' L E D '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' ꁨR4Yop' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r C o n f i g ' ,   ' c o l u m n ' ,   ' a u t o H e a d L i g h t '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' MR��op' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r C o n f i g ' ,   ' c o l u m n ' ,   ' f r o n t F o g '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' MR5u�Rf��z' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r C o n f i g ' ,   ' c o l u m n ' ,   ' F P W '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' T5u�Rf��z' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r C o n f i g ' ,   ' c o l u m n ' ,   ' R P W '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' TƉ\�5u�R���' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r C o n f i g ' ,   ' c o l u m n ' ,   ' E A M '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' TƉ\��R�p' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r C o n f i g ' ,   ' c o l u m n ' ,   ' m i r r o r H e a t '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' w�v�^i' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r C o n f i g ' ,   ' c o l u m n ' ,   ' l e a t h e r S e a t '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' �^i�R�p' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r C o n f i g ' ,   ' c o l u m n ' ,   ' s e a t H e a t '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' �^i�Θ' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r C o n f i g ' ,   ' c o l u m n ' ,   ' a i r S e a t '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' Y�R���eT�v' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r C o n f i g ' ,   ' c o l u m n ' ,   ' M F L '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' �[��]*�' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r C o n f i g ' ,   ' c o l u m n ' ,   ' C C S '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' G P S �[*�' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r C o n f i g ' ,   ' c o l u m n ' ,   ' G P S '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' Pf�����' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r C o n f i g ' ,   ' c o l u m n ' ,   ' b a c k R a d a r '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' Pf�q_�P�|�~' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r C o n f i g ' ,   ' c o l u m n ' ,   ' B I S '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' zz��c6R�e_  ꁨR/ Kb�R 
       ' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r C o n f i g ' ,   ' c o l u m n ' ,   ' A C S '  
 g o  
  
 / * = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = * /  
 / *   T a b l e :   C a r P i c                                                                                                 * /  
 / * = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = * /  
 c r e a t e   t a b l e   C a r P i c   (  
       i d                                       i n t                                     n o t   n u l l ,  
       c a r I d                                 i n t                                     n o t   n u l l ,  
       i m g U R L                               v a r c h a r ( 2 0 0 )                   n o t   n u l l ,  
       c o n s t r a i n t   P K _ C A R P I C   p r i m a r y   k e y   ( i d )  
 )  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' }lf��VGr' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r P i c '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' h�C a r . i d ;N.�' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r P i c ' ,   ' c o l u m n ' ,   ' c a r I d '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' �VGr_' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r P i c ' ,   ' c o l u m n ' ,   ' i m g U R L '  
 g o  
  
 / * = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = * /  
 / *   T a b l e :   C a r T e s t                                                                                               * /  
 / * = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = * /  
 c r e a t e   t a b l e   C a r T e s t   (  
       i d                                       i n t                                     n o t   n u l l ,  
       c o n s t r a i n t   P K _ C A R T E S T   p r i m a r y   k e y   ( i d )  
 )  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' }lf��hKm' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' C a r T e s t '  
 g o  
  
 / * = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = * /  
 / *   T a b l e :   D e a l I n f o                                                                                             * /  
 / * = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = * /  
 c r e a t e   t a b l e   D e a l I n f o   (  
       i d                                       i n t                                     n o t   n u l l ,  
       c a r d I d                               i n t                                     n o t   n u l l ,  
       b u y e r P h o n e                       v a r c h a r ( 5 0 )                     n o t   n u l l ,  
       b i d                                     d e c i m a l ( 8 , 2 )                   n o t   n u l l ,  
       c a l l B a c k                           i n t                                     n o t   n u l l ,  
       s t a t e                                 f l o a t ( 4 )                           n u l l ,  
       p r i c e                                 d e c i m a l ( 8 , 2 )                   n u l l ,  
       a d d T i m e                             d a t e t i m e                           n o t   n u l l ,  
       c o n s t r a i n t   P K _ D E A L I N F O   p r i m a r y   k e y   ( i d )  
 )  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' f����Nf�Oo`h�' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' D e a l I n f o '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' h�C a r . i d ' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' D e a l I n f o ' ,   ' c o l u m n ' ,   ' c a r d I d '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' pN�[5u݋' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' D e a l I n f o ' ,   ' c o l u m n ' ,   ' b u y e r P h o n e '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' pN�[�Q�N' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' D e a l I n f o ' ,   ' c o l u m n ' ,   ' b i d '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' 1 : �]�V5u  0 : &T' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' D e a l I n f o ' ,   ' c o l u m n ' ,   ' c a l l B a c k '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' 1 : b�N  0 : &T' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' D e a l I n f o ' ,   ' c o l u m n ' ,   ' s t a t e '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' �[E�b�N�N<h�N	�' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' D e a l I n f o ' ,   ' c o l u m n ' ,   ' p r i c e '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' �Oo`�m�R�e��' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' D e a l I n f o ' ,   ' c o l u m n ' ,   ' a d d T i m e '  
 g o  
  
 / * = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = * /  
 / *   T a b l e :   M o d u l e A c t i o n                                                                                     * /  
 / * = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = * /  
 c r e a t e   t a b l e   M o d u l e A c t i o n   (  
       i d                                       i n t                                     n o t   n u l l ,  
       n a m e                                   v a r c h a r ( 5 0 )                     n u l l ,  
       c o d e                                   v a r c h a r ( 5 0 )                     n u l l ,  
       m o d u l e I d                           i n t                                     n o t   n u l l ,  
       s o r t                                   i n t                                     n u l l ,  
       c o n s t r a i n t   P K _ M O D U L E A C T I O N   p r i m a r y   k e y   ( i d )  
 )  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' �|�~!jWW�R��' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' M o d u l e A c t i o n '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' �R��T�y' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' M o d u l e A c t i o n ' ,   ' c o l u m n ' ,   ' n a m e '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' �R���N�S' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' M o d u l e A c t i o n ' ,   ' c o l u m n ' ,   ' c o d e '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' h�S y s t e m M o d u l e . i d ' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' M o d u l e A c t i o n ' ,   ' c o l u m n ' ,   ' m o d u l e I d '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' �c�^' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' M o d u l e A c t i o n ' ,   ' c o l u m n ' ,   ' s o r t '  
 g o  
  
 / * = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = * /  
 / *   T a b l e :   R o l e A c t i o n                                                                                         * /  
 / * = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = * /  
 c r e a t e   t a b l e   R o l e A c t i o n   (  
       i d                                       i n t                                     n o t   n u l l ,  
       r o l e I d                               i n t                                     n u l l ,  
       a c t i o n I d                           i n t                                     n u l l ,  
       c o n s t r a i n t   P K _ R O L E A C T I O N   p r i m a r y   k e y   ( i d )  
 )  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' ҉r�sQT�!jWW�R��' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' R o l e A c t i o n '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' h�S y s t e m R o l e . i d ' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' R o l e A c t i o n ' ,   ' c o l u m n ' ,   ' r o l e I d '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' h�M o d u l e A c t i o n . i d ' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' R o l e A c t i o n ' ,   ' c o l u m n ' ,   ' a c t i o n I d '  
 g o  
  
 / * = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = * /  
 / *   T a b l e :   S e l l e r                                                                                                 * /  
 / * = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = * /  
 c r e a t e   t a b l e   S e l l e r   (  
       i d                                       i n t                                     n o t   n u l l ,  
       n a m e                                   n v a r c h a r ( 5 0 )                   n u l l ,  
       c a r d N o                               v a r c h a r ( 5 0 )                     n u l l ,  
       p h o n e                                 v a r c h a r ( 5 0 )                     n o t   n u l l ,  
       j o b                                     n v a r c h a r ( 5 0 )                   n u l l ,  
       a d d r e s s                             n v a r c h a r ( 5 0 )                   n u l l ,  
       c o n s t r a i n t   P K _ S E L L E R   p r i m a r y   k e y   ( i d )  
 )  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' VS�[' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' S e l l e r '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' �YT' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' S e l l e r ' ,   ' c o l u m n ' ,   ' n a m e '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' ���N��' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' S e l l e r ' ,   ' c o l u m n ' ,   ' c a r d N o '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' Kb:g�S' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' S e l l e r ' ,   ' c o l u m n ' ,   ' p h o n e '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' L�N' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' S e l l e r ' ,   ' c o l u m n ' ,   ' j o b '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' 0W@W' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' S e l l e r ' ,   ' c o l u m n ' ,   ' a d d r e s s '  
 g o  
  
 / * = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = * /  
 / *   T a b l e :   S y s t e m M o d u l e                                                                                     * /  
 / * = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = * /  
 c r e a t e   t a b l e   S y s t e m M o d u l e   (  
       i d                                       i n t                                     n o t   n u l l ,  
       n a m e                                   v a r c h a r ( 5 0 )                     n u l l ,  
       p a r e n t I d                           i n t                                     n u l l ,  
       c o n s t r a i n t   P K _ S Y S T E M M O D U L E   p r i m a r y   k e y   ( i d )  
 )  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' �|�~!jWW' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' S y s t e m M o d u l e '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' !jWWT�y' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' S y s t e m M o d u l e ' ,   ' c o l u m n ' ,   ' n a m e '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' 6r!jWWI D ' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' S y s t e m M o d u l e ' ,   ' c o l u m n ' ,   ' p a r e n t I d '  
 g o  
  
 / * = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = * /  
 / *   T a b l e :   S y s t e m R o l e                                                                                         * /  
 / * = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = * /  
 c r e a t e   t a b l e   S y s t e m R o l e   (  
       i d                                       i n t                                     n o t   n u l l ,  
       n a m e                                   v a r c h a r ( 5 0 )                     n u l l ,  
       c o n s t r a i n t   P K _ S Y S T E M R O L E   p r i m a r y   k e y   ( i d )  
 )  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' ҉r�h�' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' S y s t e m R o l e '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' ҉r�T�y' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' S y s t e m R o l e ' ,   ' c o l u m n ' ,   ' n a m e '  
 g o  
  
 / * = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = * /  
 / *   T a b l e :   S y t e m U s e r                                                                                           * /  
 / * = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = * /  
 c r e a t e   t a b l e   S y t e m U s e r   (  
       i d                                       i n t                                     n o t   n u l l ,  
       l o g i n N a m e                         n v a r c h a r ( 5 0 )                   n o t   n u l l ,  
       l o g i n P w d                           v a r c h a r ( 5 0 )                     n o t   n u l l ,  
       n a m e                                   n v a r c h a r ( 5 0 )                   n u l l ,  
       c a r d N o                               v a r c h a r ( 5 0 )                     n o t   n u l l ,  
       s t a t e                                 i n t                                     n u l l ,  
       p h o n e                                 v a r c h a r ( 5 0 )                     n o t   n u l l ,  
       a d d r e s s                             n v a r c h a r ( 1 0 0 )                 n u l l ,  
       c o n s t r a i n t   P K _ S Y T E M U S E R   p r i m a r y   k e y   ( i d )  
 )  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' �|�~�{t(u7b' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' S y t e m U s e r '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' {vU_T' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' S y t e m U s e r ' ,   ' c o l u m n ' ,   ' l o g i n N a m e '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' {vU_�[x' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' S y t e m U s e r ' ,   ' c o l u m n ' ,   ' l o g i n P w d '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' �YT' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' S y t e m U s e r ' ,   ' c o l u m n ' ,   ' n a m e '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' ���N��' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' S y t e m U s e r ' ,   ' c o l u m n ' ,   ' c a r d N o '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' 0 ( \P(u) �1 ( /T(u) ' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' S y t e m U s e r ' ,   ' c o l u m n ' ,   ' s t a t e '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' Kb:g�S' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' S y t e m U s e r ' ,   ' c o l u m n ' ,   ' p h o n e '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' 0W@W' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' S y t e m U s e r ' ,   ' c o l u m n ' ,   ' a d d r e s s '  
 g o  
  
 / * = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = * /  
 / *   T a b l e :   U s e r R o l e                                                                                             * /  
 / * = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = * /  
 c r e a t e   t a b l e   U s e r R o l e   (  
       i d                                       i n t                                     n o t   n u l l ,  
       u s e r I d                               i n t                                     n u l l ,  
       r o l e I d                               i n t                                     n u l l ,  
       c o n s t r a i n t   P K _ U S E R R O L E   p r i m a r y   k e y   ( i d )  
 )  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' �|�~(u7b҉r�' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' U s e r R o l e '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' h�S y s t e m U s e r . i d ' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' U s e r R o l e ' ,   ' c o l u m n ' ,   ' u s e r I d '  
 g o  
  
 d e c l a r e   @ C u r r e n t U s e r   s y s n a m e  
 s e l e c t   @ C u r r e n t U s e r   =   u s e r _ n a m e ( )  
 e x e c u t e   s p _ a d d e x t e n d e d p r o p e r t y   ' M S _ D e s c r i p t i o n ' ,    
       ' h�S y s t e m R o l e . i d ' ,  
       ' u s e r ' ,   @ C u r r e n t U s e r ,   ' t a b l e ' ,   ' U s e r R o l e ' ,   ' c o l u m n ' ,   ' r o l e I d '  
 g o  
  
 