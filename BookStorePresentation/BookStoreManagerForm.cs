using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BookstoreBusiness.BookstoreBusiness;
using BookStoreConsole.Data;
using Ninject;

namespace BookStorePresentation
{
    public partial class BookStoreManagerForm : Form
    {
        private IBookstoreBusiness _bookstoreBusiness;
        private List<Book> _listBook;
        private StandardKernel kernel = new StandardKernel();

        public BookStoreManagerForm(IBookstoreBusiness bookstoreBusiness)
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            _bookstoreBusiness = bookstoreBusiness;
            LoadData();
            m_formatLabel.Text = _bookstoreBusiness.GetCurrentFormat();
        }

        private void LoadData()
        {
            _listBook = _bookstoreBusiness.GetAllBooks();
            dataGridView1.DataSource = _listBook;
        }

        private void OnNewButtonClicked(object sender, EventArgs e)
        {
            m_nameTextBox.Text = string.Empty;
            m_authorTextBox.Text = string.Empty;
            m_publishYearTextBox.Text = string.Empty;
            dataGridView1.ClearSelection();
            m_newButton.Enabled = false;
            dataGridView1.Enabled = false;
            m_deleteButton.Enabled = false;
        }

        private void OnPublishYearKeyPressed(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void OnSelectedRowChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedBook = (Book) dataGridView1.SelectedRows[0].DataBoundItem;
                m_nameTextBox.Text = selectedBook.Name;
                m_authorTextBox.Text = selectedBook.Author;
                m_publishYearTextBox.Text = selectedBook.PublishYear.ToString();
            }
        }

        private void OnSaveButtonClicked(object sender, EventArgs e)
        {
            if (m_newButton.Enabled)
            {
                var selectedBook = (Book) dataGridView1.SelectedRows[0].DataBoundItem;
                var updatedBook = new Book()
                {
                    Id = selectedBook.Id,
                    Name = m_nameTextBox.Text,
                    Author = m_authorTextBox.Text,
                    PublishYear = Convert.ToInt32(m_publishYearTextBox.Text)
                };
                if (_bookstoreBusiness.UpdateBook(updatedBook))
                {
                    MessageBox.Show("Book is updated.");
                }
            }
            else
            {
                var newBook = new Book()
                {
                    Name = m_nameTextBox.Text,
                    Author = m_authorTextBox.Text,
                    PublishYear = Convert.ToInt32(m_publishYearTextBox.Text)
                };
                if (_bookstoreBusiness.InsertBook(newBook))
                {
                    MessageBox.Show("Book is inserted.");
                    
                    m_newButton.Enabled = true;
                    dataGridView1.Enabled = true;
                    m_deleteButton.Enabled = true;
                }
            }
            LoadData();
        }

        private void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var selectedBook = (Book) dataGridView1.SelectedRows[0].DataBoundItem;
            if (_bookstoreBusiness.DeleteBook(selectedBook.Id))
            {
                MessageBox.Show("Book is deleted.");
            }
            LoadData();
        }

        private void OnSearchButtonClicked(object sender, EventArgs e)
        {
            var filterList = _listBook
                .Where(s => (s.Name == m_nameTextBox.Text || string.IsNullOrEmpty(m_nameTextBox.Text))
                            && (s.Author == m_authorTextBox.Text || string.IsNullOrEmpty(m_authorTextBox.Text))
                            && (s.PublishYear.ToString() == m_publishYearTextBox.Text || string.IsNullOrEmpty(m_publishYearTextBox.Text)))
                            .ToList();
            _listBook = filterList;
            dataGridView1.DataSource = _listBook;
        }
    }
}
