USE [Orchestrator]
GO
SET IDENTITY_INSERT [dbo].[Tenant] ON 
GO
INSERT [dbo].[Tenant] ([Id], [TenantName], [PublicId], [Email], [IsActive], [IsDefaultTenant], [CreatedDate]) VALUES (0, N'MasterTenant', N'12345678', N'test@test.com', 1, 1, CAST(N'2022-09-19T14:59:00.7412775' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[Tenant] OFF
GO

INSERT [dbo].[ParameterEntity] ([Id], [EventType], [ParameterType], [Value], [CreatedDate], [TenantÍd]) VALUES (N'4b1a539f-3345-4c63-ab6b-ad18bd10d8c7', 2, 1, N'{"Host":"","Port":0,"UserName":"","Password":"","RootFolder":"C:\\Ftp\\Orchestrator","BsInputFolder":"BsInput","BsOutputFolder":"BsOutPut","OsInputFolder":"OsInput","OsOutputFolder":"OsOutput"}', CAST(N'2022-09-28T14:35:13.6164004' AS DateTime2), 0)
GO
