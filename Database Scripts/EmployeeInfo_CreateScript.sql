USE [EmployeeInfo]
GO
/****** Object:  StoredProcedure [dbo].[isUniqueCode]    Script Date: 11-12-2023 18:53:12 ******/
DROP PROCEDURE [dbo].[isUniqueCode]
GO
/****** Object:  StoredProcedure [dbo].[GetAllEmployeeDetail]    Script Date: 11-12-2023 18:53:12 ******/
DROP PROCEDURE [dbo].[GetAllEmployeeDetail]
GO
/****** Object:  StoredProcedure [dbo].[DeleteEmployeeDetail]    Script Date: 11-12-2023 18:53:12 ******/
DROP PROCEDURE [dbo].[DeleteEmployeeDetail]
GO
/****** Object:  StoredProcedure [dbo].[Add_EmployeeDetail]    Script Date: 11-12-2023 18:53:12 ******/
DROP PROCEDURE [dbo].[Add_EmployeeDetail]
GO
/****** Object:  Table [dbo].[employee_Details]    Script Date: 11-12-2023 18:53:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[employee_Details]') AND type in (N'U'))
DROP TABLE [dbo].[employee_Details]
GO
/****** Object:  Table [dbo].[employee_Details]    Script Date: 11-12-2023 18:53:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[employee_Details](
	[EmpId] [int] IDENTITY(1,1) NOT NULL,
	[Employee_Code] [varchar](50) NULL,
	[First_Name] [varchar](30) NULL,
	[Last_Name] [varchar](30) NULL,
	[Email_Address] [varchar](100) NULL,
	[Address] [varchar](500) NULL,
	[Phone] [varchar](max) NULL,
	[createdDate] [date] NULL,
	[modifyDate] [date] NULL,
	[isStatus] [tinyint] NULL,
PRIMARY KEY CLUSTERED 
(
	[EmpId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[employee_Details] ON 
GO
INSERT [dbo].[employee_Details] ([EmpId], [Employee_Code], [First_Name], [Last_Name], [Email_Address], [Address], [Phone], [createdDate], [modifyDate], [isStatus]) VALUES (4, N'601', N'abc', N'xyz', N'demo@gmail.com', N'surat', N'5634786546,5674389023,4567098765', CAST(N'2023-12-11' AS Date), NULL, NULL)
GO
INSERT [dbo].[employee_Details] ([EmpId], [Employee_Code], [First_Name], [Last_Name], [Email_Address], [Address], [Phone], [createdDate], [modifyDate], [isStatus]) VALUES (5, N'test', N'test', N'testing', N'test@gmail.com', N'ahmedabad', N'9876567876', CAST(N'2023-12-11' AS Date), NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[employee_Details] OFF
GO
/****** Object:  StoredProcedure [dbo].[Add_EmployeeDetail]    Script Date: 11-12-2023 18:53:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Add_EmployeeDetail]
(
     @EmpId int,
     @Employee_Code varchar(50),
     @First_Name varchar(30),
	 @Last_Name varchar(30),
	 @Email_Address varchar(100),
	 @Address varchar(500),
	 @Phone varchar(MAX)
)
  AS
 --SELECT @EmpId =  EmpId
 --   FROM employee_Details
	
  IF @EmpId = 0
  BEGIN
  INSERT INTO [dbo].employee_Details(
  Employee_Code,First_Name,Last_Name,Email_Address,Address,Phone,createdDate
  )
  VALUES(
  @Employee_Code,@First_Name,@Last_Name,@Email_Address,@Address,@Phone,GETDATE()
  )
  END
    ELSE 
    BEGIN
	 UPDATE [dbo].employee_Details
	 SET 
	      Employee_Code = @Employee_Code,
		  First_Name = @First_Name,
		  Last_Name = @Last_Name,
		  Email_Address = @Email_Address,
		  Address = @Address,
		  Phone = @Phone,
		  modifyDate = GETDATE()
		  WHERE EmpId = @EmpId
        
    END;
GO
/****** Object:  StoredProcedure [dbo].[DeleteEmployeeDetail]    Script Date: 11-12-2023 18:53:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure[dbo].[DeleteEmployeeDetail] 
         @EmpId int
    As
    Begin   

         Delete from employee_Details Where EmpId=@EmpId

    End
GO
/****** Object:  StoredProcedure [dbo].[GetAllEmployeeDetail]    Script Date: 11-12-2023 18:53:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllEmployeeDetail]

as
begin
     SELECT EmpId,
            Employee_Code ,
            First_Name ,
	        Last_Name ,
	        Email_Address ,
	        [Address],
	        Phone AS StrPhone
			FROM dbo.employee_Details

END
GO
/****** Object:  StoredProcedure [dbo].[isUniqueCode]    Script Date: 11-12-2023 18:53:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[isUniqueCode](
    @Employee_Code varchar(50))

 AS
 IF EXISTS(SELECT * FROM employee_Details
    WHERE Employee_Code = @Employee_Code
	) 
BEGIN
        SELECT 'False' as IsUnique
END
    ELSE 
BEGIN
       SELECT 'True' as IsUnique
END;
GO
