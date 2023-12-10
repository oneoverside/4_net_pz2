using Uni_NET_PZ2.DbSource;

namespace Uni_NET_PZ2.Forms.MainTable.CrudForms;

public partial class MainTableUpdateForm : Form
{
    private readonly TextBox _voc1Field = new TextBox();
    private readonly TextBox _voc2Field = new TextBox();
    private readonly TextBox _customField = new TextBox();
    private readonly TextBox _id = new TextBox();

    public MainTableUpdateForm()
    {
        this.InitializeComponent();
        
        var label = new Label();
        label.Location = new Point(50, 100);
        label.Size = new Size(200, 20); 
        label.Text = "Update main table element";

        this._id.Location = new Point(50, 150); 
        this._id.Text = "Id";
        this._id.Size = new Size(100, 50); 
        
        this._voc1Field.Location = new Point(50, 200); 
        this._voc1Field.Text = "Voc1Id";
        this._voc1Field.Size = new Size(100, 50); 
        
        this._voc2Field.Location = new Point(50, 250); 
        this._voc2Field.Text = "Voc2Id";
        this._voc2Field.Size = new Size(100, 50); 
        
        this._customField.Location = new Point(50, 300); 
        this._customField.Text = "CustomField";
        this._customField.Size = new Size(100, 50); 
        
        var createButton = new Button();
        createButton.Location = new Point(50, 350); 
        createButton.Size = new Size(100, 50); 
        createButton.Text = "Create";
        createButton.Click += this.Update;
        
        this.Controls.Add(label);
        this.Controls.Add(this._id);
        this.Controls.Add(this._voc1Field);
        this.Controls.Add(this._voc2Field);
        this.Controls.Add(this._customField);
        this.Controls.Add(createButton);
    }

    private void Update(object? sender, EventArgs e)
    {
        var db = new MyDbContext();
        db.Update(new DbSource.MainTable
        {
            Id = Convert.ToInt32(this._id.Text),
            CustomField = this._customField.Text,
            Voc1Id = Convert.ToInt32(this._voc1Field.Text),
            Voc2Id = Convert.ToInt32(this._voc1Field.Text),
        });
        this.Close();
    }
}