use DoctorClinic;

CREATE TABLE Patients (
    PatientId INT PRIMARY KEY,
    Name VARCHAR(120),
    Age INT,
    DateOfBirth DATE,
    Gender VARCHAR(20),
    Address VARCHAR(300),
    PhoneNumber VARCHAR(20)
);

CREATE TABLE Doctors (
    DoctorID INT PRIMARY KEY,
    Name VARCHAR(120),
    Specialization VARCHAR(80),
    Qualification VARCHAR(80),
    Experience INT,
    Age INT,
    LicenseNumber VARCHAR(80),
    PhoneNumber VARCHAR(20)
);


CREATE TABLE Appointments (
    AppointmentId INT PRIMARY KEY,
    AppointmentDateTime DATETIME,
    Duration TIME,
    Reason VARCHAR(200),
    Status VARCHAR(50),
    Notes VARCHAR(300),
    DoctorId INT,
    PatientId INT,
    FOREIGN KEY (DoctorId) REFERENCES Doctors(DoctorID),
    FOREIGN KEY (PatientId) REFERENCES Patients(PatientId)
);

