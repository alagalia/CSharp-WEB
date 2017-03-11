namespace ExamApp.ViewModels
{
    public class AdminGameViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Size { get; set; }
        public double Price { get; set; }

        public override string ToString()
        {
            string pattern = $@"<tr>
                        <td>{this.Title}</td>
                        <td>{this.Size:F2} GB</td>
                        <td>{this.Price:F2} &euro;</td>
                        <td>
                            <a href=""/home/edit?Id={Id}"" class=""btn btn-warning btn-sm"">Edit</a>
                            <a href=""/home/delete?Id={Id}"" class=""btn btn-danger btn-sm"">Delete</a>
                        </td>
                    </tr>";
            return pattern;
        }
    }
}