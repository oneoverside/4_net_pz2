using Uni_NET_PZ2.Forms.MainTable.CrudForms;

namespace Uni_NET_PZ2.Forms.MainTable;

public partial class ManageMainTableForm : Form
{
    public ManageMainTableForm()
    {
        this.InitializeComponent();
        var label = new Label();
        label.Location = new Point(50, 100);
        label.Size = new Size(200, 20); 
        label.Text = "Main table manager";

        var createButton = new Button();
        createButton.Location = new Point(50, 150); 
        createButton.Size = new Size(100, 50); 
        createButton.Text = "Create";
        createButton.Click += this.OpenForm<MainTableCreateForm>;

        var readButton = new Button();
        readButton.Location = new Point(200, 150); 
        readButton.Size = new Size(100, 50); 
        readButton.Text = "Read";
        readButton.Click += this.OpenForm<MainTableReadForm>; 
        
        var updateButton = new Button();
        updateButton.Location = new Point(350, 150);
        updateButton.Size = new Size(100, 50);
        updateButton.Text = "Update";
        updateButton.Click += this.OpenForm<MainTableUpdateForm>;
        
        var delButton = new Button();
        delButton.Location = new Point(500, 150);
        delButton.Size = new Size(100, 50);
        delButton.Text = "Delete";
        delButton.Click += this.OpenForm<MainTableDeleteForm>;
        
        this.Controls.Add(label);
        this.Controls.Add(createButton);
        this.Controls.Add(updateButton);
        this.Controls.Add(readButton);
        this.Controls.Add(delButton);
    }
}
