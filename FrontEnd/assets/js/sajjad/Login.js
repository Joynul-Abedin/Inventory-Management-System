$(document).ready(function(){

$("#loginbtn").click(function(){


      GetUser();
});

     function GetUser()
	 {
		 $.ajax({
			url:"http://localhost:11917/api/users/username",
			method:"get",
			headers:{
				      Authorization:"Basic "+btoa($("#uname").val()+ ":" + $("#pass").val()),
					  userName:$("#uname").val()

			        },

			   complete:function(xmlHttp,status){
				if(xmlHttp.status==200)
				{


					var data=xmlHttp.responseJSON;
					if(data.permission=="Invalid")
					{
						$("#uname").val("");
						$("#pass").val("");
					 alert("You are blocked! Please contact with sajjadur3434@gmail.com");
					}
					else
					{
						sessionStorage.setItem("userName",data.userName);
						sessionStorage.setItem("userType",data.type);
						sessionStorage.setItem("password",data.password);

						// window.location.href = '/index.html';
						location.href = 'index.html';
					}

				}

				else
				{
					console.log(status);

					alert("Failed");
				}
			},
			error:function(xmlHttp,status)
			{
				if(xmlHttp.status==401)
				{
					$("#uname").val("");
						$("#pass").val("");
					alert("Invalid Credentials");

				}

			}

		});

	 }

});
