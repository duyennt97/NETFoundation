using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BookStoreBusiness;
using BookstoreBusiness.BookstoreBusiness;
using BookStoreCommon;
using BookStoreConsole.Exception;

namespace BookStorePresentation
{
    public partial class BookStoreManagerForm : Form
    {
        private IBookstoreBusiness _bookstoreBusiness;
        private List<BookEntity> _listBook;

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
                var selectedBook = (BookEntity) dataGridView1.SelectedRows[0].DataBoundItem;
                m_nameTextBox.Text = selectedBook.Name;
                m_authorTextBox.Text = selectedBook.Author;
                m_publishYearTextBox.Text = selectedBook.PublishYear.ToString();
            }
        }

        private void OnSaveButtonClicked(object sender, EventArgs e)
        {
            if (m_newButton.Enabled)
            {
                var selectedBook = (BookEntity) dataGridView1.SelectedRows[0].DataBoundItem;
                var updatedBook = new BookEntity()
                {
                    Id = selectedBook.Id,
                    Name = m_nameTextBox.Text,
                    Author = m_authorTextBox.Text,
                    PublishYear = Convert.ToInt32(m_publishYearTextBox.Text),
                    Price = Convert.ToInt32(m_priceTextBox.Text)
                };
                try
                {
                    if (_bookstoreBusiness.UpdateBook(updatedBook))
                    {
                        MessageBox.Show("Book is updated.");
                    }
                }
                catch (BookNotFoundException ex)
                {
                    LogService.Log.Error(ex.Message);
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                var newBook = new BookEntity()
                {
                    Name = m_nameTextBox.Text,
                    Author = m_authorTextBox.Text,
                    PublishYear = Convert.ToInt32(m_publishYearTextBox.Text),
                    Price = Convert.ToInt32(m_priceTextBox.Text)
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
            var selectedBook = (BookEntity) dataGridView1.SelectedRows[0].DataBoundItem;
            try
            {
                if (_bookstoreBusiness.DeleteBook(selectedBook.Id))
                {
                    MessageBox.Show("Book is deleted.");
                }
            }
            catch (BookNotFoundException ex)
            {
                LogService.Log.Error(ex.Message);
                MessageBox.Show(ex.Message);
            }
           
            LoadData();
        }

        private void OnSearchButtonClicked(object sender, EventArgs e)
        {
            int? year = string.IsNullOrWhiteSpace(m_publishYearTextBox.Text)
                ? (int?)null
                : Convert.ToInt32(m_publishYearTextBox.Text);
            _listBook = _bookstoreBusiness.SearchBook(m_nameTextBox.Text, m_authorTextBox.Text, year);
            dataGridView1.DataSource = _listBook;
        }
    }
}
