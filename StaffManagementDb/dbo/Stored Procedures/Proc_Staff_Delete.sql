-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE Proc_Staff_Delete
@StaffId int
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;
    
	DELETE Staff
	where StaffId = @StaffId
	
	DELETE Admin
	where Aid = @StaffId;

	DELETE Support
	where SId = @StaffId;

	DELETE Teacher
	where TId = @StaffId

END