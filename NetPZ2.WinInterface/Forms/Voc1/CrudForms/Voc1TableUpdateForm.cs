using Uni_NET_PZ2.DbSource;

namespace Uni_NET_PZ2.Forms.Voc1.CrudForms;

public partial class Voc1TableUpdateForm : Form
{
    private readonly TextBox _id = new TextBox();
    private readonly TextBox _customField = new TextBox();

    public Voc1TableUpdateForm()
    {
        this.InitializeComponent();
        
        var label = new Label();
        label.Location = new Point(50, 100);
        label.Size = new Size(200, 20); 
        label.Text = "Update VOC1 table element";

        this._id.Location = new Point(50, 150); 
        this._id.Text = "Id";
        this._id.Size = new Size(100, 50); 
        
        this._customField.Location = new Point(50, 200); 
        this._customField.Text = "CustomField";
        this._customField.Size = new Size(100, 50); 
        
        var createButton = new Button();
        createButton.Location = new Point(50, 250); 
        createButton.Size = new Size(100, 50); 
        createButton.Text = "Update";
        createButton.Click += this.Update;
        
        this.Controls.Add(label);
        this.Controls.Add(this._id);
        this.Controls.Add(this._customField);
        this.Controls.Add(createButton);
    }

    private void Update(object? sender, EventArgs e)
    {
        var db = new MyDbContext();
        db.Update(new Voc1Table
        {
            Id = Convert.ToInt32(this._id.Text),
            CustomField = this._customField.Text,
        });
        this.Close();
    }
}