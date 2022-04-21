function validateForm() {
    var un = document.loginform.usr.value;
    var pw = document.loginform.pword.value;
    var username = "loger_exam"; 
    var password = "pass_exam";
    if ((un == username) && (pw == password)) {
        return true;
    }
    else {
        alert ("Login or password was unsuccessful, please contact admin");
        return false;
    }
}