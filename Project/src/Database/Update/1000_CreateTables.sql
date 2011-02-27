/****** Object:  Table [dbo].[MembershipOffer]    Script Date: 02/27/2011 07:03:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MembershipOffer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[InternalName] [nvarchar](64) NOT NULL,
	[ExternalName] [nvarchar](64) NOT NULL,
	[Price] [money] NOT NULL,
	[DiscountPrice] [money] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[TermInMonths] [int] NOT NULL,
	[TermInYears] [int] NOT NULL,
 CONSTRAINT [PK_MembershipOffer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[MembershipOrder]    Script Date: 02/27/2011 07:03:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MembershipOrder](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](64) NOT NULL,
	[LastName] [nvarchar](64) NOT NULL,
	[EmailAddress] [nvarchar](64) NOT NULL,
	[DateOfBirth] [datetime] NOT NULL,
	[CreditCardNumber] [nvarchar](32) NOT NULL,
	[CreditCardTypeCode] [nvarchar](16) NOT NULL,
	[MembershipOfferId] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
 CONSTRAINT [PK_MembershipOrder] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[MembershipOrder]  WITH CHECK ADD  CONSTRAINT [FK_MembershipOrder_MembershipOffer] FOREIGN KEY([MembershipOfferId])
REFERENCES [dbo].[MembershipOffer] ([Id])
GO

ALTER TABLE [dbo].[MembershipOrder] CHECK CONSTRAINT [FK_MembershipOrder_MembershipOffer]
GO


