using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JoinQueries
{
    public partial class JoiningTableData : Form
    {
        public JoiningTableData()
        {
            InitializeComponent();
        }

        private void JoiningTableData_Load(object sender, EventArgs e)
        {
            BooksExamples.BooksEntities dbcontext = new BooksExamples.BooksEntities();

            var authorAndISBNs =
                from author in dbcontext.Authors
                from book in author.Titles
                orderby author.LastName, author.FirstName
                select new {author.FirstName, author.LastName, book.ISBN};

            outputTextBox.AppendText("Authors and ISBNs");

            foreach (var record in authorAndISBNs)
            {
                outputTextBox.AppendText(
                    String.Format("\r\n\t{0,-10} {1,-10} {2,-10}", record.FirstName, record.LastName,record.ISBN));
            }

            var authorsAndTitles =
                from book in dbcontext.Titles
                from author in dbcontext.Authors
                orderby author.LastName, author.FirstName, book.Title1
                select new {author.FirstName, author.LastName, book.Title1};

            outputTextBox.AppendText("\r\n\r\nAuthors and titles:");

            foreach (var record in authorsAndTitles)
            {
                outputTextBox.AppendText(
                     String.Format("\r\n\t{0,-10} {1,-10} {2,-10}", record.FirstName, record.LastName,record.Title1));
                    
            }

        }
    }
}
