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
'买家';

comment on column Buyer.name is 
'姓名';

comment on column Buyer.cardNo is 
'身份证';

comment on column Buyer.phone is 
'手机号';

comment on column Buyer.job is 
'职业';

comment on column Buyer.address is 
'地址';

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
'车辆基本信息';

comment on column Car.sellerId is 
'表Seller.id';

comment on column Car.buyerId is 
'表Buyer.id';

comment on column Car.issueDate is 
'上牌日期';

comment on column Car.mileage is 
'里程数';

comment on column Car.issueAddress is 
'上牌地';

comment on column Car.gearBox is 
'自动、手动';

comment on column Car.ES is 
'排放标准';

comment on column Car.NJ is 
'年检到期';

comment on column Car.JQX is 
'交强险到期';

comment on column Car.SYX is 
'商业险到期';

comment on column Car.transferTimes is 
'过户次数';

comment on column Car.describe is 
'车辆描述';

comment on column Car.price is 
'车主报价（万）';

comment on column Car.dealState is 
'1:成交 0: 否';

comment on column Car.dealPrice is 
'实际成交价格（万）';

comment on column Car.saleState is 
'1:降价急售 0: 否';

comment on column Car.salePrice is 
'降价金额（万）';

comment on column Car.LSC is 
'1:练手车 0:否';

comment on column Car.newCar is 
'1:准新车 0:否';

comment on column Car.addTime is 
'信息录入时间';

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
'车辆配置';

comment on column CarConfig.carId is 
'CarInfo.id';

comment on column CarConfig.firm is 
'厂商';

comment on column CarConfig.class is 
'B级车';

comment on column CarConfig.itemName is 
'5	itemName	varchar	50	0				基本参数、发动机参数、底盘及制动';

comment on column CarConfig.gearBox is 
'自动、手动';

comment on column CarConfig.carBody is 
'车身结构';

comment on column CarConfig.LWH is 
'长宽高(mm)';

comment on column CarConfig.wheelBase is 
'轴距(mm)';

comment on column CarConfig.IDTCB is 
'行李箱容积(L)';

comment on column CarConfig.CW is 
'整备质量(KG)';

comment on column CarConfig.displacement is 
'排量(L)';

comment on column CarConfig.intakeType is 
'自然吸气、涡轮增压';

comment on column CarConfig.engineType is 
'L4、V6';

comment on column CarConfig.fullPower is 
'最大马力(Ps)';

comment on column CarConfig.MT is 
'最大扭矩(N*m)';

comment on column CarConfig.fuelType is 
'汽油、柴油';

comment on column CarConfig.fuelMode is 
'如：93(#)';

comment on column CarConfig.SW is 
'供油方式';

comment on column CarConfig.ES is 
'排放标准';

comment on column CarConfig.driveType is 
'驱动方式';

comment on column CarConfig.boostMode is 
'助力类型';

comment on column CarConfig.FSM is 
'前悬挂类型';

comment on column CarConfig.RSM is 
'后悬挂类型';

comment on column CarConfig.PBM is 
'驻车制动类型';

comment on column CarConfig.FTS is 
'前轮胎规格';

comment on column CarConfig.RTS is 
'后轮胎规格';

comment on column CarConfig.MDAB is 
'主驾驶气囊 标配/无
';

comment on column CarConfig.ADAB is 
'副驾驶气囊';

comment on column CarConfig.FSAB is 
'前排侧气囊';

comment on column CarConfig.RSAB is 
'后排侧气囊';

comment on column CarConfig.FHAB is 
'前排头部气囊';

comment on column CarConfig.RHAB is 
'后排头部气囊';

comment on column CarConfig.TPMS is 
'胎压检测';

comment on column CarConfig.carLock is 
'车内中控锁';

comment on column CarConfig.ISOFIX is 
'儿童座椅接口';

comment on column CarConfig.ABS is 
'防抱死系统';

comment on column CarConfig.ESP is 
'车身稳定系统';

comment on column CarConfig.sunroof is 
'电动天窗';

comment on column CarConfig.vistaSunroof is 
'全景天窗';

comment on column CarConfig.HID is 
'氙气大灯';

comment on column CarConfig.LED is 
'LED大灯';

comment on column CarConfig.autoHeadLight is 
'自动头灯';

comment on column CarConfig.frontFog is 
'前雾灯';

comment on column CarConfig.FPW is 
'前电动车窗';

comment on column CarConfig.RPW is 
'后电动车窗';

comment on column CarConfig.EAM is 
'后视镜电动调节';

comment on column CarConfig.mirrorHeat is 
'后视镜加热';

comment on column CarConfig.leatherSeat is 
'真皮座椅';

comment on column CarConfig.seatHeat is 
'座椅加热';

comment on column CarConfig.airSeat is 
'座椅通风';

comment on column CarConfig.MFL is 
'多功能方向盘';

comment on column CarConfig.CCS is 
'定速巡航';

comment on column CarConfig.GPS is 
'GPS导航';

comment on column CarConfig.backRadar is 
'倒车雷达';

comment on column CarConfig.BIS is 
'倒车影像系统';

comment on column CarConfig.ACS is 
'空调控制方式 自动/手动
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
'汽车图片';

comment on column CarPic.carId is 
'表Car.id主键';

comment on column CarPic.imgURL is 
'图片路径';

/*==============================================================*/
/* Table: CarTest                                               */
/*==============================================================*/
create table CarTest 
(
   id                   int                            not null,
   constraint PK_CARTEST primary key clustered (id)
);

comment on table CarTest is 
'汽车检测';

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
'车辆交易信息表';

comment on column DealInfo.cardId is 
'表Car.id';

comment on column DealInfo.buyerPhone is 
'买家电话';

comment on column DealInfo.bid is 
'买家出价';

comment on column DealInfo.callBack is 
'1:已回电 0:否';

comment on column DealInfo.state is 
'1:成交 0:否';

comment on column DealInfo.price is 
'实际成交价格（万）';

comment on column DealInfo.addTime is 
'信息添加时间';

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
'系统模块功能';

comment on column ModuleAction.name is 
'功能名称';

comment on column ModuleAction.code is 
'功能代号';

comment on column ModuleAction.moduleId is 
'表SystemModule.id';

comment on column ModuleAction.sort is 
'排序';

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
'角色关联模块功能';

comment on column RoleAction.roleId is 
'表SystemRole.id';

comment on column RoleAction.actionId is 
'表ModuleAction.id';

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
'卖家';

comment on column Seller.name is 
'姓名';

comment on column Seller.cardNo is 
'身份证';

comment on column Seller.phone is 
'手机号';

comment on column Seller.job is 
'职业';

comment on column Seller.address is 
'地址';

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
'系统模块';

comment on column SystemModule.name is 
'模块名称';

comment on column SystemModule.parentId is 
'父模块ID';

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
'角色表';

comment on column SystemRole.name is 
'角色名称';

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
'系统管理用户';

comment on column SytemUser.loginName is 
'登录名';

comment on column SytemUser.loginPwd is 
'登录密码';

comment on column SytemUser.name is 
'姓名';

comment on column SytemUser.cardNo is 
'身份证';

comment on column SytemUser.state is 
'0(停用)，1(启用)';

comment on column SytemUser.phone is 
'手机号';

comment on column SytemUser.address is 
'地址';

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
'系统用户角色';

comment on column UserRole.userId is 
'表SystemUser.id';

comment on column UserRole.roleId is 
'表SystemRole.id';

