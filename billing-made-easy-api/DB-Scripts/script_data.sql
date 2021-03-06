USE [easy-bill]
GO
SET IDENTITY_INSERT [dbo].[PartyDetails] ON 

INSERT [dbo].[PartyDetails] ([Id], [partyName], [gstNumber], [panNumber], [addressLine], [city], [stateInformation], [zipcode], [mobileNumber], [createdAt], [updatedAt]) VALUES (1, N'Debojyoti Paul', N'xxxx4321xxxx', N'xxxxxxxx', N'11, Padmanath lane kolkata 700004', N'kolkata', N'West Bengal', 700067, CAST(9804040107 AS Numeric(12, 0)), CAST(N'2020-06-20' AS Date), CAST(N'2020-06-20' AS Date))
SET IDENTITY_INSERT [dbo].[PartyDetails] OFF
SET IDENTITY_INSERT [dbo].[PaymentTypeMaster] ON 

INSERT [dbo].[PaymentTypeMaster] ([paymentType], [Id], [createdAt], [updatedAt]) VALUES (N'cash', 1, CAST(N'2020-06-20' AS Date), CAST(N'2020-06-20' AS Date))
SET IDENTITY_INSERT [dbo].[PaymentTypeMaster] OFF
SET IDENTITY_INSERT [dbo].[PaymentStatusMaster] ON 

INSERT [dbo].[PaymentStatusMaster] ([paymentStatus], [Id], [createdAt], [updatedAt]) VALUES (N'due', 1, CAST(N'2020-06-20' AS Date), CAST(N'2020-06-20' AS Date))
INSERT [dbo].[PaymentStatusMaster] ([paymentStatus], [Id], [createdAt], [updatedAt]) VALUES (N'paid', 2, CAST(N'2020-06-20' AS Date), CAST(N'2020-06-20' AS Date))
SET IDENTITY_INSERT [dbo].[PaymentStatusMaster] OFF
SET IDENTITY_INSERT [dbo].[PaymentDetails] ON 

INSERT [dbo].[PaymentDetails] ([Id], [paymentAmount], [paymentDate], [paymentMode], [paymentReferenceNumber], [paymentType], [paymentStatus], [paymentReceived], [createdAt], [updatedAt]) VALUES (1, CAST(0.000 AS Numeric(15, 3)), CAST(N'2020-06-20' AS Date), N'string', N'string', NULL, NULL, NULL, CAST(N'2020-06-20' AS Date), CAST(N'2020-06-20' AS Date))
SET IDENTITY_INSERT [dbo].[PaymentDetails] OFF
SET IDENTITY_INSERT [dbo].[DeliveryDetails] ON 

INSERT [dbo].[DeliveryDetails] ([Id], [deliveryAddress], [deliveryMode], [deliveryCharge], [deliveryDate], [createdAt], [updatedAt]) VALUES (1, N'11, Padmanath Lane', N'van', CAST(350.000 AS Numeric(13, 3)), CAST(N'2020-06-21' AS Date), CAST(N'2020-06-21' AS Date), CAST(N'2020-06-21' AS Date))
SET IDENTITY_INSERT [dbo].[DeliveryDetails] OFF
SET IDENTITY_INSERT [dbo].[Bill] ON 

INSERT [dbo].[Bill] ([Id], [billNumber], [billerName], [billType], [billDate], [billTotalAmount], [billTotalTax], [billTotalSGST], [billTotalCGST], [refPartyId], [refPaymentId], [refDeliveryId], [createdAt], [updatedAt]) VALUES (5, N'PB-2020-001', N'paul box', 1, CAST(N'2020-06-21' AS Date), CAST(0.000 AS Numeric(18, 3)), CAST(0.000 AS Numeric(18, 3)), CAST(0.000 AS Numeric(18, 3)), CAST(0.000 AS Numeric(18, 3)), 1, 1, 1, CAST(N'2020-06-21' AS Date), CAST(N'2020-06-21' AS Date))
SET IDENTITY_INSERT [dbo].[Bill] OFF
