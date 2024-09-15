--01.Logs

SELECT * FROM Accounts
CREATE TABLE Logs 
(
LogId INT PRIMARY KEY IDENTITY,
AccountId INT FOREIGN KEY REFERENCES Accounts(Id) NOT NULL,
OldSum MONEY NOT NULL,
NewSum MONEY NOT NULL
)
GO

CREATE TRIGGER tr_LogBalanceChange
ON Accounts
FOR UPDATE
AS
 INSERT INTO Logs (AccountId, OldSum, NewSum)
 SELECT i.Id, d.Balance, i.Balance
 FROM inserted AS i
 JOIN deleted AS d ON i.Id=d.Id
 WHERE i.Balance <> d.Balance
GO

UPDATE Accounts
SET Balance -= 1000
WHERE Id = 8

SELECT * FROM Logs

--02. Create table emails
CREATE TABLE NotificationEmails
(
Id INT PRIMARY KEY IDENTITY,
Recipient INT FOREIGN KEY REFERENCES Accounts(Id),
[Subject] NVARCHAR(200),
Body NVARCHAR(1000)
)

CREATE TRIGGER tr_EmailLogs
ON Logs
FOR INSERT
AS
	INSERT INTO NotificationEmails (Recipient, [Subject], Body)
	SELECT i.AccountId,
	CONCAT_WS(' ', 'Balance change for account:',i.AccountId),
	CONCAT_WS(' ','On', GETDATE(),'your balance was changed from', i.OldSum,'to',i.NewSum,'.')
	FROM inserted AS i
GO

--03. Deposit money
CREATE PROC usp_DepositMoney
	@AccountId INT,
	@MoneyAmount MONEY
AS
BEGIN
	IF @MoneyAmount > 0
	BEGIN
		UPDATE Accounts
		SET Balance = Balance + @MoneyAmount
		WHERE Id = @AccountId
	END
END

--04.Withdraw proc
CREATE PROC usp_WithdrawMoney (@AccountId INT, @MoneyAmount MONEY)
AS
BEGIN
	IF @MoneyAmount > 0 
	BEGIN
		UPDATE Accounts
		SET Balance -= @MoneyAmount
		WHERE Id = @AccountId
	END
END

--05. Money Transfer
CREATE PROC usp_TransferMoney (@SenderId INT, @ReceiverId INT, @Amount MONEY)
AS
BEGIN 
	IF(@Amount) > 0
	BEGIN TRANSACTION
	BEGIN TRY
		EXEC dbo.usp_WithdrawMoney @AccountId = @SenderId, @MoneyAmount = @Amount
		EXEC dbo.usp_DepositMoney @AccountId = @ReceiverId, @MoneyAmount= @Amount
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
	ROLLBACK TRANSACTION
	END CATCH
END 

--06.Trigger
GO
USE Diablo
GO

CREATE TRIGGER tr_BuyItem
ON UserGameItems
INSTEAD OF INSERT
AS
BEGIN
	DECLARE @UserGameId INT
	DECLARE @UserGameLevel INT
	DECLARE @ItemID INT
	DECLARE @ItemLevel INT
	DECLARE @ItemPrice MONEY

	SELECT @UserGameId = i.UserGameId, @ItemID = i.ItemId
	FROM inserted AS i

	SELECT @ItemLevel = MinLevel, @ItemPrice = Price
	FROM Items
	WHERE Id = @ItemID

	SELECT @UserGameLevel = [Level]
	FROM UsersGames
	WHERE Id = @UserGameId

	IF @UserGameLevel >= @ItemLevel
	BEGIN TRANSACTION
		
		BEGIN TRY

		INSERT INTO UserGameItems (UserGameId, ItemId)
		SELECT UserGameId, ItemId
		FROM inserted

		UPDATE UsersGames
		SET CASH -= @ItemPrice
		WHERE Id = @UserGameId
		COMMIT TRANSACTION

		END TRY
		BEGIN CATCH
		ROLLBACK TRANSACTION
		END CATCH
	
END

--ADD bonus cash:
UPDATE ug
SET CASH += 50000
FROM UsersGames AS ug
JOIN Users AS u ON u.Id = ug.UserId
JOIN Games AS g On ug.GameId = g.Id
WHERE g.[Name] = 'Bali' AND u.Username IN ('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos')


--7.

--08.
GO
USE SoftUni
GO
CREATE OR ALTER PROC usp_AssignProject
	@EmployeeId INT,
	@ProjectId INT
AS
BEGIN
	BEGIN TRANSACTION
	BEGIN TRY
	INSERT INTO EmployeesProjects (EmployeeId, ProjectId)
	VALUES(@EmployeeId, @ProjectId)

	DECLARE @ProjectCount INT
	SELECT @ProjectCount = COUNT(*)
	FROM EmployeesProjects
	WHERE EmployeeID = @EmployeeId

	IF @ProjectCount > 3
	THROW 51000,'The employee has too many projects!',1
	
	COMMIT TRANSACTION
	END TRY

	BEGIN CATCH
	ROLLBACK TRANSACTION
	END CATCH
END

EXEC usp_AssignProject 2,1
EXEC usp_AssignProject 2,2
EXEC usp_AssignProject 2,3
BEGIN TRY  
 EXEC usp_AssignProject 2,4
END TRY  
BEGIN CATCH 
   SELECT error_message()
END CATCH;

SELECT * FROM EmployeesProjects
TRUNCATE TABLE EmployeesProjects
--09. Delete employees
CREATE TABLE Deleted_Employees
(
	EmployeeId INT PRIMARY KEY,
	FirstName VARCHAR (60),
	LastName VARCHAR (60),
	MiddleName VARCHAR(60),
	JobTitle VARCHAR(60),
	DepartmentID INT FOREIGN KEY REFERENCES Departments(DepartmentId),
	Salary DECIMAL(10,2)
)

GO
CREATE OR ALTER TRIGGER tr_DeleteEmployee
ON Employees
FOR DELETE
AS
INSERT INTO Deleted_Employees (FirstName,LastName,MiddleName,JobTitle, DepartmentID, Salary)
SELECT d.FirstName, d.LastName, d.MiddleName, d.JobTitle, d.DepartmentID, d.Salary
FROM deleted AS d