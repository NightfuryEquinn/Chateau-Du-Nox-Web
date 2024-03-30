--Create Table
--User
CREATE TABLE [dbo].[User] (
    [UserId]          INT           IDENTITY (1, 1) NOT NULL,
    [Name]            VARCHAR (50)  NULL,
    [Avatar]          VARCHAR (MAX) NULL,
    [Role]            VARCHAR (50)  NULL,
    [EmailAddress]    VARCHAR (MAX) NULL,
    [Password]        VARCHAR (MAX) NULL,
    [PhoneNumber]     VARCHAR (20)  NULL,
    [ShippingAddress] VARCHAR (MAX) NULL,
    [BillingAddress]  VARCHAR (MAX) NULL,
    [RegisteredDate]  DATETIME      NULL,
    [Active]          INT           DEFAULT ((1)) NULL,
    PRIMARY KEY CLUSTERED ([UserId] ASC)
);

-- Wine
CREATE TABLE [dbo].[Wine] (
    [WineId]      INT           NOT NULL,
    [Name]        VARCHAR (50)  NULL,
    [Description] VARCHAR (MAX) NULL,
    [Price]       INT           NULL,
    [Image]       VARCHAR (MAX) NULL,
    [Varietal]    VARCHAR (50)  NULL,
    [Vintage]     INT           NULL,
    [Volume]      INT           NULL,
    [Body]        VARCHAR (50)  NULL,
    [Tannin]      VARCHAR (50)  NULL,
    [Acidity]     VARCHAR (50)  NULL,
    [ABV]         VARCHAR (50)  NULL,
    [Origin]      VARCHAR (MAX) NULL,
    [Stock]       INT           NULL,
    [Active]      INT           DEFAULT ((1)) NULL,
    [TypeId]      INT           NULL,
    PRIMARY KEY CLUSTERED ([WineId] ASC),
    CONSTRAINT [FK_Wine_ToType] FOREIGN KEY ([TypeId]) REFERENCES [dbo].[Type] ([TypeId])
);

-- Type
CREATE TABLE [dbo].[Type] (
    [TypeId] INT          IDENTITY (1, 1) NOT NULL,
    [Name]   VARCHAR (50) NULL,
    [Active] INT          DEFAULT ((1)) NULL,
    PRIMARY KEY CLUSTERED ([TypeId] ASC)
);

-- Order
CREATE TABLE [dbo].[Order] (
    [OrderId]       INT          IDENTITY (1, 1) NOT NULL,
    [Status]        VARCHAR (20) NULL,
    [DeliveredDate] DATETIME     NULL,
    [OrderedDate]   DATETIME     NULL,
    [TotalPayable]  INT          NULL,
    [ReviewWritten] INT          DEFAULT ((0)) NULL,
    [Active]        INT          DEFAULT ((1)) NULL,
    [WineId]        INT          NULL,
    [UserId]        INT          NULL,
    PRIMARY KEY CLUSTERED ([OrderId] ASC),
    CONSTRAINT [FK_Order_ToWine] FOREIGN KEY ([WineId]) REFERENCES [dbo].[Wine] ([WineId]),
    CONSTRAINT [FK_Order_ToUser] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId])
);

-- Cart
CREATE TABLE [dbo].[Cart] (
    [CartId] INT IDENTITY (1, 1) NOT NULL,
    [Amount] INT NULL,
    [WineId] INT NULL,
    [UserId] INT NULL,
    PRIMARY KEY CLUSTERED ([CartId] ASC),
    CONSTRAINT [FK_Cart_ToWine] FOREIGN KEY ([WineId]) REFERENCES [dbo].[Wine] ([WineId]),
    CONSTRAINT [FK_Cart_ToUser] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId])
);

-- Wishlist
CREATE TABLE [dbo].[Wishlist] (
    [WishlistId] INT IDENTITY (1, 1) NOT NULL,
    [Amount]     INT NULL,
    [WineId]     INT NULL,
    [UserId]     INT NULL,
    PRIMARY KEY CLUSTERED ([WishlistId] ASC),
    CONSTRAINT [FK_Wishlist_ToWine] FOREIGN KEY ([WineId]) REFERENCES [dbo].[Wine] ([WineId]),
    CONSTRAINT [FK_Wishlist_ToUser] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId])
);

-- Review
CREATE TABLE [dbo].[Review] (
    [ReviewId]    INT           IDENTITY (1, 1) NOT NULL,
    [Content]     VARCHAR (MAX) NULL,
    [Rating]      INT           NULL,
    [WrittenDate] DATETIME      NULL,
    [Active]      INT           NULL,
    [WineId]      INT           NULL,
    [UserId]      INT           NULL,
    PRIMARY KEY CLUSTERED ([ReviewId] ASC),
    CONSTRAINT [FK_Review_ToWine] FOREIGN KEY ([WineId]) REFERENCES [dbo].[Wine] ([WineId]),
    CONSTRAINT [FK_Review_ToUser] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId])
);