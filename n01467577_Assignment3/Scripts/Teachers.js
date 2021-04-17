function AddTeacher() {

	// send the request 
	//POST : http://localhost:51326/api/TeacherData/AddTeacher
	var URL = "http://localhost:51326/api/TeacherData/AddTeacher/";

	var request = new XMLHttpRequest();
	
	var TeacherFname = document.getElementById('TeacherFname').value;
	var TeacherLname = document.getElementById('TeacherLname').value;
	var EmployeeNumber = document.getElementById('EmployeeNumber').value;
	var HireDate = document.getElementById('HireDate').value;
	var Salary = document.getElementById('Salary').value;
	var TeacherData = {
		"TeacherFname": TeacherFname,
		"TeacherLname": TeacherLname,
		"EmployeeNumber": EmployeeNumber,
		"HireDate": HireDate,
		"Salary": Salary
	};
	request.open("POST", URL, true);
	request.setRequestHeader("Content-Type", "application/json");
	request.onreadystatechange = function () {
		if (request.readyState == 4 && request.status == 200) {
			
		}

	}
	request.send(JSON.stringify(TeacherData));

}
