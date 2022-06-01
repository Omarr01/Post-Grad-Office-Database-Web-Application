CREATE DATABASE PostGradOffice;
go
use PostGradOffice;
CREATE TABLE PostGradUser(
id int primary key identity(1,1),
email varchar(50) not null,
password varchar(30) not null
)
CREATE TABLE Admin(
id int primary key foreign key references PostGradUser on delete cascade on update cascade
)
CREATE TABLE GucianStudent(
id int primary key foreign key references PostGradUser on delete cascade on update cascade,
firstName varchar(20),
lastName varchar(20),
type varchar(3),
faculty varchar(30),
address varchar(50),
GPA decimal(3,2),
undergradID int
)
CREATE TABLE NonGucianStudent(
id int primary key foreign key references PostGradUser on delete cascade on update cascade,
firstName varchar(20),
lastName varchar(20),
type varchar(3),
faculty varchar(30),
address varchar(50),
GPA decimal(3,2),
)
CREATE TABLE GUCStudentPhoneNumber(
id int foreign key references GucianStudent on delete cascade on update cascade,
phone int,
primary key(id, phone)
)
CREATE TABLE NonGUCStudentPhoneNumber(
id int foreign key references NonGucianStudent on delete cascade on update cascade,
phone int,
primary key(id, phone)
)
CREATE TABLE Course(
id int primary key identity(1,1),
fees int,
creditHours int,
code varchar(10)
)
CREATE TABLE Supervisor(
id int primary key foreign key references PostGradUser,
name varchar(20),
faculty varchar(30)
);
CREATE TABLE Examiner(
id int primary key foreign key references PostGradUser on delete cascade on update cascade,
name varchar(20),
fieldOfWork varchar(100),
isNational BIT
)
CREATE TABLE Payment(
id int primary key identity(1,1),
amount decimal(7,2),
noOfInstallments int,
fundPercentage decimal(4,2)
)
CREATE TABLE Thesis(
serialNumber int primary key identity(1,1),
field varchar(20),
type varchar(3) not null,
title varchar(100) not null,
startDate date not null,
endDate date not null,
defenseDate date,
years as (year(endDate)-year(startDate)),
grade decimal(4,2),
payment_id int foreign key references payment on delete cascade on update cascade,
noOfExtensions int
)

CREATE TABLE Publication(
id int primary key identity(1,1),
title varchar(100) not null,
dateOfPublication date,
place varchar(100),
accepted BIT,
host varchar(100)
);

Create table Defense (serialNumber int,
date datetime,
location varchar(15),
grade decimal(4,2),
primary key (serialNumber, date),
foreign key (serialNumber) references Thesis on delete cascade on update cascade)
Create table GUCianProgressReport (
sid int foreign key references GUCianStudent on delete cascade on update cascade
, no int
, date datetime
, eval int
, state int
, description varchar(200)
, thesisSerialNumber int foreign key references Thesis on delete cascade on update cascade
, supid int foreign key references Supervisor
, primary key (sid, no) )
Create table NonGUCianProgressReport (sid int foreign key references NonGUCianStudent on delete
cascade on update cascade,
no int
, date datetime
, eval int
, state int
, description varchar(200)
, thesisSerialNumber int foreign key references Thesis on delete cascade on update cascade
, supid int foreign key references Supervisor
, primary key (sid, no) )
Create table Installment (date datetime,
paymentId int foreign key references Payment on delete cascade on update cascade
, amount decimal(8,2)
, done bit
, primary key (date, paymentId))
Create table NonGucianStudentPayForCourse(sid int foreign key references NonGucianStudent on
delete cascade on update cascade,
paymentNo int foreign key references Payment on delete cascade on update cascade,
cid int foreign key references Course on delete cascade on update cascade,
primary key (sid, paymentNo, cid))
Create table NonGucianStudentTakeCourse (sid int foreign key references NonGUCianStudent on delete
cascade on update cascade
, cid int foreign key references Course on delete cascade on update cascade
, grade decimal (4,2)
, primary key (sid, cid) )
Create table GUCianStudentRegisterThesis (sid int foreign key references GUCianStudent on delete
cascade on update cascade,
supid int foreign key references Supervisor
, serial_no int foreign key references Thesis on delete cascade on update cascade
, primary key(sid, supid, serial_no))
Create table NonGUCianStudentRegisterThesis (sid int foreign key references NonGUCianStudent on
delete cascade on update cascade,
supid int foreign key references Supervisor,
serial_no int foreign key references Thesis on delete cascade on update cascade ,
primary key (sid, supid, serial_no))
Create table ExaminerEvaluateDefense(date datetime,
serialNo int,
examinerId int foreign key references Examiner on delete cascade on update cascade,
comment varchar(300),
primary key(date, serialNo, examinerId),
foreign key (serialNo, date) references Defense (serialNumber, date) on delete cascade on update
cascade)
Create table ThesisHasPublication(serialNo int foreign key references Thesis on delete cascade on
update cascade,
pubid int foreign key references Publication on delete cascade on update cascade,
primary key(serialNo,pubid))


go
create proc studentRegister
@first_name varchar(20),
@last_name varchar(20),
@password varchar(20),
@faculty varchar(20),
@Gucian bit,
@email varchar(50),
@address varchar(50)
as
begin
insert into PostGradUser(email,password)
values(@email,@password)
declare @id int
SELECT @id=SCOPE_IDENTITY()
if(@Gucian=1)
insert into GucianStudent(id,firstName,lastName,faculty,address)
values(@id,@first_name,@last_name,@faculty,@address)
else
insert into NonGucianStudent(id,firstName,lastName,faculty,address)
values(@id,@first_name,@last_name,@faculty,@address)
end
go
create proc supervisorRegister
@first_name varchar(20),
@last_name varchar(20),
@password varchar(20),
@faculty varchar(20),
@email varchar(50)
as
begin
insert into PostGradUser(email,password)
values(@email,@password)
declare @id int
SELECT @id=SCOPE_IDENTITY()
declare @name varchar(50)
set @name = CONCAT(@first_name,@last_name)
insert into Supervisor(id,name,faculty) values(@id,@name,@faculty)
end
go
Create proc userLogin
@id int,
@password varchar(20),
@success bit output
as
begin
if exists(
select ID,password
from PostGradUser
where id=@id and password=@password)
set @success =1
else
set @success=0
end

GO
CREATE PROC userLoginEmail
@email VARCHAR(50),
@password VARCHAR(30),
@success BIT OUTPUT,
@id INT OUTPUT
AS
IF(EXISTS (SELECT pgu.email,pgu.password FROM PostGradUser pgu WHERE pgu.email=@email AND pgu.password=@password))
BEGIN
SET @success = 1
SELECT @id = pgu.id FROM PostGradUser pgu WHERE pgu.email=@email AND pgu.password=@password
END
ELSE
BEGIN
SET @success = 0
SET @id = 0
END

go
create proc addMobile
@ID varchar(20),
@mobile_number varchar(20)
as
begin
if @ID is not null and @mobile_number is not null
begin
--check Gucian student or not
if(exists(select * from GucianStudent where id=@ID))
insert into GUCStudentPhoneNumber values(@ID,@mobile_number)
if(exists(select * from NonGucianStudent where id=@ID))
insert into NonGUCStudentPhoneNumber values(@ID,@mobile_number)
end
end
GO
CREATE PROC showMobile
@ID INT
AS
SELECT gspn.phone FROM GUCStudentPhoneNumber gspn WHERE id = @ID
UNION
SELECT ngspn.phone FROM NonGUCStudentPhoneNumber ngspn WHERE id = @ID

go
CREATE Proc AdminListSup
As
Select u.id,u.email,u.password,s.name, s.faculty
from PostGradUser u inner join Supervisor s on u.id = s.id
go
CREATE Proc AdminViewSupervisorProfile
@supId int
As
Select u.id,u.email,u.password,s.name, s.faculty
from PostGradUser u inner join Supervisor s on u.id = s.id
WHERE @supId = s.id
go
CREATE Proc AdminViewAllTheses
As
Select
serialNumber,field,type,title,startDate,endDate,defenseDate,years,grade,payment_id,noOfExtensions
From Thesis
go
CREATE Proc AdminViewOnGoingTheses
@thesesCount int output
As
Select @thesesCount=Count(*)
From Thesis
where endDate > Convert(Date,CURRENT_TIMESTAMP) AND startDate < Convert(Date,CURRENT_TIMESTAMP)
go
CREATE Proc AdminViewStudentThesisBySupervisor
As
Select s.name,t.title,gs.firstName
From Thesis t inner join GUCianStudentRegisterThesis sr on t.serialNumber=sr.serial_no
inner join Supervisor s on s.id=sr.supid inner join GucianStudent gs on sr.sid=gs.id
where t.endDate > Convert(Date,CURRENT_TIMESTAMP)
union
Select s.name,t.title,gs.firstName
From Thesis t inner join NonGUCianStudentRegisterThesis sr on t.serialNumber=sr.serial_no
inner join Supervisors on s.id=sr.supid inner join NonGucianStudent gs on sr.sid=gs.id
where t.endDate > Convert(Date,CURRENT_TIMESTAMP)
go
go
CREATE Proc AdminListNonGucianCourse
@courseID int
As
if(exists(select * from Course where id=@courseID))
Select ng.firstName,ng.lastName,c.code,n.grade
From NonGucianStudentTakeCourse n inner join Course c on n.cid=c.id inner join NonGucianStudent ng
on ng.id=n.sid
where n.cid=@courseID
go
CREATE Proc AdminUpdateExtension
@ThesisSerialNo int
As
if(exists(select * from Thesis where serialNumber=@ThesisSerialNo))
begin
declare @noOfExtensions int
select @noOfExtensions=noOfExtensions from Thesis where serialNumber=@ThesisSerialNo
update Thesis
set noOfExtensions=@noOfExtensions+1
where serialNumber=@ThesisSerialNo
end
go
CREATE Proc AdminIssueThesisPayment
@ThesisSerialNo int,
@amount decimal,
@noOfInstallments int,
@fundPercentage decimal
As
if(exists(select * from Thesis where serialNumber=@ThesisSerialNo))
begin
insert into Payment(amount,noOfInstallments,fundPercentage)
values(@amount,@noOfInstallments,@fundPercentage)
declare @id int
SELECT @id=SCOPE_IDENTITY()
update Thesis
set payment_id=@id
where serialNumber=@ThesisSerialNo
end
go
CREATE Proc AdminViewStudentProfile
@sid int
As
if(exists(select * from GucianStudent where id=@sid))
Select u.id,u.email,u.password,s.firstName,s.lastName,s.type,s.faculty,s.address,s.address,s.GPA
from PostGradUser u inner join GucianStudent s on u.id=s.id
WHERE @sid = s.id
else if(exists(select * from NonGucianStudent where id=@sid))
Select u.id,u.email,u.password,s.firstName,s.lastName,s.type,s.faculty,s.address,s.address,s.GPA
from PostGradUser u inner join NonGucianStudent s on u.id=s.id
WHERE @sid = s.id
go
CREATE Proc AdminIssueInstallPayment
@paymentID int,
@InstallStartDate date
As
if(exists(select * from Payment where id=@paymentID))
begin
declare @numOfInst int
select @numOfInst=noOfInstallments
from Payment
where id=@paymentID
declare @payAmount int
select @payAmount=amount
from Payment
where id=@paymentID
DECLARE @Counter INT
SET @Counter=1
WHILE (@counter<=@numOfInst)
BEGIN
 declare @instdate date
 set @instdate=@InstallStartDate
 declare @instAmount int
 set @instAmount=@payAmount/@numOfInst
 if(@counter=1)
 insert into
Installment(date,paymentId,amount,done)values(@InstallStartDate,@paymentID,@instAmount,0)
 else
 begin
 set @instdate=DATEADD(MM, 6, @instdate);
 insert into
Installment(date,paymentId,amount,done)values(@instdate,@paymentID,@instAmount,0)
 end
 SET @counter=@counter+1
END
end
go
CREATE Proc AdminListAcceptPublication
As
select t.serialNumber,p.title
from ThesisHasPublication tp inner join Thesis t on tp.serialNo=t.serialNumber
inner join Publication p on p.id=tp.pubid
where p.accepted=1
go
CREATE Proc AddCourse
@courseCode varchar(10),
@creditHrs int,
@fees decimal
As
insert into Course values(@fees,@creditHrs,@courseCode)
go
CREATE Proc linkCourseStudent
@courseID int,
@studentID int
As
if(exists(select * from Course ) and exists(select * from NonGucianStudent where id=@studentID))
insert into NonGucianStudentTakeCourse(sid,cid,grade)values(@studentID,@courseID,null)
go
CREATE Proc addStudentCourseGrade
@courseID int,
@studentID int,
@grade decimal
As
if(exists(select * from NonGucianStudentTakeCourse where sid=@studentID and cid=@courseID))
update NonGucianStudentTakeCourse
set grade =@grade
where cid=@courseID and sid=@studentID
go
CREATE Proc ViewExamSupDefense
@defenseDate datetime
As
select s.serial_no,ee.date,e.name,sup.name
from ExaminerEvaluateDefense ee inner join examiner e on ee.examinerId=e.id
inner join GUCianStudentRegisterThesis s on ee.serialNo=s.serial_no
inner join Supervisor sup on sup.id=s.supid
go
CREATE Proc EvaluateProgressReport
@supervisorID int,
@thesisSerialNo int,
@progressReportNo int,
@evaluation int
As
if(exists(select * from Thesis where serialNumber=@thesisSerialNo ) and @evaluation in(0,1,2,3) )
begin
if(exists(select * from GUCianStudentRegisterThesis where serial_no=@thesisSerialNo and
supid=@supervisorID))
begin
declare @gucSid int
select @gucSid=sid
from GUCianStudentRegisterThesis
where serial_no=@thesisSerialNo
update GUCianProgressReport
set eval=@evaluation
where sid=@gucSid and thesisSerialNumber=@thesisSerialNo and no=@progressReportNo
end
else if(exists(select * from NonGUCianStudentRegisterThesis where serial_no=@thesisSerialNo and
supid=@supervisorID))
begin
declare @nonGucSid int
select @nonGucSid=sid
from NonGUCianStudentRegisterThesis
where serial_no=@thesisSerialNo
update NonGUCianProgressReport
set eval=@evaluation
where sid=@nonGucSid and thesisSerialNumber=@thesisSerialNo and no=@progressReportNo
end
end
go
CREATE Proc ViewSupStudentsYears
@supervisorID int
As
if(exists(select * from Supervisor where id=@supervisorID))
begin
select s.firstName,s.lastName,t.years
from GUCianStudentRegisterThesis sr inner join GucianStudent s on sr.sid=s.id
inner join Thesis t on t.serialNumber=sr.serial_no
Where sr.supid=@supervisorID
union
select s.firstName,s.lastName,t.years
from NonGUCianStudentRegisterThesis sr inner join NonGucianStudent s on sr.sid=s.id
inner join Thesis t on t.serialNumber=sr.serial_no
WHERE sr.supid = @supervisorID
end
go
CREATE Proc SupViewProfile
@supervisorID int
As
if(exists(select * from Supervisor where id=@supervisorID))
begin
select u.id,u.email,u.password,s.name,s.faculty
from PostGradUser u inner join Supervisor s on u.id=s.id
WHERE U.id = @supervisorID
end
go
---------------------------------------
create proc UpdateSupProfile
@supervisorID int, @name varchar(20), @faculty varchar(20)
as
update Supervisor
set name = @name, faculty = @faculty
where id = @supervisorID
go
create proc ViewAStudentPublications
@StudentID int
as
select P.*
from GUCianStudentRegisterThesis GUC
inner join Thesis T
on GUC.serial_no = T.serialNumber
inner join ThesisHasPublication TP
on T.serialNumber = TP.serialNo
inner join Publication P
on P.id = TP.pubid
where GUC.sid = @StudentID
union all
select P.*
from NonGUCianStudentRegisterThesis NON
inner join Thesis T
on NON.serial_no = T.serialNumber
inner join ThesisHasPublication TP
on T.serialNumber = TP.serialNo
inner join Publication P
on P.id = TP.pubid
where NON.sid = @StudentID
go
create proc AddDefenseGucian
@ThesisSerialNo int , @DefenseDate Datetime , @DefenseLocation varchar(15)
as
insert into Defense values(@ThesisSerialNo,@DefenseDate,@DefenseLocation,null)
UPDATE Thesis SET defenseDate=@DefenseDate WHERE serialNumber=@ThesisSerialNo;
go
create proc AddDefenseNonGucian
@ThesisSerialNo int , @DefenseDate Datetime , @DefenseLocation varchar(15)
as
declare @idOfStudent int
select @idOfStudent = sid
from NonGUCianStudentRegisterThesis
where serial_no = @ThesisSerialNo
if(not exists(select grade
from NonGucianStudentTakeCourse
where sid = @idOfStudent and grade < 50))
begin
insert into Defense values(@ThesisSerialNo,@DefenseDate,@DefenseLocation,null)
UPDATE Thesis SET defenseDate=@DefenseDate WHERE serialNumber=@ThesisSerialNo;
end
go
create proc AddExaminer
@ThesisSerialNo int , @DefenseDate Datetime , @ExaminerName varchar(20),@Password varchar(30),
@National bit, @fieldOfWork varchar(20)
as
insert into PostGradUser values(@ExaminerName,@Password)
declare @id int
set @id = SCOPE_IDENTITY()
insert into Examiner values(@id,@ExaminerName,@fieldOfWork,@National)
insert into ExaminerEvaluateDefense values(@DefenseDate,@ThesisSerialNo,@id,null)
go
create proc CancelThesis
@ThesisSerialNo int
as
if(exists(
select *
from GUCianProgressReport
where thesisSerialNumber = @ThesisSerialNo
))
begin
declare @gucianEval int
set @gucianEval = (
select top 1 eval
from GUCianProgressReport
where thesisSerialNumber = @ThesisSerialNo
order by no desc
)
if(@gucianEval = 0)
begin
delete from Thesis where serialNumber = @ThesisSerialNo
end
end
else
begin
declare @nonGucianEval int
set @nonGucianEval = (
select top 1 eval
from NonGUCianProgressReport
where thesisSerialNumber = @ThesisSerialNo
order by no desc
)
if(@nonGucianEval = 0)
begin
delete from Thesis where serialNumber = @ThesisSerialNo
end
end
go
create proc AddGrade
@ThesisSerialNo int
as
declare @grade decimal(4,2)
select @grade = grade
from Defense
where serialNumber = @ThesisSerialNo
update Thesis
set grade = @grade
where serialNumber = @ThesisSerialNo
go
create proc AddDefenseGrade
@ThesisSerialNo int , @DefenseDate Datetime , @grade decimal(4,2)
as
update Defense
set grade = @grade
where serialNumber = @ThesisSerialNo and date = @DefenseDate
go
create proc AddCommentsGrade
@ThesisSerialNo int , @DefenseDate Datetime , @comments varchar(300)
as
update ExaminerEvaluateDefense
set comment = @comments
where serialNo = @ThesisSerialNo and date = @DefenseDate
go
create proc viewMyProfile
@studentId int
as
if(exists(
select * from GucianStudent where id = @studentId
))
begin
select G.*,P.email
from GucianStudent G
inner join PostGradUser P
on G.id = P.id
where G.id = @studentId
end
else
begin
select N.*,P.email
from NonGucianStudent N
inner join PostGradUser P
on N.id = P.id
where N.id = @studentId
end
go
create proc editMyProfile
@studentID int, @firstName varchar(20), @lastName varchar(20), @password varchar(30), @email
varchar(50)
, @address varchar(50), @type varchar(3)
as
update GucianStudent
set firstName = @firstName, lastName = @lastName, address = @address, type = @type
where id = @studentID
update NonGucianStudent
set firstName = @firstName, lastName = @lastName, address = @address, type = @type
where id = @studentID
update PostGradUser
set email = @email, password = @password
where id = @studentID
go
create proc addUndergradID
@studentID int, @undergradID varchar(10)
as
update GucianStudent
set undergradID = @undergradID
where id = @studentID
go
create proc ViewCoursesGrades
@studentID int
as
select grade
from NonGucianStudentTakeCourse 
where sid = @studentID
go
create proc ViewCoursePaymentsInstall
@studentID int
as
select P.id as 'Payment Number', P.amount as 'Amount of Payment',P.fundPercentage as 'Percentage of
fund for payment', P.noOfInstallments as 'Number of installments',
I.amount as 'Installment Amount',I.date as 'Installment date', I.done as 'Installment done or not'
from NonGucianStudentPayForCourse NPC
inner join Payment P
on NPC.paymentNo = P.id and NPC.sid = @studentID
inner join Installment I
on I.paymentId = P.id
go
create proc ViewThesisPaymentsInstall
@studentID int
as
select P.id as 'Payment Number', P.amount as 'Amount of Payment', P.fundPercentage as
'Fund',P.noOfInstallments as 'Number of installments',
I.amount as 'Installment amount',I.date as 'Installment date', I.done as 'Installment done or not'
from GUCianStudentRegisterThesis G
inner join Thesis T
on G.serial_no = T.serialNumber and G.sid = @studentID
inner join Payment P
on T.payment_id = P.id
inner join Installment I
on I.paymentId = P.id
union
select P.id as 'Payment Number',P.amount as 'Amount of Payment', P.fundPercentage as
'Fund',P.noOfInstallments as 'Number of installments',
I.amount as 'Installment amount',I.date as 'Installment date', I.done as 'Installment done or not'
from NonGUCianStudentRegisterThesis NG
inner join Thesis T
on NG.serial_no = T.serialNumber and NG.sid = @studentID
inner join Payment P
on T.payment_id = P.id
inner join Installment I
on I.paymentId = P.id
go
create proc ViewUpcomingInstallments
@studentID int
as
select I.date as 'Date of Installment' ,I.amount as 'Amount'
from Installment I
inner join NonGucianStudentPayForCourse NPC
on I.paymentId = NPC.paymentNo and NPC.sid = @studentID and I.date > CURRENT_TIMESTAMP
union
select I.date as 'Date of Installment' ,I.amount as 'Amount'
from Thesis T
inner join Payment P
on T.payment_id = P.id
inner join Installment I
on I.paymentId = P.id
inner join GUCianStudentRegisterThesis G
on G.serial_no = T.serialNumber and G.sid = @studentID
where I.date > CURRENT_TIMESTAMP
union
select I.date as 'Date of Installment' ,I.amount as 'Amount'
from Thesis T
inner join Payment P
on T.payment_id = P.id
inner join Installment I
on I.paymentId = P.id
inner join NonGUCianStudentRegisterThesis G
on G.serial_no = T.serialNumber and G.sid = @studentID
where I.date > CURRENT_TIMESTAMP
go
create proc ViewMissedInstallments
@studentID int
as
select I.date as 'Date of Installment' ,I.amount as 'Amount'
from Installment I
inner join NonGucianStudentPayForCourse NPC
on I.paymentId = NPC.paymentNo and NPC.sid = @studentID and I.date < CURRENT_TIMESTAMP and
I.done = '0'
union
select I.date as 'Date of Installment' ,I.amount as 'Amount'
from Thesis T
inner join Payment P
on T.payment_id = P.id
inner join Installment I
on I.paymentId = P.id
inner join GUCianStudentRegisterThesis G
on G.serial_no = T.serialNumber and G.sid = @studentID
where I.date < CURRENT_TIMESTAMP and I.done = '0'
union
select I.date as 'Date of Installment' ,I.amount as 'Amount'
from Thesis T
inner join Payment P
on T.payment_id = P.id
inner join Installment I
on I.paymentId = P.id
inner join NonGUCianStudentRegisterThesis G
on G.serial_no = T.serialNumber and G.sid = @studentID
where I.date < CURRENT_TIMESTAMP and I.done = '0'

GO
CREATE PROC thesisBelongsToMe
@stdID INT,
@thesisSerial INT,
@success BIT OUTPUT
AS
IF(EXISTS (SELECT * FROM GUCianStudentRegisterThesis WHERE sid = @stdID AND serial_no = @thesisSerial))
SET @success = 1;
ELSE IF(EXISTS (SELECT * FROM NonGUCianStudentRegisterThesis WHERE sid = @stdID AND serial_no = @thesisSerial))
SET @success = 1;
ELSE
SET @success = 0;
SELECT * FROM THesis
GO
CREATE PROC thesisBelongsToMeOngoing
@stdID INT,
@thesisSerial INT,
@success BIT OUTPUT
AS
IF(EXISTS (SELECT * 
FROM Thesis t
INNER JOIN GUCianStudentRegisterThesis gsrt ON t.serialNumber = gsrt.serial_no
WHERE gsrt.sid = @stdID AND t.startDate <= Convert(Date,CURRENT_TIMESTAMP) AND t.endDate >= Convert(Date,CURRENT_TIMESTAMP)
AND gsrt.serial_no = @thesisSerial))
SET @success = 1;
ELSE IF(EXISTS (SELECT * 
FROM Thesis t
INNER JOIN NonGUCianStudentRegisterThesis ngsrt ON t.serialNumber = ngsrt.serial_no
WHERE ngsrt.sid = @stdID AND t.startDate <= Convert(Date,CURRENT_TIMESTAMP) AND t.endDate >= Convert(Date,CURRENT_TIMESTAMP)
AND ngsrt.serial_no = @thesisSerial))
SET @success = 1;
ELSE
SET @success = 0;


GO
CREATE PROC progressNumUsed
@progressNum INT,
@stdID INT,
@success BIT OUTPUT
AS
IF(EXISTS (SELECT * FROM GUCianProgressReport WHERE no = @progressNum AND sid = @stdID))
SET @success = 1;
ELSE IF(EXISTS (SELECT * FROM NonGUCianProgressReport WHERE no = @progressNum AND sid = @stdID))
SET @success = 1;
ELSE
SET @success = 0;
GO
CREATE PROC showProgressReports
@stdID INT
AS
SELECT gpr.no, gpr.date, gpr.eval, gpr.state, gpr.description, gpr.thesisSerialNumber, gpr.supid FROM GUCianProgressReport gpr WHERE sid = @stdID
UNION
SELECT gpr.no, gpr.date, gpr.eval, gpr.state, gpr.description, gpr.thesisSerialNumber, gpr.supid FROM NonGUCianProgressReport gpr WHERE sid = @stdID
GO
CREATE PROC validProgressUpdate
@stdID INT,
@thesisSer INT,
@prgNum INT,
@success INT OUTPUT
AS
IF(EXISTS (SELECT * FROM GUCianProgressReport WHERE sid = @stdID AND thesisSerialNumber = @thesisSer AND no = @prgNum))
SET @success = 1
ELSE IF(EXISTS (SELECT * FROM NonGUCianProgressReport WHERE sid = @stdID AND thesisSerialNumber = @thesisSer AND no = @prgNum))
SET @success = 1
ELSE 
SET @success = 0;

go
create proc AddProgressReport
@thesisSerialNo int, @progressReportDate date, @studentID int,@progressReportNo int
as
declare @gucian int
if(exists(
select id
from GucianStudent
where id = @studentID
))
begin
set @gucian = '1'
end
else
begin
set @gucian = '0'
end
if(@gucian = '1')
begin
insert into GUCianProgressReport
values(@studentID,@progressReportNo,@progressReportDate,null,null,null,@thesisSerialNo,null)
end
else
begin
insert into NonGUCianProgressReport
values(@studentID,@progressReportNo,@progressReportDate,null,null,null,@thesisSerialNo,null)
end
go
create proc FillProgressReport
@thesisSerialNo int, @progressReportNo int, @state int, @description varchar(200),@studentID int
as
declare @gucian bit
if(exists(
select * from GucianStudent
where id = @studentID
))
begin
set @gucian = '1'
end
else
begin
set @gucian = '0'
end
if(@gucian = '1')
begin
update GUCianProgressReport
set state = @state, description = @description, date = CURRENT_TIMESTAMP
where thesisSerialNumber = @thesisSerialNo and sid = @studentID and no = @progressReportNo
end
else
begin
update NonGUCianProgressReport
set state = @state, description = @description, date = CURRENT_TIMESTAMP
where thesisSerialNumber = @thesisSerialNo and sid = @studentID and no = @progressReportNo
end
go
create proc ViewEvalProgressReport
@thesisSerialNo int, @progressReportNo int,@studentID int
as
select eval
from GUCianProgressReport
where sid = @studentID and thesisSerialNumber = @thesisSerialNo and no = @progressReportNo
union
select eval
from NonGUCianProgressReport
where sid = @studentID and thesisSerialNumber = @thesisSerialNo and no = @progressReportNo
go
create proc addPublication
@title varchar(50), @pubDate datetime, @host varchar(50), @place varchar(50), @accepted bit
as
insert into Publication values(@title,@pubDate,@place,@accepted,@host)

go
create proc linkPubThesis
@PubID int, @thesisSerialNo int
as
insert into ThesisHasPublication values(@thesisSerialNo,@PubID)
go
create trigger deleteSupervisor
on Supervisor
instead of delete
as
delete from GUCianProgressReport where supid in (select id from deleted)
delete from NonGUCianProgressReport where supid in (select id from deleted)
delete from GUCianStudentRegisterThesis where supid in (select id from deleted)
delete from NonGUCianStudentRegisterThesis where supid in (select id from deleted)
delete from Supervisor where id in (select id from deleted)
delete from PostGradUser where id in (select id from deleted)

GO
CREATE PROC emailExists
@email VARCHAR(50),
@emailAlreadyExists BIT OUTPUT
AS
BEGIN
IF(EXISTS (SELECT * FROM PostGradUser WHERE email = @email))
SET @emailAlreadyExists = 1
ELSE
SET @emailAlreadyExists = 0
END

GO 
CREATE PROC yourID
@id INT OUTPUT
AS
SELECT @id = MAX(id) FROM PostGradUser

GO
CREATE PROC examinerRegister
@email VARCHAR(50),
@password VARCHAR(20),
@name VARCHAR(20),
@nationalBit BIT,
@fieldOfWork VARCHAR(20)
AS
begin
insert into PostGradUser(email,password)
values(@email,@password)
declare @idTmp int
SELECT @idTmp=SCOPE_IDENTITY()
insert into Examiner(id, name, isNational, fieldOfWork) VALUES(@idTmp, @name, @nationalBit, @fieldOfWork)
end

GO
CREATE PROC listMyThesis
@studentID INT
AS
IF(EXISTS (SELECT * FROM GucianStudent WHERE id = @studentID))
SELECT t.* 
FROM Thesis t
INNER JOIN GUCianStudentRegisterThesis gsrt ON t.serialNumber = gsrt.serial_no
WHERE gsrt.sid = @studentID
ELSE
SELECT t.* 
FROM Thesis t
INNER JOIN NonGUCianStudentRegisterThesis ngsrt ON t.serialNumber = ngsrt.serial_no
WHERE ngsrt.sid = @studentID

GO
CREATE PROC listMyOngoingThesis
@studentID INT
AS
IF(EXISTS (SELECT * FROM GucianStudent WHERE id = @studentID))
SELECT t.* 
FROM Thesis t
INNER JOIN GUCianStudentRegisterThesis gsrt ON t.serialNumber = gsrt.serial_no
WHERE gsrt.sid = @studentID AND t.startDate <= Convert(Date,CURRENT_TIMESTAMP) AND t.endDate >= Convert(Date,CURRENT_TIMESTAMP)
ELSE
SELECT t.* 
FROM Thesis t
INNER JOIN NonGUCianStudentRegisterThesis ngsrt ON t.serialNumber = ngsrt.serial_no
WHERE ngsrt.sid = @studentID AND t.startDate <= Convert(Date,CURRENT_TIMESTAMP) AND t.endDate >= Convert(Date,CURRENT_TIMESTAMP)

GO 
CREATE PROC userType
@id INT,
@type VARCHAR(20) OUTPUT
AS
IF(EXISTS (SELECT * FROM GucianStudent WHERE id=@id))
SET @type = 'gucianstudent'
ELSE IF(EXISTS (SELECT * FROM NonGucianStudent WHERE id=@id))
SET @type = 'nongucianstudent'
ELSE IF(EXISTS (SELECT * FROM Supervisor WHERE id=@id))
SET @type = 'supervisor'
ELSE IF(EXISTS (SELECT * FROM Examiner WHERE id=@id))
SET @type = 'examiner'
ELSE IF(EXISTS (SELECT * FROM Admin WHERE id=@id))
SET @type = 'admin'



GO
CREATE PROC ListCoursesAndGrade
@studentID INT
AS
SELECT c.*, ngstc.grade
FROM Course c 
INNER JOIN NonGucianStudentTakeCourse ngstc ON c.id = ngstc.cid
WHERE ngstc.sid = @studentID


GO
CREATE PROC showPubId
@pubID INT OUTPUT
AS
SELECT @pubID = MAX(id) FROM Publication

GO
CREATE PROC pubTable
AS
SELECT * FROM Publication;

-- ....................................................................
-- ....................................................................

GO
CREATE PROC IsAStudent
@id INT,
@success BIT OUTPUT
AS
IF(EXISTS (SELECT * FROM GucianStudent WHERE id=@id))
SET @success = '1'
ELSE IF(EXISTS (SELECT * FROM NonGucianStudent WHERE id=@id))
SET @success = '1'
ELSE
SET @success = '0'

GO 
CREATE PROC doesMyThesisExists
@serialNum INT,
@superId INT,
@success BIT OUTPUT
AS
IF (EXISTS(SELECT * FROM GUCianStudentRegisterThesis WHERE @serialNum = serial_no AND @superId = supid))
SET @success = '1';
ELSE if (EXISTS(SELECT * FROM NonGUCianStudentRegisterThesis WHERE @serialNum = serial_no AND @superId = supid))
SET @success = '1';
ELSE
SET @success = '0';



GO
CREATE PROC thesisBelongToGucian
@serialNum INT,
@success BIT OUTPUT
AS
IF(EXISTS(SELECT * FROM GucianStudent G INNER JOIN GUCianStudentRegisterThesis GT ON G.id = GT.sid WHERE GT.serial_no = @serialNum))
SET @success = '1';
ELSE
SET @success = '0';

GO 
Create PROC AddExaminerForaDefense
@defenseDate DATETIME,
@thesisSerialNumber INT,
@examinerId INT
AS
INSERT INTO ExaminerEvaluateDefense (serialNo,date,examinerId) VALUES (@thesisSerialNumber,@defenseDate,@examinerId);

GO
CREATE PROC ExaminerExists
@id INT,
@success BIT OUTPUT
AS
IF(EXISTS(SELECT * FROM Examiner WHERE id=@id))
SET @success = '1';
ELSE
SET @success= '0'



GO 
CREATE PROC DoesThesisHasDefense
@serialNo INT,
@success BIT OUTPUT
AS 
IF(EXISTS(SELECT * FROM Defense WHERE serialNumber=@serialNo))
SET @success = '1';
ELSE
SET @success = '0';


GO
CREATE PROC GetDefenceDate
@serialNo INT,
@date DATETIME OUTPUT
AS
SELECT @date=defenseDate FROM Thesis WHERE serialNumber=@serialNo

GO 
CREATE PROC SupervisorHasProgressReport
@thesisSerialNumber INT,
@progressReportNumber INT,
@supervisorId INT,
@success BIT OUTPUT
AS
IF (EXISTS(SELECT * FROM GUCianProgressReport WHERE no=@progressReportNumber AND thesisSerialNumber=@thesisSerialNumber AND supid=@supervisorId))
SET @success = '1';
ELSE IF(EXISTS(SELECT * FROM NonGUCianProgressReport WHERE no=@progressReportNumber AND thesisSerialNumber=@thesisSerialNumber AND supid=@supervisorId))
SET @success = '1';
ELSE
SET @success = '0';

-- ....................................................................
-- ....................................................................


go
create proc editExamProfile
@id int,
@name varchar(20),
@fieldOfWork varchar(100)
as
IF(EXISTS (SELECT e.* from Examiner e WHERE e.id=@id))
update Examiner
set fieldOfWork=@fieldOfWork, name=@name
where id=@id
go

create proc viewExamProfile
@id int
as
select e.name, e.fieldOfWork
from Examiner e
where id=@id

go
create proc viewExamDefenseInfo
@id int
as
select t.title, sp.name, s.firstName, s.lastName
from (ExaminerEvaluateDefense e inner join GUCianStudentRegisterThesis g on e.serialNo=g.serial_no 
inner join Thesis t on g.serial_no=t.serialNumber inner join GucianStudent s on s.id= g.sid inner join Supervisor sp on sp.id= g.supid) union
select t.title, sp.name, s.firstName, s.lastName from (ExaminerEvaluateDefense e inner join NonGucianStudentRegisterThesis g on e.serialNo=g.serial_no 
inner join Thesis t on g.serial_no=t.serialNumber inner join NonGucianStudent s on s.id= g.sid inner join Supervisor sp on sp.id= g.supid) 
where e.examinerid=@id

go  

create proc checkForExamibility
@id int,
@thesis int,
@success int Output,
@date datetime Output
as
if(exists(select * from ExaminerEvaluateDefense e where e.examinerId=@id and e.serialNo=@thesis))
Begin
set @success=1 
select @date=e.date from ExaminerEvaluateDefense e where e.examinerId=@id and e.serialNo=@thesis
end
else
set @success=0
go

create proc SearchThesis
as
select * from Thesis
go


