How to run Application?

	1. Open solution in Visual Studio 2017 or later.

	2. Run SQL Server Database scripts database.sql located on root directory.

	3. check the database connection string in appsettings.json file.

	4. Run API Project.

	5. Open command line and run "npm install" on "Client" folder to install angular project dependencies.

  	6. Check API port in file Student-Information-System/Client/src/app/home/home.component.ts folder.
        it may be different on your pc/laptop when you run.

	7. run "ng serve" on "Client" Folder to run the angular project.

	API's Endpoint:

	List of Students:
	http://localhost:49491/api/student/getall - to get list of students including his files

	Get Student By Id:
	http://localhost:49491/api/student/{studentId}

	Search Student by Name:
	http://localhost:49491/api/student/searchbyname/{studentname}

	Insert Student (POST):
	http://localhost:49491/api/student

	Json Parameter:
	{
    "studentName": "Fahmeen Syed",
    "grade": 6,
    "dateOfBirth": "2007-04-11T00:00:00",
    "address": "Khaitan",
    "files": []
	}

	Update Student (PUT):
	http://localhost:49491/api/student/{studentId}

	Json Parameter:
	{
		 "id": 1,
        "studentName": "Ahmed Fathallah nasser",
        "grade": 2,
        "dateOfBirth": "2010-01-10T00:00:00",
        "address": "Salmiya"
	}

	Delete Student with Files (DELETE):
	http://localhost:49491/api/student/{studentId}

	Upload Files to the Server (POST):
	http://localhost:49491/api/student/uploadFile/{studentId}
	
	Parameters:
	Form-Data
	file = "select file" - check postman screenshot under this project.

	Get File URL from the Server (GET):
	http://localhost:49491/api/student/fileUrl/{fileName}
	it will return the binary form of image.
