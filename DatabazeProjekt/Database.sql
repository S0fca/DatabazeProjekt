CREATE TABLE patients (
     id_pat INTEGER identity(1,1) primary key, 
     name VARCHAR(50) NOT NULL CHECK (name NOT LIKE '%[^a-zA-Z·-û¡-é ]%'), 
     surname VARCHAR(50) NOT NULL CHECK (surname NOT LIKE '%[^a-zA-Z·-û¡-é ]%'), 
     birth_dat DATE NOT NULL CHECK (birth_dat <= GETDATE()), 
     birth_num VARCHAR(11) NOT NULL CHECK (birth_num LIKE '[0-9][0-9][0-9][0-9][0-9][0-9]/[0-9][0-9][0-9][0-9]'), 
     contact VARCHAR(100),
	 height DECIMAL(3,2), 
     weight DECIMAL(3,2) 
    );

CREATE TABLE doctors (
     id_doc INTEGER identity(1,1) primary key, 
     name VARCHAR(50) NOT NULL CHECK (name NOT LIKE '%[^a-zA-Z·-û¡-é ]%'), 
     surname VARCHAR(50) NOT NULL CHECK (surname NOT LIKE '%[^a-zA-Z·-û¡-é ]%'), 
     specialization VARCHAR(100) NOT NULL 
    );

CREATE TABLE visits (
     id_vis INTEGER identity(1,1) primary key, 
     patients_id_pat INTEGER NOT NULL, 
     doctors_id_doc INTEGER NOT NULL, 
	 vis_reason VARCHAR(255) NOT NULL,     
	 vis_dat DATETIME NOT NULL,
	 vis_price DECIMAL(10,2), 
     FOREIGN KEY (patients_id_pat) REFERENCES patients(id_pat) ON DELETE NO ACTION, 
     FOREIGN KEY (doctors_id_doc) REFERENCES doctors(id_doc) ON DELETE NO ACTION
    );

CREATE TABLE reports (
     id_rep INTEGER identity(1,1) primary key, 
     visits_id_vis INTEGER NOT NULL, 
     symptoms VARCHAR(500),  
     diagnosis VARCHAR(500),  
     recommendation VARCHAR(500),  
     treatment VARCHAR(500),  
     conclusion VARCHAR(500),
     rep_dat DATETIME NOT NULL,
     FOREIGN KEY (visits_id_vis) REFERENCES visits(id_vis) ON DELETE NO ACTION
	 );

CREATE TABLE labTests (
     id_tes INTEGER identity(1,1) primary key, 
     patients_id_pat INTEGER NOT NULL, 
     name VARCHAR(255) NOT NULL, 
	 tes_ok BIT NOT NULL DEFAULT 1, 
     result VARCHAR(500), 
     tes_dat DATE NOT NULL,
     notes VARCHAR(500), 
	 FOREIGN KEY (patients_id_pat) REFERENCES patients(id_pat) ON DELETE CASCADE, 
	 );