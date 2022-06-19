CREATE TABLE [dbo].[CustomerToken](
	[ID] [uniqueidentifier] NOT NULL,
	[CustomerID] [uniqueidentifier] NOT NULL,
	[RefreshToken] [nvarchar](200) NOT NULL,
	[ExpiredDate] [datetime] NOT NULL,
	[IPAddress] [nvarchar](200) NULL,
	[IsDeleted] [bit] DEFAULT 0 NOT NULL,
	[Created] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](200) NOT NULL,
	[Updated] [datetime] NULL,
	[UpdatedBy] [nvarchar](200) NULL,
 CONSTRAINT [PK_CustomerToken_ID] PRIMARY KEY NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


