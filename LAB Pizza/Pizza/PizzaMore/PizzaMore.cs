using System;

namespace PizzaMore
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Content-type: text/html\r\n");
            Console.WriteLine(@"<!DOCTYPE html>
<html lang=""en"">
<head>
	<meta charset=""UTF-8"">
	<title>PizzaMore</title>
	<meta name=""viewport"" content=""width=device-width, initial-scale=1"">
	<link rel=""stylesheet"" href=""/bootstrap/css/bootstrap.css"">
	<link rel=""stylesheet"" href=""/css/pizaMore.css"">
</head>
<body>
	<div class=""container-fluid"">

		<div id=""myCarousel"" class=""carousel slide"" data-ride=""carousel"">
		  <!-- Indicators -->
		  <ol class=""carousel-indicators"">
		    <li data-target=""#myCarousel"" data-slide-to=""0"" class=""active""></li>
		    <li data-target=""#myCarousel"" data-slide-to=""1""></li>
		  </ol>

		  <!-- Wrapper for slides -->
		  <div class=""carousel-inner"" role=""listbox"">
		    <div class=""item active"">
		      <img src=""/images/pizza_1.jpg"" alt=""pizza"">
		    </div>

		    <div class=""item"">
		      <img src=""/images/pizza_2.jpg"" alt=""pizza"">
		      <div class=""carousel-caption"">
		    	</div>
			 </div>
			</div>
		</div>


		<div  id=""navigation"" class=""navbar navbar-default"">
			<div class=""navbar-header"">
		      <a class=""navbar-brand"" href=""#"">PizzaMore</a>
		    </div>
		    <ul class=""nav navbar-nav"">
		      <li class=""active"">
		      	<a href=""#"">Home</a>
		      </li>
		      <li>
		      	<a href=""#"">Call us</a>
		      </li>
		    </ul>

		    <form method=""POST"">
		    	<input id=""languageBtn"" class=""btn navbar-btn btn-primary"" type=""submit"" value=""BG"" name=""language"" formaction=""PizzaMore.exe"" onclick=""changeLang(this)"">
		    	<a class=""btn navbar-btn btn-success"" href=""signIn.exe"">Sign In</a>
		    	<a class=""btn navbar-btn btn-warning"" href=""signUp.exe"">Sign Up</a>
		    	<a class=""btn navbar-btn btn-info"" href=""menu.exe"">Menu</a>
		    </form>
		</div>
	</div>

	<script type=""text/javascript"">
		function changeLang(element){
			element.value = element.value== ""EN"" ? ""BG"" : ""EN""
		}
	</script>
	<script type=""text/javascript"" src=""/jquery/jquery.js""></script>
	<script type=""text/javascript"" src=""/bootstrap/js/bootstrap.js""></script>
</body>
</html>");
        }
    }
}
