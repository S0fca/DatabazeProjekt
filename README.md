# Database project
This console application simulates a doctor's office and uses a Microsoft SQL Server database for data storage. Below are the instructions to set up and run the application.

## Setup Instructions
### 1. Download the project 
1. You should be here: https://github.com/S0fca/DatabazeProjekt
2. Click on the green Code button and **Download ZIP**
3. Extract the zip

### 2. Create database
1. Open **Microsoft SQL Server Management Studio**.
2. Create a new database
3. In the main folder you can find `Database.sql`
4. Run the scrpt in your database

### 3. Setup database connection file
1. Copy `app.config.template` and rename it to `app.config`.
2. Open the `app.config` file and update the **connection string** with your database details:
   - Set your **username** and **password**
   - Set your **server name** (`localhost` or a specific IP address).
   - Set your **database name** (the name you created in step 2).
3. Save the file.

### 4. Run the Application
1. 

