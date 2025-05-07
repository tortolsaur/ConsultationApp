using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;
using Syncfusion.Windows.Forms.Tools.Navigation;
using Syncfusion.WinForms.Controls;
// Add the correct ListView reference

namespace UniversityConsultationSystem
{
    public partial class ConsultationManagementForm : SfForm
    {
        // Define the consultation model
        public class ConsultationModel
        {
            public string ClientName { get; set; }
            public string ClientType { get; set; } = "Student";
            public string CourseCode { get; set; }
            public string SectionCode { get; set; }
            public string Time { get; set; }
            public string Date { get; set; }
            public string ConsultationType { get; set; }
            public string Location { get; set; }
            public string RequestedBy { get; set; }
            public string ScheduledBy { get; set; }
            public string Duration { get; set; }
            public string CancelledBy { get; set; }
            public string Status { get; set; }
            public string Notes { get; set; }
        }

        // List to store consultation data
        private List<ConsultationModel> consultations;

        // UI Components
        private SfSkinManager skinManager;
        private GradientPanel sidebarPanel;
        private TabControlAdv tabControl;
        private ButtonAdv scheduleConsultationButton;
        private SfListView consultationListView;
        private TextBoxExt searchTextBox;
        private ButtonAdv notificationButton;

        public ConsultationManagementForm()
        {
            InitializeComponent();
            InitializeData();
            SetupUI();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ConsultationManagementForm
            // 
            this.ClientSize = new Size(1200, 800);
            this.Name = "ConsultationManagementForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "University of Mindanao - Consultations";
            this.ResumeLayout(false);
        }

        private void InitializeData()
        {
            // Initialize consultation data
            consultations = new List<ConsultationModel>
            {
                new ConsultationModel
                {
                    ClientName = "Stephen Neil Garde",
                    CourseCode = "CPE 325",
                    SectionCode = "7605",
                    Time = "10:30 AM",
                    Date = "May 05, 2025",
                    ConsultationType = "Math Assistance",
                    RequestedBy = "Student",
                    Location = "BE 216",
                    Status = "Pending",
                    Notes = "Need man ganig lambing ang strong and fierceful knight, ako pa ba nga normal citizen ra sa dakbayan sa Davao (#)"
                },
                new ConsultationModel
                {
                    ClientName = "John Rabusa",
                    ClientType = "Client",
                    CourseCode = "CPE 316",
                    SectionCode = "7610",
                    Time = "2:35 PM",
                    Date = "May 05, 2025",
                    ConsultationType = "English Essay Review",
                    Location = "Library",
                    ScheduledBy = "Engr. Jay Chris Verdad",
                    Status = "Approved",
                    Notes = "Need man ganig lambing ang strong and fierceful knight, ako pa ba nga normal citizen ra sa dakbayan sa Davao (#)"
                },
                new ConsultationModel
                {
                    ClientName = "Miles Darren Bagnol",
                    CourseCode = "CPE 224",
                    SectionCode = "7587",
                    Time = "3:45 PM",
                    Date = "May 04, 2025",
                    ConsultationType = "Art Portfolio Review",
                    Location = "BE 214",
                    Duration = "30 minutes",
                    Status = "Completed",
                    Notes = "Need man ganig lambing ang strong and fierceful knight, ako pa ba nga normal citizen ra sa dakbayan sa Davao (#)"
                },
                new ConsultationModel
                {
                    ClientName = "Kervin Toji Baneciro",
                    CourseCode = "CPE 112",
                    SectionCode = "7453",
                    Time = "1:00 PM",
                    Date = "May 0, 2025",
                    ConsultationType = "Science Project Review",
                    Location = "BE 110",
                    CancelledBy = "Student",
                    Status = "Cancelled",
                    Notes = "Need man ganig lambing ang strong and fierceful knight, ako pa ba nga normal citizen ra sa dakbayan sa Davao (#)"
                }
            };
        }

        private void SetupUI()
        {
            // Set up skin manager for modern UI
            skinManager = new SfSkinManager();
            skinManager.SetVisualStyle(
                this,
                VisualStyles.Office2019Colorful);

            // Create the main layout
            TableLayoutPanel mainLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1,
                BackColor = Color.FromArgb(245, 241, 245)
            };
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 220));
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            this.Controls.Add(mainLayout);

            // Create sidebar
            CreateSidebar(mainLayout);

            // Create content panel
            Panel contentPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(20),
                BackColor = Color.FromArgb(245, 241, 245)
            };
            mainLayout.Controls.Add(contentPanel, 1, 0);

            // Create top bar with title and search
            TableLayoutPanel topBar = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 60,
                ColumnCount = 2,
                RowCount = 1,
            };
            topBar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            topBar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            contentPanel.Controls.Add(topBar);

            // Page title
            Label pageTitle = new Label
            {
                Text = "Consultations",
                Font = new Font("Segoe UI", 18, FontStyle.Regular),
                ForeColor = Color.FromArgb(51, 51, 51),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            };
            topBar.Controls.Add(pageTitle, 0, 0);

            // Search and notification
            Panel toolbarPanel = new Panel
            {
                Dock = DockStyle.Fill
            };
            topBar.Controls.Add(toolbarPanel, 1, 0);

            // Search box
            searchTextBox = new TextBoxExt
            {
                Dock = DockStyle.None,
                Width = 250,
                Height = 35,
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font("Segoe UI", 9),
                Watermark = "Search",
                WatermarkColor = Color.Gray,
                Location = new Point(toolbarPanel.Width - 300, 12)
            };
            toolbarPanel.Controls.Add(searchTextBox);

            // Notification button
            notificationButton = new ButtonAdv
            {
                Size = new Size(40, 40),
                BackColor = Color.White,
                ForeColor = Color.FromArgb(51, 51, 51),
                Location = new Point(toolbarPanel.Width - 40, 10),
                Image = Properties.Resources.notification_icon,
                ImageAlign = ContentAlignment.MiddleCenter
            };
            toolbarPanel.Controls.Add(notificationButton);

            // Create tab control
            tabControl = new TabControlAdv
            {
                Dock = DockStyle.Top,
                Location = new Point(0, 60),
                Height = 40,
                BackColor = Color.Transparent,
                ForeColor = Color.FromArgb(51, 51, 51),
                Font = new Font("Segoe UI", 10),
                ActiveTabColor = Color.White,
                ActiveTabForeColor = Color.FromArgb(228, 42, 48),
                TabStyle = typeof(TabRendererOffice2016Colorful)
            };

            // Add tabs
            TabPageAdv consultationsTab = new TabPageAdv
            {
                Text = "Consultations",
                BackColor = Color.Transparent
            };
            tabControl.Controls.Add(consultationsTab);

            TabPageAdv archiveTab = new TabPageAdv
            {
                Text = "Archive",
                BackColor = Color.Transparent
            };
            tabControl.Controls.Add(archiveTab);

            contentPanel.Controls.Add(tabControl);

            // Create consultation list view
            Panel listContainer = new Panel
            {
                Dock = DockStyle.Fill,
                Location = new Point(0, 100),
                Padding = new Padding(0, 20, 0, 0)
            };
            contentPanel.Controls.Add(listContainer);

            consultationListView = new SfListView
            {
                Dock = DockStyle.Fill,
                ItemHeight = 150,
                BackColor = Color.FromArgb(245, 241, 245),
                Style.ItemStyle.BackColor = Color.White,
                DataSource = consultations,
                View = ViewType.Linear,
                ShowItemToolTip = false,
                AllowSwipeToDelete = false,
                BorderStyle = BorderStyle.None,
                ItemSpace = 15
            };

            // Custom drawing for consultation cards
            consultationListView.DrawItem += ConsultationListView_DrawItem;
            listContainer.Controls.Add(consultationListView);

            // Create floating action button
            scheduleConsultationButton = new ButtonAdv
            {
                Text = "Schedule Consultation",
                Size = new Size(200, 40),
                BackColor = Color.FromArgb(228, 42, 48),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                Location = new Point(contentPanel.Width - 220, contentPanel.Height - 60)
            };
            contentPanel.Controls.Add(scheduleConsultationButton);
            scheduleConsultationButton.BringToFront();

            // Resize event to reposition floating button
            this.Resize += (sender, e) =>
            {
                scheduleConsultationButton.Location = new Point(contentPanel.Width - 220, contentPanel.Height - 60);
            };
        }

        private void CreateSidebar(TableLayoutPanel mainLayout)
        {
            // Create gradient sidebar panel
            sidebarPanel = new GradientPanel { Dock = DockStyle.Fill, GradientColors = new Color[] { Color.FromArgb(228, 42, 48), Color.FromArgb(243, 112, 53) }, GradientDirection = Syncfusion.Drawing.GradientDirection.Vertical, Padding = new Padding(10), ForeColor = Color.White };
            mainLayout.Controls.Add(sidebarPanel, 0, 0);

            // Logo and university name
            PictureBox logo = new PictureBox
            {
                Image = Properties.Resources.um_logo,
                SizeMode = PictureBoxSizeMode.Zoom,
                Size = new Size(60, 60),
                Location = new Point((sidebarPanel.Width - 60) / 2, 20)
            };
            sidebarPanel.Controls.Add(logo);

            Label universityName = new Label
            {
                Text = "The University of Mindanao",
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Size = new Size(200, 20),
                Location = new Point(10, 85)
            };
            sidebarPanel.Controls.Add(universityName);

            // Separator line
            Panel separator1 = new Panel
            {
                Height = 1,
                BackColor = Color.FromArgb(255, 255, 255, 50),
                Dock = DockStyle.None,
                Width = sidebarPanel.Width - 20,
                Location = new Point(10, 115)
            };
            sidebarPanel.Controls.Add(separator1);

            // Navigation sections
            CreateNavigationSection(sidebarPanel, "Main", 130, new string[] { "Dashboard", "Bulletins", "Consultations" }, 2);
            CreateNavigationSection(sidebarPanel, "Management", 260, new string[] { "Students", "Faculty", "Reports" }, -1);
            CreateNavigationSection(sidebarPanel, "Settings", 390, new string[] { "Preferences", "Security" }, -1);

            // User profile at bottom
            Panel profilePanel = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 60,
                Padding = new Padding(10)
            };
            sidebarPanel.Controls.Add(profilePanel);

            Panel separator2 = new Panel
            {
                Height = 1,
                BackColor = Color.FromArgb(255, 255, 255, 50),
                Dock = DockStyle.Top,
                Width = profilePanel.Width - 20,
                Location = new Point(10, 0)
            };
            profilePanel.Controls.Add(separator2);

            Panel initialCircle = new Panel
            {
                Size = new Size(36, 36),
                Location = new Point(10, 12),
                BackColor = Color.White
            };
            initialCircle.Paint += (sender, e) =>
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                e.Graphics.FillEllipse(new SolidBrush(Color.White), 0, 0, initialCircle.Width - 1, initialCircle.Height - 1);
                e.Graphics.DrawString("A", new Font("Segoe UI", 14, FontStyle.Bold), new SolidBrush(Color.FromArgb(228, 42, 48)), 10, 5);
            };
            profilePanel.Controls.Add(initialCircle);

            Label profileName = new Label
            {
                Text = "Anthony Mapagmahal",
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                ForeColor = Color.White,
                Location = new Point(55, 12),
                Size = new Size(150, 15)
            };
            profilePanel.Controls.Add(profileName);

            Label profileRole = new Label
            {
                Text = "Faculty",
                Font = new Font("Segoe UI", 8, FontStyle.Regular),
                ForeColor = Color.FromArgb(255, 255, 255, 200),
                Location = new Point(55, 30),
                Size = new Size(150, 15)
            };
            profilePanel.Controls.Add(profileRole);
        }

        private void CreateNavigationSection(Panel container, string title, int startY, string[] items, int activeIndex)
        {
            Label sectionTitle = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                ForeColor = Color.FromArgb(255, 255, 255, 200),
                Location = new Point(15, startY),
                Size = new Size(200, 20)
            };
            container.Controls.Add(sectionTitle);

            int itemY = startY + 30;
            for (int i = 0; i < items.Length; i++)
            {
                Panel navItem = new Panel
                {
                    Size = new Size(200, 40),
                    Location = new Point(10, itemY),
                    BackColor = i == activeIndex ? Color.FromArgb(255, 255, 255, 40) : Color.Transparent
                };
                navItem.Paint += (sender, e) =>
                {
                    using (SolidBrush brush = new SolidBrush(Color.Transparent))
                    {
                        e.Graphics.FillRoundedRectangle(brush, 0, 0, navItem.Width, navItem.Height, 8);
                    }
                };
                container.Controls.Add(navItem);

                Label itemText = new Label
                {
                    Text = items[i],
                    Font = new Font("Segoe UI", 9, i == activeIndex ? FontStyle.Bold : FontStyle.Regular),
                    ForeColor = Color.White,
                    Location = new Point(35, 10),
                    Size = new Size(150, 20)
                };
                navItem.Controls.Add(itemText);

                itemY += 45;
            }
        }

        private void ConsultationListView_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.ItemData is ConsultationModel consultation)
            {
                // Create the card layout
                Rectangle cardBounds = new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height - 10);

                // Draw the white background
                e.Graphics.FillRoundedRectangle(new SolidBrush(Color.White), cardBounds, 10);

                // Draw time section
                Rectangle timeSection = new Rectangle(cardBounds.X, cardBounds.Y, 120, cardBounds.Height);
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(240, 240, 240)), timeSection);

                // Draw time section content
                string timeIndicator = consultation.Date == DateTime.Now.ToString("MMM dd, yyyy") ? "Today" :
                                    consultation.Date == DateTime.Now.AddDays(-1).ToString("MMM dd, yyyy") ? "Yesterday" : "";

                // Draw time indicator
                if (!string.IsNullOrEmpty(timeIndicator))
                {
                    e.Graphics.DrawString(timeIndicator, new Font("Segoe UI", 8), new SolidBrush(Color.FromArgb(0, 120, 215)),
                                        timeSection.X + 40, timeSection.Y + 20);
                }

                // Draw time
                e.Graphics.DrawString(consultation.Time, new Font("Segoe UI", 14, FontStyle.Bold),
                                    new SolidBrush(Color.FromArgb(51, 51, 51)), timeSection.X + 30, timeSection.Y + 45);

                // Draw date
                e.Graphics.DrawString(consultation.Date, new Font("Segoe UI", 8),
                                    new SolidBrush(Color.FromArgb(102, 102, 102)), timeSection.X + 30, timeSection.Y + 75);

                // Draw client info
                Rectangle detailsSection = new Rectangle(timeSection.Right + 10, cardBounds.Y + 15,
                                                        cardBounds.Width - timeSection.Width - 150, cardBounds.Height - 30);

                // Draw client name
                string clientName = consultation.ClientType == "Client" ? "Client " + consultation.ClientName : consultation.ClientName;
                e.Graphics.DrawString(clientName, new Font("Segoe UI", 11, FontStyle.Bold),
                                    new SolidBrush(Color.FromArgb(51, 51, 51)), detailsSection.X, detailsSection.Y);

                // Draw course info
                e.Graphics.DrawString($"{consultation.CourseCode} - L ({consultation.SectionCode})", new Font("Segoe UI", 9),
                                    new SolidBrush(Color.FromArgb(102, 102, 102)), detailsSection.X, detailsSection.Y + 25);

                // Draw consultation type
                e.Graphics.DrawString($"Academic - {consultation.ConsultationType}", new Font("Segoe UI", 9),
                                    new SolidBrush(Color.FromArgb(85, 85, 85)), detailsSection.X, detailsSection.Y + 50);

                // Draw location if available
                if (!string.IsNullOrEmpty(consultation.Location))
                {
                    e.Graphics.DrawString($"Location: {consultation.Location}", new Font("Segoe UI", 9),
                                        new SolidBrush(Color.FromArgb(85, 85, 85)), detailsSection.X + 200, detailsSection.Y + 50);
                }

                // Draw note
                Rectangle noteRect = new Rectangle(detailsSection.X, detailsSection.Y + 75,
                                                detailsSection.Width, 40);
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(249, 249, 249)), noteRect);
                e.Graphics.DrawRectangle(new Pen(Color.FromArgb(228, 42, 48), 2),
                                        noteRect.X, noteRect.Y, 2, noteRect.Height);
                e.Graphics.DrawString(consultation.Notes, new Font("Segoe UI", 9),
                                    new SolidBrush(Color.FromArgb(85, 85, 85)), noteRect.X + 10, noteRect.Y + 10);

                // Draw status and action buttons
                Rectangle statusSection = new Rectangle(cardBounds.Right - 130, cardBounds.Y + 15, 120, 30);

                // Draw status
                Color statusColor = Color.Gray;
                string statusText = consultation.Status;

                switch (consultation.Status)
                {
                    case "Pending":
                        statusColor = Color.FromArgb(228, 155, 35);
                        break;
                    case "Approved":
                        statusColor = Color.FromArgb(40, 167, 69);
                        break;
                    case "Completed":
                        statusColor = Color.FromArgb(23, 162, 184);
                        break;
                    case "Cancelled":
                        statusColor = Color.FromArgb(220, 53, 69);
                        break;
                }

                e.Graphics.DrawString(statusText, new Font("Segoe UI", 9, FontStyle.Bold),
                                    new SolidBrush(statusColor), statusSection.X, statusSection.Y);

                // Draw action buttons
                int buttonY = statusSection.Y + 40;

                // Draw appropriate buttons based on status
                switch (consultation.Status)
                {
                    case "Pending":
                        DrawActionButton(e.Graphics, "Approve", Color.FromArgb(40, 167, 69),
                                        new Rectangle(cardBounds.Right - 110, buttonY, 90, 30));
                        DrawActionButton(e.Graphics, "Decline", Color.FromArgb(220, 53, 69),
                                        new Rectangle(cardBounds.Right - 110, buttonY + 35, 90, 30));
                        DrawActionButton(e.Graphics, "Reschedule", Color.FromArgb(108, 117, 125),
                                        new Rectangle(cardBounds.Right - 110, buttonY + 70, 90, 30));
                        break;
                    case "Approved":
                        DrawActionButton(e.Graphics, "Add notes", Color.FromArgb(23, 162, 184),
                                        new Rectangle(cardBounds.Right - 110, buttonY, 90, 30));
                        DrawActionButton(e.Graphics, "Reschedule", Color.FromArgb(108, 117, 125),
                                        new Rectangle(cardBounds.Right - 110, buttonY + 35, 90, 30));
                        break;
                    case "Completed":
                        DrawActionButton(e.Graphics, "View Report", Color.FromArgb(0, 120, 215),
                                        new Rectangle(cardBounds.Right - 110, buttonY, 90, 30));
                        DrawActionButton(e.Graphics, "Follow-up", Color.FromArgb(102, 16, 242),
                                        new Rectangle(cardBounds.Right - 110, buttonY + 35, 90, 30));
                        break;
                    case "Cancelled":
                        DrawActionButton(e.Graphics, "Reschedule", Color.FromArgb(108, 117, 125),
                                        new Rectangle(cardBounds.Right - 110, buttonY, 90, 30));
                        break;
                }
            }
        }

        private void DrawActionButton(Graphics g, string text, Color color, Rectangle bounds)
        {
            g.FillRoundedRectangle(new SolidBrush(color), bounds, 5);
            g.DrawString(text, new Font("Segoe UI", 8, FontStyle.Bold), new SolidBrush(Color.White),
                        bounds.X + (bounds.Width - g.MeasureString(text, new Font("Segoe UI", 8, FontStyle.Bold)).Width) / 2,
                        bounds.Y + (bounds.Height - g.MeasureString(text, new Font("Segoe UI", 8, FontStyle.Bold)).Height) / 2);
        }
    }

    // Extension method to draw rounded rectangles
    public static class GraphicsExtensions
    {
        public static void FillRoundedRectangle(this Graphics graphics, Brush brush, Rectangle bounds, int cornerRadius)
        {
            using (System.Drawing.Drawing2D.GraphicsPath path = RoundedRect(bounds, cornerRadius))
            {
                graphics.FillPath(brush, path);
            }
        }

        public static void DrawRoundedRectangle(this Graphics graphics, Pen pen, Rectangle bounds, int cornerRadius)
        {
            using (System.Drawing.Drawing2D.GraphicsPath path = RoundedRect(bounds, cornerRadius))
            {
                graphics.DrawPath(pen, path);
            }
        }

        private static System.Drawing.Drawing2D.GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            int diameter = radius * 2;
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(bounds.Location, size);
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();

            if (radius == 0)
            {
                path.AddRectangle(bounds);
                return path;
            }

            // Top left arc  
            path.AddArc(arc, 180, 90);

            // Top right arc  
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);

            // Bottom right arc  
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            // Bottom left arc 
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }
    }
}