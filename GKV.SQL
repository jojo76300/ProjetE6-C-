/*
 ----------------------------------------------------------------------------
             Génération d'une base de données pour
                        SQL Server 2005
                       (4/3/2026 16:02:27)
 ----------------------------------------------------------------------------
     Nom de la base : MLR4
     Projet : Espace de travail
     Auteur : Enzo VINCENT
     Date de dernière modification : 4/3/2026 16:02:19
 ----------------------------------------------------------------------------
*/

drop database MLR4
go

/* -----------------------------------------------------------------------------
      OUVERTURE DE LA BASE MLR4
----------------------------------------------------------------------------- */

create database MLR4
go

use MLR4
go



/* -----------------------------------------------------------------------------
      TABLE : UTILISATEUR
----------------------------------------------------------------------------- */

create table UTILISATEUR
  (
     UTIL_ID int  not null  ,
     UTIL_LOGIN char(32)  null  ,
     UTIL_MDP char(32)  null  ,
     UTIL_PRENOM char(32)  null  ,
     UTIL_NOM char(32)  null  ,
     UTIL_ESTGESTIONNAIRE bit  null  
     ,
     constraint PK_UTILISATEUR primary key (UTIL_ID)
  ) 
go



/* -----------------------------------------------------------------------------
      TABLE : LIEU
----------------------------------------------------------------------------- */

create table LIEU
  (
     LIEU_ID int  not null  ,
     LIEU_VILLE char(32)  null  ,
     LIEU_PAYS char(32)  null  ,
     LIEU_NOM char(32)  null  
     ,
     constraint PK_LIEU primary key (LIEU_ID)
  ) 
go



/* -----------------------------------------------------------------------------
      TABLE : TRAJET
----------------------------------------------------------------------------- */

create table TRAJET
  (
     TRA_ID int  not null  ,
     LIEU_ID int  not null  ,
     TRAN_ID int  not null  ,
     TRA_DATE_ARRIVE char(32)  null  ,
     TRA_DATE_DEPART char(32)  null  ,
     TRA_STATUS char(32)  null  
     ,
     constraint PK_TRAJET primary key (TRA_ID)
  ) 
go



/*      INDEX DE TRAJET      */



/* -----------------------------------------------------------------------------
      TABLE : TRANSPORT
----------------------------------------------------------------------------- */

create table TRANSPORT
  (
     TRAN_ID int  not null  ,
     TRAN_TYPE char(32)  null  ,
     TRAN_COMPAGNIE char(32)  null  ,
     TRAN_NUMERO char(32)  null  
     ,
     constraint PK_TRANSPORT primary key (TRAN_ID)
  ) 
go



/* -----------------------------------------------------------------------------
      TABLE : AFFECTER
----------------------------------------------------------------------------- */

create table AFFECTER
  (
     TRA_ID int  not null  ,
     UTIL_ID int  not null  
     ,
     constraint PK_AFFECTER primary key (TRA_ID, UTIL_ID)
  ) 
go



/*      INDEX DE AFFECTER      */



/* -----------------------------------------------------------------------------
      REFERENCES SUR LES TABLES
----------------------------------------------------------------------------- */



alter table TRAJET 
     add constraint FK_TRAJET_LIEU foreign key (LIEU_ID) 
               references LIEU (LIEU_ID)
go




alter table TRAJET 
     add constraint FK_TRAJET_TRANSPORT foreign key (TRAN_ID) 
               references TRANSPORT (TRAN_ID)
go




alter table AFFECTER 
     add constraint FK_AFFECTER_TRAJET foreign key (TRA_ID) 
               references TRAJET (TRA_ID)
go




alter table AFFECTER 
     add constraint FK_AFFECTER_UTILISATEUR foreign key (UTIL_ID) 
               references UTILISATEUR (UTIL_ID)
go




/*
 -----------------------------------------------------------------------------
               FIN DE GENERATION
 -----------------------------------------------------------------------------
*/