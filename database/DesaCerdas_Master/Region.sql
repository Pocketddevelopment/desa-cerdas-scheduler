CREATE TABLE [dbo].[Region](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](500) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Longitude] [decimal](9,6) NULL,
	[Latitude] [decimal](9,6) NULL,
	[IsDeleted] [bit] DEFAULT 0 NOT NULL,
	[Created] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](200) NOT NULL,
	[Updated] [datetime] NULL,
	[UpdatedBy] [nvarchar](200) NULL
 CONSTRAINT [PK_Region_ID] PRIMARY KEY NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
