using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseManager
{
    public partial class CourseViewer : Form
    {
        private SchoolEntities schoolContext;

        public CourseViewer()
        {
            InitializeComponent();
        }

        private void closeForm_Click(object sender, EventArgs e)
        {
            schoolContext.Dispose();
            this.Close();
        }

        private void CourseViewer_Load(object sender, EventArgs e)
        {
            schoolContext = new SchoolEntities();

            var departmentQuery = from d in schoolContext.Departments.Include("Courses")
                                  orderby d.Name
                                  select d;

            try
            {
                this.departmentList.DisplayMember = "Name";
                this.departmentList.DataSource = departmentQuery.ToList();
                courseGridView.DataSource = departmentQuery.ToList();

                //this is from the tutorial and does not work
                //this.departmentList.DataSource = ((ObjectQuery)departmentQuery).Execute(MergeOption.AppendOnly);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void courseGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Department department = (Department)this.departmentList.SelectedItem;


                //this is from the tutorial and does not work
                //courseGridView.DataSource = department.Courses;
                courseGridView.DataSource = department.Courses.ToList();

                courseGridView.Columns["Department"].Visible = false;
                courseGridView.Columns["StudentGrades"].Visible = false;
                courseGridView.Columns["OnlineCourse"].Visible = false;
                courseGridView.Columns["OnsiteCourse"].Visible = false;
                courseGridView.Columns["People"].Visible = false;
                courseGridView.Columns["DepartmentId"].Visible = false;

                courseGridView.AllowUserToDeleteRows = false;
                courseGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void saveChanges_Click(object sender, EventArgs e)
        {
            try
            {
                schoolContext.SaveChanges();
                MessageBox.Show("Changes saved to the database.");
                this.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
