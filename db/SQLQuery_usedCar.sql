/*==============================================================*/
/* DBMS name:      Sybase SQL Anywhere 11                       */
/* Created on:     2016/3/15 16:22:46                           */
/*==============================================================*/


if exists(
   select 1 from sys.systable 
   where table_name='Buyer'
     and table_type in ('BASE', 'GBL TEMP')
) then
    drop table Buyer
end if;

if exists(
   select 1 from sys.systable 
   where table_name='Car'
     and table_type in ('BASE', 'GBL TEMP')
) then
    drop table Car
end if;

if exists(
   select 1 from sys.systable 
   where table_name='CarConfig'
     and table_type in ('BASE', 'GBL TEMP')
) then
    drop table CarConfig
end if;

if exists(
   select 1 from sys.systable 
   where table_name='CarPic'
     and table_type in ('BASE', 'GBL TEMP')
) then
    drop table CarPic
end if;

if exists(
   select 1 from sys.systable 
   where table_name='CarTest'
     and table_type in ('BASE', 'GBL TEMP')
) then
    drop table CarTest
end if;

if exists(
   select 1 from sys.systable 
   where table_name='DealInfo'
     and table_type in ('BASE', 'GBL TEMP')
) then
    drop table DealInfo
end if;

if exists(
   select 1 from sys.systable 
   where table_name='ModuleAction'
     and table_type in ('BASE', 'GBL TEMP')
) then
    drop table ModuleAction
end if;

if exists(
   select 1 from sys.systable 
   where table_name='RoleAction'
     and table_type in ('BASE', 'GBL TEMP')
) then
    drop table RoleAction
end if;

if exists(
   select 1 from sys.systable 
   where table_name='Seller'
     and table_type in ('BASE', 'GBL TEMP')
) then
    drop table Seller
end if;

if exists(
   select 1 from sys.systable 
   where table_name='SystemModule'
     and table_type in ('BASE', 'GBL TEMP')
) then
    drop table SystemModule
end if;

if exists(
   select 1 from sys.systable 
   where table_name='SystemRole'
     and table_type in ('BASE', 'GBL TEMP')
) then
    drop table SystemRole
end if;

if exists(
   select 1 from sys.systable 
   where table_name='SytemUser'
     and table_type in ('BASE', 'GBL TEMP')
) then
    drop table SytemUser
end if;

if exists(
   select 1 from sys.systable 
   where table_name='UserRole'
     and table_type in ('BASE', 'GBL TEMP')
) then
    drop table UserRole
end if;

/*==============================================================*/
/* Table: Buyer                                                 */
/*==============================================================*/
create table Buyer 
(
   id                   int                            not null,
   name                 nvarchar(50)          null,
   cardNo               varchar(50)                    null,
   phone                varchar(50)                    not null,
   job                  nvarchar(50)          null,
   address              nvarchar(50)          null,
   constraint PK_BUYER primary key clustered (id)
);

comment on table Buyer is 
'���';

comment on column Buyer.name is 
'����';

comment on column Buyer.cardNo is 
'���֤';

comment on column Buyer.phone is 
'�ֻ���';

comment on column Buyer.job is 
'ְҵ';

comment on column Buyer.address is 
'��ַ';

/*==============================================================*/
/* Table: Car                                                   */
/*==============================================================*/
create table Car 
(
   id                   int                            not null,
   sellerId             int                            not null,
   buyerId              int                            null,
   issueDate            datetime                       not null,
   mileage              float(4)                       not null,
   issueAddress         nvarchar(50)          not null,
   gearBox              varchar(50)                    not null,
   ES                   varchar(50)                    not null,
   NJ                   datetime                       not null,
   JQX                  datetime                       not null,
   SYX                  datetime                       not null,
   transferTimes        int                            null,
   describe             nvarchar(500)         null,
   price                decimal(8,2)                   not null,
   dealState            float(4)                       null,
   dealPrice            decimal(8,2)                   null,
   saleState            int                            null,
   salePrice            decimal(8,2)                   null,
   LSC                  int                            null,
   newCar               int                            null,
   addTime              datetime                       null,
   constraint PK_CAR primary key clustered (id)
);

comment on table Car is 
'����������Ϣ';

comment on column Car.sellerId is 
'��Seller.id';

comment on column Car.buyerId is 
'��Buyer.id';

comment on column Car.issueDate is 
'��������';

comment on column Car.mileage is 
'�����';

comment on column Car.issueAddress is 
'���Ƶ�';

comment on column Car.gearBox is 
'�Զ����ֶ�';

comment on column Car.ES is 
'�ŷű�׼';

comment on column Car.NJ is 
'��쵽��';

comment on column Car.JQX is 
'��ǿ�յ���';

comment on column Car.SYX is 
'��ҵ�յ���';

comment on column Car.transferTimes is 
'��������';

comment on column Car.describe is 
'��������';

comment on column Car.price is 
'�������ۣ���';

comment on column Car.dealState is 
'1:�ɽ� 0: ��';

comment on column Car.dealPrice is 
'ʵ�ʳɽ��۸���';

comment on column Car.saleState is 
'1:���ۼ��� 0: ��';

comment on column Car.salePrice is 
'���۽���';

comment on column Car.LSC is 
'1:���ֳ� 0:��';

comment on column Car.newCar is 
'1:׼�³� 0:��';

comment on column Car.addTime is 
'��Ϣ¼��ʱ��';

/*==============================================================*/
/* Table: CarConfig                                             */
/*==============================================================*/
create table CarConfig 
(
   id                   int                            not null,
   carId                int                            null,
   firm                 nvarchar(50)          null,
   class                varchar(50)                    null,
   itemName             varchar(50)                    null,
   gearBox              varchar(50)                    null,
   carBody              varchar(50)                    null,
   LWH                  varchar(50)                    null,
   wheelBase            int                            null,
   IDTCB                float(4)                       null,
   CW                   float(4)                       null,
   displacement         float(4)                       null,
   intakeType           varchar(50)                    null,
   engineType           varchar(50)                    null,
   fullPower            int                            null,
   MT                   int                            null,
   fuelType             varchar(50)                    null,
   fuelMode             int                            null,
   SW                   varchar(50)                    null,
   ES                   varchar(50)                    null,
   driveType            varchar(50)                    null,
   boostMode            varchar(50)                    null,
   FSM                  varchar(50)                    null,
   RSM                  varchar(50)                    null,
   PBM                  varchar(50)                    null,
   FTS                  varchar(50)                    null,
   RTS                  varchar(50)                    null,
   MDAB                 varchar(50)                    null,
   ADAB                 varchar(50)                    null,
   FSAB                 varchar(50)                    null,
   RSAB                 varchar(50)                    null,
   FHAB                 varchar(50)                    null,
   RHAB                 varchar(50)                    null,
   TPMS                 varchar(50)                    null,
   carLock              varchar(50)                    null,
   ISOFIX               varchar(50)                    null,
   ABS                  varchar(50)                    null,
   ESP                  varchar(50)                    null,
   sunroof              varchar(50)                    null,
   vistaSunroof         varchar(50)                    null,
   HID                  varchar(50)                    null,
   LED                  varchar(50)                    null,
   autoHeadLight        varchar(50)                    null,
   frontFog             varchar(50)                    null,
   FPW                  varchar(50)                    null,
   RPW                  varchar(50)                    null,
   EAM                  varchar(50)                    null,
   mirrorHeat           varchar(50)                    null,
   leatherSeat          varchar(50)                    null,
   seatHeat             varchar(50)                    null,
   airSeat              varchar(50)                    null,
   MFL                  varchar(50)                    null,
   CCS                  varchar(50)                    null,
   GPS                  varchar(50)                    null,
   backRadar            varchar(50)                    null,
   BIS                  varchar(50)                    null,
   ACS                  varchar(50)                    null,
   constraint PK_CARCONFIG primary key clustered (id)
);

comment on table CarConfig is 
'��������';

comment on column CarConfig.carId is 
'CarInfo.id';

comment on column CarConfig.firm is 
'����';

comment on column CarConfig.class is 
'B����';

comment on column CarConfig.itemName is 
'5	itemName	varchar	50	0				�������������������������̼��ƶ�';

comment on column CarConfig.gearBox is 
'�Զ����ֶ�';

comment on column CarConfig.carBody is 
'����ṹ';

comment on column CarConfig.LWH is 
'�����(mm)';

comment on column CarConfig.wheelBase is 
'���(mm)';

comment on column CarConfig.IDTCB is 
'�������ݻ�(L)';

comment on column CarConfig.CW is 
'��������(KG)';

comment on column CarConfig.displacement is 
'����(L)';

comment on column CarConfig.intakeType is 
'��Ȼ������������ѹ';

comment on column CarConfig.engineType is 
'L4��V6';

comment on column CarConfig.fullPower is 
'�������(Ps)';

comment on column CarConfig.MT is 
'���Ť��(N*m)';

comment on column CarConfig.fuelType is 
'���͡�����';

comment on column CarConfig.fuelMode is 
'�磺93(#)';

comment on column CarConfig.SW is 
'���ͷ�ʽ';

comment on column CarConfig.ES is 
'�ŷű�׼';

comment on column CarConfig.driveType is 
'������ʽ';

comment on column CarConfig.boostMode is 
'��������';

comment on column CarConfig.FSM is 
'ǰ��������';

comment on column CarConfig.RSM is 
'����������';

comment on column CarConfig.PBM is 
'פ���ƶ�����';

comment on column CarConfig.FTS is 
'ǰ��̥���';

comment on column CarConfig.RTS is 
'����̥���';

comment on column CarConfig.MDAB is 
'����ʻ���� ����/��
';

comment on column CarConfig.ADAB is 
'����ʻ����';

comment on column CarConfig.FSAB is 
'ǰ�Ų�����';

comment on column CarConfig.RSAB is 
'���Ų�����';

comment on column CarConfig.FHAB is 
'ǰ��ͷ������';

comment on column CarConfig.RHAB is 
'����ͷ������';

comment on column CarConfig.TPMS is 
'̥ѹ���';

comment on column CarConfig.carLock is 
'�����п���';

comment on column CarConfig.ISOFIX is 
'��ͯ���νӿ�';

comment on column CarConfig.ABS is 
'������ϵͳ';

comment on column CarConfig.ESP is 
'�����ȶ�ϵͳ';

comment on column CarConfig.sunroof is 
'�綯�촰';

comment on column CarConfig.vistaSunroof is 
'ȫ���촰';

comment on column CarConfig.HID is 
'������';

comment on column CarConfig.LED is 
'LED���';

comment on column CarConfig.autoHeadLight is 
'�Զ�ͷ��';

comment on column CarConfig.frontFog is 
'ǰ���';

comment on column CarConfig.FPW is 
'ǰ�綯����';

comment on column CarConfig.RPW is 
'��綯����';

comment on column CarConfig.EAM is 
'���Ӿ��綯����';

comment on column CarConfig.mirrorHeat is 
'���Ӿ�����';

comment on column CarConfig.leatherSeat is 
'��Ƥ����';

comment on column CarConfig.seatHeat is 
'���μ���';

comment on column CarConfig.airSeat is 
'����ͨ��';

comment on column CarConfig.MFL is 
'�๦�ܷ�����';

comment on column CarConfig.CCS is 
'����Ѳ��';

comment on column CarConfig.GPS is 
'GPS����';

comment on column CarConfig.backRadar is 
'�����״�';

comment on column CarConfig.BIS is 
'����Ӱ��ϵͳ';

comment on column CarConfig.ACS is 
'�յ����Ʒ�ʽ �Զ�/�ֶ�
';

/*==============================================================*/
/* Table: CarPic                                                */
/*==============================================================*/
create table CarPic 
(
   id                   int                            not null,
   carId                int                            not null,
   imgURL               varchar(200)                   not null,
   constraint PK_CARPIC primary key clustered (id)
);

comment on table CarPic is 
'����ͼƬ';

comment on column CarPic.carId is 
'��Car.id����';

comment on column CarPic.imgURL is 
'ͼƬ·��';

/*==============================================================*/
/* Table: CarTest                                               */
/*==============================================================*/
create table CarTest 
(
   id                   int                            not null,
   constraint PK_CARTEST primary key clustered (id)
);

comment on table CarTest is 
'�������';

/*==============================================================*/
/* Table: DealInfo                                              */
/*==============================================================*/
create table DealInfo 
(
   id                   int                            not null,
   cardId               int                            not null,
   buyerPhone           varchar(50)                    not null,
   bid                  decimal(8,2)                   not null,
   callBack             int                            not null,
   state                float(4)                       null,
   price                decimal(8,2)                   null,
   addTime              datetime                       not null,
   constraint PK_DEALINFO primary key clustered (id)
);

comment on table DealInfo is 
'����������Ϣ��';

comment on column DealInfo.cardId is 
'��Car.id';

comment on column DealInfo.buyerPhone is 
'��ҵ绰';

comment on column DealInfo.bid is 
'��ҳ���';

comment on column DealInfo.callBack is 
'1:�ѻص� 0:��';

comment on column DealInfo.state is 
'1:�ɽ� 0:��';

comment on column DealInfo.price is 
'ʵ�ʳɽ��۸���';

comment on column DealInfo.addTime is 
'��Ϣ���ʱ��';

/*==============================================================*/
/* Table: ModuleAction                                          */
/*==============================================================*/
create table ModuleAction 
(
   id                   int                            not null,
   name                 varchar(50)                    null,
   code                 varchar(50)                    null,
   moduleId             int                            not null,
   sort                 int                            null,
   constraint PK_MODULEACTION primary key clustered (id)
);

comment on table ModuleAction is 
'ϵͳģ�鹦��';

comment on column ModuleAction.name is 
'��������';

comment on column ModuleAction.code is 
'���ܴ���';

comment on column ModuleAction.moduleId is 
'��SystemModule.id';

comment on column ModuleAction.sort is 
'����';

/*==============================================================*/
/* Table: RoleAction                                            */
/*==============================================================*/
create table RoleAction 
(
   id                   int                            not null,
   roleId               int                            null,
   actionId             int                            null,
   constraint PK_ROLEACTION primary key clustered (id)
);

comment on table RoleAction is 
'��ɫ����ģ�鹦��';

comment on column RoleAction.roleId is 
'��SystemRole.id';

comment on column RoleAction.actionId is 
'��ModuleAction.id';

/*==============================================================*/
/* Table: Seller                                                */
/*==============================================================*/
create table Seller 
(
   id                   int                            not null,
   name                 nvarchar(50)          null,
   cardNo               varchar(50)                    null,
   phone                varchar(50)                    not null,
   job                  nvarchar(50)          null,
   address              nvarchar(50)          null,
   constraint PK_SELLER primary key clustered (id)
);

comment on table Seller is 
'����';

comment on column Seller.name is 
'����';

comment on column Seller.cardNo is 
'���֤';

comment on column Seller.phone is 
'�ֻ���';

comment on column Seller.job is 
'ְҵ';

comment on column Seller.address is 
'��ַ';

/*==============================================================*/
/* Table: SystemModule                                          */
/*==============================================================*/
create table SystemModule 
(
   id                   int                            not null,
   name                 varchar(50)                    null,
   parentId             int                            null,
   constraint PK_SYSTEMMODULE primary key clustered (id)
);

comment on table SystemModule is 
'ϵͳģ��';

comment on column SystemModule.name is 
'ģ������';

comment on column SystemModule.parentId is 
'��ģ��ID';

/*==============================================================*/
/* Table: SystemRole                                            */
/*==============================================================*/
create table SystemRole 
(
   id                   int                            not null,
   name                 varchar(50)                    null,
   constraint PK_SYSTEMROLE primary key clustered (id)
);

comment on table SystemRole is 
'��ɫ��';

comment on column SystemRole.name is 
'��ɫ����';

/*==============================================================*/
/* Table: SytemUser                                             */
/*==============================================================*/
create table SytemUser 
(
   id                   int                            not null,
   loginName            nvarchar(50)          not null,
   loginPwd             varchar(50)                    not null,
   name                 nvarchar(50)          null,
   cardNo               varchar(50)                    not null,
   state                int                            null,
   phone                varchar(50)                    not null,
   address              nvarchar(100)         null,
   constraint PK_SYTEMUSER primary key clustered (id)
);

comment on table SytemUser is 
'ϵͳ�����û�';

comment on column SytemUser.loginName is 
'��¼��';

comment on column SytemUser.loginPwd is 
'��¼����';

comment on column SytemUser.name is 
'����';

comment on column SytemUser.cardNo is 
'���֤';

comment on column SytemUser.state is 
'0(ͣ��)��1(����)';

comment on column SytemUser.phone is 
'�ֻ���';

comment on column SytemUser.address is 
'��ַ';

/*==============================================================*/
/* Table: UserRole                                              */
/*==============================================================*/
create table UserRole 
(
   id                   int                            not null,
   userId               int                            null,
   roleId               int                            null,
   constraint PK_USERROLE primary key clustered (id)
);

comment on table UserRole is 
'ϵͳ�û���ɫ';

comment on column UserRole.userId is 
'��SystemUser.id';

comment on column UserRole.roleId is 
'��SystemRole.id';

