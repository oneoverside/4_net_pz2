using Uni_NET_PZ2.DbSource;

namespace Uni_NET_PZ2.Forms.Voc1.CrudForms;

public partial class Voc1TableDeleteForm : Form
{
    private readonly TextBox _id = new TextBox();

    public Voc1TableDeleteForm()
    {
        this.InitializeComponent();
        
        var label = new Label();
        label.Location = new Point(50, 100);
        label.Size = new Size(200, 20); 
        label.Text = "Delete VOC1 table element";
        
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
        db.DeleteVoc1(Convert.ToInt32(this._id.Text));
        this.Close();
    }
}