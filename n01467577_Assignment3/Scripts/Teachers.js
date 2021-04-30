function validateData() {
	var formHandle = document.forms.form_Teacher;
	var TeacherFname = formHandle.TeacherFname;
	var TeacherLname = formHandle.TeacherLname;
	var EmployeeNumber = formHandle.EmployeeNumber;
	var HireDate = formHandle.HireDate;
	var Salary = formHandle.Salary;

	//Validation
	if (TeacherFname.value === "") {
		TeacherFname.style.background = "red";
		TeacherFname.focus();
		return false;
	}
	if (TeacherLname.value === "") {
		TeacherLname.style.background = "red";
		TeacherLname.focus();
		return false;
	}
	if (EmployeeNumber.value === "") {
		EmployeeNumber.style.background = "red";
		EmployeeNumber.focus();
		return false;
	}
	if (HireDate.value === "") {
		HireDate.style.background = "red";
		HireDate.focus();
		return false;
	}
	if (Salary.value === "") {
		Salary.style.background = "red";
		Salary.focus();
		return false;
	}
}

function UpdateTeacher(TeacherId) {

	var IsValid = ValidateData();
	if (!IsValid) return;

	var URL = "http://localhost:62050/api/AuthorData/UpdateAuthor/" + TeacherId;

	var rq = new XMLHttpRequest();
	// where is this request sent to?
	// is the method GET or POST?
	// what should we do with the response?

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


	rq.open("POST", URL, true);
	rq.setRequestHeader("Content-Type", "application/json");
	rq.onreadystatechange = function () {
		//ready state should be 4 AND status should be 200
		if (rq.readyState == 4 && rq.status == 200) {
			//request is successful and the request is finished

			//nothing to render, the method returns nothing.


		}

	}
	//POST information sent through the .send() method
	rq.send(JSON.stringify(TeacherData));

}
function AddTeacher() {

	var IsValid = ValidateData();
	if (!IsValid) return;
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
