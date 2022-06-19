CREATE TABLE [dbo].[Customer](
	[ID] [uniqueidentifier] NOT NULL,
	[DistrictID] [uniqueidentifier] NOT NULL,
	[FirstName] [nvarchar](500) NOT NULL,
	[LastName] [nvarchar](500) NULL,
	[Password] [nvarchar](500) NOT NULL,
	[Email] [nvarchar](200) NULL,
	[MobileNo] [nvarchar](20) NULL,
	[NIK] [nvarchar](200) NOT NULL,
	[Gender] [nvarchar](10) NOT NULL,
	[DateOfBirth] [datetime] NULL,
	[RegisterType] [nvarchar](20) NOT NULL,
	[IPAddress] [nvarchar](200) NULL,
	[IsDeleted] [bit] DEFAULT 0 NOT NULL,
	[Created] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](200) NOT NULL,
	[Updated] [datetime] NULL,
	[UpdatedBy] [nvarchar](200) NULL
 CONSTRAINT [PK_Customer_ID] PRIMARY KEY NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) 
GO
