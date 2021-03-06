USE [biosite]
GO
INSERT [dbo].[homolog_biosite_area] ([Id], [Name], [Description]) VALUES (N'35749af6-0bf5-43c2-9eb2-ad94b12b2748', N'Biomarcadores', N'Área de biomarcadores')
INSERT [dbo].[homolog_biosite_area] ([Id], [Name], [Description]) VALUES (N'c9d18b19-7686-445a-861d-c696469dd754', N'Órgãos', N'Área de órgãos')
GO
INSERT [dbo].[homolog_biosite_plan] ([Id], [Name], [Description], [LastUpdate]) VALUES (N'62417368-440d-4c17-a1cd-156537193680', N'AdminProj', N'AdminProj', CAST(N'2021-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[homolog_biosite_plan] ([Id], [Name], [Description], [LastUpdate]) VALUES (N'd4a56cea-5bf8-44c9-817e-41b5f90be6e8', N'Biomarker', N'Plano com acesso ao informações avançadas sobre biomarcadores', CAST(N'2021-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[homolog_biosite_plan] ([Id], [Name], [Description], [LastUpdate]) VALUES (N'b5c38649-cb0b-401e-9f46-4712804acdde', N'Organ', N'Plano com acesso ao informações avançadas sobre órgãos', CAST(N'2021-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[homolog_biosite_plan] ([Id], [Name], [Description], [LastUpdate]) VALUES (N'81e6fc83-5d40-4778-85f1-af52edfb0017', N'AllPlan', N'Plano completo com acesso ilimitado a todas as área da plataforma', CAST(N'2021-01-01T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[homolog_biosite_plan_area] ([PlanId], [AreaId], [Id]) VALUES (N'62417368-440d-4c17-a1cd-156537193680', N'35749af6-0bf5-43c2-9eb2-ad94b12b2748', N'585153ad-3238-49f7-8078-8d7409d637e8')
INSERT [dbo].[homolog_biosite_plan_area] ([PlanId], [AreaId], [Id]) VALUES (N'62417368-440d-4c17-a1cd-156537193680', N'c9d18b19-7686-445a-861d-c696469dd754', N'9eddacb3-9737-49fb-a17f-1458ba1a80e1')
INSERT [dbo].[homolog_biosite_plan_area] ([PlanId], [AreaId], [Id]) VALUES (N'd4a56cea-5bf8-44c9-817e-41b5f90be6e8', N'35749af6-0bf5-43c2-9eb2-ad94b12b2748', N'e6a403ba-ef5b-4ebc-ba83-f336cdd404df')
INSERT [dbo].[homolog_biosite_plan_area] ([PlanId], [AreaId], [Id]) VALUES (N'b5c38649-cb0b-401e-9f46-4712804acdde', N'c9d18b19-7686-445a-861d-c696469dd754', N'a01e4752-2500-46d3-80ad-f558b44bb6bc')
INSERT [dbo].[homolog_biosite_plan_area] ([PlanId], [AreaId], [Id]) VALUES (N'81e6fc83-5d40-4778-85f1-af52edfb0017', N'35749af6-0bf5-43c2-9eb2-ad94b12b2748', N'97a3064e-9e78-45bf-8e43-88966f02212a')
INSERT [dbo].[homolog_biosite_plan_area] ([PlanId], [AreaId], [Id]) VALUES (N'81e6fc83-5d40-4778-85f1-af52edfb0017', N'c9d18b19-7686-445a-861d-c696469dd754', N'0a3073ab-c1d3-4dac-8ff5-98a48b32fbb9')
GO
INSERT [dbo].[homolog_biosite_user] ([Id], [Name], [Password], [Email], [Active], [Weight], [Height], [Gender], [IsPregnant], [Birthdate], [Verified], [VerificationCode], [ActivationCode], [LastLoginDate], [LastAuthorizationCodeRequest], [PlanId]) VALUES (N'c3a6bb81-7a67-49bd-acf4-1793291a7f64', N'Carlos Rogerio', N'f2ef91ca8684404d1652b6e46d43e7ef5869cf4ac5ce4af71ce6dc3ef5de2f93bce1d84bb5ad609b0a4fb78b03d36397b65c1cc765cf688603bd25d59ea261cd', N'carlos@biosite.com', 1, 75, 1.77, N'M', 0, CAST(N'1976-05-10T10:00:00.000' AS DateTime), 1, NULL, N'A64A', CAST(N'2022-07-07T18:00:13.297' AS DateTime), CAST(N'2020-02-09T00:16:07.517' AS DateTime), N'd4a56cea-5bf8-44c9-817e-41b5f90be6e8')
INSERT [dbo].[homolog_biosite_user] ([Id], [Name], [Password], [Email], [Active], [Weight], [Height], [Gender], [IsPregnant], [Birthdate], [Verified], [VerificationCode], [ActivationCode], [LastLoginDate], [LastAuthorizationCodeRequest], [PlanId]) VALUES (N'a5205f14-e790-4b52-a911-5c89b9a275e4', N'Ester Pereira Reginatto', N'f2ef91ca8684404d1652b6e46d43e7ef5869cf4ac5ce4af71ce6dc3ef5de2f93bce1d84bb5ad609b0a4fb78b03d36397b65c1cc765cf688603bd25d59ea261cd', N'ester@biosite.com', 1, 65, 1.7, N'F', 0, CAST(N'2020-10-19T10:00:00.000' AS DateTime), 1, NULL, N'A64A', CAST(N'2022-07-07T18:02:49.480' AS DateTime), CAST(N'2020-02-09T00:16:07.000' AS DateTime), N'62417368-440d-4c17-a1cd-156537193680')
GO
INSERT [dbo].[homolog_biosite_biomarker] ([Id], [Name], [Description], [Unity], [BodyImageType], [AboveImpact], [BelowImpact], [Active], [LastUpdate]) VALUES (N'dc60b22e-4089-4784-65c7-08d95a0e9f4c', N'Ácido Úrico', N'Informações sobre ácido úrico', N'', 0, N'Degeneração da glia, neurotoxicidade', N'Neuroprotetor', 1, CAST(N'2021-08-07T22:48:01.677' AS DateTime))
INSERT [dbo].[homolog_biosite_biomarker] ([Id], [Name], [Description], [Unity], [BodyImageType], [AboveImpact], [BelowImpact], [Active], [LastUpdate]) VALUES (N'c203b71b-3dc1-4b21-65c8-08d95a0e9f4c', N'Ferritina', N'Informações sobre ácido úrico', N'', 0, N'Degeneração da glia, neurotoxicidade', N'Neuroprotetor', 1, CAST(N'2021-08-07T22:50:54.913' AS DateTime))
GO
INSERT [dbo].[homolog_biosite_organ] ([Id], [Name], [Description], [Svg]) VALUES (N'86fae0dd-d6c9-4075-9065-8ddc303c25af', N'Tireóide', N'Glândula responsável pelo metabolismo corporal', N'imagem-svg')
INSERT [dbo].[homolog_biosite_organ] ([Id], [Name], [Description], [Svg]) VALUES (N'fd287def-e7da-4964-87e4-c241d1adefe4', N'Fígado', N'Órgão responsável pelos processos de bio-ativação e bio-transformação', N'imagem-svg')
GO
