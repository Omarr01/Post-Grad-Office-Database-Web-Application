-- Payments
INSERT INTO Payment(amount, noOfInstallments, fundPercentage)
VALUES(12500.0, 0, 0)

INSERT INTO Payment(amount, noOfInstallments, fundPercentage)
VALUES(17500.0, 2, 0)
INSERT INTO Installment(date, paymentId, amount, done)
VALUES('2022-2-15', 2, 8750.0, '0')
INSERT INTO Installment(date, paymentId, amount, done)
VALUES('2022-6-30', 2, 8750.0, '0')

INSERT INTO Payment(amount, noOfInstallments, fundPercentage)
VALUES(15000.0, 3, 0)
INSERT INTO Installment(date, paymentId, amount, done)
VALUES('2022-2-15', 3, 5000.0, '0')
INSERT INTO Installment(date, paymentId, amount, done)
VALUES('2022-4-15', 3, 5000.0, '0')
INSERT INTO Installment(date, paymentId, amount, done)
VALUES('2022-6-15', 3, 5000.0, '0')

INSERT INTO Payment(amount, noOfInstallments, fundPercentage)
VALUES(10000.0, 2, 0)
INSERT INTO Installment(date, paymentId, amount, done)
VALUES('2022-1-27', 4, 5000.0, '0')
INSERT INTO Installment(date, paymentId, amount, done)
VALUES('2022-3-22', 4, 5000.0, '0')

INSERT INTO Payment(amount, noOfInstallments, fundPercentage)
VALUES(10000.0, 2, 0)
INSERT INTO Installment(date, paymentId, amount, done)
VALUES('2022-1-27', 5, 5000.0, '0')
INSERT INTO Installment(date, paymentId, amount, done)
VALUES('2022-3-22', 5, 5000.0, '0')

INSERT INTO Payment(amount, noOfInstallments, fundPercentage)
VALUES(11000.0, 2, 0)
-- ..................
INSERT INTO Payment(amount, noOfInstallments, fundPercentage)
VALUES(55000.0, 4, 0)
INSERT INTO Installment(date, paymentId, amount, done)
VALUES('2022-1-20', 7, 13750, '0')
INSERT INTO Installment(date, paymentId, amount, done)
VALUES('2022-4-20', 7, 13750, '0')
INSERT INTO Installment(date, paymentId, amount, done)
VALUES('2022-7-20', 7, 13750, '0')
INSERT INTO Installment(date, paymentId, amount, done)
VALUES('2022-10-20', 7, 13750, '0')

INSERT INTO Payment(amount, noOfInstallments, fundPercentage)
VALUES(60000.0, 3, 0)

INSERT INTO Payment(amount, noOfInstallments, fundPercentage)
VALUES(52500.0, 2, 0)

INSERT INTO Payment(amount, noOfInstallments, fundPercentage)
VALUES(47500.0, 4, 0)
INSERT INTO Installment(date, paymentId, amount, done)
VALUES('2022-10-20', 10, 11875, '0')
INSERT INTO Installment(date, paymentId, amount, done)
VALUES('2022-12-20', 10, 11875, '0')
INSERT INTO Installment(date, paymentId, amount, done)
VALUES('2023-2-20', 10, 11875, '0')
INSERT INTO Installment(date, paymentId, amount, done)
VALUES('2024-4-20', 10, 11875, '0')

INSERT INTO Payment(amount, noOfInstallments, fundPercentage)
VALUES(62500.0, 4, 0)

INSERT INTO Payment(amount, noOfInstallments, fundPercentage)
VALUES(62500.0, 2, 0)

INSERT INTO Payment(amount, noOfInstallments, fundPercentage)
VALUES(65000.0, 2, 0)
INSERT INTO Installment(date, paymentId, amount, done)
VALUES('2022-1-20', 13, 32500, '0')
INSERT INTO Installment(date, paymentId, amount, done)
VALUES('2022-3-20', 13, 32500, '0')

INSERT INTO Payment(amount, noOfInstallments, fundPercentage)
VALUES(72000.0, 3, 0)

INSERT INTO Payment(amount, noOfInstallments, fundPercentage)
VALUES(61500, 3, 0)

INSERT INTO Payment(amount, noOfInstallments, fundPercentage)
VALUES(50500.0, 4, 0)
INSERT INTO Installment(date, paymentId, amount, done)
VALUES('2021-1-20', 16, 12625, '0')
INSERT INTO Installment(date, paymentId, amount, done)
VALUES('2022-3-20', 16, 12625, '0')
INSERT INTO Installment(date, paymentId, amount, done)
VALUES('2022-5-20', 16, 12625, '0')
INSERT INTO Installment(date, paymentId, amount, done)
VALUES('2022-7-20', 16, 12625, '0')

-- .........................................................

-- Users
INSERT INTO PostGradUser(email, password)
VALUES('ahmed@yahoo.com','12ahmed345')
INSERT INTO PostGradUser(email, password)
VALUES('omar@yahoo.com','1omar2345')

INSERT INTO PostGradUser(email, password)
VALUES('abdelrahman@yahoo.com','a324345')
INSERT INTO PostGradUser(email, password)
VALUES('ibrahim@yahoo.com','ibr12005')
INSERT INTO PostGradUser(email, password)
VALUES('omars@yahoo.com','omar2325')
INSERT INTO PostGradUser(email, password)
VALUES('ahmed2@yahoo.com','ahmed2010')
INSERT INTO PostGradUser(email, password)
VALUES('tarek@yahoo.com','taroka1122')
INSERT INTO PostGradUser(email, password)
VALUES('hanafy@yahoo.com','han3456')
INSERT INTO PostGradUser(email, password)
VALUES('hefny@yahoo.com','hefnyhefny123')
INSERT INTO PostGradUser(email, password)
VALUES('mahmoud@yahoo.com','7oda123')
INSERT INTO PostGradUser(email, password)
VALUES('safa@yahoo.com','sa1234fa')
INSERT INTO PostGradUser(email, password)
VALUES('abanob@yahoo.com','abyo12345')
INSERT INTO PostGradUser(email, password)
VALUES('bahaa@yahoo.com','bahaa1111')
INSERT INTO PostGradUser(email, password)
VALUES('shorba@yahoo.com','shor1245')
INSERT INTO PostGradUser(email, password)
VALUES('joe@yahoo.com','youssef1133')
INSERT INTO PostGradUser(email, password)
VALUES('yara@yahoo.com','200yara12')
INSERT INTO PostGradUser(email, password)
VALUES('ali@yahoo.com','ali1111')
INSERT INTO PostGradUser(email, password)
VALUES('salma@yahoo.com','sal12312')
INSERT INTO PostGradUser(email, password)
VALUES('gina@yahoo.com','1gina234')

INSERT INTO PostGradUser(email, password)
VALUES('mervat@yahoo.com','mer121212')
INSERT INTO PostGradUser(email, password)
VALUES('slim@yahoo.com','balabizo123')
INSERT INTO PostGradUser(email, password)
VALUES('ramiyounes@yahoo.com','rami12312')
INSERT INTO PostGradUser(email, password)
VALUES('yasser@yahoo.com','yasserhig78')
INSERT INTO PostGradUser(email, password)
VALUES('hanysharq@yahoo.com','hanyshark121')

INSERT INTO PostGradUser(email, password)
VALUES('taher@yahoo.com','taher787')
INSERT INTO PostGradUser(email, password)
VALUES('elrasas@yahoo.com','rasas1219')
INSERT INTO PostGradUser(email, password)
VALUES('antoni@yahoo.com','antoni1111')
INSERT INTO PostGradUser(email, password)
VALUES('philip@yahoo.com','phil112233')


-- Admin
INSERT INTO Admin(id) VALUES(1)
INSERT INTO Admin(id) VALUES(2)

-- GucianStudent
INSERT INTO GucianStudent(id, firstName, lastName, type, faculty, address, GPA)
VALUES(3, 'abdelrahman', 'mohamed', 'Msc', 'MET', 'Tagamo 3', 0.7)
INSERT INTO GucianStudent(id, firstName, lastName, type, faculty, address, GPA)
VALUES(4, 'ibrahim', 'mohamed', 'Msc', 'EMS', 'Tagamo 5', 0.95)
INSERT INTO GucianStudent(id, firstName, lastName, type, faculty, address, GPA, undergradID)
VALUES(5, 'omar', 'sameh', 'PhD', 'MET', 'Madinaty', 0.7, 407989)
INSERT INTO GucianStudent(id, firstName, lastName, type, faculty, address, GPA, undergradID)
VALUES(6, 'ahmed', 'kayed', 'Msc', 'IET', 'MadNasr', 0.7, 432775)
INSERT INTO GucianStudent(id, firstName, lastName, type, faculty, address, GPA, undergradID)
VALUES(7, 'tarek', 'sameh', 'Msc', 'MET', 'Maadi', 1.88, 437183)
INSERT INTO GucianStudent(id, firstName, lastName, type, faculty, address, GPA, undergradID)
VALUES(8, 'hanafy', 'abdelrahman', 'PhD', 'IET', 'Tagamo 5', 1.3, 401234)

-- NonGucianStudent
INSERT INTO NonGucianStudent(id, firstName, lastName, type, faculty, address, GPA)
VALUES(9, 'hefny', 'hefny', 'Msc', 'Mechatronics', 'MadNasr', 3.0)
INSERT INTO NonGucianStudent(id, firstName, lastName, type, faculty, address, GPA)
VALUES(10, 'mahmoud', 'hefny', 'Msc', 'Mechatronics', 'MadNasr', 2.7)
INSERT INTO NonGucianStudent(id, firstName, lastName, type, faculty, address, GPA)
VALUES(11, 'safa', 'ahmed', 'Msc', 'CS', 'MadNasr', 4.0)
INSERT INTO NonGucianStudent(id, firstName, lastName, type, faculty, address, GPA)
VALUES(12, 'abanob', 'george', 'PhD', 'Civil', 'Giza', 3.5)
INSERT INTO NonGucianStudent(id, firstName, lastName, type, faculty, address, GPA)
VALUES(13, 'bahaa', 'mohamed', 'PhD', 'CS', 'Maadi', 4.0)
INSERT INTO NonGucianStudent(id, firstName, lastName, type, faculty, address, GPA)
VALUES(14, 'shorbagy', 'youssef', 'PhD', 'CS', 'Douki', 4.0)
INSERT INTO NonGucianStudent(id, firstName, lastName, type, faculty, address, GPA)
VALUES(15, 'youssef', 'ahmed', 'PhD', 'CS', 'Madinaty', 4.0)
INSERT INTO NonGucianStudent(id, firstName, lastName, type, faculty, address, GPA)
VALUES(16, 'yara', 'mohamed', 'Msc', 'Civil', 'Rehab', 3.6)
INSERT INTO NonGucianStudent(id, firstName, lastName, type, faculty, address, GPA)
VALUES(17, 'ali', 'ahmed', 'PhD', 'Mechatronics', 'Ain Shams', 3.2)
INSERT INTO NonGucianStudent(id, firstName, lastName, type, faculty, address, GPA)
VALUES(18, 'salma', 'hani', 'Msc', 'CS', 'Rehab', 3.7)
INSERT INTO NonGucianStudent(id, firstName, lastName, type, faculty, address, GPA)
VALUES(19, 'gina', 'taher', 'Msc', 'CS', 'Madinaty', 3.6)

-- Supervisor
INSERT INTO Supervisor(id, name, faculty)
VALUES(20, 'Mervat', 'MET')
INSERT INTO Supervisor(id, name, faculty)
VALUES(21, 'Slim', 'MET')
INSERT INTO Supervisor(id, name, faculty)
VALUES(22, 'Rami Younes', 'Engineering')
INSERT INTO Supervisor(id, name, faculty)
VALUES(23, 'Yasser Higazi', 'IET')
INSERT INTO Supervisor(id, name, faculty)
VALUES(24, 'Hany Sharkawy', 'Engineering')

-- Examiner
INSERT INTO Examiner(id, name, fieldOfWork, isNational)
VALUES(25, 'Taher', 'Nuclear Energy', '1')
INSERT INTO Examiner(id, name, fieldOfWork, isNational)
VALUES(26, 'Omar Elrasas', 'AI', '1')
INSERT INTO Examiner(id, name, fieldOfWork, isNational)
VALUES(27, 'Antoni', 'Structural Engineer', '0')
INSERT INTO Examiner(id, name, fieldOfWork, isNational)
VALUES(28, 'Philip', 'Machine Learning', '0')

-- .........................................................

-- Courses
INSERT INTO Course(fees, creditHours, code)
VALUES(12500.0, 6, 'CSEN906')
INSERT INTO Course(fees, creditHours, code)
VALUES(17500.0, 8, 'CSEN911')
INSERT INTO Course(fees, creditHours, code)
VALUES(15000, 8, 'CIG1002')
INSERT INTO Course(fees, creditHours, code)
VALUES(10000.0, 4, 'MCTR1002')
INSERT INTO Course(fees, creditHours, code)
VALUES(11000.0, 4, 'NETW1006')

-- .........................................................

-- NonGucianTakeCourse
INSERT INTO NonGucianStudentTakeCourse(sid, cid)
VALUES(9, 4)
INSERT INTO NonGucianStudentTakeCourse(sid, cid, grade)
VALUES(10, 4, 85)
INSERT INTO NonGucianStudentTakeCourse(sid, cid)
VALUES(11, 1)
INSERT INTO NonGucianStudentTakeCourse(sid, cid)
VALUES(11, 2)
INSERT INTO NonGucianStudentTakeCourse(sid, cid)
VALUES(12, 3)
INSERT INTO NonGucianStudentTakeCourse(sid, cid, grade)
VALUES(18, 1, 96)
INSERT INTO NonGucianStudentTakeCourse(sid, cid)
VALUES(18, 2)

-- NonGucianPayCourse
INSERT INTO NonGucianStudentPayForCourse(sid, paymentNo, cid)
VALUES(9, 4, 4)
INSERT INTO NonGucianStudentPayForCourse(sid, paymentNo, cid)
VALUES(10, 5, 4)
INSERT INTO NonGucianStudentPayForCourse(sid, paymentNo, cid)
VALUES(12, 3, 3)
INSERT INTO NonGucianStudentPayForCourse(sid, paymentNo, cid)
VALUES(18, 1, 1)
INSERT INTO NonGucianStudentPayForCourse(sid, paymentNo, cid)
VALUES(18, 2, 2)

-- .........................................................

-- Thesis
INSERT INTO Thesis(field, type, title, startDate, endDate, defenseDate, payment_id, noOfExtensions) -- Mecha Masters
VALUES('Supply Chain', 'Msc', 'Developing a supply chain template', '2020-12-25', '2022-1-10', '2023-5-15', 7, 0)
INSERT INTO GUCianStudentRegisterThesis(sid, supid, serial_no)
VALUES(4, 22, 1)
INSERT INTO Thesis(field, type, title, startDate, endDate, defenseDate, noOfExtensions) -- Mecha Masters
VALUES('Supply Chain', 'PhD', 'Logistics and supply chain management', '2022-3-25', '2023-3-15', '2023-6-15',0)
INSERT INTO GUCianStudentRegisterThesis(sid, supid, serial_no)
VALUES(4, 22, 18)

INSERT INTO Thesis(field, type, title, startDate, endDate, defenseDate, payment_id, noOfExtensions) -- IET Masters
VALUES('Electronics', 'Msc', 'Developing embedded communication system', '2022-6-10', '2023-6-10', '2023-5-20', 8, 0)
INSERT INTO GUCianStudentRegisterThesis(sid, supid, serial_no)
VALUES(6, 23, 2)

INSERT INTO Thesis(field, type, title, startDate, endDate, defenseDate, payment_id, noOfExtensions) -- CS Masters
VALUES('Computer Science', 'Msc', 'The role of risk in IT', '2021-5-25', '2022-5-10', '2022-7-20', 10, 0)
INSERT INTO GUCianStudentRegisterThesis(sid, supid, serial_no)
VALUES(3, 21, 3)
INSERT INTO Thesis(field, type, title, startDate, endDate, defenseDate, noOfExtensions) -- CS Masters
VALUES('Computer Science', 'PhD', 'Information system and networks', '2022-9-10', '2023-12-10', '2023-8-20', 0)
INSERT INTO GUCianStudentRegisterThesis(sid, supid, serial_no)
VALUES(3, 21, 19)


INSERT INTO Thesis(field, type, title, startDate, endDate, payment_id) -- CS Masters
VALUES('Computer Science', 'Msc', 'e-waste using IT strategies', '2022-5-15', '2023-12-15', 12)
INSERT INTO GUCianStudentRegisterThesis(sid, supid, serial_no)
VALUES(7, 21, 4)

INSERT INTO Thesis(field, type, title, startDate, endDate, defenseDate, payment_id) -- Civil Masters 
VALUES('Civil', 'Msc', 'Research on the impact of sustainability concepts', '2022-5-15', '2023-12-15', '2023-7-12', 15)
INSERT INTO NonGUCianStudentRegisterThesis(sid, supid, serial_no)
VALUES(16, 22, 5)

INSERT INTO Thesis(field, type, title, startDate, endDate, defenseDate, payment_id) -- Civil PhD
VALUES('Civil', 'PhD', 'Building Information Modelling in construction', '2022-5-15', '2023-12-15', '2023-7-12', 9)
INSERT INTO NonGUCianStudentRegisterThesis(sid, supid, serial_no)
VALUES(12, 24, 6)

-- No payment thesis
INSERT INTO Thesis(field, type, title, startDate, endDate, defenseDate) -- IET PhD
VALUES('Electronics', 'PhD', 'Radiation in integrated circuits', '2022-6-10', '2023-6-10', '2023-5-20')
INSERT INTO GUCianStudentRegisterThesis(sid, supid, serial_no)
VALUES(8, 23, 7)

INSERT INTO Thesis(field, type, title, startDate, endDate, defenseDate) -- Mecha Masters
VALUES('Supply Chain', 'Msc', 'The effect of globalisation on sc', '2022-12-19', '2023-4-10', '2023-4-15')
INSERT INTO NonGUCianStudentRegisterThesis(sid, supid, serial_no)
VALUES(9, 24, 8)

INSERT INTO Thesis(field, type, title, startDate, endDate, defenseDate) -- Mecha PhD
VALUES('Supply Chain', 'PhD', 'Impact of culture on supply chain', '2022-12-19', '2023-4-10', '2023-2-15')
INSERT INTO NonGUCianStudentRegisterThesis(sid, supid, serial_no)
VALUES(17, 23, 9)

INSERT INTO Thesis(field, type, title, startDate, endDate, defenseDate, grade, noOfExtensions) -- CS Masters
VALUES('Computer Science', 'Msc', 'IT in improving productivity', '2019-5-15', '2020-12-15', '2020-9-12', 75, 3)
INSERT INTO NonGUCianStudentRegisterThesis(sid, supid, serial_no)
VALUES(11, 21, 10)

INSERT INTO Thesis(field, type, title, startDate, endDate, defenseDate, grade) -- CS Masters
VALUES('Computer Science', 'Msc', 'Measurement systems to measure e-waste.', '2019-5-15', '2020-12-15', '2020-9-15', 80)
INSERT INTO NonGUCianStudentRegisterThesis(sid, supid, serial_no)
VALUES(18, 21, 11)

INSERT INTO Thesis(field, type, title, startDate, endDate, defenseDate, grade, noOfExtensions) -- CS PhD
VALUES('Computer Science', 'PhD', 'Research on E-waste in the UK', '2019-2-10', '2020-2-20', '2020-1-11', 85, 2)
INSERT INTO GUCianStudentRegisterThesis(sid, supid, serial_no)
VALUES(5, 21, 12)

INSERT INTO Thesis(field, type, title, startDate, endDate, defenseDate, grade) -- CS PhD
VALUES('Computer Science', 'PhD', 'Research on E-waste in the UK', '2019-3-10', '2020-2-10', '2020-2-11', 82)
INSERT INTO NonGUCianStudentRegisterThesis(sid, supid, serial_no)
VALUES(13, 21, 13)

-- No progress report thesis
INSERT INTO Thesis(field, type, title, startDate, endDate, payment_id, noOfExtensions) -- Mecha Masters
VALUES('Supply Chain', 'Msc', 'Optimisation of supply chain', '2019-12-19', '2021-4-10', 16, 2)
INSERT INTO NonGUCianStudentRegisterThesis(sid, supid, serial_no)
VALUES(10, 24, 14)

-- No defense thesis
INSERT INTO Thesis(field, type, title, startDate, endDate, defenseDate, payment_id) -- CS Masters
VALUES('Computer Science', 'Msc', 'Face Recognition System', '2022-7-15', '2023-12-20', '2023-10-12', 13)
INSERT INTO NonGUCianStudentRegisterThesis(sid, supid, serial_no)
VALUES(19, 21, 15)

-- last progress report 0
INSERT INTO Thesis(field, type, title, startDate, endDate, defenseDate, payment_id) -- CS PhD
VALUES('Computer Science', 'PhD', 'Mobile Educational Application', '2022-2-15', '2023-2-20', '2023-2-12', 11)
INSERT INTO NonGUCianStudentRegisterThesis(sid, supid, serial_no)
VALUES(14, 21, 16)

INSERT INTO Thesis(field, type, title, startDate, endDate, defenseDate, payment_id) -- CS PhD
VALUES('Computer Science', 'PhD', 'Identify and reduce e-waste with IT', '2022-1-10', '2023-2-20', '2022-12-11', 14)
INSERT INTO NonGUCianStudentRegisterThesis(sid, supid, serial_no)
VALUES(15, 20, 17)
-- One publication with no links


-- .........................................................

-- Defenses
INSERT INTO Defense(serialNumber, date, location, grade)
VALUES(10, '2020-9-12', 'New Cairo', 75)

INSERT INTO Defense(serialNumber, date, location)
VALUES(5, '2023-7-12', 'Maadi')

INSERT INTO Defense(serialNumber, date, location)
VALUES(7, '2023-6-10', 'New Cairo')

INSERT INTO Defense(serialNumber, date, location, grade)
VALUES(11, '2020-9-15', 'Sheraton', 85)

INSERT INTO Defense(serialNumber, date, location, grade)
VALUES(13, '2020-2-11', 'Sheraton', 87)

INSERT INTO Defense(serialNumber, date, location)
VALUES(2, '2023-5-20', 'New Cairo')

INSERT INTO Defense(serialNumber, date, location)
VALUES(15, '2023-10-12', 'Maadi')

-- ExaminerEvalDefense
INSERT INTO ExaminerEvaluateDefense(date, serialNo, examinerId)
VALUES('2020-9-12', 10, 26)

INSERT INTO ExaminerEvaluateDefense(date, serialNo, examinerId, comment)
VALUES('2020-9-12', 10, 28, 'The defense is well-written, provide good motivation and introduction, and present clear explanations of background material.')

INSERT INTO ExaminerEvaluateDefense(date, serialNo, examinerId)
VALUES('2023-7-12', 5, 27)

INSERT INTO ExaminerEvaluateDefense(date, serialNo, examinerId)
VALUES('2023-5-20', 2, 25)


-- Gucian Progress Reports
INSERT INTO GUCianProgressReport (sid,no, date, state, description ,thesisSerialNumber, supid) 
VALUES (4,1, '2021-01-10' ,2, 'Supply Chain Management’ is a concept that is widely heard of and implemented to optimize various business activities. ',1,22);

-- Non-GUCian Progress Reports
INSERT INTO NonGUCianProgressReport (sid,no, date, eval, state,description, thesisSerialNumber, supid) 
VALUES (11,1,'2019-08-15', 3,10, 'Information technology has advanced across the years with more and more improvements to be made along the way. From industrial automation to mobile phones and computers.', 10, 21);
INSERT INTO NonGUCianProgressReport (sid,no, date, eval, state, thesisSerialNumber, supid) 
VALUES (13,2, '2019-06-10', 1, 5, 13, 21);
INSERT INTO NonGUCianProgressReport (sid,no, date, eval, state, thesisSerialNumber, supid) 
VALUES (13, 3,'2019-07-10', 0, 2, 13, 21);
-- to be filled in the future
INSERT INTO NonGUCianProgressReport (sid, no,date, thesisSerialNumber, supid) 
VALUES (10, 4,'2022-02-10' ,14,24)

-- Publications
INSERT INTO Publication(title, dateOfPublication, place, accepted, host)
VALUES('Supply Chain for a Business','2021-6-20','United Kingdom','1','International journal of logistics management')
INSERT INTO Publication(title, dateOfPublication, place, accepted, host)
VALUES('Develop a learningOrg, its impact on SC','2021-7-20','United Kingdom','1','International journal of logistics management')
INSERT INTO ThesisHasPublication(serialNo, pubid)
VALUES(1,1)
INSERT INTO ThesisHasPublication(serialNo, pubid)
VALUES(1,2)

INSERT INTO Publication(title, dateOfPublication, place, accepted, host)
VALUES('Current status of E-waste in UK', '2019-9-10','United Kingdom','1','British Journal of CS and Information Technology')
INSERT INTO ThesisHasPublication(serialNo, pubid)
VALUES(12, 3)

-- to be linked with 10
INSERT INTO Publication(title, dateOfPublication, place, accepted, host)
VALUES('Information technology strategies and systems.', '2019-12-15','Egypt','1','Egyptian Computer Science Journal')

-- GucianPhoneNumbers
INSERT INTO GUCStudentPhoneNumber(id, phone)
VALUES(5,'01057323356')
INSERT INTO GUCStudentPhoneNumber(id, phone)
VALUES(6,'01275882197')
INSERT INTO GUCStudentPhoneNumber(id, phone)
VALUES(6,'01275887912')
INSERT INTO GUCStudentPhoneNumber(id, phone)
VALUES(8,'01575222497')

-- NonGucianPhoneNumbers
INSERT INTO NonGUCStudentPhoneNumber(id, phone)
VALUES(10,'01174553562')
INSERT INTO NonGUCStudentPhoneNumber(id, phone)
VALUES(10,'01174556235')
INSERT INTO NonGUCStudentPhoneNumber(id, phone)
VALUES(10,'01155556235')
INSERT INTO NonGUCStudentPhoneNumber(id, phone)
VALUES(13,'01067678995')
INSERT INTO NonGUCStudentPhoneNumber(id, phone)
VALUES(13,'01566724356')

