# Database project
This console application simulates a doctor's office and uses a Microsoft SQL Server database for data storage. Below are the instructions to set up and run the application.

## Setup Instructions
### 1. Download the project 
1. You should be here: https://github.com/S0fca/DatabazeProjekt
2. Click on **Releases** and from **Assets** download
   - `DatabaseProject.zip`
   - `Database.sql`
3. Extract the zip

### 2. Create database
1. Open **Microsoft SQL Server Management Studio**.
2. Create a new database
3. Open database script `Database.sql`
4. **Run the script** in your database

### 3. Setup database connection file
1. Go to `DatabaseProject/Release/net8.0`
2. Here you can find `DatabazeProjekt.dll.config`
3. Open the **DatabazeProjekt.dll.config** and update the **connection information** with yours:
   - Set your **username** and **password**
   - Set your **server name** (localhost or a specific IP address).
   - Set your **database name** (the name you created in step 2).
3. Save the file.

### 4. Run the Application
1. In **DatabaseProject/Release/net8.0** you can find `DatabazeProjekt.exe`
2. **Run** DatabazeProjekt.exe
