USE [memory]
GO
/****** Object:  Table [dbo].[cards]    Script Date: 3/8/2016 4:07:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[cards](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[theme] [varchar](255) NULL,
	[pairnum] [int] NULL,
	[randnum] [int] NULL,
	[turnt] [bit] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
