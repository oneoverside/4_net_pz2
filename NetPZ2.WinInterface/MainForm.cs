using Uni_NET_PZ2.Forms.MainTable;
using Uni_NET_PZ2.Forms.Voc1;
using Uni_NET_PZ2.Forms.Voc2;

namespace Uni_NET_PZ2;

public partial class MainForm : Form
{
    public MainForm()
    {
        this.InitializeComponent();

        var mainTableManagerButton = new Button();
        mainTableManagerButton.Location = new Point(50, 150); 
        mainTableManagerButton.Size = new Size(100, 50); 
        mainTableManagerButton.Text = "Main table CRUD";
        mainTableManagerButton.Click += this.OpenForm<ManageMainTableForm>; 
        
        var voc1ManagerButton = new Button();
        voc1ManagerButton.Location = new Point(200, 150); 
        voc1ManagerButton.Size = new Size(100, 50); 
        voc1ManagerButton.Text = "Voc1 CRUD";
        voc1ManagerButton.Click += this.OpenForm<ManageVoc1TableForm>;
        
        var voc2ManagerButton = new Button();
        voc2ManagerButton.Location = new Point(350, 150);
        voc2ManagerButton.Size = new Size(100, 50); 
        voc2ManagerButton.Text = "Voc2 CRUD";
        voc2ManagerButton.Click += this.OpenForm<ManageVoc2TableForm>; 
        
        this.Controls.Add(mainTableManagerButton);
        this.Controls.Add(voc1ManagerButton);
        this.Controls.Add(voc2ManagerButton);
    }
}

public static class Extensions
{
    public static void OpenForm<T>(this Form form, object? sender, EventArgs e) where T : Form, new() => new T().Show();
}