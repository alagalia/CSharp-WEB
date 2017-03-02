namespace PizzaForumApp.ViewModels
{
    public class CategorySectionViewModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public override string ToString()
        {
            string htmlContent = $@"<tr>
                                    <td><a href=""/categories/topics?CategoryName={CategoryName}"">{CategoryName}</a></td>
                                    <td><a href=""/categories/edit?id={CategoryId}"" class=""btn btn-primary""/>Edit</a></td>
				                    <td><a href=""#"" class=""btn btn-danger""/>Delete</a></td>
			                    </tr>";
            return htmlContent;
        }
    }
}