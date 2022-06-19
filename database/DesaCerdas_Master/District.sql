CREATE TABLE [dbo].[District](
	[ID] [uniqueidentifier] NOT NULL,
	[RegionID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](500) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Longitude] [decimal](9,6) NULL,
	[Latitude] [decimal](9,6) NULL,
	[Icon] [nvarchar](500) NULL,
	[MapURL] [nvarchar](500) NULL,
	[StructureOrganizationURL] [nvarchar](500) NULL,
	[IsDeleted] [bit] DEFAULT 0 NOT NULL,
	[Created] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](200) NOT NULL,
	[Updated] [datetime] NULL,
	[UpdatedBy] [nvarchar](200) NULL
 CONSTRAINT [PK_District_ID] PRIMARY KEY NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
