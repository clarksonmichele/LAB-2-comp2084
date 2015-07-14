using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//add a reference so we can use EF for the database
using comp2084_lab2.Models;

namespace comp2084_lab2
{
    public partial class students : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //call the GetStudents function to populate the grid
            if (!IsPostBack)
            {
                GetStudents();
            }
        }

        protected void GetStudents()
        { 
            //use EF to connect and get the list of students
            using (DefaultConnection db = new DefaultConnection())
            {
                var studs = from s in db.Students
                           select s;

                //bind the studs query result to our grid
                grdStudents.DataSource = studs.ToList();
                grdStudents.DataBind();
            }
        }
    
        protected void grdStudents_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //set the NewPageIndex and repopulate the grid
            grdStudents.PageIndex = e.NewPageIndex;
            GetStudents();
        }
        
        protected void grdStudents_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //identify the student id to be deleted from the row the user selected
            Int32 StudentID = Convert.ToInt32(grdStudents.DataKeys[e.RowIndex].Values["StudentID"]);
            
            //connect
            using (DefaultConnection db = new DefaultConnection())

            {
                Student stud = (from s in db.Students
                                where s.StudentID == StudentID
                                select s).FirstOrDefault();
                //delete
                db.Students.Remove(stud);
                db.SaveChanges();

                //refresh the grid
                GetStudents();
            }
        }
      }
   }
