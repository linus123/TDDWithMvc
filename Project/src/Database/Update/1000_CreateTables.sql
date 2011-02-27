/****** Object:  Table [dbo].[MembershipOffer]    Script Date: 02/26/2011 18:50:52 ******/
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


