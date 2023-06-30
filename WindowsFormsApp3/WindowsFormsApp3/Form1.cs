using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Soho_Hotel
{
    public partial class Form1 : Form
    {
        OrderManagement order;
        Rooms[] room;
        const int maxRoom = 1;
        private int selectedDaysCounter = 0;
        private Timer timer;
        private int currentPhotoIndex1 = 0;
        private int currentPhotoIndex2 = 0;
        private int currentPhotoIndex3 = 0;
        public Form1()
        {
            InitializeComponent();
            room = new Rooms[maxRoom];
            monthCalendar1.MaxSelectionCount = 30;

            InitializeTimer();

            DateTime currentDate = DateTime.Today;
            DateTime maxDate = currentDate.AddMonths(6);

            // Set the MinDate and MaxDate properties of monthCalendar1
            monthCalendar1.MinDate = currentDate;
            monthCalendar1.MaxDate = maxDate;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void InitializeTimer()
        {
            timer = new Timer();
            timer.Interval = 3000; // Change photo every 3 seconds
            timer.Enabled = true;
            timer.Tick += timer1_Tick;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdatePictureBoxImage(pbxStandard, imageList1, ref currentPhotoIndex1);
            UpdatePictureBoxImage(PbxSuite, imageList3, ref currentPhotoIndex2);
            UpdatePictureBoxImage(pbxDeluxe, imageList2, ref currentPhotoIndex3);
        }
        private void UpdatePictureBoxImage(PictureBox pictureBox, ImageList imageList, ref int currentIndex)
        {
            pictureBox.Image = imageList.Images[currentIndex];
            if (currentIndex == imageList.Images.Count - 1)
            {
                currentIndex = 0;
            }
            else
            {
                currentIndex++;
            }
        }
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

            lblTYpe.Text = monthCalendar1.SelectionRange.Start.ToShortDateString() + " - " +
                  monthCalendar1.SelectionRange.End.ToShortDateString();
            lblDates2.Text = monthCalendar1.SelectionRange.Start.ToShortDateString() + " - " +
                  monthCalendar1.SelectionRange.End.ToShortDateString();

            selectedDaysCounter = (int)(e.End - e.Start).TotalDays + 1;
        }
        private void cmbRoomOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRoomOptions.SelectedIndex == 0)
            {
                grpSuiteRoom.Visible = false;
                grpDeluxRoom.Visible = false;
                grpStandardRoom.Visible = true;
                room[0] = new StandardRoom();
                txtStandardRoom.Text = room[0].ToString();
            }

            if (cmbRoomOptions.SelectedIndex == 1)
            {
                grpSuiteRoom.Visible = false;
                grpStandardRoom.Visible = false;
                grpDeluxRoom.Visible = true;
                room[0] = new DeluxeRoom();
                txtDeluxeRoom.Text = room[0].ToString();
            }
            if (cmbRoomOptions.SelectedIndex == 2)
            {
                grpDeluxRoom.Visible = false;
                grpStandardRoom.Visible = false;
                grpSuiteRoom.Visible = true;
                room[0] = new SuiteRoom();
                txtSuiteRoom.Text = room[0].ToString();
            }
        }
        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            if (selectedDaysCounter == 0)
            {
                // The dates were not picked
                MessageBox.Show("Please select the check-in and check-out dates.");
                return; // Add a return statement to exit the method
            }
            if (cmbRoomOptions.SelectedIndex == -1) MessageBox.Show("Please select type of room");
            else
            {
                txtBookingDetails.Text = cmbRoomOptions.SelectedItem.ToString();
                grpBookinDetials.Visible = true;
                grpMain.Visible = false;
            }
            grpSuiteRoom.Visible = false;
            grpDeluxRoom.Visible = false;
            grpStandardRoom.Visible = false;
            
        }
        private void btnBook_Click(object sender, EventArgs e)
        {
            order = new OrderManagement(txtName.Text, txtPhone.Text);
            if (order.GetFullName()==null||order.GetPhoneNum()==null)
            {
                MessageBox.Show("Error! Please enter name/phone number(between 9-10 digits)");
                return;
            }
            else
            {
               
                txtCheckOut.Text = order.bookingDetails();
                txtTotalCost.Text = order.CalculateTotalCost(selectedDaysCounter, room[0]).ToString();
                btnCheckOutDone.Enabled = true;
            }
        }

        private void btnRemoveRoom_Click(object sender, EventArgs e)
        {
            txtBookingDetails.Clear();
            txtCheckOut.Clear();
            txtName.Clear();
            txtPhone.Clear();
            txtTotalCost.Clear();
            grpBookinDetials.Visible = false;
            grpMain.Visible = true;

        }
        private void btnCheckOutDone_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"thank you {order.GetFullName()} for staying with us! \nbooking approval will be sent to your mail soon.");
            txtBookingDetails.Clear();
            txtCheckOut.Clear();
            txtName.Clear();
            txtPhone.Clear();
            txtTotalCost.Clear();
            grpBookinDetials.Visible = false;
            grpMain.Visible = true;
            btnCheckOutDone.Enabled = false;
            this.Close();
        }

        private void cmbRoomOptions_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Press me to open room options", cmbRoomOptions);
        }

        private void monthCalendar1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Choose Check In and Check Out Dates here", monthCalendar1);
        }
    }
}