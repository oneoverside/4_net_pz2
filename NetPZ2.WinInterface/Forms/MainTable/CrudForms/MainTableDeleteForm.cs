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
        
        var createButton = new Button();
        createButton.Location = new Point(50, 350); 
        createButton.Size = new Size(100, 50); 
        createButton.Text = "Delete";
        createButton.Click += this.Delete;
    }
    
    private void Delete(object? sender, EventArgs e)
    {
        // TODO:
        this.Close();
    }
}