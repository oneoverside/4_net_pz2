namespace Uni_NET_PZ2.Forms.MainTable.CrudForms;

public partial class MainTableCreate : Form
{
    public MainTableCreate()
    {
        InitializeComponent();
        
        this.InitializeComponent();
        var label = new Label();
        label.Location = new Point(50, 100);
        label.Size = new Size(200, 20); 
        label.Text = "Main table manager";

        var createButton = new Button();
        createButton.Location = new Point(50, 150); 
        createButton.Size = new Size(100, 50); 
        createButton.Text = "Create";
        createButton.Click += this.OpenForm<MainForm>;
    }
}