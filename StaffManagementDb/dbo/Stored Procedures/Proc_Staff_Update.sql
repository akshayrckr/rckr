CREATE PROCEDURE Proc_Staff_Update
@Name VARCHAR (50)=NULL,@Rolee VARCHAR(30),@StaffId int=NULL ,@Phone VARCHAR (30)=NULL, @Email VARCHAR (30)=NULL, @Address VARCHAR (10)=NULL, @Roles NVARCHAR (30), @Privelage NVARCHAR (50)=NULL, @Position NVARCHAR (50)=NULL,@Experience int=NULL, @Designation NVARCHAR (50)=NULL
AS
BEGIN
    Update Staff SET Name = @Name, Email= @Email where StaffId=@StaffId;

			Declare @RId int;
			select @RId = RoleId from Roles where Role=@Rolee;

			MERGE Admin as A
			Using Staff as S
			On S.StaffId = A.AId And S.StaffId = @StaffId and S.RoleId=@RId
			When Matched then 
			Update SET A.Privelage=@Privelage;

			MERGE Teacher as T
			Using Staff as S
			On S.StaffId = T.TId And S.StaffId = @StaffId and S.RoleId=@RId
			When Matched then 
			Update SET T.Experience = @Experience;

			MERGE Support as Su
			Using Staff as S
			On S.StaffId = Su.SId And S.StaffId = @StaffId and S.RoleId=@RId
			When Matched then 
			Update SET Su.Position=@Position;
    COMMIT TRANSACTION;
END