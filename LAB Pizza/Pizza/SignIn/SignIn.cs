using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignIn
{
    class SignIn
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Content-type: text/html\r\n");
            Console.WriteLine(@"<!DOCTYPE html>
<html lang=""en"">
<head>
	<meta charset=""UTF-8"">
	<title>Sign In</title>
	<link rel=""stylesheet"" href=""/bootstrap/css/bootstrap.css"">
	<link rel=""stylesheet"" href=""/css/signIn.css"">
</head>
<body>
	<div class=""container"">
		<div class=""jumbotron centered"">
			<form class=""form-horizontal "" method=""POST"" align=""center"">
				<div class=""form-group"">
					<div class=""col-sm-4 col-sm-offset-4"">
						<input type=""email"" class=""form-control"" name=""signUpEmail"" placeholder=""Enter your email""/>
					</div>
				</div>
				<div class=""form-group"">
					<div class=""col-sm-4 col-sm-offset-4"">
						<input type=""password"" class=""form-control"" name=""signUpPass"" placeholder=""Enter your password""/>
					</div>
				</div>
				<div class=""checkbox col-sm-4 col-sm-offset-4"">
					<label><input type=""checkbox"" value="""">Remember me</label>
				</div>
				<div class=""form-group"" >
					<div class=""col-sm-offset-5 col-sm-4"">
						<a href=""PizzaMore.exe"" class=""btn btn-danger"">Go back</a>
						<input class=""btn btn-success"" id=""signInBtn"" value=""Sign In"">
					</div>
				</div>
			</form>
		</div>
	</div>
</body>
</html>");
        }
    }
}
