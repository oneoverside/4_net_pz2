using Uni_NET_PZ2.DbSource;

namespace Uni_NET_PZ2.Forms.Voc1.CrudForms;

public partial class Voc1TableCreateForm : Form
{
    private readonly TextBox _customField = new TextBox();
    
    public Voc1TableCreateForm()
    {
        this.InitializeComponent();
        
        var label = new Label();
        label.Location = new Point(50, 100);
        label.Size = new Size(200, 20); 
        label.Text = "Create VOC1 table element";
        
        this._customField.Location = new Point(50, 150); 
        this._customField.Text = "CustomField";
        this._customField.Size = new Size(100, 50); 
        
        var createButton = new Button();
        createButton.Location = new Point(50, 200);
        createButton.Size = new Size(100, 50); 
        createButton.Text = "Create";
        createButton.Click += this.Create;
        
        this.Controls.Add(label);
        this.Controls.Add(this._customField);
        this.Controls.Add(createButton);
    }

    private void Create(object? sender, EventArgs e)
    {
        var db = new MyDbContext();
        db.Add(new Voc1Table
        {
            CustomField = this._customField.Text,
        });
        this.Close();
    }
}