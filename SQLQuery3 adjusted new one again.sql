-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/26/2019 14:17:39
-- Generated from EDMX file: C:\Users\PX Hao\source\repos\FIT_5032_Ass_Car\FIT_5032_Ass_Car\Models\Fit_5032_car.edmx
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Location'
CREATE TABLE [dbo].[Location] (
    [LocationCode] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  Not NULL,
    [Description] nvarchar(max)   NULL,
    [Latitude] decimal(18,10)  NOT NULL,
    [Longitude] decimal(18,10)  NOT NULL
);
GO


-- Creating table 'Car'
CREATE TABLE [dbo].[Car] (
    [CarID] int IDENTITY(1,1) NOT NULL,
    [CarVin] nvarchar(max)  NOT NULL,
    [CarMark] nvarchar(max)  NOT NULL,
    [CarModel] nvarchar(max)  NOT NULL,
    [CarType] nvarchar(max)  NOT NULL,
    [CarPrice] float  NOT NULL,
    [CarRegisterDate] datetime  NOT NULL
);
GO

-- --inserting the data in the car and location------
-----------------------------------------------------
insert into Car (CarVin, CarMark, CarModel, CarType, CarPrice, CarRegisterDate) values ('1G6DV1EP2B0760600', 'Ford', 'Crown Victoria', 'SUV', '120', '2019/01/26');
insert into Car (CarVin, CarMark, CarModel, CarType, CarPrice, CarRegisterDate) values ('WBAYM1C52DD535394', 'GMC', '3500 Club Coupe', 'SUV', '110', '2019/08/30');
insert into Car (CarVin, CarMark, CarModel, CarType, CarPrice, CarRegisterDate) values ('WBAVA33557P640781', 'Suzuki', 'Swift', 'Compact', '65', '2019/04/30');
insert into Car (CarVin, CarMark, CarModel, CarType, CarPrice, CarRegisterDate) values ('SCBBR9ZA6BC090662', 'GMC', 'Sonoma Club Coupe', 'SUV', '130', '2019/05/23');
insert into Car (CarVin, CarMark, CarModel, CarType, CarPrice, CarRegisterDate) values ('WBAFR9C59CD581181', 'Mercedes-Benz', 'E-Class', 'Sedan', '140', '2019/03/22');

---  Location ---- Inserting ----
insert into Location (Name, Description, Latitude, Longitude) values ('Monash UNI Caulfield', 'Caulfield','37.87682300','145.04583700')
insert into Location (Name, Description, Latitude, Longitude) values ('Monash UNI Clayton','Clayton Campus','37.91500000','145.13000000')
insert into Location (Name, Description, Latitude, Longitude) values ('Melbourne Airport','Melbourne Au','-37.669826','144.848792')
insert into Location (Name, Description, Latitude, Longitude) values ('Melbourne Center','Near Flagstaff Gardens','-37.810551','144.962840')


-- Creating table 'Booking'
CREATE TABLE [dbo].[Booking] (
    [BookingID] int IDENTITY(1,1) NOT NULL,
    [BookingTime] datetime  NOT NULL,
    [RentingStart] datetime  NOT NULL,
    [RentingEnd] datetime  NOT NULL,
    [PickUP_LocationCode] int  NOT NULL,
    [Contact_PhoneNumber] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Order_Line'
CREATE TABLE [dbo].[Order_Line] (
    [BookingBookingID] int  NOT NULL,
    [ReturnDate] datetime  NOT NULL,
    [ReturnStatus] nvarchar(max)  NOT NULL,
    [OlCarID] int  NOT NULL
);
GO



-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [LocationCode] in table 'Location'
ALTER TABLE [dbo].[Location]
ADD CONSTRAINT [PK_Location]
    PRIMARY KEY CLUSTERED ([LocationCode] ASC);
GO

-- Creating primary key on [BookingID] in table 'Booking'
ALTER TABLE [dbo].[Booking]
ADD CONSTRAINT [PK_Booking]
    PRIMARY KEY CLUSTERED ([BookingID] ASC);
GO

-- Creating primary key on [BookingBookingID], [OlCarID] in table 'Order_Line'
ALTER TABLE [dbo].[Order_Line]
ADD CONSTRAINT [PK_Order_Line]
    PRIMARY KEY CLUSTERED ([BookingBookingID], [OlCarID] ASC);
GO

-- Creating primary key on [CarID] in table 'Car'
ALTER TABLE [dbo].[Car]
ADD CONSTRAINT [PK_Car]
    PRIMARY KEY CLUSTERED ([CarID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [PickUP_LocationCode] in table 'Booking'
ALTER TABLE [dbo].[Booking]
ADD CONSTRAINT [FK_LocationBooking]
    FOREIGN KEY ([PickUP_LocationCode])
    REFERENCES [dbo].[Location]
        ([LocationCode])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LocationBooking'
CREATE INDEX [IX_FK_LocationBooking]
ON [dbo].[Booking]
    ([PickUP_LocationCode]);
GO

-- Creating foreign key on [BookingBookingID] in table 'Order_Line'
ALTER TABLE [dbo].[Order_Line]
ADD CONSTRAINT [FK_BookingOrder_Line]
    FOREIGN KEY ([BookingBookingID])
    REFERENCES [dbo].[Booking]
        ([BookingID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [OlCarID] in table 'Order_Line'
ALTER TABLE [dbo].[Order_Line]
ADD CONSTRAINT [FK_CarOrder_Line]
    FOREIGN KEY ([OlCarID])
    REFERENCES [dbo].[Car]
        ([CarID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CarOrder_Line'
CREATE INDEX [IX_FK_CarOrder_Line]
ON [dbo].[Order_Line]
    ([OlCarID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------




---------new table query :::::


Alter Table Location 
Alter column [Latitude] numeric(10,8) not null

Alter table Location
Alter column [Longitude] numeric(11,8) not null

Alter table Location 
add CONSTRAINT CK_Latitude CHECK (Latitude >= -90 AND Latitude <= 90)

Alter table Location
add CONSTRAINT CK_Longtitude CHECK (Longitude >= -180 AND Longitude <=
180)

INSERT INTO [Location] ([Name], [Description], [Latitude],
[Longitude]) VALUES (N'Monash University', N'Caulfield Campus', CAST(-
37.87682300 AS Decimal(10, 8)), CAST(145.04583700 AS Decimal(11, 8)))
INSERT INTO [Location] ([Name], [Description], [Latitude],
[Longitude]) VALUES (N'Monash University', N'Clayton Campus', CAST(-
37.91500000 AS Decimal(10, 8)), CAST(145.13000000 AS Decimal(11, 8)))

