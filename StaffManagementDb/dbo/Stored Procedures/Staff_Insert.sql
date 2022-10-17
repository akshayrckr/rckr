CREATE PROCEDURE Staff_Insert
@Name VARCHAR (50)=NULL, @Phone VARCHAR (30)=NULL, @Email VARCHAR (30)=NULL, @Address VARCHAR (10)=NULL, @Roles NVARCHAR (30), @Privelage NVARCHAR (50)=NULL, @Position NVARCHAR (50)=NULL, @Designation NVARCHAR (50)=NULL
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;
    BEGIN TRANSACTION;
    DECLARE @RoleId AS INT;
    SELECT @RoleId = RoleId
    FROM   Roles
    WHERE  Role = @Roles;
    INSERT  INTO Staff (Name, Email, Address, Phone,RoleId)
    VALUES            (@Name, @Email,@Address, @Phone, @RoleId);
    DECLARE @EmpId AS INT = @@IDENTITY;
    
    INSERT INTO Admin 
	SELECT @EmpID, @Privelage FROM Staff WHERE StaffId = @EmpId AND @Roles = 'Admin';

    INSERT INTO Support 
	SELECT @EmpID, @Position FROM Staff WHERE StaffId = @EmpId AND @Roles = 'Support';

    INSERT INTO Teacher
	SELECT @EmpID, @Privelage FROM Staff WHERE StaffId = @EmpId AND @Roles = 'Teacher';
    COMMIT TRANSACTION;
END