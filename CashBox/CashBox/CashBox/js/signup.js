//Submitting form to script
_('#signupBtn').addEventListener('click',function (){
    var hr = ajaxObj('POST','./signup.php');

   var email = _("#email").value;

   var all_data = "&email="+email;
   hr.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
    hr.onreadystatechange = function(){
        if(ajaxReturn(hr) == true){
            //alert(hr.responseText);
            var d = JSON.parse(hr.responseText);
            if(d.f){

                 console.log(d);
                _('#status').innerHTML = '<h4 class="text-center text-danger">'+d.f+'</h4>';
            } else{
                _('#status').innerHTML = '<h4 class="text-center text-success">'+d.s+'</h4>';
       
                _("#email").value = "";
            
            }
        }
    }
    hr.send(all_data);
});

//Verify email address
_('#email').addEventListener('blur',function (){
    var hr = ajaxObj('POST','./signup.php');
   var email = _("#email").value;
   hr.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
    hr.onreadystatechange = function(){
        if(ajaxReturn(hr) == true){
            //alert(hr.responseText);
            var d = JSON.parse(hr.responseText);
            if(d.f){
                _('#email').style.borderColor = 'red';
                _('#email').focus();
                _('#estatus').innerHTML = 'Email exist, choose another.';
            } else{
                _('#email').style.borderColor = '';
                _('#estatus').innerHTML = '';
            }
        }
    }
    hr.send("emailCheck="+email);
});


