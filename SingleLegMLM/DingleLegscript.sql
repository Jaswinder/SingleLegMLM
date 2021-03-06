USE [SingleLegDB]
GO
/****** Object:  Table [dbo].[AccountDetail]    Script Date: 17/04/2020 11:06:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountDetail](
	[CNT] [int] IDENTITY(1,1) NOT NULL,
	[MsrNo] [int] NOT NULL,
	[DirectI] [int] NOT NULL,
	[LevelI] [int] NOT NULL,
	[RewardI] [int] NOT NULL,
	[SponserI] [decimal](12, 2) NOT NULL,
	[Royalty] [decimal](12, 2) NOT NULL,
	[Levelno] [int] NOT NULL,
	[TotalAmount] [int] NOT NULL,
	[TDS] [numeric](18, 2) NOT NULL,
	[Admin] [numeric](18, 2) NOT NULL,
	[NetAmount1] [numeric](18, 2) NOT NULL,
	[Addamt] [decimal](12, 2) NOT NULL,
	[Lessamt] [decimal](12, 2) NOT NULL,
	[Remark] [varchar](5000) NULL,
	[PayDate] [datetime] NOT NULL,
	[ChNo] [int] NOT NULL,
	[ChDate] [datetime] NULL,
	[IsLast] [int] NOT NULL,
	[ReEntry] [int] NOT NULL,
	[Paytype] [char](1) NULL,
	[IsFinalPaid] [int] NOT NULL,
	[Walletamount] [decimal](12, 2) NOT NULL,
	[WalletFlag] [int] NOT NULL,
	[Singleleg] [decimal](12, 2) NOT NULL,
	[LeaderShipBonus] [decimal](12, 2) NOT NULL,
	[Rlevelno] [int] NOT NULL,
	[ManagerialLevel] [int] NOT NULL,
	[ManagerialI] [decimal](12, 2) NOT NULL,
	[RepurRoyalty] [decimal](12, 2) NOT NULL,
	[Totalmembers] [int] NOT NULL,
	[PDate] [datetime] NULL,
	[IsPayment] [datetime] NULL,
	[Paymentoption] [int] NOT NULL,
	[AdvanceI] [decimal](12, 2) NOT NULL,
	[NetAmount]  AS ((([Netamount1]+[addamt])-[Lessamt])-[reentry]),
 CONSTRAINT [PK_AccountDetail] PRIMARY KEY CLUSTERED 
(
	[CNT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CompanyInfo]    Script Date: 17/04/2020 11:06:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompanyInfo](
	[CNT] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [varchar](150) NOT NULL,
	[Add1] [varchar](100) NOT NULL,
	[Add2] [varchar](100) NOT NULL,
	[PhNo] [varchar](50) NOT NULL,
	[MobileNo] [varchar](100) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[CompURL] [varchar](100) NOT NULL,
	[UserName] [varchar](20) NOT NULL,
	[Password] [varchar](20) NOT NULL,
	[MGrowthPer] [int] NOT NULL,
	[JumpID] [int] NULL,
	[Start] [int] NOT NULL,
 CONSTRAINT [PK_CompanyInfo] PRIMARY KEY CLUSTERED 
(
	[CNT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[eTicket]    Script Date: 17/04/2020 11:06:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[eTicket](
	[PinId] [int] IDENTITY(1,1) NOT NULL,
	[GenDate] [datetime] NOT NULL,
	[Nos] [int] NOT NULL,
	[UserId] [varchar](50) NOT NULL,
	[ETicket] [varchar](50) NOT NULL,
	[IsPrint] [int] NOT NULL,
	[IsUsed] [int] NOT NULL,
	[IsCancel] [int] NOT NULL,
	[ItemId] [int] NOT NULL,
	[PMode] [varchar](20) NULL,
	[DDNo] [varchar](30) NULL,
	[DDDate] [datetime] NULL,
	[EpinNo] [int] NOT NULL,
	[Narration] [varchar](max) NULL,
	[Bank] [varchar](500) NULL,
	[UserType] [varchar](50) NULL,
	[Transfer] [varchar](5000) NOT NULL,
	[ToMsrno] [int] NOT NULL,
	[ToDate] [datetime] NULL,
 CONSTRAINT [PK_eTicket] PRIMARY KEY CLUSTERED 
(
	[PinId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GreenDetail]    Script Date: 17/04/2020 11:06:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GreenDetail](
	[Sno] [int] IDENTITY(1,1) NOT NULL,
	[Msrno] [int] NOT NULL,
	[MemberID] [varchar](50) NULL,
	[Paiddt] [datetime] NULL,
	[ETicketId] [int] NOT NULL,
 CONSTRAINT [PK_GreenDetail] PRIMARY KEY CLUSTERED 
(
	[Sno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InccentiveSlab]    Script Date: 17/04/2020 11:06:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InccentiveSlab](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PVfrom] [int] NOT NULL,
	[PVto] [int] NOT NULL,
	[Amount] [decimal](15, 2) NOT NULL,
 CONSTRAINT [PK_InccentiveSlab_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LevelHistory]    Script Date: 17/04/2020 11:06:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LevelHistory](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Msrno] [int] NOT NULL,
	[DateOn] [datetime] NOT NULL,
	[LevelNo] [int] NOT NULL,
 CONSTRAINT [PK_LevelHistory] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LevelMaster]    Script Date: 17/04/2020 11:06:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LevelMaster](
	[LevelId] [int] IDENTITY(1,1) NOT NULL,
	[LevelName] [int] NOT NULL,
	[LevelPercent] [int] NOT NULL,
 CONSTRAINT [PK_LevelMaster] PRIMARY KEY CLUSTERED 
(
	[LevelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PartyIncome]    Script Date: 17/04/2020 11:06:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PartyIncome](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Msrno] [int] NOT NULL,
	[MemberID] [varchar](100) NOT NULL,
	[ParentStr] [varchar](max) NOT NULL,
	[IntroIDStr] [varchar](max) NOT NULL,
	[LeftMsrno] [int] NOT NULL,
	[Rightmsrno] [int] NOT NULL,
	[Mscheme] [int] NOT NULL,
	[SelfPV] [int] NOT NULL,
	[TotalPV] [int] NOT NULL,
	[CurPV] [int] NOT NULL,
	[Paidpairs] [int] NOT NULL,
	[PaidXpv] [int] NOT NULL,
	[PaidyPV] [int] NOT NULL,
	[ForBinary] [int] NOT NULL,
	[Legdate] [datetime] NULL,
	[LegFlag] [int] NOT NULL,
	[Royltymem] [int] NOT NULL,
	[Magmembers] [int] NOT NULL,
	[ManagerialLevel] [int] NOT NULL,
	[PDcount] [int] NOT NULL,
	[CurrMagmembers] [int] NOT NULL,
	[Singleleg] [decimal](12, 2) NOT NULL,
	[UnlimitedI] [decimal](12, 2) NOT NULL,
	[Royalty] [decimal](12, 2) NOT NULL,
	[ManagerialI] [decimal](12, 2) NOT NULL,
	[DirectI] [int] NOT NULL,
	[Isactive] [int] NOT NULL,
 CONSTRAINT [PK_PartyIncome] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PartyMaster]    Script Date: 17/04/2020 11:06:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PartyMaster](
	[Msrno] [int] IDENTITY(1,1) NOT NULL,
	[MemberId] [varchar](50) NOT NULL,
	[SponsorId] [varchar](50) NULL,
	[IntroMsrNo] [int] NULL,
	[UpId] [varchar](50) NULL,
	[UpMsrNo] [int] NULL,
	[Sex] [varchar](10) NULL,
	[MemberName] [varchar](100) NULL,
	[DOJ] [datetime] NOT NULL,
	[CareOfTitle] [varchar](4) NULL,
	[CareOfName] [varchar](40) NULL,
	[DOB] [datetime] NULL,
	[Address] [varchar](500) NULL,
	[City] [varchar](50) NULL,
	[State] [varchar](50) NULL,
	[PinCode] [varchar](50) NULL,
	[Phones] [varchar](100) NULL,
	[Mobile] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Profession] [varchar](50) NULL,
	[MStatus] [varchar](50) NULL,
	[NName] [varchar](50) NULL,
	[NRelation] [varchar](50) NULL,
	[NDOB] [datetime] NULL,
	[MScheme] [int] NULL,
	[PMode] [varchar](50) NULL,
	[DDNo] [varchar](50) NULL,
	[DDDate] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[Paiddt] [datetime] NULL,
	[IsActive] [char](1) NULL,
	[BankName] [varchar](200) NULL,
	[BranchName] [varchar](50) NULL,
	[AcNo] [varchar](50) NULL,
	[PanNo] [varchar](50) NULL,
	[DtUser] [varchar](50) NULL,
	[ETicket] [varchar](50) NOT NULL,
	[Rejoining] [int] NOT NULL,
	[DeActive] [int] NOT NULL,
	[LastLogin] [datetime] NULL,
	[LegC] [int] NOT NULL,
	[PageOPTION] [int] NOT NULL,
	[tempLeg] [char](1) NULL,
	[Scode] [varchar](50) NULL,
	[Nameprefix] [varchar](5) NULL,
	[Coupan] [varchar](30) NULL,
	[Cuopan1] [varchar](200) NULL,
	[ISFC] [varchar](200) NULL,
	[UserUode] [varchar](200) NULL,
	[InvoiceNo] [varchar](200) NULL,
	[StateID] [int] NOT NULL,
	[IsPrint] [int] NOT NULL,
	[BillDate] [datetime] NULL,
	[IsPan] [int] NOT NULL,
	[PaymentOptionId] [int] NOT NULL,
	[IsTransferAc] [varchar](50) NULL,
	[IsTransferVoucher] [varchar](50) NULL,
	[Submscheme] [int] NOT NULL,
	[Remark] [varchar](500) NULL,
	[Shipping] [int] NOT NULL,
	[ByMsrno] [int] NOT NULL,
	[Isdocument] [int] NOT NULL,
	[DocumentDt] [datetime] NULL,
	[OldMscheme] [int] NOT NULL,
	[UniqueUrl] [nvarchar](500) NULL,
	[AadharNo] [nvarchar](50) NULL,
	[SponsorName] [nvarchar](100) NULL,
 CONSTRAINT [PK_PartyMaster] PRIMARY KEY CLUSTERED 
(
	[Msrno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Partypromotion]    Script Date: 17/04/2020 11:06:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Partypromotion](
	[Sno] [int] IDENTITY(1,1) NOT NULL,
	[Msrno] [int] NOT NULL,
	[MemberID] [varchar](50) NOT NULL,
	[Level1] [int] NOT NULL,
	[Level2] [int] NOT NULL,
	[Level3] [int] NOT NULL,
	[Level4] [int] NOT NULL,
	[Level5] [int] NOT NULL,
	[Level6] [int] NOT NULL,
	[ISLevel1] [int] NOT NULL,
	[ISLevel2] [int] NOT NULL,
	[ISLevel3] [int] NOT NULL,
	[ISLevel4] [int] NOT NULL,
	[ISLevel5] [int] NOT NULL,
	[ISLevel6] [int] NOT NULL,
 CONSTRAINT [PK_Partypromotion] PRIMARY KEY CLUSTERED 
(
	[Sno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Partytree]    Script Date: 17/04/2020 11:06:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Partytree](
	[MsrNo] [int] IDENTITY(1,1) NOT NULL,
	[MemberId] [varchar](50) NOT NULL,
	[ParentId] [int] NOT NULL,
	[ParentStr] [varchar](max) NULL,
	[IntroIdStr] [varchar](max) NULL,
	[LeftMsrNo] [int] NOT NULL,
	[RightMsrNo] [int] NOT NULL,
	[TotalMembers] [int] NOT NULL,
	[TotalPV] [int] NOT NULL,
	[Paidpairs] [int] NOT NULL,
	[Reward] [varchar](200) NOT NULL,
	[Gen_in] [varchar](200) NOT NULL,
	[DirectI] [int] NOT NULL,
	[ForBinary] [int] NOT NULL,
	[Mscheme] [int] NOT NULL,
	[Levelno] [int] NULL,
	[SelfPV] [int] NOT NULL,
	[PaidXPV] [int] NOT NULL,
	[PaidYPV] [int] NOT NULL,
	[Ptotalmembers] [int] NOT NULL,
	[PtotalPV] [decimal](12, 2) NOT NULL,
	[Paiddt] [datetime] NULL,
	[Isactive] [char](1) NULL,
	[PTotalUnits] [decimal](12, 2) NOT NULL,
	[TotalUnits] [decimal](12, 2) NOT NULL,
	[PDcount] [int] NOT NULL,
	[Paidlevel] [int] NOT NULL,
	[NWMonth] [int] NOT NULL,
	[GrowthI] [decimal](12, 2) NOT NULL,
	[SponserI] [decimal](12, 2) NOT NULL,
	[RewardI] [decimal](12, 2) NOT NULL,
	[LevelI] [decimal](12, 2) NOT NULL,
	[SpIncome] [decimal](10, 2) NOT NULL,
	[Royalty] [decimal](12, 2) NOT NULL,
	[Rlevel] [int] NOT NULL,
	[LeaderShipB] [decimal](12, 2) NOT NULL,
	[UnlimitedI] [decimal](12, 2) NOT NULL,
	[SingleLeg] [decimal](12, 2) NOT NULL,
	[LegDate] [datetime] NULL,
	[LegFlag] [int] NOT NULL,
	[ManagerialI] [decimal](12, 2) NOT NULL,
	[ManagerialLevel] [int] NOT NULL,
	[MagMembers] [int] NOT NULL,
	[CurrmagMembers] [int] NOT NULL,
	[SpI] [decimal](12, 2) NOT NULL,
	[RePurLevelno] [int] NOT NULL,
	[RepurRoyalty] [decimal](12, 2) NOT NULL,
	[PurchaseI] [decimal](12, 2) NOT NULL,
	[TSaleCountDirect] [int] NOT NULL,
	[Royltymem] [int] NOT NULL,
	[RewardPV] [int] NOT NULL,
 CONSTRAINT [PK_Partytree] PRIMARY KEY CLUSTERED 
(
	[MsrNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Paydetail]    Script Date: 17/04/2020 11:06:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Paydetail](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDNO] [float] NULL,
	[ReferenceNo] [nvarchar](255) NULL,
	[AccNo] [nvarchar](255) NULL,
	[NameofCustomer] [nvarchar](255) NULL,
	[BANKNAME] [nvarchar](255) NULL,
	[DETAIL] [nvarchar](255) NULL,
	[Paymentoptionid] [int] NOT NULL,
 CONSTRAINT [PK_Paydetail] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblRewards]    Script Date: 17/04/2020 11:06:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblRewards](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CNT] [int] NOT NULL,
	[IssueDate] [datetime] NOT NULL,
	[LevelNo] [int] NOT NULL,
	[Ides] [varchar](max) NOT NULL,
 CONSTRAINT [PK_tblRewards] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbltransferepin]    Script Date: 17/04/2020 11:06:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbltransferepin](
	[Sno] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [varchar](50) NULL,
	[ToMemberid] [varchar](50) NULL,
	[Totepin] [varchar](500) NULL,
	[DateTo] [datetime] NULL,
	[ItemId] [int] NULL,
 CONSTRAINT [PK_tbltransferepin] PRIMARY KEY CLUSTERED 
(
	[Sno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblWalletDetails]    Script Date: 17/04/2020 11:06:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblWalletDetails](
	[CNT] [int] IDENTITY(1,1) NOT NULL,
	[MsrNo] [int] NOT NULL,
	[Amount] [decimal](12, 2) NOT NULL,
	[TransactionWith] [int] NOT NULL,
	[Description] [varchar](200) NOT NULL,
	[DateOn] [datetime] NULL,
	[ByAdmin] [varchar](50) NULL,
	[Usertype] [varchar](50) NULL,
	[TType] [varchar](50) NULL,
	[IsLast] [int] NOT NULL,
 CONSTRAINT [PK_tblWalletDetails] PRIMARY KEY CLUSTERED 
(
	[CNT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblWalletPayment]    Script Date: 17/04/2020 11:06:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblWalletPayment](
	[CNT] [int] IDENTITY(1,1) NOT NULL,
	[MsrNo] [int] NOT NULL,
	[Amount] [decimal](12, 2) NOT NULL,
	[PayDate] [datetime] NOT NULL,
	[ChNo] [int] NOT NULL,
	[ChDate] [datetime] NULL,
 CONSTRAINT [PK_tblWalletPayment] PRIMARY KEY CLUSTERED 
(
	[CNT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblWalletSCode]    Script Date: 17/04/2020 11:06:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblWalletSCode](
	[CNT] [int] IDENTITY(1,1) NOT NULL,
	[MsrNo] [int] NOT NULL,
	[SCode] [varchar](25) NOT NULL,
	[DateOn] [datetime] NOT NULL,
 CONSTRAINT [PK_tblWalletSCode] PRIMARY KEY CLUSTERED 
(
	[CNT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblWalletStatus]    Script Date: 17/04/2020 11:06:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblWalletStatus](
	[CNT] [int] IDENTITY(1,1) NOT NULL,
	[MsrNo] [int] NOT NULL,
	[Cr] [decimal](12, 2) NOT NULL,
	[Dr] [decimal](12, 2) NOT NULL,
	[BalAmount]  AS ([Cr]-[Dr]),
 CONSTRAINT [PK_tblWalletStatus] PRIMARY KEY CLUSTERED 
(
	[CNT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usermaster]    Script Date: 17/04/2020 11:06:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usermaster](
	[Sno] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](100) NULL,
	[Password] [varchar](100) NULL,
	[IsAdmin] [int] NOT NULL,
	[Name] [varchar](200) NULL,
	[TIN] [varchar](200) NULL,
	[ParentCode] [varchar](200) NULL,
	[Type] [varchar](200) NULL,
	[Creditlimit] [decimal](12, 2) NOT NULL,
	[Epassword] [varchar](50) NULL,
	[Block] [int] NOT NULL,
	[UserType] [varchar](50) NULL,
	[BranchCode] [int] NOT NULL,
 CONSTRAINT [PK_Usermaster] PRIMARY KEY CLUSTERED 
(
	[Sno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[eTicket] ON 

INSERT [dbo].[eTicket] ([PinId], [GenDate], [Nos], [UserId], [ETicket], [IsPrint], [IsUsed], [IsCancel], [ItemId], [PMode], [DDNo], [DDDate], [EpinNo], [Narration], [Bank], [UserType], [Transfer], [ToMsrno], [ToDate]) VALUES (4, CAST(N'2020-04-14T00:00:00.000' AS DateTime), 1, N'1', N'abc', 0, 0, 0, 1, NULL, NULL, NULL, 1, NULL, NULL, NULL, N',', 0, NULL)
SET IDENTITY_INSERT [dbo].[eTicket] OFF
SET IDENTITY_INSERT [dbo].[PartyMaster] ON 

INSERT [dbo].[PartyMaster] ([Msrno], [MemberId], [SponsorId], [IntroMsrNo], [UpId], [UpMsrNo], [Sex], [MemberName], [DOJ], [CareOfTitle], [CareOfName], [DOB], [Address], [City], [State], [PinCode], [Phones], [Mobile], [Email], [Profession], [MStatus], [NName], [NRelation], [NDOB], [MScheme], [PMode], [DDNo], [DDDate], [Password], [Paiddt], [IsActive], [BankName], [BranchName], [AcNo], [PanNo], [DtUser], [ETicket], [Rejoining], [DeActive], [LastLogin], [LegC], [PageOPTION], [tempLeg], [Scode], [Nameprefix], [Coupan], [Cuopan1], [ISFC], [UserUode], [InvoiceNo], [StateID], [IsPrint], [BillDate], [IsPan], [PaymentOptionId], [IsTransferAc], [IsTransferVoucher], [Submscheme], [Remark], [Shipping], [ByMsrno], [Isdocument], [DocumentDt], [OldMscheme], [UniqueUrl], [AadharNo], [SponsorName]) VALUES (15, N'ADIN20041', NULL, 0, NULL, NULL, N'Male', N'Jaswinder', CAST(N'2020-04-17T10:18:15.227' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'7600000', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'123456', NULL, N'N', NULL, NULL, NULL, N'rtyfg', NULL, N'0', 0, 0, NULL, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, 0, 4, NULL, NULL, 0, NULL, 0, 0, 0, NULL, 0, NULL, NULL, NULL)
INSERT [dbo].[PartyMaster] ([Msrno], [MemberId], [SponsorId], [IntroMsrNo], [UpId], [UpMsrNo], [Sex], [MemberName], [DOJ], [CareOfTitle], [CareOfName], [DOB], [Address], [City], [State], [PinCode], [Phones], [Mobile], [Email], [Profession], [MStatus], [NName], [NRelation], [NDOB], [MScheme], [PMode], [DDNo], [DDDate], [Password], [Paiddt], [IsActive], [BankName], [BranchName], [AcNo], [PanNo], [DtUser], [ETicket], [Rejoining], [DeActive], [LastLogin], [LegC], [PageOPTION], [tempLeg], [Scode], [Nameprefix], [Coupan], [Cuopan1], [ISFC], [UserUode], [InvoiceNo], [StateID], [IsPrint], [BillDate], [IsPan], [PaymentOptionId], [IsTransferAc], [IsTransferVoucher], [Submscheme], [Remark], [Shipping], [ByMsrno], [Isdocument], [DocumentDt], [OldMscheme], [UniqueUrl], [AadharNo], [SponsorName]) VALUES (16, N'ADIN20042', NULL, 0, NULL, NULL, N'Male', N'Jaswinder 2', CAST(N'2020-04-17T10:18:29.740' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'7600000', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'123456', NULL, N'N', NULL, NULL, NULL, N'rtyfg', NULL, N'0', 0, 0, NULL, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, 0, 4, NULL, NULL, 0, NULL, 0, 0, 0, NULL, 0, NULL, NULL, NULL)
INSERT [dbo].[PartyMaster] ([Msrno], [MemberId], [SponsorId], [IntroMsrNo], [UpId], [UpMsrNo], [Sex], [MemberName], [DOJ], [CareOfTitle], [CareOfName], [DOB], [Address], [City], [State], [PinCode], [Phones], [Mobile], [Email], [Profession], [MStatus], [NName], [NRelation], [NDOB], [MScheme], [PMode], [DDNo], [DDDate], [Password], [Paiddt], [IsActive], [BankName], [BranchName], [AcNo], [PanNo], [DtUser], [ETicket], [Rejoining], [DeActive], [LastLogin], [LegC], [PageOPTION], [tempLeg], [Scode], [Nameprefix], [Coupan], [Cuopan1], [ISFC], [UserUode], [InvoiceNo], [StateID], [IsPrint], [BillDate], [IsPan], [PaymentOptionId], [IsTransferAc], [IsTransferVoucher], [Submscheme], [Remark], [Shipping], [ByMsrno], [Isdocument], [DocumentDt], [OldMscheme], [UniqueUrl], [AadharNo], [SponsorName]) VALUES (17, N'ADIN20043', N'ADIN20042', 0, NULL, NULL, N'Male', N'Harpreet', CAST(N'2020-04-17T10:44:16.103' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'01826220128', N'chauhanpersonal@gmail.com', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'123', NULL, N'N', NULL, NULL, NULL, N'546tyr1', NULL, N'0', 0, 0, NULL, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, 0, 4, NULL, NULL, 0, NULL, 0, 0, 0, NULL, 0, NULL, NULL, N'jaswinder singh')
INSERT [dbo].[PartyMaster] ([Msrno], [MemberId], [SponsorId], [IntroMsrNo], [UpId], [UpMsrNo], [Sex], [MemberName], [DOJ], [CareOfTitle], [CareOfName], [DOB], [Address], [City], [State], [PinCode], [Phones], [Mobile], [Email], [Profession], [MStatus], [NName], [NRelation], [NDOB], [MScheme], [PMode], [DDNo], [DDDate], [Password], [Paiddt], [IsActive], [BankName], [BranchName], [AcNo], [PanNo], [DtUser], [ETicket], [Rejoining], [DeActive], [LastLogin], [LegC], [PageOPTION], [tempLeg], [Scode], [Nameprefix], [Coupan], [Cuopan1], [ISFC], [UserUode], [InvoiceNo], [StateID], [IsPrint], [BillDate], [IsPan], [PaymentOptionId], [IsTransferAc], [IsTransferVoucher], [Submscheme], [Remark], [Shipping], [ByMsrno], [Isdocument], [DocumentDt], [OldMscheme], [UniqueUrl], [AadharNo], [SponsorName]) VALUES (21, N'ADIN20044', N'ADIN20042', 0, NULL, NULL, N'Male', N'Harpret', CAST(N'2020-04-17T11:04:11.363' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'678', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'123', NULL, N'N', NULL, NULL, NULL, N'345', NULL, N'0', 0, 0, NULL, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, 0, 4, NULL, NULL, 0, NULL, 0, 0, 0, NULL, 0, NULL, NULL, N'jaswinder')
INSERT [dbo].[PartyMaster] ([Msrno], [MemberId], [SponsorId], [IntroMsrNo], [UpId], [UpMsrNo], [Sex], [MemberName], [DOJ], [CareOfTitle], [CareOfName], [DOB], [Address], [City], [State], [PinCode], [Phones], [Mobile], [Email], [Profession], [MStatus], [NName], [NRelation], [NDOB], [MScheme], [PMode], [DDNo], [DDDate], [Password], [Paiddt], [IsActive], [BankName], [BranchName], [AcNo], [PanNo], [DtUser], [ETicket], [Rejoining], [DeActive], [LastLogin], [LegC], [PageOPTION], [tempLeg], [Scode], [Nameprefix], [Coupan], [Cuopan1], [ISFC], [UserUode], [InvoiceNo], [StateID], [IsPrint], [BillDate], [IsPan], [PaymentOptionId], [IsTransferAc], [IsTransferVoucher], [Submscheme], [Remark], [Shipping], [ByMsrno], [Isdocument], [DocumentDt], [OldMscheme], [UniqueUrl], [AadharNo], [SponsorName]) VALUES (22, N'ADIN20045', N'ADIN20042', 16, NULL, NULL, N'Male', N'Harpret', CAST(N'2020-04-17T11:05:42.933' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'678', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'123', NULL, N'N', NULL, NULL, NULL, N'345', NULL, N'0', 0, 0, NULL, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, 0, 4, NULL, NULL, 0, NULL, 0, 0, 0, NULL, 0, NULL, NULL, N'jaswinder')
SET IDENTITY_INSERT [dbo].[PartyMaster] OFF
ALTER TABLE [dbo].[CompanyInfo] ADD  CONSTRAINT [DF__CompanyIn__Compa__6442E2C9]  DEFAULT ('') FOR [CompanyName]
GO
ALTER TABLE [dbo].[CompanyInfo] ADD  CONSTRAINT [DF__CompanyInf__Add1__65370702]  DEFAULT ('') FOR [Add1]
GO
ALTER TABLE [dbo].[CompanyInfo] ADD  CONSTRAINT [DF__CompanyInf__Add2__662B2B3B]  DEFAULT ('') FOR [Add2]
GO
ALTER TABLE [dbo].[CompanyInfo] ADD  CONSTRAINT [DF__CompanyInf__PhNo__671F4F74]  DEFAULT ('') FOR [PhNo]
GO
ALTER TABLE [dbo].[CompanyInfo] ADD  CONSTRAINT [DF__CompanyIn__Mobil__681373AD]  DEFAULT ('') FOR [MobileNo]
GO
ALTER TABLE [dbo].[CompanyInfo] ADD  CONSTRAINT [DF__CompanyIn__Email__690797E6]  DEFAULT ('') FOR [Email]
GO
ALTER TABLE [dbo].[CompanyInfo] ADD  CONSTRAINT [DF__CompanyIn__CompU__69FBBC1F]  DEFAULT ('') FOR [CompURL]
GO
ALTER TABLE [dbo].[CompanyInfo] ADD  CONSTRAINT [DF__CompanyIn__UserN__6AEFE058]  DEFAULT ('admin') FOR [UserName]
GO
ALTER TABLE [dbo].[CompanyInfo] ADD  CONSTRAINT [DF__CompanyIn__Passw__6BE40491]  DEFAULT ('admin') FOR [Password]
GO
ALTER TABLE [dbo].[CompanyInfo] ADD  CONSTRAINT [DF__CompanyIn__MGrow__373B3228]  DEFAULT ((0)) FOR [MGrowthPer]
GO
ALTER TABLE [dbo].[CompanyInfo] ADD  CONSTRAINT [DF__CompanyIn__start__5402595F]  DEFAULT ((0)) FOR [Start]
GO
ALTER TABLE [dbo].[eTicket] ADD  CONSTRAINT [DF_ePin_GenDate]  DEFAULT (getdate()) FOR [GenDate]
GO
ALTER TABLE [dbo].[eTicket] ADD  CONSTRAINT [DF_ePin_IsPrint]  DEFAULT ((0)) FOR [IsPrint]
GO
ALTER TABLE [dbo].[eTicket] ADD  CONSTRAINT [DF_ePin_IsUsed]  DEFAULT ((0)) FOR [IsUsed]
GO
ALTER TABLE [dbo].[eTicket] ADD  CONSTRAINT [DF_ePin_IsCancel]  DEFAULT ((0)) FOR [IsCancel]
GO
ALTER TABLE [dbo].[eTicket] ADD  CONSTRAINT [DF__eTicket__Transfe__31E24B85]  DEFAULT (',') FOR [Transfer]
GO
ALTER TABLE [dbo].[eTicket] ADD  CONSTRAINT [DF__eTicket__toMsrno__32D66FBE]  DEFAULT ((0)) FOR [ToMsrno]
GO
ALTER TABLE [dbo].[PartyIncome] ADD  CONSTRAINT [DF__PartyInco__Msrno__104C4D90]  DEFAULT ((0)) FOR [Msrno]
GO
ALTER TABLE [dbo].[PartyIncome] ADD  CONSTRAINT [DF__PartyInco__Paren__114071C9]  DEFAULT (',') FOR [ParentStr]
GO
ALTER TABLE [dbo].[PartyIncome] ADD  CONSTRAINT [DF__PartyInco__Intro__12349602]  DEFAULT (',') FOR [IntroIDStr]
GO
ALTER TABLE [dbo].[PartyIncome] ADD  CONSTRAINT [DF__PartyInco__LeftM__1328BA3B]  DEFAULT ((0)) FOR [LeftMsrno]
GO
ALTER TABLE [dbo].[PartyIncome] ADD  CONSTRAINT [DF__PartyInco__Right__141CDE74]  DEFAULT ((0)) FOR [Rightmsrno]
GO
ALTER TABLE [dbo].[PartyIncome] ADD  CONSTRAINT [DF__PartyInco__Msche__151102AD]  DEFAULT ((0)) FOR [Mscheme]
GO
ALTER TABLE [dbo].[PartyIncome] ADD  CONSTRAINT [DF__PartyInco__SelfP__160526E6]  DEFAULT ((0)) FOR [SelfPV]
GO
ALTER TABLE [dbo].[PartyIncome] ADD  CONSTRAINT [DF__PartyInco__Total__16F94B1F]  DEFAULT ((0)) FOR [TotalPV]
GO
ALTER TABLE [dbo].[PartyIncome] ADD  CONSTRAINT [DF__PartyInco__CurPV__17ED6F58]  DEFAULT ((0)) FOR [CurPV]
GO
ALTER TABLE [dbo].[PartyIncome] ADD  CONSTRAINT [DF__PartyInco__Paidp__18E19391]  DEFAULT ((0)) FOR [Paidpairs]
GO
ALTER TABLE [dbo].[PartyIncome] ADD  CONSTRAINT [DF__PartyInco__PaidX__19D5B7CA]  DEFAULT ((0)) FOR [PaidXpv]
GO
ALTER TABLE [dbo].[PartyIncome] ADD  CONSTRAINT [DF__PartyInco__Paidy__1AC9DC03]  DEFAULT ((0)) FOR [PaidyPV]
GO
ALTER TABLE [dbo].[PartyIncome] ADD  CONSTRAINT [DF__PartyInco__ForBi__1BBE003C]  DEFAULT ((0)) FOR [ForBinary]
GO
ALTER TABLE [dbo].[PartyIncome] ADD  CONSTRAINT [DF__PartyInco__LegFl__1CB22475]  DEFAULT ((0)) FOR [LegFlag]
GO
ALTER TABLE [dbo].[PartyIncome] ADD  CONSTRAINT [DF__PartyInco__Roylt__1DA648AE]  DEFAULT ((0)) FOR [Royltymem]
GO
ALTER TABLE [dbo].[PartyIncome] ADD  CONSTRAINT [DF__PartyInco__Magme__226AFDCB]  DEFAULT ((0)) FOR [Magmembers]
GO
ALTER TABLE [dbo].[PartyIncome] ADD  CONSTRAINT [DF__PartyInco__Manag__235F2204]  DEFAULT ((0)) FOR [ManagerialLevel]
GO
ALTER TABLE [dbo].[PartyIncome] ADD  CONSTRAINT [DF__PartyInco__PDcou__2B0043CC]  DEFAULT ((0)) FOR [PDcount]
GO
ALTER TABLE [dbo].[PartyIncome] ADD  CONSTRAINT [DF__PartyInco__currM__2BF46805]  DEFAULT ((0)) FOR [CurrMagmembers]
GO
ALTER TABLE [dbo].[PartyIncome] ADD  CONSTRAINT [DF__PartyInco__Singl__394E6323]  DEFAULT ((0)) FOR [Singleleg]
GO
ALTER TABLE [dbo].[PartyIncome] ADD  CONSTRAINT [DF__PartyInco__Unlim__3A42875C]  DEFAULT ((0)) FOR [UnlimitedI]
GO
ALTER TABLE [dbo].[PartyIncome] ADD  CONSTRAINT [DF__PartyInco__Royal__3C2ACFCE]  DEFAULT ((0)) FOR [Royalty]
GO
ALTER TABLE [dbo].[PartyIncome] ADD  CONSTRAINT [DF__PartyInco__Manag__3D1EF407]  DEFAULT ((0)) FOR [ManagerialI]
GO
ALTER TABLE [dbo].[PartyIncome] ADD  CONSTRAINT [DF__PartyInco__Direc__1A94D1D9]  DEFAULT ((0)) FOR [DirectI]
GO
ALTER TABLE [dbo].[PartyIncome] ADD  CONSTRAINT [DF__PartyInco__Isact__1B88F612]  DEFAULT ((0)) FOR [Isactive]
GO
ALTER TABLE [dbo].[PartyMaster] ADD  CONSTRAINT [DF_MemberMaster_IntroMsrNo]  DEFAULT ((0)) FOR [IntroMsrNo]
GO
ALTER TABLE [dbo].[PartyMaster] ADD  CONSTRAINT [DF_MemberMaster_IsActive]  DEFAULT ('N') FOR [IsActive]
GO
ALTER TABLE [dbo].[PartyMaster] ADD  CONSTRAINT [DF_MemberMaster_Rejoining]  DEFAULT ((0)) FOR [Rejoining]
GO
ALTER TABLE [dbo].[PartyMaster] ADD  CONSTRAINT [DF__MemberMas__DeAct__0E6E26BF]  DEFAULT ((0)) FOR [DeActive]
GO
ALTER TABLE [dbo].[PartyMaster] ADD  CONSTRAINT [DF__PartyMaste__legC__09A971A2]  DEFAULT ((0)) FOR [LegC]
GO
ALTER TABLE [dbo].[PartyMaster] ADD  CONSTRAINT [DF__PartyMast__POPTI__6166761E]  DEFAULT ((0)) FOR [PageOPTION]
GO
ALTER TABLE [dbo].[PartyMaster] ADD  CONSTRAINT [DF__PartyMast__State__47E69B3D]  DEFAULT ((0)) FOR [StateID]
GO
ALTER TABLE [dbo].[PartyMaster] ADD  CONSTRAINT [DF_PartyMaster_isprint]  DEFAULT ((0)) FOR [IsPrint]
GO
ALTER TABLE [dbo].[PartyMaster] ADD  CONSTRAINT [DF__PartyMast__Ispan__17CD73C7]  DEFAULT ((0)) FOR [IsPan]
GO
ALTER TABLE [dbo].[PartyMaster] ADD  CONSTRAINT [DF__PartyMast__Payme__25276EE5]  DEFAULT ((4)) FOR [PaymentOptionId]
GO
ALTER TABLE [dbo].[PartyMaster] ADD  CONSTRAINT [DF__PartyMast__Subms__6C79016E]  DEFAULT ((0)) FOR [Submscheme]
GO
ALTER TABLE [dbo].[PartyMaster] ADD  CONSTRAINT [DF__PartyMast__Shipp__06F7ED80]  DEFAULT ((0)) FOR [Shipping]
GO
ALTER TABLE [dbo].[PartyMaster] ADD  CONSTRAINT [DF__PartyMast__byMsr__4C9641C1]  DEFAULT ((0)) FOR [ByMsrno]
GO
ALTER TABLE [dbo].[PartyMaster] ADD  CONSTRAINT [DF__PartyMast__Isdoc__6FAA73D4]  DEFAULT ((0)) FOR [Isdocument]
GO
ALTER TABLE [dbo].[PartyMaster] ADD  CONSTRAINT [DF__PartyMast__OldMs__37311087]  DEFAULT ((0)) FOR [OldMscheme]
GO
ALTER TABLE [dbo].[Partypromotion] ADD  CONSTRAINT [DF__Partyprom__Level__611C5D5B]  DEFAULT ((0)) FOR [Level1]
GO
ALTER TABLE [dbo].[Partypromotion] ADD  CONSTRAINT [DF__Partyprom__Level__62108194]  DEFAULT ((0)) FOR [Level2]
GO
ALTER TABLE [dbo].[Partypromotion] ADD  CONSTRAINT [DF__Partyprom__Level__6304A5CD]  DEFAULT ((0)) FOR [Level3]
GO
ALTER TABLE [dbo].[Partypromotion] ADD  CONSTRAINT [DF__Partyprom__Level__63F8CA06]  DEFAULT ((0)) FOR [Level4]
GO
ALTER TABLE [dbo].[Partypromotion] ADD  CONSTRAINT [DF__Partyprom__Level__64ECEE3F]  DEFAULT ((0)) FOR [Level5]
GO
ALTER TABLE [dbo].[Partypromotion] ADD  CONSTRAINT [DF__Partyprom__Level__65E11278]  DEFAULT ((0)) FOR [Level6]
GO
ALTER TABLE [dbo].[Partypromotion] ADD  CONSTRAINT [DF__Partyprom__ISLev__6D823440]  DEFAULT ((0)) FOR [ISLevel1]
GO
ALTER TABLE [dbo].[Partypromotion] ADD  CONSTRAINT [DF__Partyprom__ISLev__6E765879]  DEFAULT ((0)) FOR [ISLevel2]
GO
ALTER TABLE [dbo].[Partypromotion] ADD  CONSTRAINT [DF__Partyprom__ISLev__6F6A7CB2]  DEFAULT ((0)) FOR [ISLevel3]
GO
ALTER TABLE [dbo].[Partypromotion] ADD  CONSTRAINT [DF__Partyprom__ISLev__705EA0EB]  DEFAULT ((0)) FOR [ISLevel4]
GO
ALTER TABLE [dbo].[Partypromotion] ADD  CONSTRAINT [DF__Partyprom__ISLev__7152C524]  DEFAULT ((0)) FOR [ISLevel5]
GO
ALTER TABLE [dbo].[Partypromotion] ADD  CONSTRAINT [DF__Partyprom__ISLev__7246E95D]  DEFAULT ((0)) FOR [ISLevel6]
GO
ALTER TABLE [dbo].[Partytree] ADD  CONSTRAINT [DF_Membertree_ParentId]  DEFAULT ((0)) FOR [ParentId]
GO
ALTER TABLE [dbo].[Partytree] ADD  CONSTRAINT [DF_Membertree_LeftMsrNo]  DEFAULT ((0)) FOR [LeftMsrNo]
GO
ALTER TABLE [dbo].[Partytree] ADD  CONSTRAINT [DF_Table_1_RightMsrno]  DEFAULT ((0)) FOR [RightMsrNo]
GO
ALTER TABLE [dbo].[Partytree] ADD  CONSTRAINT [DF_Membertree_TotalMembers]  DEFAULT ((0)) FOR [TotalMembers]
GO
ALTER TABLE [dbo].[Partytree] ADD  CONSTRAINT [DF_Membertree_TotalPV]  DEFAULT ((0)) FOR [TotalPV]
GO
ALTER TABLE [dbo].[Partytree] ADD  CONSTRAINT [DF_Membertree_Paidpairs]  DEFAULT ((0)) FOR [Paidpairs]
GO
ALTER TABLE [dbo].[Partytree] ADD  CONSTRAINT [DF_Membertree_Eligible]  DEFAULT (',') FOR [Reward]
GO
ALTER TABLE [dbo].[Partytree] ADD  CONSTRAINT [DF_Membertree_gen_in]  DEFAULT (',') FOR [Gen_in]
GO
ALTER TABLE [dbo].[Partytree] ADD  CONSTRAINT [DF_Membertree_DirectRewardLNo_1]  DEFAULT ((0)) FOR [DirectI]
GO
ALTER TABLE [dbo].[Partytree] ADD  CONSTRAINT [DF__Membertre__ForBi__16CE6296]  DEFAULT ((0)) FOR [ForBinary]
GO
ALTER TABLE [dbo].[Partytree] ADD  CONSTRAINT [DF_Membertree_Mscheme]  DEFAULT ((0)) FOR [Mscheme]
GO
ALTER TABLE [dbo].[Partytree] ADD  CONSTRAINT [DF__Membertre__Level__78D3EB5B]  DEFAULT ((0)) FOR [Levelno]
GO
ALTER TABLE [dbo].[Partytree] ADD  CONSTRAINT [DF_Partytree_SelfPV]  DEFAULT ((0)) FOR [SelfPV]
GO
ALTER TABLE [dbo].[Partytree] ADD  CONSTRAINT [DF__Partytree__PaidX__5BE2A6F2]  DEFAULT ((0)) FOR [PaidXPV]
GO
ALTER TABLE [dbo].[Partytree] ADD  CONSTRAINT [DF__Partytree__PaidY__5CD6CB2B]  DEFAULT ((0)) FOR [PaidYPV]
GO
ALTER TABLE [dbo].[Partytree] ADD  CONSTRAINT [DF__Partytree__Ptota__68487DD7]  DEFAULT ((0)) FOR [Ptotalmembers]
GO
ALTER TABLE [dbo].[Partytree] ADD  CONSTRAINT [DF__Partytree__Ptota__693CA210]  DEFAULT ((0)) FOR [PtotalPV]
GO
ALTER TABLE [dbo].[Partytree] ADD  CONSTRAINT [DF__Partytree__PTota__6B24EA82]  DEFAULT ((0)) FOR [PTotalUnits]
GO
ALTER TABLE [dbo].[Partytree] ADD  CONSTRAINT [DF__Partytree__Total__6C190EBB]  DEFAULT ((0)) FOR [TotalUnits]
GO
ALTER TABLE [dbo].[Partytree] ADD  CONSTRAINT [DF__Partytree__PDcou__08B54D69]  DEFAULT ((0)) FOR [PDcount]
GO
ALTER TABLE [dbo].[Partytree] ADD  CONSTRAINT [DF__Partytree__Paidl__7E02B4CC]  DEFAULT ((0)) FOR [Paidlevel]
GO
ALTER TABLE [dbo].[Partytree] ADD  CONSTRAINT [DF__Partytree__NWMon__7EF6D905]  DEFAULT ((0)) FOR [NWMonth]
GO
ALTER TABLE [dbo].[Partytree] ADD  CONSTRAINT [DF__Partytree__Growt__7FEAFD3E]  DEFAULT ((0)) FOR [GrowthI]
GO
ALTER TABLE [dbo].[Partytree] ADD  CONSTRAINT [DF__Partytree__Spons__00DF2177]  DEFAULT ((0)) FOR [SponserI]
GO
ALTER TABLE [dbo].[Partytree] ADD  CONSTRAINT [DF__Partytree__Rewar__5E54FF49]  DEFAULT ((0)) FOR [RewardI]
GO
ALTER TABLE [dbo].[Partytree] ADD  CONSTRAINT [DF__Partytree__Level__5F492382]  DEFAULT ((0)) FOR [LevelI]
GO
ALTER TABLE [dbo].[Partytree] ADD  CONSTRAINT [DF__Partytree__spInc__61316BF4]  DEFAULT ((0)) FOR [SpIncome]
GO
ALTER TABLE [dbo].[Partytree] ADD  CONSTRAINT [DF__Partytree__Royal__762C88DA]  DEFAULT ((0)) FOR [Royalty]
GO
ALTER TABLE [dbo].[Partytree] ADD  CONSTRAINT [DF__Partytree__Rleve__23893F36]  DEFAULT ((0)) FOR [Rlevel]
GO
ALTER TABLE [dbo].[Partytree] ADD  CONSTRAINT [DF__Partytree__Leade__2A363CC5]  DEFAULT ((0)) FOR [LeaderShipB]
GO
ALTER TABLE [dbo].[Partytree] ADD  CONSTRAINT [DF__Partytree__Unlim__2D12A970]  DEFAULT ((0)) FOR [UnlimitedI]
GO
ALTER TABLE [dbo].[Partytree] ADD  CONSTRAINT [DF__Partytree__Singl__2EFAF1E2]  DEFAULT ((0)) FOR [SingleLeg]
GO
ALTER TABLE [dbo].[Partytree] ADD  CONSTRAINT [DF__Partytree__LegFl__2FEF161B]  DEFAULT ((0)) FOR [LegFlag]
GO
ALTER TABLE [dbo].[Partytree] ADD  CONSTRAINT [DF__Partytree__Manag__420DC656]  DEFAULT ((0)) FOR [ManagerialI]
GO
ALTER TABLE [dbo].[Partytree] ADD  CONSTRAINT [DF__Partytree__Manag__4301EA8F]  DEFAULT ((0)) FOR [ManagerialLevel]
GO
ALTER TABLE [dbo].[Partytree] ADD  CONSTRAINT [DF__Partytree__magMe__45DE573A]  DEFAULT ((0)) FOR [MagMembers]
GO
ALTER TABLE [dbo].[Partytree] ADD  CONSTRAINT [DF__Partytree__Currm__46D27B73]  DEFAULT ((0)) FOR [CurrmagMembers]
GO
ALTER TABLE [dbo].[Partytree] ADD  CONSTRAINT [DF__Partytree__SpI__5A6F5FCC]  DEFAULT ((0)) FOR [SpI]
GO
ALTER TABLE [dbo].[Partytree] ADD  CONSTRAINT [DF__Partytree__RePur__6C8E1007]  DEFAULT ((0)) FOR [RePurLevelno]
GO
ALTER TABLE [dbo].[Partytree] ADD  CONSTRAINT [DF__Partytree__Repur__7ADC2F5E]  DEFAULT ((0)) FOR [RepurRoyalty]
GO
ALTER TABLE [dbo].[Partytree] ADD  CONSTRAINT [DF__Partytree__Purch__04659998]  DEFAULT ((0)) FOR [PurchaseI]
GO
ALTER TABLE [dbo].[Partytree] ADD  CONSTRAINT [DF__Partytree__tSale__0A1E72EE]  DEFAULT ((0)) FOR [TSaleCountDirect]
GO
ALTER TABLE [dbo].[Partytree] ADD  CONSTRAINT [DF__Partytree__Roylt__5CACADF9]  DEFAULT ((0)) FOR [Royltymem]
GO
ALTER TABLE [dbo].[Partytree] ADD  CONSTRAINT [DF__Partytree__Rewar__3FDB6521]  DEFAULT ((0)) FOR [RewardPV]
GO
ALTER TABLE [dbo].[Paydetail] ADD  CONSTRAINT [DF__Paydetail__Payme__1D5142F3]  DEFAULT ((0)) FOR [Paymentoptionid]
GO
ALTER TABLE [dbo].[tblWalletDetails] ADD  CONSTRAINT [DF__tblWallet__MsrNo__30AE302A]  DEFAULT ((0)) FOR [MsrNo]
GO
ALTER TABLE [dbo].[tblWalletDetails] ADD  CONSTRAINT [DF__tblWallet__Amoun__31A25463]  DEFAULT ((0)) FOR [Amount]
GO
ALTER TABLE [dbo].[tblWalletDetails] ADD  CONSTRAINT [DF__tblWallet__Trans__3296789C]  DEFAULT ((0)) FOR [TransactionWith]
GO
ALTER TABLE [dbo].[tblWalletDetails] ADD  CONSTRAINT [DF__tblWallet__Descr__338A9CD5]  DEFAULT ('') FOR [Description]
GO
ALTER TABLE [dbo].[tblWalletDetails] ADD  CONSTRAINT [DF__tblWallet__DateO__347EC10E]  DEFAULT (NULL) FOR [DateOn]
GO
ALTER TABLE [dbo].[tblWalletDetails] ADD  CONSTRAINT [DF__tblWallet__IsLas__3631FF56]  DEFAULT ((0)) FOR [IsLast]
GO
ALTER TABLE [dbo].[tblWalletPayment] ADD  CONSTRAINT [DF__tblWallet__MsrNo__084B3915]  DEFAULT ((0)) FOR [MsrNo]
GO
ALTER TABLE [dbo].[tblWalletPayment] ADD  CONSTRAINT [DF__tblWallet__Amoun__093F5D4E]  DEFAULT ((0)) FOR [Amount]
GO
ALTER TABLE [dbo].[tblWalletPayment] ADD  CONSTRAINT [DF__tblWalletP__ChNo__0A338187]  DEFAULT ((0)) FOR [ChNo]
GO
ALTER TABLE [dbo].[tblWalletPayment] ADD  CONSTRAINT [DF__tblWallet__ChDat__0B27A5C0]  DEFAULT (NULL) FOR [ChDate]
GO
ALTER TABLE [dbo].[tblWalletSCode] ADD  CONSTRAINT [DF_tblSCodeDetails_DateOn]  DEFAULT (getdate()) FOR [DateOn]
GO
ALTER TABLE [dbo].[tblWalletStatus] ADD  CONSTRAINT [DF__tblWallet__MsrNo__7720AD13]  DEFAULT ((0)) FOR [MsrNo]
GO
ALTER TABLE [dbo].[tblWalletStatus] ADD  CONSTRAINT [DF__tblWalletSta__Cr__7814D14C]  DEFAULT ((0)) FOR [Cr]
GO
ALTER TABLE [dbo].[tblWalletStatus] ADD  CONSTRAINT [DF__tblWalletSta__Dr__7908F585]  DEFAULT ((0)) FOR [Dr]
GO
ALTER TABLE [dbo].[Usermaster] ADD  CONSTRAINT [DF__Usermaste__IsAdm__7132C993]  DEFAULT ((0)) FOR [IsAdmin]
GO
ALTER TABLE [dbo].[Usermaster] ADD  CONSTRAINT [DF__Usermaste__credi__61FB72FB]  DEFAULT ((0)) FOR [Creditlimit]
GO
ALTER TABLE [dbo].[Usermaster] ADD  CONSTRAINT [DF__Usermaste__Block__1A3FCC1E]  DEFAULT ((0)) FOR [Block]
GO
ALTER TABLE [dbo].[Usermaster] ADD  CONSTRAINT [DF__Usermaste__Branc__050FA50E]  DEFAULT ((0)) FOR [BranchCode]
GO
/****** Object:  StoredProcedure [dbo].[spInsertMember]    Script Date: 17/04/2020 11:06:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spInsertMember]  
@SponsorId varchar(50),  
@SponsorName varchar(100),  
@MemberName varchar(100),

@Sex varchar(10),
@PanNo varchar(50),
@Mobile varchar(50),
@Email varchar(50),
@Password varchar(50)
  
AS  
BEGIN  
    -- SET NOCOUNT ON added to prevent extra result sets from  
    -- interfering with SELECT statements.  
    SET NOCOUNT ON;  
	DECLARE @MAXMemberId varchar(50)
	DECLARE @MemberID varchar(50)
	DECLARE @IntroMSRNo AS INT

	select @IntroMSRNo = Msrno from PartyMaster where MemberId=@SponsorId;

	SELECT  @MAXMemberId = (MAX(SUBSTRING(MemberId, PATINDEX('%[0-9]%', MemberId), PATINDEX('%[0-9][^0-9]%', MemberId + 't') - PATINDEX('%[0-9]%', 
                    MemberId) + 1))) from Partymaster;
	IF (@MAXMemberId IS NULL)
		SET @MAXMemberId = '20040'

	SELECT @MemberID = CONCAT('ADIN', @MAXMemberId + 1);

	

    Insert into PartyMaster(MemberId,SponsorId,SponsorName,MemberName,Sex,PanNo,Mobile,Email,[Password],DOJ,ETicket,IntroMsrNo)values 
	(@MemberID,@SponsorId,@SponsorName,@MemberName,@Sex,@PanNo,@Mobile,@Email,@Password,getdate(),0,@IntroMSRNo);
	return 1;
END 

GO
