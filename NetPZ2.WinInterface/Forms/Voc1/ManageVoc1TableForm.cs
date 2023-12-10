using Uni_NET_PZ2.Forms.Voc1.CrudForms;

namespace Uni_NET_PZ2.Forms.Voc1;

public partial class ManageVoc1TableForm : Form
{
    public ManageVoc1TableForm()
    {
        this.InitializeComponent();
        var label = new Label();
        label.Location = new Point(50, 100);
        label.Size = new Size(200, 20); 
        label.Text = "VOC1 table manager";

        var createButton = new Button();
        createButton.Location = new Point(50, 150); 
        createButton.Size = new Size(100, 50); 
        createButton.Text = "Create";
        createButton.Click += this.OpenForm<Voc1TableCreateForm>;

        var readButton = new Button();
        readButton.Location = new Point(200, 150); 
        readButton.Size = new Size(100, 50); 
        readButton.Text = "Read";
        readButton.Click += this.OpenForm<Voc1TableReadForm>; 
        
        var updateButton = new Button();
        updateButton.Location = new Point(350, 150);
        updateButton.Size = new Size(100, 50);
        updateButton.Text = "Update";
        updateButton.Click += this.OpenForm<Voc1TableUpdateForm>;
        
        var delButton = new Button();
        delButton.Location = new Point(500, 150);
        delButton.Size = new Size(100, 50);
        delButton.Text = "Delete";
        delButton.Click += this.OpenForm<Voc1TableDeleteForm>;
        
        this.Controls.Add(label);
        this.Controls.Add(createButton);
        this.Controls.Add(updateButton);
        this.Controls.Add(readButton);
        this.Controls.Add(delButton);
    }
}
