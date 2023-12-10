using Uni_NET_PZ2.DbSource;

namespace Uni_NET_PZ2.Forms.MainTable.CrudForms;

public partial class MainTableDeleteForm : Form
{
    private readonly TextBox _id = new TextBox();

    public MainTableDeleteForm()
    {
        this.InitializeComponent();
        
        var label = new Label();
        label.Location = new Point(50, 100);
        label.Size = new Size(200, 20); 
        label.Text = "Delete main table element";
        
        this._id.Location = new Point(50, 150); 
        this._id.Text = "Id";
        this._id.Size = new Size(100, 50); 
        
        var button = new Button();
        button.Location = new Point(50, 350); 
        button.Size = new Size(100, 50); 
        button.Text = "Delete";
        button.Click += this.Delete;
        
        this.Controls.Add(this._id);
        this.Controls.Add(button);
    }
    
    private void Delete(object? sender, EventArgs e)
    {
        var db = new MyDbContext();
        db.DeleteMain(Convert.ToInt32(this._id.Text));
        this.Close();
    }
}